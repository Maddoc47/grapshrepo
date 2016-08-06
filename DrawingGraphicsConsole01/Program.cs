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

            Application.EnableVisualStyles();
            Application.Run(new MyForm("Welcome to the Graphics Console!"));
        }
    }
}
