namespace Client
{
    partial class Game_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game_form));
            this.ans1Button = new System.Windows.Forms.Button();
            this.ans3Button = new System.Windows.Forms.Button();
            this.ans4Button = new System.Windows.Forms.Button();
            this.ans2Button = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.roomNameLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.questionNoLabel = new System.Windows.Forms.Label();
            this.questionLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.correctLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ans1Button
            // 
            this.ans1Button.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ans1Button.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold);
            this.ans1Button.ForeColor = System.Drawing.SystemColors.Window;
            this.ans1Button.Location = new System.Drawing.Point(33, 164);
            this.ans1Button.Name = "ans1Button";
            this.ans1Button.Size = new System.Drawing.Size(644, 36);
            this.ans1Button.TabIndex = 6;
            this.ans1Button.Text = "---";
            this.ans1Button.UseVisualStyleBackColor = false;
            this.ans1Button.Click += new System.EventHandler(this.ans1Button_Click);
            // 
            // ans3Button
            // 
            this.ans3Button.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ans3Button.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold);
            this.ans3Button.ForeColor = System.Drawing.SystemColors.Window;
            this.ans3Button.Location = new System.Drawing.Point(33, 248);
            this.ans3Button.Name = "ans3Button";
            this.ans3Button.Size = new System.Drawing.Size(644, 36);
            this.ans3Button.TabIndex = 10;
            this.ans3Button.Text = "---";
            this.ans3Button.UseVisualStyleBackColor = false;
            this.ans3Button.Click += new System.EventHandler(this.ans3Button_Click);
            // 
            // ans4Button
            // 
            this.ans4Button.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ans4Button.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold);
            this.ans4Button.ForeColor = System.Drawing.SystemColors.Window;
            this.ans4Button.Location = new System.Drawing.Point(33, 290);
            this.ans4Button.Name = "ans4Button";
            this.ans4Button.Size = new System.Drawing.Size(644, 36);
            this.ans4Button.TabIndex = 11;
            this.ans4Button.Text = "---";
            this.ans4Button.UseVisualStyleBackColor = false;
            this.ans4Button.Click += new System.EventHandler(this.ans4Button_Click);
            // 
            // ans2Button
            // 
            this.ans2Button.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ans2Button.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold);
            this.ans2Button.ForeColor = System.Drawing.SystemColors.Window;
            this.ans2Button.Location = new System.Drawing.Point(33, 206);
            this.ans2Button.Name = "ans2Button";
            this.ans2Button.Size = new System.Drawing.Size(644, 36);
            this.ans2Button.TabIndex = 12;
            this.ans2Button.Text = "---";
            this.ans2Button.UseVisualStyleBackColor = false;
            this.ans2Button.Click += new System.EventHandler(this.ans2Button_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(546, 12);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(143, 21);
            this.usernameLabel.TabIndex = 15;
            this.usernameLabel.Text = "Name Of User";
            // 
            // roomNameLabel
            // 
            this.roomNameLabel.AutoSize = true;
            this.roomNameLabel.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomNameLabel.Location = new System.Drawing.Point(263, 42);
            this.roomNameLabel.Name = "roomNameLabel";
            this.roomNameLabel.Size = new System.Drawing.Size(128, 21);
            this.roomNameLabel.TabIndex = 16;
            this.roomNameLabel.Text = "Room name";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.exitButton.Font = new System.Drawing.Font("Script MT Bold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.Red;
            this.exitButton.Location = new System.Drawing.Point(12, 12);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(72, 38);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.Exit_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(336, 346);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(37, 21);
            this.timeLabel.TabIndex = 17;
            this.timeLabel.Text = "---";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(559, 78);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(84, 21);
            this.scoreLabel.TabIndex = 18;
            this.scoreLabel.Text = "score: 0";
            // 
            // questionNoLabel
            // 
            this.questionNoLabel.AutoSize = true;
            this.questionNoLabel.Font = new System.Drawing.Font("Lucida Handwriting", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionNoLabel.Location = new System.Drawing.Point(39, 82);
            this.questionNoLabel.Name = "questionNoLabel";
            this.questionNoLabel.Size = new System.Drawing.Size(113, 17);
            this.questionNoLabel.TabIndex = 19;
            this.questionNoLabel.Text = "Question no:";
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Font = new System.Drawing.Font("Lucida Handwriting", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLabel.Location = new System.Drawing.Point(36, 115);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(328, 36);
            this.questionLabel.TabIndex = 20;
            this.questionLabel.Text = "----The question ---";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Handwriting", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Last answer was: ";
            // 
            // correctLabel
            // 
            this.correctLabel.AutoSize = true;
            this.correctLabel.Font = new System.Drawing.Font("Lucida Handwriting", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correctLabel.Location = new System.Drawing.Point(370, 82);
            this.correctLabel.Name = "correctLabel";
            this.correctLabel.Size = new System.Drawing.Size(68, 17);
            this.correctLabel.TabIndex = 22;
            this.correctLabel.Text = "Correct";
            // 
            // Game_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(116)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(701, 406);
            this.ControlBox = false;
            this.Controls.Add(this.correctLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.questionNoLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.roomNameLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.ans2Button);
            this.Controls.Add(this.ans4Button);
            this.Controls.Add(this.ans3Button);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.ans1Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Game_form";
            this.Text = "Trivia Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ans1Button;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button ans3Button;
        private System.Windows.Forms.Button ans4Button;
        private System.Windows.Forms.Button ans2Button;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label roomNameLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label questionNoLabel;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label correctLabel;
    }
}

