using System;
using System.Runtime.CompilerServices;
using Eto.Drawing;
using Eto.Forms;

namespace Calc
{
    // Our Main Form's Designs Are in this class
    public class ControlA
    {
        //We Another Class for our custom controls
        //Which they have a label and a textbox
        //this is to keep codes shorter and easier to understand
        private static LabeledTextbox numA;
        private static LabeledTextbox numB;
        public static StackLayout MainContent()
        {
            //We are using StackLayout as our container of choice because it makes content to go up to down like a list
            //Which it's better for our form type
            //We have four button for Operations and we use single event handler for all of them
            //to avoid repeating our code
            var btnSum = new Button {Text = "+"};
            var btnSub = new Button {Text = "-"};
            var btnMul = new Button {Text = "*"};
            var btnDiv = new Button {Text = "/"};
            numA = new LabeledTextbox("Number 1: "
                , Fonts.Serif(20f, FontStyle.None, FontDecoration.None)
                , "A");
            numB = new LabeledTextbox("Number 2: "
                , Fonts.Serif(20f, FontStyle.None, FontDecoration.None)
                , "B");
            //Button EventHandlers
            btnSum.Click += Calculate;
            btnSub.Click += Calculate;
            btnMul.Click += Calculate;
            btnDiv.Click += Calculate;
            return new StackLayout {Items = 
                { numA.getControl(), 
                    numB.getControl(), 
                    new StackLayout // We have Another StackLayout for Our Operation buttons
                    {
                        Orientation = Orientation.Horizontal, 
                        Items = { btnSum,new StackLayoutItem(),  btnSub, btnMul, btnDiv}
                    }
                }
            };
        }

        private static void Calculate(object sender, EventArgs e)
        {
            //This is our EventHandler
            double numOne = 0; 
            double numTwo = 0;
            //Instead of using try and catch block to catch our Exceptions We use double.TryParse to make our code smaller
            //and Producing Different Messages
            if (!double.TryParse(numA.GetText(), out numOne ))
            {
                MessageBox.Show("Please enter number in place of Number1");
                return;
            }
            if (!double.TryParse(numB.GetText(), out numTwo ))
            {
                MessageBox.Show("Please enter number in place of Number2");
                return;
            }
            //We Op string to get the EventSenders (One of the Operation Buttons Which have been pressed) Text
            var Op = ((Button) sender).Text;
            var result = Op == "+" ? numOne + numTwo :
                Op == "-" ? numOne - numTwo :
                Op == "*" ? numOne * numTwo :
                Op == "/" ? numOne / numTwo : 0;
            //We produce messages in this line with dollar sign Prefix like $"{statement} Text" instead of using
            //String.Format or "{0} Text".format
            var msg = $"{numOne} {Op} {numTwo} = {result}";
            MessageBox.Show(msg);
        }
    }
}