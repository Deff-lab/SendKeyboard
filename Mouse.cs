using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendKeyboard
{
    public static class Mouse
    {
        [Flags]
        public enum MouseEventFlags
        {
            /// <summary>
            /// Левая кнопка опущена.
            /// </summary>
            LeftDown = 0x00000002,
            /// <summary>
            /// Левая кнопка вверх.
            /// </summary>
            LeftUp = 0x00000004,
            /// <summary>
            /// Средняя кнопка вниз.
            /// </summary>
            MiddleDown = 0x00000020,
            /// <summary>
            /// Средняя кнопка вверх.
            /// </summary>
            MiddleUp = 0x00000040,
            /// <summary>
            /// Движение произошло.
            /// </summary>
            Move = 0x00000001,
            /// <summary>
            /// Правая кнопка вниз.
            /// </summary>
            RightDown = 0x00000008,
            /// <summary>
            /// Правая кнопка вверх.
            /// </summary>
            RightUp = 0x00000010,
            /// <summary>
            /// Колесо было перемещено, если у мыши есть колесо.
            /// Количество движения указано в dwData
            /// </summary>
            Absolute = 0x00008000,
            /// <summary>
            /// Кнопка X была нажата.
            /// </summary>
            Xdown = 0x00000080,
            /// <summary>
            /// Кнопка X была выпущена.
            /// </summary>
            Xup = 0x00000100,
            /// <summary>
            /// Кнопка колеса наклонена.
            /// </summary>
            Hwheel = 0x00001000,
        }

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public static void MouseEvent(MouseEventFlags action)
        {
            mouse_event
                ((int)action,
                 0, // типо X но жмёт все равно на позицию курсора
                 0, // типо Y но жмёт все равно на позицию курсора
                 0,
                 0)
                ;
        }

        /// <summary>
        /// имитирует движение мыши. параметры указывают изменения
        /// в относительном положении.положительные значения указывают на движение
        /// вправо или вниз
        /// </summary>
        /// <param name="xDelta">Сдвиг по X</param>
        /// <param name="yDelta">Сдвиг по Y</param>
        public static void Move(int xDelta, int yDelta)
        {
            /*
            var screenBounds = Screen.PrimaryScreen.Bounds;

            var outputX = (xDelta * 65536 / screenBounds.Width) + 1;
            var outputY = (yDelta * 65536 / screenBounds.Height) + 1;
            */
            mouse_event((int)MouseEventFlags.Move, xDelta, yDelta, 0, 0);
        }


        /// <summary>
        /// имитирует движение мыши. параметры определяют
        /// абсолютное местоположение, с верхним левым углом
        /// происхождения
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void MoveTo(int x, int y)
        {
            
            var screenBounds = Screen.PrimaryScreen.Bounds;

            var outputX = (x * 65536 / screenBounds.Width) + 1;
            var outputY = (y * 65536 / screenBounds.Height) + 1;
            
            mouse_event((int)MouseEventFlags.Absolute | (int)MouseEventFlags.Move, outputX, outputY, 0, 0);
        }
    }
}
