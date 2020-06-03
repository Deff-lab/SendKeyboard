using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SendKeyboard.MouseHook;

namespace SendKeyboard
{

    public enum MouseKeys
    {
        Left = 0,
        Right = 1,
        Middle = 2
    }

    public class MouseState
    {
        public MouseKeys key;
        public ManagerKeyState state;
    }

    class MouseManager
    {
        public List<MouseState> mouseKeyStates = new List<MouseState>()
        {
            new MouseState(){ key = MouseKeys.Left, state = ManagerKeyState.None },
            new MouseState(){ key = MouseKeys.Right, state = ManagerKeyState.None },
            new MouseState(){ key = MouseKeys.Middle, state = ManagerKeyState.None },
        };

        /// <summary>
        /// События
        /// </summary>
        public List<Event> events = new List<Event>();

        MouseHook hook = new MouseHook();

        public MouseManager()
        {
            events.Add(
                new Event()
                {
                    mouseTrigger = new mouseTrigger() { key = MouseKeys.Right, type = ManagerKeyState.Down},
                    actions = new List<Action>()
                    {
                        new Action(){ keyboardKey = DirectXKeyboard.DirectXKeyStrokes.A, type = ActionType.Down }
                    }
                }
                );

            events.Add(
                new Event()
                {
                    mouseTrigger = new mouseTrigger() { key = MouseKeys.Right, type = ManagerKeyState.Hold },
                    actions = new List<Action>()
                    {
                        new Action(){ keyboardKey = DirectXKeyboard.DirectXKeyStrokes.A, type = ActionType.Down }
                    }
                }
                );

            hook.Start();
            hook.AttachToMouseAction(MouseAction);
        }

        void MouseAction(MouseEvents @event, MOUSEHOOKSTRUCT data, int delta)
        {
            switch (@event)
            {
                case MouseEvents.LBUTTONDOWN:
                    mouseKeyStates[0].state = mouseKeyStates[0].state == ManagerKeyState.Down ? ManagerKeyState.Hold : ManagerKeyState.Down;
                    break;
                case MouseEvents.LBUTTONUP:
                    mouseKeyStates[0].state = ManagerKeyState.Up;
                    break;
                case MouseEvents.MOUSEMOVE:
                    break;
                case MouseEvents.MOUSEWHEEL:
                    //MessageBox.Show("Test :" + delta);
                    break;
                case MouseEvents.MOUSEHWHEEL:
                    break;
                case MouseEvents.RBUTTONDOWN:
                    mouseKeyStates[1].state = mouseKeyStates[1].state == ManagerKeyState.Down ? ManagerKeyState.Hold : ManagerKeyState.Down;
                    break;
                case MouseEvents.RBUTTONUP:
                    mouseKeyStates[1].state = ManagerKeyState.Up;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Обрабатываение событий
        /// </summary>
        public void DoEvents()
        {
            foreach (var mEvent in events)
            {
                if (mouseKeyStates[(int)mEvent.mouseTrigger.key].state == mEvent.mouseTrigger.type)
                {
                    mEvent.Call();
                }
            }

            foreach (var item in mouseKeyStates)
            {
                switch (item.state)
                {
                    case ManagerKeyState.Up:
                        item.state = ManagerKeyState.None;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Остановка обработки мыши
        /// </summary>
        public void Stop()
        {
            hook.Stop();
        }
    }
}
