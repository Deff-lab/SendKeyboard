using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//https://stackoverflow.com/questions/35138778/sending-keys-to-a-directx-game <- класс для посылания нажати DirectX приложениям

namespace SendKeyboard
{
    public partial class Form1 : Form
    {
        KeyboardManager keyboardManager = new KeyboardManager();
        MouseManager mouseManager = new MouseManager();

        string savesPath = Directory.GetCurrentDirectory() + @"\Saves\";

        bool disableRemoveButton = false;

        /// <summary>
        /// Список событий для реагирования
        /// </summary>
        List<KeyValuePair<ManagerKeyState, string>> triggerEvents = new List<KeyValuePair<ManagerKeyState, string>>()
        {
            new KeyValuePair<ManagerKeyState, string>(ManagerKeyState.Down, "Нажатие"),
            new KeyValuePair<ManagerKeyState, string>(ManagerKeyState.Hold, "Удерживание"),
            new KeyValuePair<ManagerKeyState, string>(ManagerKeyState.Up, "Отпускание")
        };

        List<KeyValuePair<ActionType, string>> keyboardEventTypes = new List<KeyValuePair<ActionType, string>>()
        {
            new KeyValuePair<ActionType, string>(ActionType.Press, "Нажатие"),
            new KeyValuePair<ActionType, string>(ActionType.PressDealy, "Нажатие с удержанием"),
            new KeyValuePair<ActionType, string>(ActionType.Down, "Опускание"),
            new KeyValuePair<ActionType, string>(ActionType.Up, "Отпускание"),
        };

        List<KeyValuePair<Mouse.MouseEventFlags[], string>> mouseKeys = new List<KeyValuePair<Mouse.MouseEventFlags[], string>>()
        {
            new KeyValuePair<Mouse.MouseEventFlags[], string>(new Mouse.MouseEventFlags[] { Mouse.MouseEventFlags.LeftDown, Mouse.MouseEventFlags.LeftUp }, "Левая" ),
            new KeyValuePair<Mouse.MouseEventFlags[], string>(new Mouse.MouseEventFlags[] { Mouse.MouseEventFlags.RightDown, Mouse.MouseEventFlags.RightUp }, "Правая" ),
            new KeyValuePair<Mouse.MouseEventFlags[], string>(new Mouse.MouseEventFlags[] { Mouse.MouseEventFlags.MiddleDown, Mouse.MouseEventFlags.MiddleUp }, "Колесо" ),
        };

        List<KeyValuePair<ActionType, string>> mouseEventTypes = new List<KeyValuePair<ActionType, string>>()
        {
            new KeyValuePair<ActionType, string>(ActionType.MousePress, "Нажатие"),
            new KeyValuePair<ActionType, string>(ActionType.MousePressDelay, "Нажатие (с удержанием)"),
            new KeyValuePair<ActionType, string>(ActionType.MouseMove, "Движение"),
        };


        public Form1()
        {
            InitializeComponent();
        }

