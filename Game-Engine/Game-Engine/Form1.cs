using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Game_Engine
{
    public partial class Form1 : Form
    {
        
        protected override CreateParams CreateParams
        {
            get 
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        
        private int x = 1;
        public Form1()
        {
            InitializeComponent();
            
        }
       
        private void screen_Paint(object sender, PaintEventArgs e)//paint method is run on window event or by the invalidate method located in the timer1_Tick method
        {
            
            this.DoubleBuffered = true;
            Graphics gObject = screen.CreateGraphics();

            Brush blau = new SolidBrush(Color.Blue);
            Pen blauPen = new Pen(blau, 8);

            gObject.DrawLine(blauPen, x, 10, 400, 376);
        }

        //

        private void timer1_Tick(object sender, EventArgs e) //every tick
        {
            x += 10;//This changes x by 10
            screen.Invalidate(); //This renders the screen avery frame (which is evcery 33 miliseconds, if you check the timer 1 object in the Design viewer for this class
        } 
    }

}
