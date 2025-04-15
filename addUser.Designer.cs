
namespace PGESCOM
{
    partial class addUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addUser));
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.fullName = new System.Windows.Forms.TextBox();
            this.SuperUserRadioButton = new System.Windows.Forms.RadioButton();
            this.normalUserRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.fullNameLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(319, 87);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(125, 22);
            this.username.TabIndex = 0;
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(319, 161);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(125, 22);
            this.password.TabIndex = 1;
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // fullName
            // 
            this.fullName.Location = new System.Drawing.Point(319, 245);
            this.fullName.Name = "fullName";
            this.fullName.Size = new System.Drawing.Size(125, 22);
            this.fullName.TabIndex = 2;
            this.fullName.TextChanged += new System.EventHandler(this.fullName_TextChanged);
            // 
            // SuperUserRadioButton
            // 
            this.SuperUserRadioButton.AutoSize = true;
            this.SuperUserRadioButton.Location = new System.Drawing.Point(676, 87);
            this.SuperUserRadioButton.Name = "SuperUserRadioButton";
            this.SuperUserRadioButton.Size = new System.Drawing.Size(37, 20);
            this.SuperUserRadioButton.TabIndex = 3;
            this.SuperUserRadioButton.TabStop = true;
            this.SuperUserRadioButton.Text = "S";
            this.SuperUserRadioButton.UseVisualStyleBackColor = true;
            this.SuperUserRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // normalUserRadioButton
            // 
            this.normalUserRadioButton.AutoSize = true;
            this.normalUserRadioButton.Location = new System.Drawing.Point(678, 139);
            this.normalUserRadioButton.Name = "normalUserRadioButton";
            this.normalUserRadioButton.Size = new System.Drawing.Size(38, 20);
            this.normalUserRadioButton.TabIndex = 4;
            this.normalUserRadioButton.TabStop = true;
            this.normalUserRadioButton.Text = "N";
            this.normalUserRadioButton.UseVisualStyleBackColor = true;
            this.normalUserRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Location = new System.Drawing.Point(330, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "add user";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.addUser_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.usernameLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.usernameLabel.Location = new System.Drawing.Point(222, 87);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(73, 16);
            this.usernameLabel.TabIndex = 6;
            this.usernameLabel.Text = "Username ";
            this.usernameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(225, 161);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(67, 16);
            this.passwordLabel.TabIndex = 7;
            this.passwordLabel.Text = "Password";
            // 
            // fullNameLabel
            // 
            this.fullNameLabel.AutoSize = true;
            this.fullNameLabel.Location = new System.Drawing.Point(225, 245);
            this.fullNameLabel.Name = "fullNameLabel";
            this.fullNameLabel.Size = new System.Drawing.Size(68, 16);
            this.fullNameLabel.TabIndex = 8;
            this.fullNameLabel.Text = "Full Name";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(173, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // addUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.fullNameLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.normalUserRadioButton);
            this.Controls.Add(this.SuperUserRadioButton);
            this.Controls.Add(this.fullName);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Name = "addUser";
            this.Text = "addUser";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox fullName;
        private System.Windows.Forms.RadioButton SuperUserRadioButton;
        private System.Windows.Forms.RadioButton normalUserRadioButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label fullNameLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}