        public bool IsDirectoryEmpty(string path)
        {
            try
            {
                return !Directory.EnumerateDirectories(path).Any();
            }
            catch (Exception)
            {
                return true;
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MouseDelayTooltip.SetToolTip(MouseDelayBox, "Если действие активируется на удержание клавиши то имитируемое действие можеть сливаться в одно, установив эту галочку после каждого срабатывания будет происходить задержка что бы избежать этого эффекта");

            foreach (var keyName in Keyboard.keys.Select(k => k.Name))
            {
                tKeyBox.Items.Add(keyName);
                eKeyBox.Items.Add(keyName);
            }
            tKeyBox.SelectedIndex = 0;
            eKeyBox.SelectedIndex = 0;

            foreach (var item in triggerEvents.Select(k => k.Value))
            {
                tEventBox.Items.Add(item);
            }
            tEventBox.SelectedIndex = 0;

            bool result = false;

            // Ждём завершения проверки директории
            Task t = Task.Run(() => {
                result = IsDirectoryEmpty(savesPath);
            });
            t.Wait();

            if (!result)
            {
                foreach (var item in Directory.GetDirectories(savesPath))
                {
                    saveBox.Items.Add(item.Replace(savesPath, string.Empty).Replace(@"\", string.Empty));
                }
                saveBox.SelectedIndex = 0;
            }

            foreach (var item in keyboardEventTypes.Select(k => k.Value))
            {
                eTypeBox.Items.Add(item);
            }
            eTypeBox.SelectedIndex = 0;

            foreach (var item in mouseKeys.Select(k => k.Value))
            {
                MouseEventKeyBox.Items.Add(item);
            }
            MouseEventKeyBox.SelectedIndex = 0;

            foreach (var item in mouseEventTypes.Select(k => k.Value))
            {
                MouseEventTypeBox.Items.Add(item);
            }
            MouseEventTypeBox.SelectedIndex = 0;

            EventTable.Columns.Add("key", "Клавиша триггер");
            EventTable.Columns.Add("event", "Тип триггер");
            EventTable.Columns.Add("guid", "Guid");
            EventTable.Columns[2].Visible = false;

            ActionTable.Columns.Add("key", "Клавиша");
            ActionTable.Columns.Add("type", "Тип");
            ActionTable.Columns.Add("delay", "Задержка");
            ActionTable.Columns.Add("guid", "Guid");
            ActionTable.Columns[3].Visible = false;

            {
                MouseXBar.Minimum = 0;
                MouseXBar.Maximum = Screen.PrimaryScreen.Bounds.Width;
                MouseXBar.Value = 100;

                MouseYBar.Minimum = 0;
                MouseYBar.Maximum = Screen.PrimaryScreen.Bounds.Height;
                MouseYBar.Value = 100;
            }
        }

            //KeyHistory.Text += "key is " + key + " up" + Environment.NewLine;
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            keyboardManager.Stop();
            mouseManager.Stop();
        }

        //var gHandle = WindowFromPoint(Cursor.Position);
        //uint pId = 0;
        //GetWindowThreadProcessId(gHandle, out pId);
        //Process myProcess = Process.get GetProcesses().Single(p => p.Id != 0 && p.Handle == gHandle);
        //Process.GetProcessById((int)pId).MainWindowHandle.ToString();

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!IsActiveBox.Checked)
                return;
            var info = keyboardManager.DoEvents();
            mouseManager.DoEvents();
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// Добавить событие в таблицу
        /// </summary>
        /// <param name="event"></param>
        void AddEventInTable(Event @event)
        {
            disableRemoveButton = true;

            int index = EventTable.Rows.Count - 1;

            EventTable.Rows.Add(1);

            EventTable[0, index].Value = Keyboard.keys.Where(k => k.wKey == @event.triggerKey).First().Name;
            EventTable[1, index].Value = triggerEvents.Where(t => t.Key == @event.triggerType).First().Value;
            EventTable[2, index].Value = @event.guid;

            disableRemoveButton = false;
        }

        void AddActionInTable(Action action)
        {
            int index = ActionTable.Rows.Count - 1;

            ActionTable.Rows.Add(1);

            ActionTable[0, index].Value = (action.keyboardKey !=  DirectXKeyboard.DirectXKeyStrokes.NONE ? Keyboard.keys.Where(k => k.dKey == action.keyboardKey).First().Name : string.Empty);
            ActionTable[1, index].Value = Action.ActionTypeTostring(action.type);
            if (action.type == ActionType.PressDealy)
                ActionTable[2, index].Value = action.delay;
            ActionTable[3, index].Value = action.guid;
        }

        /// <summary>
        /// Получить Guid выбранного события
        /// </summary>
        /// <returns></returns>
        Guid GetSelectedEvent()
        {
            if (EventTable.SelectedCells.Count == 0)
                return Guid.Empty;

            DataGridViewCell cell = EventTable.SelectedCells[0];

            if (EventTable[2, cell.RowIndex].Value == null)
                return Guid.Empty;

            return (Guid)EventTable[2, cell.RowIndex].Value;
        }

        /// <summary>
        /// Получить Guid выбранного действия
        /// </summary>
        /// <returns></returns>
        Guid GetSelectedAction()
        {
            if (ActionTable.SelectedCells.Count == 0)
                return Guid.Empty;

            DataGridViewCell cell = ActionTable.SelectedCells[0];
            return (Guid)ActionTable[3, cell.RowIndex].Value;
        }

        void FullEventTable()
        {
            EventTable.Rows.Clear();

            foreach (Event @event in keyboardManager.events)
            {
                AddEventInTable(@event);
            }
        }

        /// <summary>
        /// Заполнение таблицы имитируемых действий относительно выбранного действия
        /// </summary>
        /// <param name="guid"></param>
        void FullActionTable(Guid guid)
        {
            Event @event = keyboardManager.events.Where(e => e.guid == guid).First();

            ActionTable.Rows.Clear();

            foreach (Action action in @event.actions)
            {
                AddActionInTable(action);
            }
        }

        private void EventTable_SelectionChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Rows: " + EventTable.Rows.Count + ", Columns: " + EventTable.Columns.Count);

            if (EventTable.Rows.Count < 3)
                return;

            Guid selectedEvent = GetSelectedEvent();

            if (selectedEvent == Guid.Empty)
                return;

            FullActionTable(selectedEvent);

            /*
            if (selectedEvent != Guid.Empty)
                MessageBox.Show("" + selectedEvent);
            */

            if (disableRemoveButton)
                return;

            /*
            for (int i = 0; i < EventTable.SelectedCells.Count; i++)
            {
                if (EventTable.SelectedCells[i].ColumnIndex == 2)
                {
                    Guid guid = (Guid)EventTable[3, EventTable.SelectedCells[i].RowIndex].Value;
                    keyboardManager.RemoveEvent(guid);
                }
            }

            disableRemoveButton = true;
            EventTable.Rows.Clear();
            disableRemoveButton = false;

            foreach (var @event in keyboardManager.events)
            {
                AddEventInTable(@event);
            }
            */
        }

