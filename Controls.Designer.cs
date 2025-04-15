
namespace PGESCOM
{
    partial class Controls
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controls));
            this.grpBox_button = new System.Windows.Forms.GroupBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.pictureBox_new = new System.Windows.Forms.PictureBox();
            this.lbl_new = new System.Windows.Forms.Label();
            this.grpBox_controls = new System.Windows.Forms.GroupBox();
            this.grpBox_enable = new System.Windows.Forms.GroupBox();
            this.radioBtn_enableOff = new System.Windows.Forms.RadioButton();
            this.radioBtn_enableOn = new System.Windows.Forms.RadioButton();
            this.lbl_enableValue = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_cancelAddOrUpdate = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.txtBox_equalizeDuration = new System.Windows.Forms.TextBox();
            this.lbl_equalizeDuration = new System.Windows.Forms.Label();
            this.txtBox_delay = new System.Windows.Forms.TextBox();
            this.lbl_delay = new System.Windows.Forms.Label();
            this.txtBox_adjust2 = new System.Windows.Forms.TextBox();
            this.lbl_adjust2 = new System.Windows.Forms.Label();
            this.txtBox_adjust1 = new System.Windows.Forms.TextBox();
            this.lbl_adjust1 = new System.Windows.Forms.Label();
            this.txtBox_description = new System.Windows.Forms.TextBox();
            this.lbl_description = new System.Windows.Forms.Label();
            this.listView_controls = new System.Windows.Forms.ListView();
            this.Inc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descriptions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Adjust1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Adjust2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Delay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Eq_Duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Enable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItem_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.grpBox_button.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_new)).BeginInit();
            this.grpBox_controls.SuspendLayout();
            this.grpBox_enable.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBox_button
            // 
            this.grpBox_button.Controls.Add(this.btn_cancel);
            this.grpBox_button.Controls.Add(this.btn_ok);
            this.grpBox_button.Controls.Add(this.pictureBox_new);
            this.grpBox_button.Controls.Add(this.lbl_new);
            this.grpBox_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBox_button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBox_button.Location = new System.Drawing.Point(0, 0);
            this.grpBox_button.Name = "grpBox_button";
            this.grpBox_button.Size = new System.Drawing.Size(838, 53);
            this.grpBox_button.TabIndex = 0;
            this.grpBox_button.TabStop = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(495, 15);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(85, 30);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(390, 15);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 30);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // pictureBox_new
            // 
            this.pictureBox_new.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_new.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_new.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_new.Image")));
            this.pictureBox_new.Location = new System.Drawing.Point(310, 17);
            this.pictureBox_new.Name = "pictureBox_new";
            this.pictureBox_new.Size = new System.Drawing.Size(28, 28);
            this.pictureBox_new.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_new.TabIndex = 1;
            this.pictureBox_new.TabStop = false;
            this.pictureBox_new.Click += new System.EventHandler(this.pictureBox_new_Click);
            // 
            // lbl_new
            // 
            this.lbl_new.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_new.ForeColor = System.Drawing.Color.Black;
            this.lbl_new.Location = new System.Drawing.Point(270, 20);
            this.lbl_new.Name = "lbl_new";
            this.lbl_new.Size = new System.Drawing.Size(35, 20);
            this.lbl_new.TabIndex = 0;
            this.lbl_new.Text = "New";
            this.lbl_new.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_new.Click += new System.EventHandler(this.pictureBox_new_Click);
            // 
            // grpBox_controls
            // 
            this.grpBox_controls.Controls.Add(this.grpBox_enable);
            this.grpBox_controls.Controls.Add(this.lbl_enableValue);
            this.grpBox_controls.Controls.Add(this.btn_update);
            this.grpBox_controls.Controls.Add(this.btn_cancelAddOrUpdate);
            this.grpBox_controls.Controls.Add(this.btn_save);
            this.grpBox_controls.Controls.Add(this.txtBox_equalizeDuration);
            this.grpBox_controls.Controls.Add(this.lbl_equalizeDuration);
            this.grpBox_controls.Controls.Add(this.txtBox_delay);
            this.grpBox_controls.Controls.Add(this.lbl_delay);
            this.grpBox_controls.Controls.Add(this.txtBox_adjust2);
            this.grpBox_controls.Controls.Add(this.lbl_adjust2);
            this.grpBox_controls.Controls.Add(this.txtBox_adjust1);
            this.grpBox_controls.Controls.Add(this.lbl_adjust1);
            this.grpBox_controls.Controls.Add(this.txtBox_description);
            this.grpBox_controls.Controls.Add(this.lbl_description);
            this.grpBox_controls.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBox_controls.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBox_controls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBox_controls.Location = new System.Drawing.Point(0, 53);
            this.grpBox_controls.Name = "grpBox_controls";
            this.grpBox_controls.Size = new System.Drawing.Size(838, 136);
            this.grpBox_controls.TabIndex = 1;
            this.grpBox_controls.TabStop = false;
            this.grpBox_controls.Visible = false;
            // 
            // grpBox_enable
            // 
            this.grpBox_enable.Controls.Add(this.radioBtn_enableOff);
            this.grpBox_enable.Controls.Add(this.radioBtn_enableOn);
            this.grpBox_enable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBox_enable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBox_enable.Location = new System.Drawing.Point(382, 49);
            this.grpBox_enable.Name = "grpBox_enable";
            this.grpBox_enable.Size = new System.Drawing.Size(120, 76);
            this.grpBox_enable.TabIndex = 13;
            this.grpBox_enable.TabStop = false;
            this.grpBox_enable.Text = "Enable";
            // 
            // radioBtn_enableOff
            // 
            this.radioBtn_enableOff.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioBtn_enableOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtn_enableOff.ForeColor = System.Drawing.Color.Red;
            this.radioBtn_enableOff.Location = new System.Drawing.Point(10, 45);
            this.radioBtn_enableOff.Name = "radioBtn_enableOff";
            this.radioBtn_enableOff.Size = new System.Drawing.Size(80, 20);
            this.radioBtn_enableOff.TabIndex = 15;
            this.radioBtn_enableOff.Text = "Off";
            this.radioBtn_enableOff.UseVisualStyleBackColor = false;
            this.radioBtn_enableOff.CheckedChanged += new System.EventHandler(this.radioBtn_enableOff_CheckedChanged);
            // 
            // radioBtn_enableOn
            // 
            this.radioBtn_enableOn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioBtn_enableOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtn_enableOn.ForeColor = System.Drawing.Color.Red;
            this.radioBtn_enableOn.Location = new System.Drawing.Point(10, 20);
            this.radioBtn_enableOn.Name = "radioBtn_enableOn";
            this.radioBtn_enableOn.Size = new System.Drawing.Size(80, 20);
            this.radioBtn_enableOn.TabIndex = 14;
            this.radioBtn_enableOn.Text = "On";
            this.radioBtn_enableOn.UseVisualStyleBackColor = false;
            this.radioBtn_enableOn.CheckedChanged += new System.EventHandler(this.radioBtn_enableOn_CheckedChanged);
            // 
            // lbl_enableValue
            // 
            this.lbl_enableValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_enableValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_enableValue.ForeColor = System.Drawing.Color.Black;
            this.lbl_enableValue.Location = new System.Drawing.Point(435, 83);
            this.lbl_enableValue.Name = "lbl_enableValue";
            this.lbl_enableValue.Size = new System.Drawing.Size(56, 20);
            this.lbl_enableValue.TabIndex = 12;
            this.lbl_enableValue.Text = "N/A";
            this.lbl_enableValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_enableValue.Visible = false;
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_update.Location = new System.Drawing.Point(656, 86);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(85, 30);
            this.btn_update.TabIndex = 2;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_cancelAddOrUpdate
            // 
            this.btn_cancelAddOrUpdate.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_cancelAddOrUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cancelAddOrUpdate.Location = new System.Drawing.Point(746, 86);
            this.btn_cancelAddOrUpdate.Name = "btn_cancelAddOrUpdate";
            this.btn_cancelAddOrUpdate.Size = new System.Drawing.Size(85, 30);
            this.btn_cancelAddOrUpdate.TabIndex = 11;
            this.btn_cancelAddOrUpdate.Text = "Cancel";
            this.btn_cancelAddOrUpdate.UseVisualStyleBackColor = false;
            this.btn_cancelAddOrUpdate.Click += new System.EventHandler(this.btn_cancelAddOrUpdate_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_save.Location = new System.Drawing.Point(656, 86);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(85, 30);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txtBox_equalizeDuration
            // 
            this.txtBox_equalizeDuration.BackColor = System.Drawing.Color.Lavender;
            this.txtBox_equalizeDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_equalizeDuration.ForeColor = System.Drawing.Color.DarkRed;
            this.txtBox_equalizeDuration.Location = new System.Drawing.Point(66, 80);
            this.txtBox_equalizeDuration.MaxLength = 50;
            this.txtBox_equalizeDuration.Multiline = true;
            this.txtBox_equalizeDuration.Name = "txtBox_equalizeDuration";
            this.txtBox_equalizeDuration.Size = new System.Drawing.Size(75, 27);
            this.txtBox_equalizeDuration.TabIndex = 9;
            // 
            // lbl_equalizeDuration
            // 
            this.lbl_equalizeDuration.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_equalizeDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_equalizeDuration.ForeColor = System.Drawing.Color.Black;
            this.lbl_equalizeDuration.Location = new System.Drawing.Point(141, 86);
            this.lbl_equalizeDuration.Name = "lbl_equalizeDuration";
            this.lbl_equalizeDuration.Size = new System.Drawing.Size(136, 20);
            this.lbl_equalizeDuration.TabIndex = 8;
            this.lbl_equalizeDuration.Text = "Equalize Duration";
            this.lbl_equalizeDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBox_delay
            // 
            this.txtBox_delay.BackColor = System.Drawing.Color.Lavender;
            this.txtBox_delay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_delay.ForeColor = System.Drawing.Color.DarkRed;
            this.txtBox_delay.Location = new System.Drawing.Point(277, 80);
            this.txtBox_delay.MaxLength = 50;
            this.txtBox_delay.Multiline = true;
            this.txtBox_delay.Name = "txtBox_delay";
            this.txtBox_delay.Size = new System.Drawing.Size(75, 27);
            this.txtBox_delay.TabIndex = 7;
            // 
            // lbl_delay
            // 
            this.lbl_delay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_delay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_delay.ForeColor = System.Drawing.Color.Black;
            this.lbl_delay.Location = new System.Drawing.Point(10, 86);
            this.lbl_delay.Name = "lbl_delay";
            this.lbl_delay.Size = new System.Drawing.Size(56, 20);
            this.lbl_delay.TabIndex = 6;
            this.lbl_delay.Text = "Delay";
            this.lbl_delay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBox_adjust2
            // 
            this.txtBox_adjust2.BackColor = System.Drawing.Color.Lavender;
            this.txtBox_adjust2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_adjust2.ForeColor = System.Drawing.Color.DarkRed;
            this.txtBox_adjust2.Location = new System.Drawing.Point(703, 20);
            this.txtBox_adjust2.MaxLength = 50;
            this.txtBox_adjust2.Multiline = true;
            this.txtBox_adjust2.Name = "txtBox_adjust2";
            this.txtBox_adjust2.Size = new System.Drawing.Size(75, 27);
            this.txtBox_adjust2.TabIndex = 5;
            // 
            // lbl_adjust2
            // 
            this.lbl_adjust2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_adjust2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_adjust2.ForeColor = System.Drawing.Color.Black;
            this.lbl_adjust2.Location = new System.Drawing.Point(637, 26);
            this.lbl_adjust2.Name = "lbl_adjust2";
            this.lbl_adjust2.Size = new System.Drawing.Size(66, 20);
            this.lbl_adjust2.TabIndex = 4;
            this.lbl_adjust2.Text = "Adjust2";
            this.lbl_adjust2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBox_adjust1
            // 
            this.txtBox_adjust1.BackColor = System.Drawing.Color.Lavender;
            this.txtBox_adjust1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_adjust1.ForeColor = System.Drawing.Color.DarkRed;
            this.txtBox_adjust1.Location = new System.Drawing.Point(562, 20);
            this.txtBox_adjust1.MaxLength = 50;
            this.txtBox_adjust1.Multiline = true;
            this.txtBox_adjust1.Name = "txtBox_adjust1";
            this.txtBox_adjust1.Size = new System.Drawing.Size(75, 27);
            this.txtBox_adjust1.TabIndex = 3;
            // 
            // lbl_adjust1
            // 
            this.lbl_adjust1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_adjust1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_adjust1.ForeColor = System.Drawing.Color.Black;
            this.lbl_adjust1.Location = new System.Drawing.Point(496, 26);
            this.lbl_adjust1.Name = "lbl_adjust1";
            this.lbl_adjust1.Size = new System.Drawing.Size(66, 20);
            this.lbl_adjust1.TabIndex = 2;
            this.lbl_adjust1.Text = "Adjust1";
            this.lbl_adjust1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBox_description
            // 
            this.txtBox_description.BackColor = System.Drawing.Color.Lavender;
            this.txtBox_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_description.ForeColor = System.Drawing.Color.DarkRed;
            this.txtBox_description.Location = new System.Drawing.Point(96, 20);
            this.txtBox_description.MaxLength = 50;
            this.txtBox_description.Multiline = true;
            this.txtBox_description.Name = "txtBox_description";
            this.txtBox_description.Size = new System.Drawing.Size(400, 27);
            this.txtBox_description.TabIndex = 1;
            // 
            // lbl_description
            // 
            this.lbl_description.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_description.ForeColor = System.Drawing.Color.Black;
            this.lbl_description.Location = new System.Drawing.Point(10, 26);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(86, 20);
            this.lbl_description.TabIndex = 0;
            this.lbl_description.Text = "Description";
            this.lbl_description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView_controls
            // 
            this.listView_controls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView_controls.CheckBoxes = true;
            this.listView_controls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Inc,
            this.Descriptions,
            this.Adjust1,
            this.Adjust2,
            this.Delay,
            this.Eq_Duration,
            this.Enable,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listView_controls.ContextMenuStrip = this.contextMenuStrip;
            this.listView_controls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_controls.ForeColor = System.Drawing.Color.Blue;
            this.listView_controls.FullRowSelect = true;
            this.listView_controls.GridLines = true;
            this.listView_controls.HideSelection = false;
            this.listView_controls.Location = new System.Drawing.Point(0, 189);
            this.listView_controls.Name = "listView_controls";
            this.listView_controls.Size = new System.Drawing.Size(838, 379);
            this.listView_controls.TabIndex = 2;
            this.listView_controls.UseCompatibleStateImageBehavior = false;
            this.listView_controls.View = System.Windows.Forms.View.Details;
            this.listView_controls.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView_controls_ItemCheck);
            this.listView_controls.DoubleClick += new System.EventHandler(this.listView_controls_DoubleClick);
            // 
            // Inc
            // 
            this.Inc.Text = "Inc";
            this.Inc.Width = 30;
            // 
            // Descriptions
            // 
            this.Descriptions.Text = "Descriptions";
            this.Descriptions.Width = 479;
            // 
            // Adjust1
            // 
            this.Adjust1.Text = "Adjust1";
            // 
            // Adjust2
            // 
            this.Adjust2.Text = "Adjust2";
            // 
            // Delay
            // 
            this.Delay.Text = "Delay";
            // 
            // Eq_Duration
            // 
            this.Eq_Duration.Text = "Eq Duration";
            this.Eq_Duration.Width = 85;
            // 
            // Enable
            // 
            this.Enable.Text = "Enable";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 0;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Width = 0;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Width = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItem_delete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(211, 56);
            // 
            // mnuItem_delete
            // 
            this.mnuItem_delete.Name = "mnuItem_delete";
            this.mnuItem_delete.Size = new System.Drawing.Size(210, 24);
            this.mnuItem_delete.Text = "Delete";
            this.mnuItem_delete.Click += new System.EventHandler(this.mnuItem_delete_Click);
            // 
            // Controls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 568);
            this.Controls.Add(this.listView_controls);
            this.Controls.Add(this.grpBox_controls);
            this.Controls.Add(this.grpBox_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Controls";
            this.Text = "Controls";
            this.grpBox_button.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_new)).EndInit();
            this.grpBox_controls.ResumeLayout(false);
            this.grpBox_controls.PerformLayout();
            this.grpBox_enable.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBox_button;
        private System.Windows.Forms.Label lbl_new;
        private System.Windows.Forms.PictureBox pictureBox_new;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.GroupBox grpBox_controls;
        private System.Windows.Forms.Label lbl_description;
        internal System.Windows.Forms.TextBox txtBox_description;
        private System.Windows.Forms.Label lbl_adjust1;
        private System.Windows.Forms.TextBox txtBox_adjust1;
        private System.Windows.Forms.Label lbl_adjust2;
        internal System.Windows.Forms.TextBox txtBox_adjust2;
        private System.Windows.Forms.Label lbl_delay;
        private System.Windows.Forms.TextBox txtBox_delay;
        private System.Windows.Forms.Label lbl_equalizeDuration;
        private System.Windows.Forms.TextBox txtBox_equalizeDuration;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancelAddOrUpdate;
        private System.Windows.Forms.Button btn_update;
        public System.Windows.Forms.ListView listView_controls;
        private System.Windows.Forms.ColumnHeader Inc;
        private System.Windows.Forms.ColumnHeader Descriptions;
        private System.Windows.Forms.ColumnHeader Adjust1;
        private System.Windows.Forms.ColumnHeader Adjust2;
        private System.Windows.Forms.ColumnHeader Delay;
        private System.Windows.Forms.ColumnHeader Eq_Duration;
        private System.Windows.Forms.ColumnHeader Enable;
        private System.Windows.Forms.Label lbl_enableValue;
        private System.Windows.Forms.GroupBox grpBox_enable;
        private System.Windows.Forms.RadioButton radioBtn_enableOn;
        private System.Windows.Forms.RadioButton radioBtn_enableOff;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuItem_delete;
    }
}