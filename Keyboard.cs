using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendKeyboard
{
    public class MyKey
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name;
        /// <summary>
        /// для windows
        /// </summary>
        public Keys wKey;
        /// <summary>
        /// для directX
        /// </summary>
        public DirectXKeyboard.DirectXKeyStrokes dKey;
    }

    public static class Keyboard
    {
        public static List<MyKey> keys = new List<MyKey>()
        {
            new MyKey { Name = "A", wKey = Keys.A, dKey = DirectXKeyboard.DirectXKeyStrokes.A },
            new MyKey { Name = "B", wKey = Keys.B, dKey = DirectXKeyboard.DirectXKeyStrokes.B },
            new MyKey { Name = "C", wKey = Keys.C, dKey = DirectXKeyboard.DirectXKeyStrokes.C },
            new MyKey { Name = "D", wKey = Keys.D, dKey = DirectXKeyboard.DirectXKeyStrokes.D },
            new MyKey { Name = "E", wKey = Keys.E, dKey = DirectXKeyboard.DirectXKeyStrokes.E },
            new MyKey { Name = "F", wKey = Keys.F, dKey = DirectXKeyboard.DirectXKeyStrokes.F },
            new MyKey { Name = "G", wKey = Keys.G, dKey = DirectXKeyboard.DirectXKeyStrokes.G },
            new MyKey { Name = "H", wKey = Keys.H, dKey = DirectXKeyboard.DirectXKeyStrokes.H },
            new MyKey { Name = "I", wKey = Keys.I, dKey = DirectXKeyboard.DirectXKeyStrokes.I },
            new MyKey { Name = "J", wKey = Keys.J, dKey = DirectXKeyboard.DirectXKeyStrokes.J },
            new MyKey { Name = "K", wKey = Keys.K, dKey = DirectXKeyboard.DirectXKeyStrokes.K },
            new MyKey { Name = "L", wKey = Keys.L, dKey = DirectXKeyboard.DirectXKeyStrokes.L },
            new MyKey { Name = "M", wKey = Keys.M, dKey = DirectXKeyboard.DirectXKeyStrokes.M },
            new MyKey { Name = "N", wKey = Keys.N, dKey = DirectXKeyboard.DirectXKeyStrokes.N },
            new MyKey { Name = "O", wKey = Keys.O, dKey = DirectXKeyboard.DirectXKeyStrokes.O },
            new MyKey { Name = "P", wKey = Keys.P, dKey = DirectXKeyboard.DirectXKeyStrokes.P },
            new MyKey { Name = "Q", wKey = Keys.Q, dKey = DirectXKeyboard.DirectXKeyStrokes.Q },
            new MyKey { Name = "R", wKey = Keys.R, dKey = DirectXKeyboard.DirectXKeyStrokes.R },
            new MyKey { Name = "S", wKey = Keys.S, dKey = DirectXKeyboard.DirectXKeyStrokes.S },
            new MyKey { Name = "T", wKey = Keys.T, dKey = DirectXKeyboard.DirectXKeyStrokes.T },
            new MyKey { Name = "U", wKey = Keys.U, dKey = DirectXKeyboard.DirectXKeyStrokes.U },
            new MyKey { Name = "V", wKey = Keys.V, dKey = DirectXKeyboard.DirectXKeyStrokes.V },
            new MyKey { Name = "W", wKey = Keys.W, dKey = DirectXKeyboard.DirectXKeyStrokes.W },
            new MyKey { Name = "X", wKey = Keys.X, dKey = DirectXKeyboard.DirectXKeyStrokes.X },
            new MyKey { Name = "Y", wKey = Keys.Y, dKey = DirectXKeyboard.DirectXKeyStrokes.Y },
            new MyKey { Name = "Z", wKey = Keys.Z, dKey = DirectXKeyboard.DirectXKeyStrokes.Z },

            new MyKey { Name = "0", wKey = Keys.D0, dKey = DirectXKeyboard.DirectXKeyStrokes.DIK_0 },
            new MyKey { Name = "1", wKey = Keys.D1, dKey = DirectXKeyboard.DirectXKeyStrokes.DIK_1 },
            new MyKey { Name = "2", wKey = Keys.D2, dKey = DirectXKeyboard.DirectXKeyStrokes.DIK_2 },
            new MyKey { Name = "3", wKey = Keys.D3, dKey = DirectXKeyboard.DirectXKeyStrokes.DIK_3 },
            new MyKey { Name = "4", wKey = Keys.D4, dKey = DirectXKeyboard.DirectXKeyStrokes.DIK_4 },
            new MyKey { Name = "5", wKey = Keys.D5, dKey = DirectXKeyboard.DirectXKeyStrokes.DIK_5 },
            new MyKey { Name = "6", wKey = Keys.D6, dKey = DirectXKeyboard.DirectXKeyStrokes.DIK_6 },
            new MyKey { Name = "7", wKey = Keys.D7, dKey = DirectXKeyboard.DirectXKeyStrokes.DIK_7 },
            new MyKey { Name = "8", wKey = Keys.D8, dKey = DirectXKeyboard.DirectXKeyStrokes.DIK_8 },
            new MyKey { Name = "9", wKey = Keys.D9, dKey = DirectXKeyboard.DirectXKeyStrokes.DIK_9 },

            new MyKey { Name = "NumPad 0", wKey = Keys.NumPad0, dKey = DirectXKeyboard.DirectXKeyStrokes.NUMPAD0 },
            new MyKey { Name = "NumPad 1", wKey = Keys.NumPad1, dKey = DirectXKeyboard.DirectXKeyStrokes.NUMPAD1 },
            new MyKey { Name = "NumPad 2", wKey = Keys.NumPad2, dKey = DirectXKeyboard.DirectXKeyStrokes.NUMPAD2 },
            new MyKey { Name = "NumPad 3", wKey = Keys.NumPad3, dKey = DirectXKeyboard.DirectXKeyStrokes.NUMPAD3 },
            new MyKey { Name = "NumPad 4", wKey = Keys.NumPad4, dKey = DirectXKeyboard.DirectXKeyStrokes.NUMPAD4 },
            new MyKey { Name = "NumPad 5", wKey = Keys.NumPad5, dKey = DirectXKeyboard.DirectXKeyStrokes.NUMPAD5 },
            new MyKey { Name = "NumPad 6", wKey = Keys.NumPad6, dKey = DirectXKeyboard.DirectXKeyStrokes.NUMPAD6 },
            new MyKey { Name = "NumPad 7", wKey = Keys.NumPad7, dKey = DirectXKeyboard.DirectXKeyStrokes.NUMPAD7 },
            new MyKey { Name = "NumPad 8", wKey = Keys.NumPad8, dKey = DirectXKeyboard.DirectXKeyStrokes.NUMPAD8 },
            new MyKey { Name = "NumPad 9", wKey = Keys.NumPad9, dKey = DirectXKeyboard.DirectXKeyStrokes.NUMPAD9 },

            new MyKey { Name = "F1", wKey = Keys.F1, dKey = DirectXKeyboard.DirectXKeyStrokes.F1 },
            new MyKey { Name = "F2", wKey = Keys.F2, dKey = DirectXKeyboard.DirectXKeyStrokes.F2 },
            new MyKey { Name = "F3", wKey = Keys.F3, dKey = DirectXKeyboard.DirectXKeyStrokes.F3 },
            new MyKey { Name = "F4", wKey = Keys.F4, dKey = DirectXKeyboard.DirectXKeyStrokes.F4 },
            new MyKey { Name = "F5", wKey = Keys.F5, dKey = DirectXKeyboard.DirectXKeyStrokes.F5 },
            new MyKey { Name = "F6", wKey = Keys.F6, dKey = DirectXKeyboard.DirectXKeyStrokes.F6 },
            new MyKey { Name = "F7", wKey = Keys.F7, dKey = DirectXKeyboard.DirectXKeyStrokes.F7 },
            new MyKey { Name = "F8", wKey = Keys.F8, dKey = DirectXKeyboard.DirectXKeyStrokes.F8 },
            new MyKey { Name = "F9", wKey = Keys.F9, dKey = DirectXKeyboard.DirectXKeyStrokes.F9 },
            new MyKey { Name = "F10", wKey = Keys.F10, dKey = DirectXKeyboard.DirectXKeyStrokes.F10 },
            new MyKey { Name = "F11", wKey = Keys.F11, dKey = DirectXKeyboard.DirectXKeyStrokes.F11 },
            new MyKey { Name = "F12", wKey = Keys.F12, dKey = DirectXKeyboard.DirectXKeyStrokes.F12 },
            new MyKey { Name = "F13", wKey = Keys.F13, dKey = DirectXKeyboard.DirectXKeyStrokes.F13 },
            new MyKey { Name = "F14", wKey = Keys.F14, dKey = DirectXKeyboard.DirectXKeyStrokes.F14 },
            new MyKey { Name = "F15", wKey = Keys.F15, dKey = DirectXKeyboard.DirectXKeyStrokes.F15 },
            /*
            new MyKey { Name = "F16", wKey = Keys.F16, dKey = DirectXKeyboard.DirectXKeyStrokes.F16 },
            new MyKey { Name = "F17", wKey = Keys.F17, dKey = DirectXKeyboard.DirectXKeyStrokes.F17 },
            new MyKey { Name = "F18", wKey = Keys.F18, dKey = DirectXKeyboard.DirectXKeyStrokes.F18 },
            new MyKey { Name = "F19", wKey = Keys.F19, dKey = DirectXKeyboard.DirectXKeyStrokes.F19 },
            new MyKey { Name = "F20", wKey = Keys.F20, dKey = DirectXKeyboard.DirectXKeyStrokes.F20 },
            new MyKey { Name = "F21", wKey = Keys.F21, dKey = DirectXKeyboard.DirectXKeyStrokes.F21 },
            new MyKey { Name = "F22", wKey = Keys.F22, dKey = DirectXKeyboard.DirectXKeyStrokes.F22 },
            new MyKey { Name = "F23", wKey = Keys.F23, dKey = DirectXKeyboard.DirectXKeyStrokes.F23 },
            new MyKey { Name = "F24", wKey = Keys.F24, dKey = DirectXKeyboard.DirectXKeyStrokes.F24 },
            */

            new MyKey { Name = "Стрелка Вверх", wKey = Keys.Up, dKey = DirectXKeyboard.DirectXKeyStrokes.UPARROW },
            new MyKey { Name = "Стрелка Вниз", wKey = Keys.Down, dKey = DirectXKeyboard.DirectXKeyStrokes.DOWNARROW },
            new MyKey { Name = "Стрелка Влево", wKey = Keys.Left, dKey = DirectXKeyboard.DirectXKeyStrokes.LEFTARROW },
            new MyKey { Name = "Стрелка Вправо", wKey = Keys.Right, dKey = DirectXKeyboard.DirectXKeyStrokes.RIGHTARROW },

            new MyKey { Name = "Левый Alt", wKey = Keys.Alt, dKey = DirectXKeyboard.DirectXKeyStrokes.LALT },
            new MyKey { Name = "Правый Alt", wKey = Keys.RMenu, dKey = DirectXKeyboard.DirectXKeyStrokes.RALT },

            new MyKey { Name = "Левый Shift", wKey = Keys.LShiftKey, dKey = DirectXKeyboard.DirectXKeyStrokes.LSHIFT },
            new MyKey { Name = "Правый Shift", wKey = Keys.RShiftKey, dKey = DirectXKeyboard.DirectXKeyStrokes.RSHIFT },

            new MyKey { Name = "Левый Control", wKey = Keys.LControlKey, dKey = DirectXKeyboard.DirectXKeyStrokes.LCONTROL },
            new MyKey { Name = "Правый Control", wKey = Keys.RControlKey, dKey = DirectXKeyboard.DirectXKeyStrokes.RCONTROL },

            new MyKey { Name = "Левый Win", wKey = Keys.LWin, dKey = DirectXKeyboard.DirectXKeyStrokes.LWIN },
            new MyKey { Name = "Правый Win", wKey = Keys.RWin, dKey = DirectXKeyboard.DirectXKeyStrokes.RWIN },

            new MyKey { Name = "Tab", wKey = Keys.Tab, dKey = DirectXKeyboard.DirectXKeyStrokes.TAB },
            new MyKey { Name = "Caps Lock", wKey = Keys.CapsLock, dKey = DirectXKeyboard.DirectXKeyStrokes.CAPSLOCK },
        };
    }
}
