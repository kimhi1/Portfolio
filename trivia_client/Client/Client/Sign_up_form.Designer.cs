namespace Client
{
    partial class Sign_up_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sign_up_form));
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.User_name = new System.Windows.Forms.Label();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.email = new System.Windows.Forms.Label();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            this.promptLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(237, 160);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(407, 20);
            this.passwordTextbox.TabIndex = 0;
            this.passwordTextbox.Text = "Aa12";
            // 
            // User_name
            // 
            this.User_name.AutoSize = true;
            this.User_name.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.User_name.Font = new System.Drawing.Font("Mistral", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_name.Location = new System.Drawing.Point(127, 120);
            this.User_name.Name = "User_name";
            this.User_name.Size = new System.Drawing.Size(104, 29);
            this.User_name.TabIndex = 1;
            this.User_name.Text = "User Name";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(237, 127);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(407, 20);
            this.usernameTextbox.TabIndex = 2;
            this.usernameTextbox.Text = "newUser";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Password.Font = new System.Drawing.Font("Mistral", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(127, 153);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(93, 29);
            this.Password.TabIndex = 3;
            this.Password.Text = "Password";
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.okButton.Font = new System.Drawing.Font("Script MT Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.ForeColor = System.Drawing.SystemColors.Window;
            this.okButton.Location = new System.Drawing.Point(322, 254);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(157, 60);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.backButton.Font = new System.Drawing.Font("Script MT Bold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.Red;
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(72, 38);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.Back_Click);
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.email.Font = new System.Drawing.Font("Mistral", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(127, 200);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(62, 29);
            this.email.TabIndex = 10;
            this.email.Text = "email";
            // 
            // emailTextbox
            // 
            this.emailTextbox.Location = new System.Drawing.Point(237, 209);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(407, 20);
            this.emailTextbox.TabIndex = 11;
            this.emailTextbox.Text = "yourMail@gmail.com";
            // 
            // promptLabel
            // 
            this.promptLabel.AutoSize = true;
            this.promptLabel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promptLabel.ForeColor = System.Drawing.Color.Red;
            this.promptLabel.Location = new System.Drawing.Point(202, 67);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(291, 19);
            this.promptLabel.TabIndex = 13;
            this.promptLabel.Text = "--PROMPT--(notice that this is not visible)";
            this.promptLabel.Visible = false;
            // 
            // Sign_up_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(116)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(701, 406);
            this.ControlBox = false;
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.emailTextbox);
            this.Controls.Add(this.email);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.User_name);
            this.Controls.Add(this.passwordTextbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sign_up_form";
            this.Text = "Trivia Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Label User_name;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.TextBox emailTextbox;
        private System.Windows.Forms.Label promptLabel;
    }
}

