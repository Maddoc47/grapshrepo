using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace DrawingGraphicsConsole01
{
    class MyForm : Form
    {
        //DECLARE WIDGETS;
        Graphics g;
        Button btnCalc;
        int x1 = 10;
        int y1 = 10;
        int x2 = 400;
        int y2 = 400;

        private MyForm()
        {            
        }
        public MyForm(string title = "")
        {

            InitForm(title);            
            InitGraphics();
        }

        private void InitForm(string title)
        {
            this.Text = title;
            this.Width = 800;
            this.Height = 600;
            this.BackColor = Color.White;

            //CREATE WIDGETS
            btnCalc = new Button();
            btnCalc.Location = new Point(700, 510);
            btnCalc.Size = new Size(70, 40);
            btnCalc.Text = "Hohoho";

            this.Controls.Add(btnCalc);
            btnCalc.Click += BtnCalc_Click;

        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            //Pushing the button will draw on the graphics
            g.DrawLine(new Pen(Color.Black), new Point(x1,y1), new Point(x2, y2));
            x1 += 5;
            x2 -= 5;
        }

        private void InitGraphics()
        {
            //TURN FORM INTO GRAPHICS
            g = this.CreateGraphics();
            
        }


    }
}
