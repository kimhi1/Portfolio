namespace Client
{
    partial class Status_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Status_form));
            this.backButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.My_Performances = new System.Windows.Forms.Label();
            this.Number_of_games = new System.Windows.Forms.Label();
            this.Number_of_right_answers = new System.Windows.Forms.Label();
            this.Number_of_worng_answers = new System.Windows.Forms.Label();
            this.average_time_for_answer = new System.Windows.Forms.Label();
            this.avgLabel = new System.Windows.Forms.Label();
            this.worngAnsLabel = new System.Windows.Forms.Label();
            this.rightAnsLabel = new System.Windows.Forms.Label();
            this.noGameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.usernameLabel.Location = new System.Drawing.Point(526, 9);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(28, 21);
            this.usernameLabel.TabIndex = 14;
            this.usernameLabel.Text = "...";
            // 
            // My_Performances
            // 
            this.My_Performances.AutoSize = true;
            this.My_Performances.BackColor = System.Drawing.Color.White;
            this.My_Performances.Font = new System.Drawing.Font("Lucida Sans Typewriter", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.My_Performances.Location = new System.Drawing.Point(109, 84);
            this.My_Performances.Name = "My_Performances";
            this.My_Performances.Size = new System.Drawing.Size(488, 55);
            this.My_Performances.TabIndex = 17;
            this.My_Performances.Text = "My Performances:";
            // 
            // Number_of_games
            // 
            this.Number_of_games.AutoSize = true;
            this.Number_of_games.BackColor = System.Drawing.Color.White;
            this.Number_of_games.Font = new System.Drawing.Font("Lucida Sans Typewriter", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Number_of_games.Location = new System.Drawing.Point(106, 176);
            this.Number_of_games.Name = "Number_of_games";
            this.Number_of_games.Size = new System.Drawing.Size(197, 22);
            this.Number_of_games.TabIndex = 18;
            this.Number_of_games.Text = "Number of games -";
            // 
            // Number_of_right_answers
            // 
            this.Number_of_right_answers.AutoSize = true;
            this.Number_of_right_answers.BackColor = System.Drawing.Color.White;
            this.Number_of_right_answers.Font = new System.Drawing.Font("Lucida Sans Typewriter", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Number_of_right_answers.Location = new System.Drawing.Point(106, 209);
            this.Number_of_right_answers.Name = "Number_of_right_answers";
            this.Number_of_right_answers.Size = new System.Drawing.Size(296, 22);
            this.Number_of_right_answers.TabIndex = 19;
            this.Number_of_right_answers.Text = "Number of right answers - ";
            // 
            // Number_of_worng_answers
            // 
            this.Number_of_worng_answers.AutoSize = true;
            this.Number_of_worng_answers.BackColor = System.Drawing.Color.White;
            this.Number_of_worng_answers.Font = new System.Drawing.Font("Lucida Sans Typewriter", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Number_of_worng_answers.Location = new System.Drawing.Point(106, 240);
            this.Number_of_worng_answers.Name = "Number_of_worng_answers";
            this.Number_of_worng_answers.Size = new System.Drawing.Size(296, 22);
            this.Number_of_worng_answers.TabIndex = 20;
            this.Number_of_worng_answers.Text = "Number of wrong answers - ";
            // 
            // average_time_for_answer
            // 
            this.average_time_for_answer.AutoSize = true;
            this.average_time_for_answer.BackColor = System.Drawing.Color.White;
            this.average_time_for_answer.Font = new System.Drawing.Font("Lucida Sans Typewriter", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.average_time_for_answer.Location = new System.Drawing.Point(106, 271);
            this.average_time_for_answer.Name = "average_time_for_answer";
            this.average_time_for_answer.Size = new System.Drawing.Size(296, 22);
            this.average_time_for_answer.TabIndex = 21;
            this.average_time_for_answer.Text = "average time for answer - ";
            // 
            // avgLabel
            // 
            this.avgLabel.AutoSize = true;
            this.avgLabel.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.avgLabel.Location = new System.Drawing.Point(408, 273);
            this.avgLabel.Name = "avgLabel";
            this.avgLabel.Size = new System.Drawing.Size(51, 20);
            this.avgLabel.TabIndex = 22;
            this.avgLabel.Text = "avg";
            // 
            // worngAnsLabel
            // 
            this.worngAnsLabel.AutoSize = true;
            this.worngAnsLabel.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.worngAnsLabel.Location = new System.Drawing.Point(408, 242);
            this.worngAnsLabel.Name = "worngAnsLabel";
            this.worngAnsLabel.Size = new System.Drawing.Size(121, 20);
            this.worngAnsLabel.TabIndex = 23;
            this.worngAnsLabel.Text = "worngAns";
            // 
            // rightAnsLabel
            // 
            this.rightAnsLabel.AutoSize = true;
            this.rightAnsLabel.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rightAnsLabel.Location = new System.Drawing.Point(408, 212);
            this.rightAnsLabel.Name = "rightAnsLabel";
            this.rightAnsLabel.Size = new System.Drawing.Size(121, 20);
            this.rightAnsLabel.TabIndex = 24;
            this.rightAnsLabel.Text = "rightAns";
            // 
            // noGameLabel
            // 
            this.noGameLabel.AutoSize = true;
            this.noGameLabel.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.noGameLabel.Location = new System.Drawing.Point(311, 179);
            this.noGameLabel.Name = "noGameLabel";
            this.noGameLabel.Size = new System.Drawing.Size(93, 20);
            this.noGameLabel.TabIndex = 25;
            this.noGameLabel.Text = "NoGame";
            // 
            // Status_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(116)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(701, 406);
            this.ControlBox = false;
            this.Controls.Add(this.noGameLabel);
            this.Controls.Add(this.rightAnsLabel);
            this.Controls.Add(this.worngAnsLabel);
            this.Controls.Add(this.avgLabel);
            this.Controls.Add(this.average_time_for_answer);
            this.Controls.Add(this.Number_of_worng_answers);
            this.Controls.Add(this.Number_of_right_answers);
            this.Controls.Add(this.Number_of_games);
            this.Controls.Add(this.My_Performances);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.backButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Status_form";
            this.Text = "Trivia Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label My_Performances;
        private System.Windows.Forms.Label Number_of_games;
        private System.Windows.Forms.Label Number_of_right_answers;
        private System.Windows.Forms.Label average_time_for_answer;
        private System.Windows.Forms.Label Number_of_worng_answers;
        private System.Windows.Forms.Label avgLabel;
        private System.Windows.Forms.Label worngAnsLabel;
        private System.Windows.Forms.Label rightAnsLabel;
        private System.Windows.Forms.Label noGameLabel;
    }
}

