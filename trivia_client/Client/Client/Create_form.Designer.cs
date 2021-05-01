namespace Client
{
    partial class Create_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Create_form));
            this.sendButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.Rooms_list = new System.Windows.Forms.Label();
            this.roomNameTextbox = new System.Windows.Forms.TextBox();
            this.Time_for_question = new System.Windows.Forms.Label();
            this.Number_of_questions = new System.Windows.Forms.Label();
            this.Number_of_players = new System.Windows.Forms.Label();
            this.timeTextbox = new System.Windows.Forms.TextBox();
            this.questionNumberTextBox = new System.Windows.Forms.TextBox();
            this.playerNumberTextbox = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.sendButton.Font = new System.Drawing.Font("Script MT Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.ForeColor = System.Drawing.SystemColors.Window;
            this.sendButton.Location = new System.Drawing.Point(532, 334);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(157, 60);
            this.sendButton.TabIndex = 8;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
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
            this.Rooms_list.Font = new System.Drawing.Font("Lucida Sans Typewriter", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rooms_list.Location = new System.Drawing.Point(69, 109);
            this.Rooms_list.Name = "Rooms_list";
            this.Rooms_list.Size = new System.Drawing.Size(109, 22);
            this.Rooms_list.TabIndex = 17;
            this.Rooms_list.Text = "Room name";
            // 
            // roomNameTextbox
            // 
            this.roomNameTextbox.Location = new System.Drawing.Point(292, 111);
            this.roomNameTextbox.Name = "roomNameTextbox";
            this.roomNameTextbox.Size = new System.Drawing.Size(245, 20);
            this.roomNameTextbox.TabIndex = 18;
            this.roomNameTextbox.Text = "room_name";
            // 
            // Time_for_question
            // 
            this.Time_for_question.AutoSize = true;
            this.Time_for_question.BackColor = System.Drawing.Color.White;
            this.Time_for_question.Font = new System.Drawing.Font("Lucida Sans Typewriter", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time_for_question.Location = new System.Drawing.Point(69, 219);
            this.Time_for_question.Name = "Time_for_question";
            this.Time_for_question.Size = new System.Drawing.Size(197, 22);
            this.Time_for_question.TabIndex = 19;
            this.Time_for_question.Text = "Time for question";
            // 
            // Number_of_questions
            // 
            this.Number_of_questions.AutoSize = true;
            this.Number_of_questions.BackColor = System.Drawing.Color.White;
            this.Number_of_questions.Font = new System.Drawing.Font("Lucida Sans Typewriter", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Number_of_questions.Location = new System.Drawing.Point(69, 183);
            this.Number_of_questions.Name = "Number_of_questions";
            this.Number_of_questions.Size = new System.Drawing.Size(219, 22);
            this.Number_of_questions.TabIndex = 20;
            this.Number_of_questions.Text = "Number of questions";
            // 
            // Number_of_players
            // 
            this.Number_of_players.AutoSize = true;
            this.Number_of_players.BackColor = System.Drawing.Color.White;
            this.Number_of_players.Font = new System.Drawing.Font("Lucida Sans Typewriter", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Number_of_players.Location = new System.Drawing.Point(69, 147);
            this.Number_of_players.Name = "Number_of_players";
            this.Number_of_players.Size = new System.Drawing.Size(197, 22);
            this.Number_of_players.TabIndex = 21;
            this.Number_of_players.Text = "Number of players";
            // 
            // timeTextbox
            // 
            this.timeTextbox.Location = new System.Drawing.Point(292, 223);
            this.timeTextbox.Name = "timeTextbox";
            this.timeTextbox.Size = new System.Drawing.Size(245, 20);
            this.timeTextbox.TabIndex = 22;
            this.timeTextbox.Text = "7";
            // 
            // questionNumberTextBox
            // 
            this.questionNumberTextBox.Location = new System.Drawing.Point(292, 187);
            this.questionNumberTextBox.Name = "questionNumberTextBox";
            this.questionNumberTextBox.Size = new System.Drawing.Size(245, 20);
            this.questionNumberTextBox.TabIndex = 23;
            this.questionNumberTextBox.Text = "5";
            this.questionNumberTextBox.TextChanged += new System.EventHandler(this.questionNumberTextBox_TextChanged);
            // 
            // playerNumberTextbox
            // 
            this.playerNumberTextbox.Location = new System.Drawing.Point(292, 151);
            this.playerNumberTextbox.Name = "playerNumberTextbox";
            this.playerNumberTextbox.Size = new System.Drawing.Size(245, 20);
            this.playerNumberTextbox.TabIndex = 24;
            this.playerNumberTextbox.Text = "3";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(220, 270);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(195, 17);
            this.errorLabel.TabIndex = 25;
            this.errorLabel.Text = "Error -- [for qution or other]";
            this.errorLabel.Visible = false;
            // 
            // Create_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(116)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(701, 406);
            this.ControlBox = false;
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.playerNumberTextbox);
            this.Controls.Add(this.questionNumberTextBox);
            this.Controls.Add(this.timeTextbox);
            this.Controls.Add(this.Number_of_players);
            this.Controls.Add(this.Number_of_questions);
            this.Controls.Add(this.Time_for_question);
            this.Controls.Add(this.roomNameTextbox);
            this.Controls.Add(this.Rooms_list);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.sendButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Create_form";
            this.Text = "Trivia Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label Rooms_list;
        private System.Windows.Forms.TextBox roomNameTextbox;
        private System.Windows.Forms.Label Time_for_question;
        private System.Windows.Forms.Label Number_of_questions;
        private System.Windows.Forms.Label Number_of_players;
        private System.Windows.Forms.TextBox timeTextbox;
        private System.Windows.Forms.TextBox questionNumberTextBox;
        private System.Windows.Forms.TextBox playerNumberTextbox;
        private System.Windows.Forms.Label errorLabel;
    }
}

