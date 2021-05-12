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
    public partial class ServerAddressDialog : Form
    {
        public ServerAddressDialog()
        {
            InitializeComponent();
            textBox1.Text = "127";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "1";
        }

        public string GetAddress()
        {
            return String.Format("{0}.{1}.{2}.{3}", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
