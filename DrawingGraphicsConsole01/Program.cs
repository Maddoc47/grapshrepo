using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace DrawingGraphicsConsole01
{
    class Program
    {
        static void Main(string[] args)
        {
            Form frmSurface = new Form();
            frmSurface.Text = "Can we draw on this?";
            Application.Run(frmSurface);            
        }
    }
}
