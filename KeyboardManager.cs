using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendKeyboard
{
    public enum ManagerKeyState
    {
        None,
        Down,
        Hold,
        Up
    }

    struct Informaiton
    {
        public IntPtr lastMessage;
        public Keys lastDownKey;
        public Keys lasUpKey;
    }

    class KeyboardManager
    {
        /// <summary>
        /// Состояния клавиш
        /// </summary>
        ManagerKeyState[] keyStates = new ManagerKeyState[256];

        /// <summary>
        /// События
        /// </summary>
        public List<Event> events = new List<Event>();

        /// <summary>
        /// Перехватчик назатия клавиш
        /// </summary>
        KeyboardHook hook = new KeyboardHook();

        Informaiton info;

        public KeyboardManager()
        {
            hook.Start();
            hook.AttachToKeyDown(KeyDown);
            hook.AttachToKeyUp(KeyUp);
            hook.AttachToGetMessageNumber(Message);
        }

        void Message(IntPtr message)
        {
            info.lastMessage = message;
        }

        /// <summary>
        /// Остановка обработки нажатий
        /// </summary>
        public void Stop()
        {
            hook.Stop();
        }

        /// <summary>
        /// Обрабатываение событий
        /// </summary>
        public Informaiton DoEvents()
        {
            foreach (var mEvent in events)
            {
                if (keyStates[(int)mEvent.triggerKey] == mEvent.triggerType)
                {
                    mEvent.Call();
                }
            }

            // присваивание всем "отпущенным" клавишам состояние None
            for (int i = 0; i < keyStates.Count(); i++)
            {
                keyStates[i] = keyStates[i] == ManagerKeyState.Down ? ManagerKeyState.Hold : keyStates[i];
                keyStates[i] = keyStates[i] == ManagerKeyState.Up ? ManagerKeyState.None : keyStates[i];
            }

            return info;
        }

        /// <summary>
        /// возвращает true если такое событие уже существует
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public bool CheckEvent(Event @event)
        {
            return events.Where(e => e.triggerKey == @event.triggerKey && e.triggerType == @event.triggerType).Count() > 0;
        }

        /// <summary>
        /// Добавить событие
        /// </summary>
        /// <param name="kEvent">событиеw</param>
        public void AddEvent(Event kEvent)
        {
            events.Add(kEvent);
        }

        /// <summary>
        /// Удалить событие
        /// </summary>
        /// <param name="guid"></param>
        public void RemoveEvent(Guid guid)
        {
            events.RemoveAll(e => e.guid == guid);
        }

        /// <summary>
        /// Добавить действию к событие
        /// </summary>
        /// <param name="eGuid"></param>
        /// <param name="action"></param>
        public void AddActionToEvent(Guid eGuid, Action action)
        {
            Event @event = events.Where(e => e.guid == eGuid).First();

            if (@event.actions.Where(a => a.keyboardKey == action.keyboardKey && a.type == action.type).Count() == 0)
                @event.Add(action);
        }

        /// <summary>
        /// Удалить действие у события
        /// </summary>
        /// <param name="eGuid"></param>
        /// <param name="aGuid"></param>
        public void RemoveActionFromEvent(Guid eGuid, Guid aGuid)
        {
            Event @event = events.Where(e => e.guid == eGuid).First();

            @event.actions.Remove(@event.actions.Where(a => a.guid == aGuid).First());
        }

        void KeyDown(Keys key, IntPtr wParam, IntPtr lParam)
        {
            info.lastDownKey = key;

            if (keyStates[(int)key] == ManagerKeyState.None)
            {
                keyStates[(int)key] = ManagerKeyState.Down;
            }
            else
            {
                keyStates[(int)key] = ManagerKeyState.Hold;
            }
            //keyStates[(int)key] = keyStates[(int)key] == (KeyboardManagerKeyState.Down | KeyboardManagerKeyState.Hold) ? KeyboardManagerKeyState.Hold : KeyboardManagerKeyState.Down;
        }

        void KeyUp(Keys key, IntPtr wParam, IntPtr lParam)
        {
            info.lasUpKey = key;

            keyStates[(int)key] = ManagerKeyState.Up;// keyStates[(int)key] == KeyboardManagerKeyState.Up ? KeyboardManagerKeyState.None : KeyboardManagerKeyState.Up;
        }
    }
}
