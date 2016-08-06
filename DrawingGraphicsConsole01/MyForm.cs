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
        Button btnCalc;
        Pen greyPen = new Pen(Color.Gray);
        Pen blackPen = new Pen(Color.Black);

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
            btnCalc.Location = new Point(700, 510);
            btnCalc.Size = new Size(70, 40);
            btnCalc.Text = "Draw Graph";
            btnCalc.Click += BtnCalc_Click;
            this.Controls.Add(btnCalc);

            //turn form into a graphics surface
            g = this.CreateGraphics();
        }

        //EVENTS
        private void MyForm_Shown(object sender, EventArgs e)
        {
            g.DrawLine(greyPen, new Point(150, 280), new Point(650, 280));
            g.DrawLine(greyPen, new Point(400, 20), new Point(400, 520));
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            //Pushing the button will draw a graph on 
            Point zeroPoint = new Point(400, 280);

            for (int x = -100; x < 100; x++)
            {
                int y = (int)Math.Pow(x, 2) - (4 * x) + 2;
                g.DrawLine(blackPen,new Point(zeroPoint.X +x, zeroPoint.Y ), new Point(zeroPoint.X +x, zeroPoint.Y - y));
            }
        }

    }
}
