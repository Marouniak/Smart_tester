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
		const string MSG_REGISTERED = "������� ������� ��� ����������������, �������� UnRegister ��� ������ �����������.";
		const string MSG_UNREGISTERED = "������� ������� �� ����������������, �������� Register ��� �����������.";
		//������ �� ������ ������ singleton
		private HotKeyHelper() {
		}
		public static readonly HotKeyHelper Instance = new HotKeyHelper();
		bool isRegistered;
		ushort atom;
		ModifierKey modifiers;
		Keys keyCode;
		public void Register(ModifierKey modifiers, Keys keyCode) {
			//��� �������� ��� ����� ����� � PreFilterMessage
			this.modifiers = modifiers;
			this.keyCode = keyCode;
			//�� ��������� �� ��� �����������?
			if (isRegistered) return;
				//throw new InvalidOperationException(MSG_REGISTERED);
			//��������� atom, ��� ����������� ������ �����������
			atom = GlobalAddAtom(Guid.NewGuid().ToString());
			if (atom == 0) return;
				//ThrowWin32Exception();
			if (!RegisterHotKey(IntPtr.Zero, atom, modifiers, keyCode))
				return;
				//ThrowWin32Exception();
			//��������� ���� � ������� �������� ���������
			Application.AddMessageFilter(this);
			isRegistered = true;
		}
		public void UnRegister() {
			//�� �������� �� ��� �����������?
			if (!isRegistered)
				return;
				//throw new InvalidOperationException(MSG_UNREGISTERED);
			if (!UnregisterHotKey(IntPtr.Zero, atom)) return;
				//ThrowWin32Exception();
			GlobalDeleteAtom(atom);
			//������� ���� �� ������� �������� ���������
			Application.RemoveMessageFilter(this);
			isRegistered = false;
		}
		//���������� Win32Exception � ����� �� ��������� ����� ������������� Win32 �������
		void ThrowWin32Exception() {
			throw new Win32Exception(Marshal.GetLastWin32Error());
		}
		//�������, ������������ ��� ����������� ������� HotKeys
		public event EventHandler HotKeyPressed;
		public bool PreFilterMessage(ref Message m) {
			//�������� �� ��������� WM_HOTKEY
			if (m.Msg == WM_HOTKEY &&
				//�������� �� ����
				m.HWnd == IntPtr.Zero &&
				//�������� virtual key code
				m.LParam.ToInt32() >> 16 == (int)keyCode &&
				//�������� ������ �������������
				(m.LParam.ToInt32() & 0x0000FFFF) == (int)modifiers &&
				//�������� �� ������� ����������� ���������
				HotKeyPressed != null) {
				HotKeyPressed(this, EventArgs.Empty);
			}
			return false;
		}
		//����������� Win32 ��������� � �������
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
