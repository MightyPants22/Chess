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
    public partial class ChooseFigureForm : Form
    {
        private FigureTypes figuretype;
        public ChooseFigureForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            figuretype = FigureTypes.Queen;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    figuretype = FigureTypes.Queen;
                    break;
                case 1:
                    figuretype = FigureTypes.Rook;
                    break;
                case 2:
                    figuretype = FigureTypes.Bishop;
                    break;
                case 3 :
                    figuretype = FigureTypes.Knight;
                    break;
            }
                        
          
        }


        public FigureTypes GetFigureType()
        {
            return figuretype;
        }
    }
}
