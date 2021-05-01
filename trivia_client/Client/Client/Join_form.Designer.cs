namespace Client
{
    partial class Join_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Join_form));
            this.refreshButton = new System.Windows.Forms.Button();
            this.joinButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.Rooms_list = new System.Windows.Forms.Label();
            this.usersLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.roomsListbox = new System.Windows.Forms.ListBox();
            this.usersListbox = new System.Windows.Forms.ListBox();
            this.promptLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.refreshButton.Font = new System.Drawing.Font("Script MT Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.ForeColor = System.Drawing.SystemColors.Window;
            this.refreshButton.Location = new System.Drawing.Point(532, 309);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(157, 60);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "refresh";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // joinButton
            // 
            this.joinButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.joinButton.Font = new System.Drawing.Font("Script MT Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joinButton.ForeColor = System.Drawing.SystemColors.Window;
            this.joinButton.Location = new System.Drawing.Point(38, 309);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(157, 60);
            this.joinButton.TabIndex = 8;
            this.joinButton.Text = "Join";
            this.joinButton.UseVisualStyleBackColor = false;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.backButton.Font = new System.Drawing.Font("Script MT Bold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.Red;
            this.backButton.Location = new System.Drawing.Point(13, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(72, 38);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.Back_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(546, 9);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(143, 21);
            this.usernameLabel.TabIndex = 14;
            this.usernameLabel.Text = "Name Of User";
            // 
            // Rooms_list
            // 
            this.Rooms_list.AutoSize = true;
            this.Rooms_list.BackColor = System.Drawing.Color.White;
            this.Rooms_list.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rooms_list.Location = new System.Drawing.Point(280, 81);
            this.Rooms_list.Name = "Rooms_list";
            this.Rooms_list.Size = new System.Drawing.Size(153, 23);
            this.Rooms_list.TabIndex = 16;
            this.Rooms_list.Text = "Rooms list:";
            // 
            // usersLabel
            // 
            this.usersLabel.AutoSize = true;
            this.usersLabel.BackColor = System.Drawing.Color.White;
            this.usersLabel.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersLabel.Location = new System.Drawing.Point(312, 274);
            this.usersLabel.Name = "usersLabel";
            this.usersLabel.Size = new System.Drawing.Size(88, 23);
            this.usersLabel.TabIndex = 18;
            this.usersLabel.Text = "Users:";
            this.usersLabel.Visible = false;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Forte", 8.25F);
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(302, 469);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(98, 12);
            this.ErrorLabel.TabIndex = 19;
            this.ErrorLabel.Text = "no available rooms";
            this.ErrorLabel.Visible = false;
            // 
            // roomsListbox
            // 
            this.roomsListbox.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomsListbox.FormattingEnabled = true;
            this.roomsListbox.ItemHeight = 17;
            this.roomsListbox.Location = new System.Drawing.Point(226, 107);
            this.roomsListbox.Name = "roomsListbox";
            this.roomsListbox.Size = new System.Drawing.Size(273, 157);
            this.roomsListbox.TabIndex = 20;
            this.roomsListbox.SelectedIndexChanged += new System.EventHandler(this.roomsListbox_SelectedIndexChanged);
            // 
            // usersListbox
            // 
            this.usersListbox.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Italic);
            this.usersListbox.FormattingEnabled = true;
            this.usersListbox.ItemHeight = 17;
            this.usersListbox.Location = new System.Drawing.Point(226, 309);
            this.usersListbox.Name = "usersListbox";
            this.usersListbox.Size = new System.Drawing.Size(273, 157);
            this.usersListbox.TabIndex = 21;
            // 
            // promptLabel
            // 
            this.promptLabel.AutoSize = true;
            this.promptLabel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promptLabel.ForeColor = System.Drawing.Color.Red;
            this.promptLabel.Location = new System.Drawing.Point(198, 40);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(291, 19);
            this.promptLabel.TabIndex = 22;
            this.promptLabel.Text = "--PROMPT--(notice that this is not visible)";
            this.promptLabel.Visible = false;
            // 
            // Join_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(116)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(725, 490);
            this.ControlBox = false;
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.usersListbox);
            this.Controls.Add(this.roomsListbox);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.usersLabel);
            this.Controls.Add(this.Rooms_list);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.refreshButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Join_form";
            this.Text = "Trivia Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button joinButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label Rooms_list;
        private System.Windows.Forms.Label usersLabel;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.ListBox roomsListbox;
        private System.Windows.Forms.ListBox usersListbox;
        private System.Windows.Forms.Label promptLabel;
    }
}

