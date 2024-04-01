using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //int time, int moneyMade, int kills, 
        public void loadValues(string[] sigils)
        {
            for(int i = 0; i < sigils.Length; i++)
            {
                if(i == 0)
                {
                    label6.Text = sigils[i];
                } else if (i <= 2)
                {
                    label6.Text = label6.Text + ", " + sigils[i];
                } else if (i == 3)
                {
                    label11.Text = sigils[i];
                } else
                {
                    label11.Text = label11.Text + ", " + sigils[i];
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
