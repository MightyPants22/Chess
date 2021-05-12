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
    public partial class Form1 : Form
    {
        private Side side;

        public Form1(Side side,string s = "")
        {
            InitializeComponent();
            string scolor;
            this.side = side;
            if (side == Side.Black)
                scolor = "черного";
            else
                scolor = "белого";
            label4.Text = String.Format("имя {0} игрока:", scolor);
            textBox1.Text = s;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string GetName()
        {
            if (textBox1.Text != "")
                return textBox1.Text;
            else
                if (side == Side.White)
                    return "Белый игрок";
                else
                    return "Черный игрок";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
