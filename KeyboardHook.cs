using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendKeyboard
{
    public class KeyboardHook
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        public delegate void MethodContainer(Keys key, IntPtr wParam, IntPtr lParam);

        public delegate void MethodContainer2(short x, short y);

        public delegate void MethodContainer3(IntPtr message);

        /// <summary>
        /// Событие отпускания клавиши
        /// </summary>
        public static event MethodContainer CallKeyUp;

        /// <summary>
        /// Событие нажатия клавиши
        /// </summary>
        public static event MethodContainer CallKeyDown;

        public static event MethodContainer3 CallMessageNumber;

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public void Start()
        {
            _hookID = SetHook(_proc);
        }

        public void Stop()
        {
            UnhookWindowsHookEx(_hookID);
        }

        /// <summary>
        /// Привязка к отпусканию клавиши
        /// </summary>
        /// <param name="method"></param>
        public void AttachToKeyUp(MethodContainer method)
        {
            CallKeyUp += method;
        }

        /// <summary>
        /// Привязка к нажатию клавиши
        /// </summary>
        /// <param name="method"></param>
        public void AttachToKeyDown(MethodContainer method)
        {
            CallKeyDown += method;
        }

        public void AttachToGetMessageNumber(MethodContainer3 method)
        {
            CallMessageNumber += method;
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                CallMessageNumber(wParam);
            }

            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                CallKeyDown((Keys)vkCode, wParam, lParam);
            }

            if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                CallKeyUp((Keys)vkCode, wParam, lParam);
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
