using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendKeyboard
{
    /// <summary>
    /// Типы события
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Нажать 
        /// </summary>
        Press,
        MousePress,
        /// <summary>
        /// Нажать с удержанием
        /// </summary>
        PressDealy,
        MousePressDelay,
        /// <summary>
        /// Опустить
        /// </summary>
        Down,
        /// <summary>
        /// Поднять
        /// </summary>
        Up,
        MouseMove
    }

    class Action
    {
        /// <summary>
        /// Имитируемая клавиша клавиатуры
        /// </summary>
        public DirectXKeyboard.DirectXKeyStrokes keyboardKey =  DirectXKeyboard.DirectXKeyStrokes.NONE;

        /// <summary>
        /// Имитируемая клавиша мыши
        /// </summary>
        public Mouse.MouseEventFlags[] mouseKey;

        /// <summary>
        /// true для движения мыши относительно текущего положения
        /// </summary>
        public bool mouseMoveRelatively = false;

        public int mouseX = 0;
        public int mouseY = 0;

        /// <summary>
        /// Тип события
        /// </summary>
        public ActionType type;

        /// <summary>
        /// Время удержиния для имитации удержания
        /// </summary>
        public uint delay = 0;

        /// <summary>
        /// Ожидать после срабатывания
        /// </summary>
        public bool waitAfterDo = false;

        public Guid guid = Guid.NewGuid();

        public void Call()
        {
            switch (type)
            {
                case ActionType.Press:
                    DirectXKeyboard.SendKey(keyboardKey, false, DirectXKeyboard.InputType.Keyboard);
                    Application.DoEvents();
                    DirectXKeyboard.SendKey(keyboardKey, true, DirectXKeyboard.InputType.Keyboard);
                    break;
                case ActionType.MousePress:
                    Mouse.MouseEvent(mouseKey[0]);
                    Application.DoEvents();
                    Mouse.MouseEvent(mouseKey[1]);
                    break;
                case ActionType.PressDealy:
                    {
                        var endTime = DateTime.Now.AddMilliseconds(delay);
                        while (DateTime.Now < endTime)
                        {
                            System.Threading.Thread.Sleep(100);
                            DirectXKeyboard.SendKey(keyboardKey, false, DirectXKeyboard.InputType.Keyboard);
                            Application.DoEvents();
                        }
                        DirectXKeyboard.SendKey(keyboardKey, true, DirectXKeyboard.InputType.Keyboard);
                    }
                    break;
                case ActionType.MousePressDelay:
                    {
                        var endTime = DateTime.Now.AddMilliseconds(delay);
                        while (DateTime.Now < endTime)
                        {
                            System.Threading.Thread.Sleep(10);
                            Mouse.MouseEvent(mouseKey[0]);
                            Application.DoEvents();
                        }
                        Mouse.MouseEvent(mouseKey[1]);
                    }
                    break;
                case ActionType.Down:
                    DirectXKeyboard.SendKey(keyboardKey, false, DirectXKeyboard.InputType.Keyboard);
                    break;
                case ActionType.Up:
                    DirectXKeyboard.SendKey(keyboardKey, true, DirectXKeyboard.InputType.Keyboard);
                    break;
                case ActionType.MouseMove:
                    if (mouseMoveRelatively)
                        Mouse.Move(mouseX, mouseY);
                    else
                        Mouse.MoveTo(mouseX, mouseY);
                    break;
                default:
                    break;
            }

            if (waitAfterDo)
                System.Threading.Thread.Sleep(15);
        }

        public static string ActionTypeTostring(ActionType action)
        {
            switch (action)
            {
                case ActionType.Press:
                    return "Нажатие";
                case ActionType.MousePress:
                    return "Нажатие (мышь)";
                case ActionType.PressDealy:
                    return "Нажатие с удержание";
                case ActionType.MousePressDelay:
                    return "Нажатие с удержание (мышь)";
                case ActionType.Down:
                    return "Опускание";
                case ActionType.Up:
                    return "Отпускание";
                case ActionType.MouseMove:
                    return "Движение мыши";
                default:
                    return string.Empty;
            }
        }
    }
}
