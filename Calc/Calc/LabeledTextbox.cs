using Eto.Drawing;
using Eto.Forms;

namespace Calc
{
    public class LabeledTextbox
    {
        private Label _label;
        private TextBox _textBox;

        public LabeledTextbox(string caption, string id)
        {
            _label = new Label {Text = caption, Font = Fonts.Sans(40f, FontStyle.None, FontDecoration.None)};
            _textBox = new TextBox {ID = id};
        }
        public LabeledTextbox(string caption, Font font, string id)
        {
            _label = new Label {Text = caption, Font = font};
            _textBox = new TextBox {ID = id, Font = font};
        }
        public string GetText()
        {
            return _textBox.Text;
        }

        public void SetText(string text)
        {
            _textBox.Text = text;
        }

        public StackLayout getControl()
        {
            var tmpstack = new StackLayout();
            tmpstack.Orientation = Orientation.Horizontal;
            tmpstack.Items.Add(_label);
            tmpstack.Items.Add(_textBox);
            return tmpstack;
        }
    }
}