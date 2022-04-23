using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace SmartZuSoft.SmartTester.WinApp {
	public enum ModifierKey:uint {
		MOD_ALT = 0x0001,
		MOD_CONTROL = 0x0002,
		MOD_SHIFT = 0x0004,
		MOD_WIN = 0x0008,
	}
	public sealed class HotKeyHelper: IMessageFilter {
		const string MSG_REGISTERED = "Горячие клавиши уже зарегистрированы, вызовите UnRegister для отмены регистрации.";
		const string MSG_UNREGISTERED = "Горячие клавиши не зарегистрированы, вызовите Register для регистрации.";
		//Делаем из нашего класса singleton
		private HotKeyHelper() {
		}
		public static readonly HotKeyHelper Instance = new HotKeyHelper();
		bool isRegistered;
		ushort atom;
		ModifierKey modifiers;
		Keys keyCode;
		public void Register(ModifierKey modifiers, Keys keyCode) {
			//Эти значения нам будут нужны в PreFilterMessage
			this.modifiers = modifiers;
			this.keyCode = keyCode;
			//Не выполнена ли уже регистрация?
			if (isRegistered) return;
				//throw new InvalidOperationException(MSG_REGISTERED);
			//Сохраняем atom, для последующей отмены регистрации
			atom = GlobalAddAtom(Guid.NewGuid().ToString());
			if (atom == 0) return;
				//ThrowWin32Exception();
			if (!RegisterHotKey(IntPtr.Zero, atom, modifiers, keyCode))
				return;
				//ThrowWin32Exception();
			//Добавляем себя в цепочку фильтров сообщений
			Application.AddMessageFilter(this);
			isRegistered = true;
		}
		public void UnRegister() {
			//Не отменена ли уже регистрация?
			if (!isRegistered)
				return;
				//throw new InvalidOperationException(MSG_UNREGISTERED);
			if (!UnregisterHotKey(IntPtr.Zero, atom)) return;
				//ThrowWin32Exception();
			GlobalDeleteAtom(atom);
			//Удаляем себя из цепочки фильтров сообщений
			Application.RemoveMessageFilter(this);
			isRegistered = false;
		}
		//Генерирует Win32Exception в ответ на неудачный вызов импортируемой Win32 функции
		void ThrowWin32Exception() {
			throw new Win32Exception(Marshal.GetLastWin32Error());
		}
		//Событие, инициируемое при обнаружении нажатия HotKeys
		public event EventHandler HotKeyPressed;
		public bool PreFilterMessage(ref Message m) {
			//Проверка на сообщение WM_HOTKEY
			if (m.Msg == WM_HOTKEY &&
				//Проверка на окно
				m.HWnd == IntPtr.Zero &&
				//Проверка virtual key code
				m.LParam.ToInt32() >> 16 == (int)keyCode &&
				//Проверка кнопок модификаторов
				(m.LParam.ToInt32() & 0x0000FFFF) == (int)modifiers &&
				//Проверка на наличие подписчиков сообщения
				HotKeyPressed != null) {
				HotKeyPressed(this, EventArgs.Empty);
			}
			return false;
		}
		//Необходимые Win32 константы и функции
		const string USER32_DLL = "User32.dll";
		const string KERNEL32_DLL = "Kernel32.dll";
		const int WM_HOTKEY = 0x0312;
		[DllImport(USER32_DLL, SetLastError = true)]
		static extern bool RegisterHotKey(IntPtr hWnd, int id, ModifierKey fsModifiers, Keys vk);
		[DllImport(USER32_DLL, SetLastError = true)]
		static extern bool UnregisterHotKey(IntPtr hWnd, int id);
		[DllImport(KERNEL32_DLL, SetLastError = true)]
		static extern ushort GlobalAddAtom(string lpString);
		[DllImport(KERNEL32_DLL)]
		static extern ushort GlobalDeleteAtom(ushort nAtom);
	}	
}
