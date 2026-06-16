using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorChangingLabel
{
    public partial class Form1 : Form
    {
        private int colorIndex = 0;

        private readonly Color[] colors =
        {
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Orange,
            Color.Purple,
            Color.Cyan,
            Color.Magenta,
            Color.Yellow,
            Color.Lime,
            Color.Pink
        };

        public Form1()
        {
            InitializeComponent();
            timer1.Tick += timer1_Tick;

            timer1.Interval = 1000; 
            timer1.Start();

            label1.ForeColor = colors[0];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            colorIndex = (colorIndex + 1) % colors.Length;
            label1.ForeColor = colors[colorIndex];
        }
    }
}