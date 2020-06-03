using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SendKeyboard
{
    class MouseHook
    {
        internal static class NativeMethods
        {
            internal static ushort HIWORD(IntPtr dwValue)
            {
                return (ushort)((((long)dwValue) >> 0x10) & 0xffff);
            }

            internal static ushort HIWORD(uint dwValue)
            {
                return (ushort)(dwValue >> 0x10);
            }

            internal static int GET_WHEEL_DELTA_WPARAM(IntPtr wParam)
            {
                return (short)HIWORD(wParam);
            }

            internal static int GET_WHEEL_DELTA_WPARAM(uint wParam)
            {
                return (short)HIWORD(wParam);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public int X;
            public int Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEHOOKSTRUCT
        {
            public Point pt;
            public IntPtr hwnd;
            public uint wHitTestCode;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseHookStructEx
        {
            public MOUSEHOOKSTRUCT mouseHookStruct;
            public int MouseData;
        }

        private const int WH_MOUSE_LL = 14;

        private static LowLevelMouseProc _proc = HookCallback;

        private static IntPtr _hookID = IntPtr.Zero;

        public enum MouseEvents
        {
            LBUTTONDOWN = 0x0201,
            LBUTTONUP = 0x0202,
            MOUSEMOVE = 0x0200,
            /// <summary>
            /// Колесо мыши вперёд, назад
            /// </summary>
            MOUSEWHEEL = 0x020A,
            MOUSEHWHEEL = 0x020E,
            RBUTTONDOWN = 0x0204,
            RBUTTONUP = 0x0205
        }

        public delegate void MethodContainer(MouseEvents @event, MOUSEHOOKSTRUCT data, int delta);

        /// <summary>
        /// Событие мыши
        /// </summary>
        public static event MethodContainer CallMouseEvent;

        public void Start()
        {
            _hookID = SetHook(_proc);
        }

        public void Stop()
        {
            WinApiFunctions.UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                    WinApiFunctions.GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                MOUSEHOOKSTRUCT pMouseStruct = (MOUSEHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MOUSEHOOKSTRUCT));
                CallMouseEvent((MouseEvents)wParam, pMouseStruct, NativeMethods.GET_WHEEL_DELTA_WPARAM(wParam));
            }

            return WinApiFunctions.CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        /// <summary>
        /// Привязка к событию мыши
        /// </summary>
        /// <param name="method"></param>
        public void AttachToMouseAction(MethodContainer method)
        {
            CallMouseEvent += method;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
    }
}
