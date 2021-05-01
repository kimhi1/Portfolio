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
    public partial class Status_form : Form
    {
        public Status_form()
        {
            InitializeComponent();
        }

        public void setUsernameLabel(string name)
        {
            usernameLabel.Text = name;
        }

        public void setDisplay(string noGames, string rightAns, string wrongAns, string avg)
        {
            noGameLabel.Text = noGames;
            rightAnsLabel.Text = rightAns;
            worngAnsLabel.Text = wrongAns;
            avgLabel.Text = avg;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}

