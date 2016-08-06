using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace DrawingGraphicsConsole01
{
    sealed class MyForm : Form
    {
        //DECLARE WIDGETS AND COMPONENTS;
        Graphics g;
        Button btnCalc,btnClear;
        Pen greyPen = new Pen(Color.Gray);
        Pen redPen = new Pen(Color.Red);

        //CONSTRUCTOR
        private MyForm()
        {
        }
        public MyForm(string title = "")
        {
            InitForm(title);
        }

        //INIT METHODS
        private void InitForm(string title)
        {
            //set form layout
            this.Text = title;
            this.Width = 800;
            this.Height = 600;
            this.BackColor = Color.White;
            this.Shown += MyForm_Shown;

            //create widgets
            btnCalc = new Button();
            btnCalc.Location = new Point(700, 410);
            btnCalc.Size = new Size(70, 40);
            btnCalc.Text = "Draw Graph";
            btnCalc.Click += BtnCalc_Click;
            this.Controls.Add(btnCalc);

            btnClear = new Button();
            btnClear.Text = "Erase Graph";
            btnClear.Location = new Point(700, 470);
            btnClear.Size = new Size(70, 40);
            btnClear.Click += BtnClear_Click;
            this.Controls.Add(btnClear);

            //turn form into a graphics surface
            g = this.CreateGraphics();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            //Clear the Graph 
            g.Clear(Color.White);
            DrawCross();
        }

        //EVENTS
        private void MyForm_Shown(object sender, EventArgs e)
        {
            DrawCross();
        }
        private void BtnCalc_Click(object sender, EventArgs e)
        {
            //Pushing the button will draw a graph on 
            Point zeroPoint = new Point(400, 280);

            for (int x = -100; x < 100; x++)
            {
                int y = (int)(2 * Math.Pow(x, 2)) + (5 * x) + 20;
                g.DrawLine(redPen,new Point(zeroPoint.X +x, zeroPoint.Y - y + 3), new Point(zeroPoint.X +x, zeroPoint.Y - y));                
            }
        }

        //HELPER METHODS
        private void DrawCross()
        {
            g.DrawLine(greyPen, new Point(150, 280), new Point(650, 280));
            g.DrawLine(greyPen, new Point(400, 20), new Point(400, 520));
        }

    }
}
