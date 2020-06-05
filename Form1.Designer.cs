namespace SendKeyboard
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.KeyHistory = new System.Windows.Forms.RichTextBox();
            this.IsActiveBox = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tKeyBox = new System.Windows.Forms.ComboBox();
            this.tEventBox = new System.Windows.Forms.ComboBox();
            this.eKeyBox = new System.Windows.Forms.ComboBox();
            this.eTypeBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.AddEventButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EraseEventButton = new System.Windows.Forms.Button();
            this.EventTable = new System.Windows.Forms.DataGridView();
            this.DelayTrackBar = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.AddActionButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MouseRelativelyBox = new System.Windows.Forms.CheckBox();
            this.MouseYBar = new System.Windows.Forms.TrackBar();
            this.MouseXBar = new System.Windows.Forms.TrackBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MouseDelayTrackBar = new System.Windows.Forms.TrackBar();
            this.MouseDelayBox = new System.Windows.Forms.CheckBox();
            this.AddMouseActionButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.MouseEventTypeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MouseEventKeyBox = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.KeyboardDelayBox = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.EraseActionButton = new System.Windows.Forms.Button();
            this.ActionTable = new System.Windows.Forms.DataGridView();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.saveBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MouseDelayTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayTrackBar)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MouseYBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MouseXBar)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MouseDelayTrackBar)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActionTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // KeyHistory
            // 
            this.KeyHistory.Location = new System.Drawing.Point(572, 141);
            this.KeyHistory.Name = "KeyHistory";
            this.KeyHistory.Size = new System.Drawing.Size(279, 60);
            this.KeyHistory.TabIndex = 0;
            this.KeyHistory.Text = "";
            // 
            // IsActiveBox
            // 
            this.IsActiveBox.AutoSize = true;
            this.IsActiveBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IsActiveBox.Location = new System.Drawing.Point(18, 12);
            this.IsActiveBox.Name = "IsActiveBox";
            this.IsActiveBox.Size = new System.Drawing.Size(65, 17);
            this.IsActiveBox.TabIndex = 8;
            this.IsActiveBox.Text = "Активно";
            this.IsActiveBox.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // tKeyBox
            // 
            this.tKeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tKeyBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tKeyBox.FormattingEnabled = true;
            this.tKeyBox.Location = new System.Drawing.Point(413, 19);
            this.tKeyBox.Name = "tKeyBox";
            this.tKeyBox.Size = new System.Drawing.Size(121, 21);
            this.tKeyBox.TabIndex = 16;
            this.tKeyBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TKeyBox_KeyDown);
            // 
            // tEventBox
            // 
            this.tEventBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tEventBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tEventBox.FormattingEnabled = true;
            this.tEventBox.Location = new System.Drawing.Point(413, 46);
            this.tEventBox.Name = "tEventBox";
            this.tEventBox.Size = new System.Drawing.Size(121, 21);
            this.tEventBox.TabIndex = 17;
            // 
            // eKeyBox
            // 
            this.eKeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eKeyBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eKeyBox.FormattingEnabled = true;
            this.eKeyBox.Location = new System.Drawing.Point(173, 19);
            this.eKeyBox.Name = "eKeyBox";
            this.eKeyBox.Size = new System.Drawing.Size(121, 21);
            this.eKeyBox.TabIndex = 18;
            // 
            // eTypeBox
            // 
            this.eTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eTypeBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eTypeBox.FormattingEnabled = true;
            this.eTypeBox.Location = new System.Drawing.Point(173, 46);
            this.eTypeBox.Name = "eTypeBox";
            this.eTypeBox.Size = new System.Drawing.Size(121, 21);
            this.eTypeBox.TabIndex = 19;
            this.eTypeBox.SelectedIndexChanged += new System.EventHandler(this.ETypeBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Клавиша";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Событие";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Клавиша";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Действие";
            // 
            // AddEventButton
            // 
            this.AddEventButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddEventButton.Location = new System.Drawing.Point(287, 83);
            this.AddEventButton.Name = "AddEventButton";
            this.AddEventButton.Size = new System.Drawing.Size(94, 29);
            this.AddEventButton.TabIndex = 24;
            this.AddEventButton.Text = "Добавить";
            this.AddEventButton.UseVisualStyleBackColor = true;
            this.AddEventButton.Click += new System.EventHandler(this.AddEventButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EraseEventButton);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tEventBox);
            this.groupBox2.Controls.Add(this.tKeyBox);
            this.groupBox2.Controls.Add(this.EventTable);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.AddEventButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 199);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Список событий";
            // 
            // EraseEventButton
            // 
            this.EraseEventButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EraseEventButton.Location = new System.Drawing.Point(6, 154);
            this.EraseEventButton.Name = "EraseEventButton";
            this.EraseEventButton.Size = new System.Drawing.Size(94, 29);
            this.EraseEventButton.TabIndex = 25;
            this.EraseEventButton.Text = "Удалить";
            this.EraseEventButton.UseVisualStyleBackColor = true;
            this.EraseEventButton.Click += new System.EventHandler(this.EraseEventButton_Click);
            // 
            // EventTable
            // 
            this.EventTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EventTable.Location = new System.Drawing.Point(6, 19);
            this.EventTable.MultiSelect = false;
            this.EventTable.Name = "EventTable";
            this.EventTable.ReadOnly = true;
            this.EventTable.Size = new System.Drawing.Size(275, 129);
            this.EventTable.TabIndex = 0;
            this.EventTable.SelectionChanged += new System.EventHandler(this.EventTable_SelectionChanged);
            // 
            // DelayTrackBar
            // 
            this.DelayTrackBar.Location = new System.Drawing.Point(6, 37);
            this.DelayTrackBar.Minimum = 1;
            this.DelayTrackBar.Name = "DelayTrackBar";
            this.DelayTrackBar.Size = new System.Drawing.Size(257, 45);
            this.DelayTrackBar.TabIndex = 25;
            this.DelayTrackBar.Value = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Время удержания";
            // 
            // AddActionButton
            // 
            this.AddActionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddActionButton.Location = new System.Drawing.Point(10, 269);
            this.AddActionButton.Name = "AddActionButton";
            this.AddActionButton.Size = new System.Drawing.Size(94, 29);
            this.AddActionButton.TabIndex = 25;
            this.AddActionButton.Text = "Добавить";
            this.AddActionButton.UseVisualStyleBackColor = true;
            this.AddActionButton.Click += new System.EventHandler(this.AddActionButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.EraseActionButton);
            this.groupBox4.Controls.Add(this.ActionTable);
            this.groupBox4.Location = new System.Drawing.Point(12, 240);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(914, 343);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Список действий";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.MouseDelayBox);
            this.groupBox5.Controls.Add(this.AddMouseActionButton);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.MouseEventTypeBox);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.MouseEventKeyBox);
            this.groupBox5.Location = new System.Drawing.Point(593, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(311, 314);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Мышь";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.MouseRelativelyBox);
            this.groupBox7.Controls.Add(this.MouseYBar);
            this.groupBox7.Controls.Add(this.MouseXBar);
            this.groupBox7.Location = new System.Drawing.Point(6, 106);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(262, 157);
            this.groupBox7.TabIndex = 33;
            this.groupBox7.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "X";
            // 
            // MouseRelativelyBox
            // 
            this.MouseRelativelyBox.AutoSize = true;
            this.MouseRelativelyBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MouseRelativelyBox.Location = new System.Drawing.Point(6, 113);
            this.MouseRelativelyBox.Name = "MouseRelativelyBox";
            this.MouseRelativelyBox.Size = new System.Drawing.Size(154, 17);
            this.MouseRelativelyBox.TabIndex = 31;
            this.MouseRelativelyBox.Text = "Относительно положения";
            this.MouseRelativelyBox.UseVisualStyleBackColor = true;
            this.MouseRelativelyBox.CheckedChanged += new System.EventHandler(this.MouseRelativelyBox_CheckedChanged);
            // 
            // MouseYBar
            // 
            this.MouseYBar.Location = new System.Drawing.Point(26, 67);
            this.MouseYBar.Maximum = 100;
            this.MouseYBar.Minimum = -100;
            this.MouseYBar.Name = "MouseYBar";
            this.MouseYBar.Size = new System.Drawing.Size(222, 45);
            this.MouseYBar.TabIndex = 30;
            // 
            // MouseXBar
            // 
            this.MouseXBar.Location = new System.Drawing.Point(26, 16);
            this.MouseXBar.Maximum = 100;
            this.MouseXBar.Minimum = -100;
            this.MouseXBar.Name = "MouseXBar";
            this.MouseXBar.Size = new System.Drawing.Size(222, 45);
            this.MouseXBar.TabIndex = 29;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.MouseDelayTrackBar);
            this.groupBox6.Location = new System.Drawing.Point(6, 106);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(292, 100);
            this.groupBox6.TabIndex = 32;
            this.groupBox6.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Время удержания";
            // 
            // MouseDelayTrackBar
            // 
            this.MouseDelayTrackBar.Location = new System.Drawing.Point(9, 40);
            this.MouseDelayTrackBar.Minimum = 1;
            this.MouseDelayTrackBar.Name = "MouseDelayTrackBar";
            this.MouseDelayTrackBar.Size = new System.Drawing.Size(257, 45);
            this.MouseDelayTrackBar.TabIndex = 27;
            this.MouseDelayTrackBar.Value = 1;
            // 
            // MouseDelayBox
            // 
            this.MouseDelayBox.AutoSize = true;
            this.MouseDelayBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MouseDelayBox.Location = new System.Drawing.Point(138, 83);
            this.MouseDelayBox.Name = "MouseDelayBox";
            this.MouseDelayBox.Size = new System.Drawing.Size(157, 17);
            this.MouseDelayBox.TabIndex = 28;
            this.MouseDelayBox.Text = "Задержка после действия";
            this.MouseDelayBox.UseVisualStyleBackColor = true;
            // 
            // AddMouseActionButton
            // 
            this.AddMouseActionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddMouseActionButton.Location = new System.Drawing.Point(6, 269);
            this.AddMouseActionButton.Name = "AddMouseActionButton";
            this.AddMouseActionButton.Size = new System.Drawing.Size(94, 29);
            this.AddMouseActionButton.TabIndex = 27;
            this.AddMouseActionButton.Text = "Добавить";
            this.AddMouseActionButton.UseVisualStyleBackColor = true;
            this.AddMouseActionButton.Click += new System.EventHandler(this.AddMouseActionButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Действие";
            // 
            // MouseEventTypeBox
            // 
            this.MouseEventTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MouseEventTypeBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MouseEventTypeBox.FormattingEnabled = true;
            this.MouseEventTypeBox.Location = new System.Drawing.Point(174, 54);
            this.MouseEventTypeBox.Name = "MouseEventTypeBox";
            this.MouseEventTypeBox.Size = new System.Drawing.Size(121, 21);
            this.MouseEventTypeBox.TabIndex = 27;
            this.MouseEventTypeBox.SelectedIndexChanged += new System.EventHandler(this.MouseEventTypeBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Клавиша";
            // 
            // MouseEventKeyBox
            // 
            this.MouseEventKeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MouseEventKeyBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MouseEventKeyBox.FormattingEnabled = true;
            this.MouseEventKeyBox.Location = new System.Drawing.Point(174, 19);
            this.MouseEventKeyBox.Name = "MouseEventKeyBox";
            this.MouseEventKeyBox.Size = new System.Drawing.Size(121, 21);
            this.MouseEventKeyBox.TabIndex = 27;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.KeyboardDelayBox);
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.eKeyBox);
            this.groupBox3.Controls.Add(this.AddActionButton);
            this.groupBox3.Controls.Add(this.eTypeBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(287, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 314);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Клавиатура";
            // 
            // KeyboardDelayBox
            // 
            this.KeyboardDelayBox.AutoSize = true;
            this.KeyboardDelayBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KeyboardDelayBox.Location = new System.Drawing.Point(137, 83);
            this.KeyboardDelayBox.Name = "KeyboardDelayBox";
            this.KeyboardDelayBox.Size = new System.Drawing.Size(157, 17);
            this.KeyboardDelayBox.TabIndex = 34;
            this.KeyboardDelayBox.Text = "Задержка после действия";
            this.KeyboardDelayBox.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.DelayTrackBar);
            this.groupBox8.Location = new System.Drawing.Point(3, 106);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(272, 157);
            this.groupBox8.TabIndex = 27;
            this.groupBox8.TabStop = false;
            // 
            // EraseActionButton
            // 
            this.EraseActionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EraseActionButton.Location = new System.Drawing.Point(6, 182);
            this.EraseActionButton.Name = "EraseActionButton";
            this.EraseActionButton.Size = new System.Drawing.Size(94, 29);
            this.EraseActionButton.TabIndex = 27;
            this.EraseActionButton.Text = "Удалить";
            this.EraseActionButton.UseVisualStyleBackColor = true;
            this.EraseActionButton.Click += new System.EventHandler(this.EraseActionButton_Click);
            // 
            // ActionTable
            // 
            this.ActionTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ActionTable.Location = new System.Drawing.Point(6, 19);
            this.ActionTable.MultiSelect = false;
            this.ActionTable.Name = "ActionTable";
            this.ActionTable.ReadOnly = true;
            this.ActionTable.Size = new System.Drawing.Size(275, 157);
            this.ActionTable.TabIndex = 0;
            // 
            // SaveButton
            // 
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Location = new System.Drawing.Point(6, 19);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(94, 29);
            this.SaveButton.TabIndex = 26;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadButton.Location = new System.Drawing.Point(6, 54);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(94, 29);
            this.LoadButton.TabIndex = 28;
            this.LoadButton.Text = "Загрузить";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // saveBox
            // 
            this.saveBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saveBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBox.FormattingEnabled = true;
            this.saveBox.Location = new System.Drawing.Point(106, 59);
            this.saveBox.Name = "saveBox";
            this.saveBox.Size = new System.Drawing.Size(121, 21);
            this.saveBox.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SaveButton);
            this.groupBox1.Controls.Add(this.saveBox);
            this.groupBox1.Controls.Add(this.LoadButton);
            this.groupBox1.Location = new System.Drawing.Point(572, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 100);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Меню";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(932, 586);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.IsActiveBox);
            this.Controls.Add(this.KeyHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayTrackBar)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MouseYBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MouseXBar)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MouseDelayTrackBar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActionTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox KeyHistory;
        private System.Windows.Forms.CheckBox IsActiveBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox tKeyBox;
        private System.Windows.Forms.ComboBox tEventBox;
        private System.Windows.Forms.ComboBox eKeyBox;
        private System.Windows.Forms.ComboBox eTypeBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button AddEventButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView EventTable;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar DelayTrackBar;
        private System.Windows.Forms.Button AddActionButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView ActionTable;
        private System.Windows.Forms.Button EraseEventButton;
        private System.Windows.Forms.Button EraseActionButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.ComboBox saveBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox MouseEventTypeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox MouseEventKeyBox;
        private System.Windows.Forms.TrackBar MouseDelayTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddMouseActionButton;
        private System.Windows.Forms.CheckBox MouseDelayBox;
        private System.Windows.Forms.ToolTip MouseDelayTooltip;
        private System.Windows.Forms.TrackBar MouseYBar;
        private System.Windows.Forms.TrackBar MouseXBar;
        private System.Windows.Forms.CheckBox MouseRelativelyBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox KeyboardDelayBox;
    }
}