        #region Кнопки добавить

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            Event mEvent = new Event()
            {
                triggerKey = Keyboard.keys.Where(k => k.Name == tKeyBox.Text).First().wKey,// ParseEnum<Keys>(tKeyBox.Text),
                triggerType = triggerEvents.Where(k => k.Value == tEventBox.Items[tEventBox.SelectedIndex].ToString()).First().Key,
            };

            // Добавляем событие если такого ещё нет
            if (!keyboardManager.CheckEvent(mEvent))
            {
                AddEventInTable(mEvent);
                keyboardManager.AddEvent(mEvent);
            }
        }

        private void AddActionButton_Click(object sender, EventArgs e)
        {
            if (EventTable.SelectedCells.Count == 0)
            {
                MessageBox.Show("Нет выделенного действия.");
                return;
            }

            Guid guid = GetSelectedEvent();

            Action action = new Action()
            {
                keyboardKey = Keyboard.keys.Where(k => k.Name == eKeyBox.Text).First().dKey,
                type = keyboardEventTypes.Where(k => k.Value == eTypeBox.Items[eTypeBox.SelectedIndex].ToString()).First().Key,
                waitAfterDo = KeyboardDelayBox.Checked,
                delay = (uint)DelayTrackBar.Value * 100
            };

            keyboardManager.AddActionToEvent(
            guid,
            action
            );

            FullActionTable(guid);
        }

        private void AddMouseActionButton_Click(object sender, EventArgs e)
        {
            if (EventTable.SelectedCells.Count == 0)
            {
                MessageBox.Show("Нет выделенного действия.");
                return;
            }

            Guid guid = GetSelectedEvent();

            var key = mouseKeys.Where(k => k.Value == MouseEventKeyBox.Items[MouseEventKeyBox.SelectedIndex].ToString()).First().Key;
            var type = mouseEventTypes.Where(k => k.Value == MouseEventTypeBox.Items[MouseEventTypeBox.SelectedIndex].ToString()).First().Key;

            Action action = new Action()
            {
                mouseKey = key,
                type = type,
                delay = (uint)MouseDelayTrackBar.Value * 10,
                waitAfterDo = MouseDelayBox.Checked,
                mouseX = (type == ActionType.MouseMove ? MouseXBar.Value : 0),
                mouseY = (type == ActionType.MouseMove ? MouseYBar.Value : 0),
                mouseMoveRelatively = MouseRelativelyBox.Checked
            };

            keyboardManager.AddActionToEvent(
            guid,
            action
            );

            FullActionTable(guid);
        }

