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

        private int px = 0;
        private int py = 0;
        private int speed = 1;
        private float pvx = 0;
        private float pvy = 0;

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

        private void screen_Paint(object sender, PaintEventArgs e)
        {
            //paint method is run on window event or by the invalidate method located in the timer1_Tick method
            this.DoubleBuffered = true;
            Graphics gObject = screen.CreateGraphics();
            Render(gObject);
        }



        private void timer1_Tick(object sender, EventArgs e) //every tick
        {
            
            screen.Invalidate();
            //This renders the screen every frame (which is every 33 milliseconds, if you check the timer 1 object in the Design viewer for this class
        }

        private void timer2_Tick(object sender, EventArgs e) //every tick
        {

            
        }

        
        //TICK METHOD
        private void Tick()
        {
            pvx *= 0.9F;
            pvy *= 0.9F;

            px += (int)pvx;
            py += (int)pvy;
        }

        private void Render(Graphics g)
        {
            FillRec(Color.Green, g, px, py, px + 50, py + 50);
        }

        //Rendering Code
        private void DrawLine(int size, Color c, Graphics g, int x1, int y1, int x2, int y2)
        {
            Brush Bc = new SolidBrush(c);
            Pen Pc = new Pen(c, size);
            g.DrawLine(Pc, x1, y1, x2, y2);
        }

        private void DrawRec(int size, Color c, Graphics g, int x1, int y1, int x2, int y2)
        {
            DrawLine(size, c, g, x1, y1, x2, y1);
            DrawLine(size, c, g, x2, y1, x2, y2);
            DrawLine(size, c, g, x1, y1, x1, y2);
            DrawLine(size, c, g, x1, y2, x2, y2);
        }



        private void FillRec(Color c, Graphics g, int x1, int y1, int x2, int y2)
        {
            for (int i = 0; i < x2 - x1; i++)
            {
                DrawRec(1, c, g, x1 + i, y1, x2 - i, y2);
            }
        }

        //INPUTS
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Up")
            {
                pvy -= speed;
            }
            if (e.KeyCode.ToString() == "Down")
            {
                pvy += speed;
            }
            if (e.KeyCode.ToString() == "Right")
            {
                pvx += speed;
            }
            if (e.KeyCode.ToString() == "Left")
            {
                pvx -= speed;
            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            Console.WriteLine("UPS");
            Tick();
            
            
        }
    }
}