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

        Label lblA, lblB, lblC, lblD, lblE, lblInfo, lblY, lblX;
        TextBox txtA, txtB, txtC, txtD, txtE;
        GroupBox grbxInput;
        Panel holder;

        //variables for the calculation
        double a, b, c, d, e;

        //CONSTRUCTOR
        public MyForm(string title = "")
        {
            InitForm(title);
        }

        //INIT METHOD to set up form
        private void InitForm(string title)
        {
            //set form layout
            this.Text = title;
            this.Width = 800;
            this.Height = 600;
            this.BackColor = Color.White;
            this.Shown += MyForm_Shown;         //Shown event is run because we want to draw the cross when the form launches

            //BUTTONS
            btnCalc = new Button();
            btnCalc.Location = new Point(700, 410);
            btnCalc.Size = new Size(70, 40);
            btnCalc.Text = "Draw Graph";
            btnCalc.Click += BtnCalc_Click;
            btnCalc.BackColor = Color.AliceBlue;
            this.Controls.Add(btnCalc);

            btnClear = new Button();
            btnClear.Text = "Erase Graph";
            btnClear.Location = new Point(700, 470);
            btnClear.Size = new Size(70, 40);
            btnClear.BackColor = Color.AliceBlue;
            btnClear.Click += BtnClear_Click;
            this.Controls.Add(btnClear);

            //PANEL
            holder = new Panel();
            holder.Location = new Point(20, 300);
            holder.Size = new Size(200, 210);
            holder.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(holder);

            //GROUPBOX
            grbxInput = new GroupBox();
            grbxInput.Size = new Size(200, 210);
            grbxInput.Location = new Point(0, 0);
            grbxInput.Text = "Input Panel";
            grbxInput.BackColor = Color.AliceBlue;
            holder.Controls.Add(grbxInput);
              
            
            //LABELS
            lblA = new Label();
            lblA.Location = new Point(10, 20);
            lblA.Size = new Size(70, 20);
            lblA.Text = "ax^4";
            grbxInput.Controls.Add(lblA);            

            lblB = new Label();
            lblB.Location = new Point(10, 60);
            lblB.Size = new Size(70, 20);
            lblB.Text = "bx^3";
            grbxInput.Controls.Add(lblB);           

            lblC = new Label();
            lblC.Location = new Point(10, 100);
            lblC.Size = new Size(70, 20);
            lblC.Text = "cx^2";           
            grbxInput.Controls.Add(lblC);

            lblD = new Label();
            lblD.Location = new Point(10, 140);
            lblD.Size = new Size(70, 20);
            lblD.Text = "dx";
            grbxInput.Controls.Add(lblD);

            lblE = new Label();
            lblE.Location = new Point(10, 180);
            lblE.Size = new Size(70, 20);
            lblE.Text = "e";
            grbxInput.Controls.Add(lblE);

            lblInfo = new Label();
            lblInfo.Location = new Point(20, 20);
            lblInfo.Size = new Size(150, 200);
            lblInfo.Text = "This Application will draw a graph.\nFor a linear graph use 0 for variables A and B and C.";
            lblInfo.Text = lblInfo.Text + "\nFor a hyperbole fill in 0 for variables A and B.";
            lblInfo.Text = lblInfo.Text + "\nFor a power 3 graph fill in 0 for variable A only.";
            lblInfo.Text = lblInfo.Text + "\nUse all variables for a power 4 graph.";
            lblInfo.BorderStyle = BorderStyle.FixedSingle;
            lblInfo.BackColor = Color.AliceBlue;
            this.Controls.Add(lblInfo);

            lblX = new Label();
            lblX.Location = new Point(647, 285);
            lblX.Size = new Size(20, 20);
            lblX.Text = "X";
            lblX.ForeColor = Color.Green;
            this.Controls.Add(lblX);

            lblY = new Label();
            lblY.Location = new Point(382, 20);
            lblY.Size = new Size(10,10);
            lblY.Text = "Y";
            lblY.ForeColor = Color.Green;
            this.Controls.Add(lblY);            

            //TEXTBOXES
            txtA = new TextBox();
            txtA.Location = new Point(90, 20);
            txtA.Focus();
            txtA.Text = "0";
            grbxInput.Controls.Add(txtA);

            txtB = new TextBox();
            txtB.Location = new Point(90, 60);
            txtB.Text = "0";
            grbxInput.Controls.Add(txtB);

            txtC = new TextBox();
            txtC.Location = new Point(90, 100);
            txtC.Text = "0";
            grbxInput.Controls.Add(txtC);

            txtD = new TextBox();
            txtD.Location = new Point(90, 140);
            txtD.Text = "0";
            grbxInput.Controls.Add(txtD);

            txtE = new TextBox();
            txtE.Location = new Point(90, 180);
            txtE.Text = "0";
            grbxInput.Controls.Add(txtE);
                        
            //CREATE GRAPHICS SURFACE
            g = this.CreateGraphics();
        }

        //EVENTS
        private void MyForm_Shown(object sender, EventArgs e)
        {
            DrawCross();
        }
        private void BtnCalc_Click(object sender, EventArgs e)
        {
            //Pushing the button will draw a graph 
                DrawGraph();

         }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            //Clear the Graph 
            g.Clear(Color.White);
            DrawCross();
        }

        //HELPER METHODS
        private void DrawCross()
        {
            //the cross lines
            g.DrawLine(greyPen, new Point(150, 280), new Point(650, 280));
            g.DrawLine(greyPen, new Point(400, 20), new Point(400, 520));
            //the arrow lines
            g.DrawLine(greyPen, new Point(400, 20), new Point(405, 25));
            g.DrawLine(greyPen, new Point(400, 20), new Point(395, 25));
            g.DrawLine(greyPen, new Point(650, 280), new Point(645, 275));
            g.DrawLine(greyPen, new Point(650, 280), new Point(645, 285));
        }

        void DrawGraph()
        {
            //initialize variables
            a = b = c = d = e = 0;
            //fill the variables with data from the textfields
            try
            {
                a = Double.Parse(txtA.Text);
                b = Double.Parse(txtB.Text);
                c = Double.Parse(txtC.Text);
                d = Double.Parse(txtD.Text);
                e = Double.Parse(txtE.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured! Please try again!\n " + ex.Message);
            }

            //Define Cartesian origin
            PointF zeroPoint = new PointF(400f, 280f);

            //Draw the graph for the range [200,200]
            for (float x = -200; x < 201; x++)
            {
                float y = (float)(((a * Math.Pow(x, 4)) + (b * Math.Pow(x, 3)) + (c * Math.Pow(x,2)) + (d * x) + e));
                g.DrawLine(redPen, new PointF(zeroPoint.X + x, zeroPoint.Y - y - 1), new PointF(zeroPoint.X + x, zeroPoint.Y - y + 1));
            }
        }
    }
}