        #endregion

        private void TKeyBox_KeyDown(object sender, KeyEventArgs e)
        {
            //tKeyBox.SelectedItem = tKeyBox.Items.
            //tKeyBox.SelectedIndex = (int)e.KeyCode - 4;
        }

        private void EraseEventButton_Click(object sender, EventArgs e)
        {
            Guid guid = GetSelectedEvent();

            if (guid == Guid.Empty)
                return;

            keyboardManager.RemoveEvent(guid);

            FullEventTable();
        }

        private void EraseActionButton_Click(object sender, EventArgs e)
        {
            Guid eventGuid = GetSelectedEvent();
            Guid actionGuid = GetSelectedAction();

            if (eventGuid == Guid.Empty || actionGuid == Guid.Empty)
                return;

            keyboardManager.RemoveActionFromEvent(eventGuid, actionGuid);

            FullActionTable(eventGuid);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(savesPath))
                Directory.CreateDirectory(savesPath);

            int fileNumber = 0;

            while (Directory.Exists(savesPath + @"Save_" + fileNumber + @"\"))
                fileNumber++;

            string savePath = savesPath + @"Save_" + fileNumber + @"\";
            Directory.CreateDirectory(savePath);

            int eventNumber = 0;

            foreach (var item in keyboardManager.events)
            {
                File.AppendAllText(savePath + "event_" + eventNumber + ".txt",
                Newtonsoft.Json.JsonConvert.SerializeObject(item));
                eventNumber++;
            }

            MessageBox.Show("Сохранено как Save_" + fileNumber + ". Что бы увидеть сохранение в списке перезапустите программу.");
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (saveBox.Items.Count == 0 || saveBox.SelectedIndex == -1)
            {
                MessageBox.Show("Нет сохранений.");
                return;
            }

            foreach (var item in Directory.GetFiles(savesPath + saveBox.Items[saveBox.SelectedIndex] + @"\"))
            {
                string value = File.ReadAllText(item);
                Event @event = Newtonsoft.Json.JsonConvert.DeserializeObject<Event>(value);
                keyboardManager.AddEvent(@event);
            }
            FullEventTable();
            FullActionTable(GetSelectedEvent());
            MessageBox.Show("Загружено из " + saveBox.Items[saveBox.SelectedIndex]);
        }

        private void MouseRelativelyBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MouseRelativelyBox.Checked)
            {
                MouseXBar.Minimum = -25;
                MouseXBar.Maximum = 25;
                MouseXBar.Value = 0;

                MouseYBar.Minimum = -25;
                MouseYBar.Maximum = 25;
                MouseYBar.Value = 0;
            }
            else
            {
                MouseXBar.Minimum = 0;
                MouseXBar.Maximum = Screen.PrimaryScreen.Bounds.Width;
                MouseXBar.Value = 100;

                MouseYBar.Minimum = 0;
                MouseYBar.Maximum = Screen.PrimaryScreen.Bounds.Height;
                MouseYBar.Value = 100;
            }
        }

        private void MouseEventTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (mouseEventTypes.Where(k => k.Value == MouseEventTypeBox.Items[MouseEventTypeBox.SelectedIndex].ToString()).First().Key)
            {
                case ActionType.MousePress:
                    groupBox6.Visible = false;
                    groupBox7.Visible = false;
                    break;
                case ActionType.MousePressDelay:
                    groupBox6.Visible = true;
                    groupBox7.Visible = false;
                    break;
                case ActionType.MouseMove:
                    groupBox6.Visible = false;
                    groupBox7.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void ETypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (keyboardEventTypes.Where(k => k.Value == eTypeBox.Items[eTypeBox.SelectedIndex].ToString()).First().Key)
            {
                case ActionType.Press:
                    groupBox8.Visible = false;
                    break;
                case ActionType.PressDealy:
                    groupBox8.Visible = true;
                    break;
                case ActionType.Down:
                    groupBox8.Visible = false;
                    break;
                case ActionType.Up:
                    groupBox8.Visible = false;
                    break;
                default:
                    break;
            }
        }
    }
}
