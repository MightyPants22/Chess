using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mychess
{
    public partial class StatisticForm : Form
    {
        public StatisticForm(Player pl1, Player pl2)
        {
            InitializeComponent();

            lName1.Text = pl1.Name;
            lName2.Text = pl2.Name;
            lPlayed1.Text = (pl1.GetWin() + pl1.GetLose()).ToString();
            lPlayed2.Text = (pl2.GetWin() + pl2.GetLose()).ToString();
            lLose1.Text = pl1.GetLose().ToString();
            lLose2.Text = pl2.GetLose().ToString();
            lWin1.Text = pl1.GetWin().ToString();
            lWin2.Text = pl2.GetWin().ToString();
        }

        private void okbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
