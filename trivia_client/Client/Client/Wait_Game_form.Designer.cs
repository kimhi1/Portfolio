namespace Client
{
    partial class Wait_Game_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wait_Game_form));
            this.Start_Game = new System.Windows.Forms.Button();
            this.Leave__Room = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.Room_name_to_wait = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PlayerLabel = new System.Windows.Forms.Label();
            this.QuestionsLabel = new System.Windows.Forms.Label();
            this.timePerQuestionsLabel = new System.Windows.Forms.Label();
            this.maxNumberPlayerLabel = new System.Windows.Forms.Label();
            this.numberOfQuestionLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.listPlayer = new System.Windows.Forms.ListBox();
            this.closeRoomButton = new System.Windows.Forms.Button();
            this.promptLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Start_Game
            // 
            this.Start_Game.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Start_Game.Font = new System.Drawing.Font("Script MT Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_Game.ForeColor = System.Drawing.SystemColors.Window;
            this.Start_Game.Location = new System.Drawing.Point(12, 190);
            this.Start_Game.Name = "Start_Game";
            this.Start_Game.Size = new System.Drawing.Size(137, 61);
            this.Start_Game.TabIndex = 4;
            this.Start_Game.Text = "Start Game ";
            this.Start_Game.UseVisualStyleBackColor = false;
            this.Start_Game.Click += new System.EventHandler(this.Start_Game_Click);
            // 
            // Leave__Room
            // 
            this.Leave__Room.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Leave__Room.Font = new System.Drawing.Font("Script MT Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Leave__Room.ForeColor = System.Drawing.SystemColors.Window;
            this.Leave__Room.Location = new System.Drawing.Point(12, 269);
            this.Leave__Room.Name = "Leave__Room";
            this.Leave__Room.Size = new System.Drawing.Size(137, 61);
            this.Leave__Room.TabIndex = 8;
            this.Leave__Room.Text = "Leave Room";
            this.Leave__Room.UseVisualStyleBackColor = false;
            this.Leave__Room.Click += new System.EventHandler(this.Leave_Or_Close_Room_Click);
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
            // Room_name_to_wait
            // 
            this.Room_name_to_wait.AutoSize = true;
            this.Room_name_to_wait.BackColor = System.Drawing.Color.White;
            this.Room_name_to_wait.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Room_name_to_wait.Location = new System.Drawing.Point(166, 97);
            this.Room_name_to_wait.Name = "Room_name_to_wait";
            this.Room_name_to_wait.Size = new System.Drawing.Size(348, 23);
            this.Room_name_to_wait.TabIndex = 16;
            this.Room_name_to_wait.Text = "You are connected to room ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(179, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "current participants are:";
            // 
            // PlayerLabel
            // 
            this.PlayerLabel.AutoSize = true;
            this.PlayerLabel.Font = new System.Drawing.Font("Magneto", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerLabel.ForeColor = System.Drawing.Color.Purple;
            this.PlayerLabel.Location = new System.Drawing.Point(36, 367);
            this.PlayerLabel.Name = "PlayerLabel";
            this.PlayerLabel.Size = new System.Drawing.Size(180, 19);
            this.PlayerLabel.TabIndex = 18;
            this.PlayerLabel.Text = "Max Number Player:";
            // 
            // QuestionsLabel
            // 
            this.QuestionsLabel.AutoSize = true;
            this.QuestionsLabel.Font = new System.Drawing.Font("Magneto", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionsLabel.ForeColor = System.Drawing.Color.Purple;
            this.QuestionsLabel.Location = new System.Drawing.Point(250, 367);
            this.QuestionsLabel.Name = "QuestionsLabel";
            this.QuestionsLabel.Size = new System.Drawing.Size(194, 19);
            this.QuestionsLabel.TabIndex = 19;
            this.QuestionsLabel.Text = "Number Of Questions:";
            // 
            // timePerQuestionsLabel
            // 
            this.timePerQuestionsLabel.AutoSize = true;
            this.timePerQuestionsLabel.Font = new System.Drawing.Font("Magneto", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePerQuestionsLabel.ForeColor = System.Drawing.Color.Purple;
            this.timePerQuestionsLabel.Location = new System.Drawing.Point(483, 367);
            this.timePerQuestionsLabel.Name = "timePerQuestionsLabel";
            this.timePerQuestionsLabel.Size = new System.Drawing.Size(178, 19);
            this.timePerQuestionsLabel.TabIndex = 20;
            this.timePerQuestionsLabel.Text = "Time Per Questions:";
            // 
            // maxNumberPlayerLabel
            // 
            this.maxNumberPlayerLabel.AutoSize = true;
            this.maxNumberPlayerLabel.Font = new System.Drawing.Font("Mistral", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxNumberPlayerLabel.Location = new System.Drawing.Point(211, 372);
            this.maxNumberPlayerLabel.Name = "maxNumberPlayerLabel";
            this.maxNumberPlayerLabel.Size = new System.Drawing.Size(33, 13);
            this.maxNumberPlayerLabel.TabIndex = 21;
            this.maxNumberPlayerLabel.Text = "label2";
            // 
            // numberOfQuestionLabel
            // 
            this.numberOfQuestionLabel.AutoSize = true;
            this.numberOfQuestionLabel.Font = new System.Drawing.Font("Mistral", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfQuestionLabel.Location = new System.Drawing.Point(443, 371);
            this.numberOfQuestionLabel.Name = "numberOfQuestionLabel";
            this.numberOfQuestionLabel.Size = new System.Drawing.Size(33, 13);
            this.numberOfQuestionLabel.TabIndex = 22;
            this.numberOfQuestionLabel.Text = "label3";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Mistral", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(656, 371);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(33, 13);
            this.timeLabel.TabIndex = 23;
            this.timeLabel.Text = "label4";
            // 
            // listPlayer
            // 
            this.listPlayer.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Italic);
            this.listPlayer.FormattingEnabled = true;
            this.listPlayer.ItemHeight = 17;
            this.listPlayer.Location = new System.Drawing.Point(183, 190);
            this.listPlayer.Name = "listPlayer";
            this.listPlayer.Size = new System.Drawing.Size(331, 140);
            this.listPlayer.TabIndex = 24;
            // 
            // closeRoomButton
            // 
            this.closeRoomButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.closeRoomButton.Font = new System.Drawing.Font("Script MT Bold", 15.75F, System.Drawing.FontStyle.Bold);
            this.closeRoomButton.ForeColor = System.Drawing.SystemColors.Window;
            this.closeRoomButton.Location = new System.Drawing.Point(12, 269);
            this.closeRoomButton.Name = "closeRoomButton";
            this.closeRoomButton.Size = new System.Drawing.Size(137, 61);
            this.closeRoomButton.TabIndex = 25;
            this.closeRoomButton.Text = "Close Room";
            this.closeRoomButton.UseVisualStyleBackColor = false;
            this.closeRoomButton.Click += new System.EventHandler(this.closeRoomButton_Click);
            // 
            // promptLabel
            // 
            this.promptLabel.AutoSize = true;
            this.promptLabel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promptLabel.ForeColor = System.Drawing.Color.Red;
            this.promptLabel.Location = new System.Drawing.Point(197, 54);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(291, 19);
            this.promptLabel.TabIndex = 26;
            this.promptLabel.Text = "--PROMPT--(notice that this is not visible)";
            this.promptLabel.Visible = false;
            // 
            // Wait_Game_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(116)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(701, 406);
            this.ControlBox = false;
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.closeRoomButton);
            this.Controls.Add(this.listPlayer);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.numberOfQuestionLabel);
            this.Controls.Add(this.maxNumberPlayerLabel);
            this.Controls.Add(this.timePerQuestionsLabel);
            this.Controls.Add(this.QuestionsLabel);
            this.Controls.Add(this.PlayerLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Room_name_to_wait);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.Leave__Room);
            this.Controls.Add(this.Start_Game);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Wait_Game_form";
            this.Text = "Trivia Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start_Game;
        private System.Windows.Forms.Button Leave__Room;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label Room_name_to_wait;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PlayerLabel;
        private System.Windows.Forms.Label QuestionsLabel;
        private System.Windows.Forms.Label timePerQuestionsLabel;
        private System.Windows.Forms.Label maxNumberPlayerLabel;
        private System.Windows.Forms.Label numberOfQuestionLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.ListBox listPlayer;
        private System.Windows.Forms.Button closeRoomButton;
        private System.Windows.Forms.Label promptLabel;
    }
}

