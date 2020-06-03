using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendKeyboard
{
    public class keyboardTrigger
    {
        public Keys key = Keys.None;
        public ManagerKeyState type = ManagerKeyState.None;
    }

    public class mouseTrigger
    {
        public MouseKeys key = MouseKeys.Right;
        public ManagerKeyState type = ManagerKeyState.None;
    }



    class Event
    {
        public keyboardTrigger keyboardTrigger = new keyboardTrigger();
        public mouseTrigger mouseTrigger = new mouseTrigger();

        /// <summary>
        /// Клавиша на которою срабатывает событие
        /// </summary>
        public Keys triggerKey = Keys.None;

        /// <summary>
        /// Тип события для реагирования
        /// </summary>
        public ManagerKeyState triggerType = ManagerKeyState.Down;

        /// <summary>
        /// Список имитируемых действий
        /// </summary>
        public List<Action> actions = new List<Action>();

        public Guid guid = Guid.NewGuid();

        public Event()
        {

        }

        public void Add(Action action)
        {
            actions.Add(action);
        }

        public void Call()
        {
            foreach (var action in actions)
            {
                action.Call();
            }
        }
    }
}
