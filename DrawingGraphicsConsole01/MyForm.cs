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

        Label lblA, lblB, lblC, lblD;
        TextBox txtA, txtB, txtC, txtD;
        GroupBox pnl;


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

            //create labels en textfields for user input
            pnl = new GroupBox();
            pnl.Size = new Size(200, 180);
            pnl.Location = new Point(20, 350);
            pnl.Text = "Input Panel";

            lblA = new Label();
            lblA.Location = new Point(10, 20);
            lblA.Size = new Size(70, 20);
            lblA.Text = "Variable a:";
            pnl.Controls.Add(lblA);

            txtA = new TextBox();
            txtA.Location = new Point(90, 20);
            txtA.Focus();
            pnl.Controls.Add(txtA);

            lblB = new Label();
            lblB.Location = new Point(10, 60);
            lblB.Size = new Size(70, 20);
            lblB.Text = "Variable b:";
            pnl.Controls.Add(lblB);

            txtB = new TextBox();
            txtB.Location = new Point(90, 60);
            txtB.Focus();
            pnl.Controls.Add(txtB);

            lblC = new Label();
            lblC.Location = new Point(10, 100);
            lblC.Size = new Size(70, 20);
            lblC.Text = "Variable c:";
            pnl.Controls.Add(lblC);

            txtC = new TextBox();
            txtC.Location = new Point(90, 100);
            txtC.Focus();
            pnl.Controls.Add(txtC);
            
            lblD = new Label();
            lblD.Location = new Point(10, 140);
            lblD.Size = new Size(70, 20);
            lblD.Text = "Variable d:";
            pnl.Controls.Add(lblD);

            txtD = new TextBox();
            txtD.Location = new Point(90, 140);
            txtD.Focus();
            pnl.Controls.Add(txtD);

            
            this.Controls.Add(pnl);

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
            //Pushing the button will draw a graph 

            //get numeric values from textbox
            double a, b, c, d;
            a = b = c = d = 0;

            try
            {
                a = Double.Parse(txtA.Text);
                b = Double.Parse(txtB.Text);
                c = Double.Parse(txtC.Text);
                d = Double.Parse(txtD.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured! Please try again!\n " + ex.Message);
            }


            PointF zeroPoint = new PointF(400f, 280f);
           
        

            for (float x = -200; x < 100; x++)
            {
                float y = (float)(((a * Math.Pow(x, 3)) + (b * Math.Pow(x, 2)) + (c * x) + d)/50);
                g.DrawLine(redPen,new PointF(zeroPoint.X + x, zeroPoint.Y - y + 3), new PointF(zeroPoint.X +x, zeroPoint.Y - y));                
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
