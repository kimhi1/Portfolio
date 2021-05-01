namespace Client
{
    partial class Menu_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_form));
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.signupButton = new System.Windows.Forms.Button();
            this.bestScoresButton = new System.Windows.Forms.Button();
            this.myStatusButton = new System.Windows.Forms.Button();
            this.createRoomButton = new System.Windows.Forms.Button();
            this.joinRoomButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.signinButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.promptLabel = new System.Windows.Forms.Label();
            this.hellouserLabel = new System.Windows.Forms.Label();
            this.signoutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(354, 27);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(235, 20);
            this.usernameTextbox.TabIndex = 0;
            this.usernameTextbox.Text = "user";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.usernameLabel.Font = new System.Drawing.Font("Mistral", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(244, 27);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(85, 22);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "User Name";
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(354, 70);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(235, 20);
            this.passwordTextbox.TabIndex = 2;
            this.passwordTextbox.Text = "Aa12";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.passwordLabel.Font = new System.Drawing.Font("Mistral", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(244, 70);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(75, 22);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Password";
            // 
            // signupButton
            // 
            this.signupButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.signupButton.Font = new System.Drawing.Font("Script MT Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupButton.ForeColor = System.Drawing.SystemColors.Window;
            this.signupButton.Location = new System.Drawing.Point(13, 13);
            this.signupButton.Name = "signupButton";
            this.signupButton.Size = new System.Drawing.Size(157, 60);
            this.signupButton.TabIndex = 4;
            this.signupButton.Text = "Sign up";
            this.signupButton.UseVisualStyleBackColor = false;
            this.signupButton.Click += new System.EventHandler(this.Sign_up_Click);
            // 
            // bestScoresButton
            // 
            this.bestScoresButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.bestScoresButton.Enabled = false;
            this.bestScoresButton.Font = new System.Drawing.Font("Script MT Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bestScoresButton.ForeColor = System.Drawing.SystemColors.Window;
            this.bestScoresButton.Location = new System.Drawing.Point(12, 277);
            this.bestScoresButton.Name = "bestScoresButton";
            this.bestScoresButton.Size = new System.Drawing.Size(157, 60);
            this.bestScoresButton.TabIndex = 5;
            this.bestScoresButton.Text = "Best scores";
            this.bestScoresButton.UseVisualStyleBackColor = false;
            this.bestScoresButton.Click += new System.EventHandler(this.Best_scores_Click);
            // 
            // myStatusButton
            // 
            this.myStatusButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.myStatusButton.Enabled = false;
            this.myStatusButton.Font = new System.Drawing.Font("Script MT Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myStatusButton.ForeColor = System.Drawing.SystemColors.Window;
            this.myStatusButton.Location = new System.Drawing.Point(13, 211);
            this.myStatusButton.Name = "myStatusButton";
            this.myStatusButton.Size = new System.Drawing.Size(157, 60);
            this.myStatusButton.TabIndex = 6;
            this.myStatusButton.Text = "My status";
            this.myStatusButton.UseVisualStyleBackColor = false;
            this.myStatusButton.Click += new System.EventHandler(this.My_status_Click);
            // 
            // createRoomButton
            // 
            this.createRoomButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.createRoomButton.Enabled = false;
            this.createRoomButton.Font = new System.Drawing.Font("Script MT Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createRoomButton.ForeColor = System.Drawing.SystemColors.Window;
            this.createRoomButton.Location = new System.Drawing.Point(13, 145);
            this.createRoomButton.Name = "createRoomButton";
            this.createRoomButton.Size = new System.Drawing.Size(157, 60);
            this.createRoomButton.TabIndex = 7;
            this.createRoomButton.Text = "Create room";
            this.createRoomButton.UseVisualStyleBackColor = false;
            this.createRoomButton.Click += new System.EventHandler(this.Create_room_Click);
            // 
            // joinRoomButton
            // 
            this.joinRoomButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.joinRoomButton.Enabled = false;
            this.joinRoomButton.Font = new System.Drawing.Font("Script MT Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joinRoomButton.ForeColor = System.Drawing.SystemColors.Window;
            this.joinRoomButton.Location = new System.Drawing.Point(13, 79);
            this.joinRoomButton.Name = "joinRoomButton";
            this.joinRoomButton.Size = new System.Drawing.Size(157, 60);
            this.joinRoomButton.TabIndex = 8;
            this.joinRoomButton.Text = "Join room";
            this.joinRoomButton.UseVisualStyleBackColor = false;
            this.joinRoomButton.Click += new System.EventHandler(this.Join_room_Click);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.quitButton.Font = new System.Drawing.Font("Script MT Bold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.Color.Red;
            this.quitButton.Location = new System.Drawing.Point(53, 343);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(72, 38);
            this.quitButton.TabIndex = 9;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.Quit_Click);
            // 
            // signinButton
            // 
            this.signinButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.signinButton.Font = new System.Drawing.Font("Script MT Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signinButton.ForeColor = System.Drawing.SystemColors.Window;
            this.signinButton.Location = new System.Drawing.Point(605, 45);
            this.signinButton.Name = "signinButton";
            this.signinButton.Size = new System.Drawing.Size(84, 45);
            this.signinButton.TabIndex = 10;
            this.signinButton.Text = "Sign in";
            this.signinButton.UseVisualStyleBackColor = false;
            this.signinButton.Click += new System.EventHandler(this.signinButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Client.Properties.Resources.image_trivia;
            this.pictureBox1.Location = new System.Drawing.Point(231, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(439, 293);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // promptLabel
            // 
            this.promptLabel.AutoSize = true;
            this.promptLabel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promptLabel.ForeColor = System.Drawing.Color.Red;
            this.promptLabel.Location = new System.Drawing.Point(357, 5);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(291, 19);
            this.promptLabel.TabIndex = 12;
            this.promptLabel.Text = "--PROMPT--(notice that this is not visible)";
            this.promptLabel.Visible = false;
            // 
            // hellouserLabel
            // 
            this.hellouserLabel.AutoSize = true;
            this.hellouserLabel.Font = new System.Drawing.Font("Segoe Script", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hellouserLabel.ForeColor = System.Drawing.Color.Black;
            this.hellouserLabel.Location = new System.Drawing.Point(353, 43);
            this.hellouserLabel.Name = "hellouserLabel";
            this.hellouserLabel.Size = new System.Drawing.Size(93, 44);
            this.hellouserLabel.TabIndex = 13;
            this.hellouserLabel.Text = "Hello";
            this.hellouserLabel.Visible = false;
            // 
            // signoutButton
            // 
            this.signoutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.signoutButton.Font = new System.Drawing.Font("Script MT Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signoutButton.ForeColor = System.Drawing.SystemColors.Window;
            this.signoutButton.Location = new System.Drawing.Point(13, 13);
            this.signoutButton.Name = "signoutButton";
            this.signoutButton.Size = new System.Drawing.Size(157, 60);
            this.signoutButton.TabIndex = 14;
            this.signoutButton.Text = "Sign out";
            this.signoutButton.UseVisualStyleBackColor = false;
            this.signoutButton.Visible = false;
            this.signoutButton.Click += new System.EventHandler(this.signoutButton_Click);
            // 
            // Menu_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(116)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(701, 406);
            this.ControlBox = false;
            this.Controls.Add(this.signoutButton);
            this.Controls.Add(this.hellouserLabel);
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.signinButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.joinRoomButton);
            this.Controls.Add(this.createRoomButton);
            this.Controls.Add(this.myStatusButton);
            this.Controls.Add(this.bestScoresButton);
            this.Controls.Add(this.signupButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_form";
            this.Text = "Trivia Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_form_FormClosing);
            this.Shown += new System.EventHandler(this.Menu_form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button signupButton;
        private System.Windows.Forms.Button bestScoresButton;
        private System.Windows.Forms.Button myStatusButton;
        private System.Windows.Forms.Button createRoomButton;
        private System.Windows.Forms.Button joinRoomButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button signinButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label promptLabel;
        private System.Windows.Forms.Label hellouserLabel;
        private System.Windows.Forms.Button signoutButton;
    }
}

