using System;
using Eto.Forms;
using Eto.Drawing;

namespace Calc
{
    public partial class MainForm : Form
    {
        //This is Our Main Form
        //We have Controls and designing at the other classes
        //To Keep out main class cleaner
        public MainForm()
        {
            Title = "My Eto Form";
            ClientSize = new Size(400, 350);
            Content = Calc.ControlA.MainContent();
        }
    }
}