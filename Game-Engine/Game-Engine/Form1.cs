using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Engine
{
    public partial class Form1 : Form
    {
       
      

        private int x = 10;
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
       
        private void screen_Paint(object sender, PaintEventArgs e)
        {
            this.DoubleBuffered = true;
            Graphics gObject = screen.CreateGraphics();

            Brush red = new SolidBrush(Color.Red);
            Pen redPen = new Pen(red, 8);

            gObject.DrawLine(redPen, x, 10, 400, 376);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 5;
            screen.Invalidate();
        } 
    }

}
