using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Scores_form : Form
    {

        public Scores_form()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        public void setUsernameLabel(string name)
        {
            usernameLabel.Text = name;
        }

        public void setNames(string[] names)
        {
            userFirst.Text = names[0];
            userSecond.Text = names[1];
            userThird.Text = names[2];
        }

        public void setScores(string[] scores)
        {
            scoreLabel0.Text = scores[0];
            scoreLabel1.Text = scores[1];
            scoreLabel2.Text = scores[2];
        }
    }
}
