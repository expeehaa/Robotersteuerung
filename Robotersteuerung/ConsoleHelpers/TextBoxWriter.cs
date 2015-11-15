using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Robotersteuerung.ConsoleHelpers
{
    class TextBoxWriter : TextWriter
    {
        TextBox tb;

        public TextBoxWriter(TextBox tb)
        {
            this.tb = tb;
        }

        public override void Write(string value)
        {
            DateTime t = DateTime.Now;
            string timenow = "[" + t.ToLongTimeString() + "]";
            tb.AppendText(timenow + value);
            base.Write(value);
        }

        public override Task WriteAsync(string value)
        {
            DateTime t = DateTime.Now;
            string timenow = "[" + t.ToLongTimeString() + "]";
            tb.AppendText(timenow + value + "\n");
            return base.WriteAsync(value);
        }

        public override void WriteLine(string value)
        {
            DateTime t = DateTime.Now;
            string timenow = "[" + t.ToLongTimeString() + "]";
            tb.AppendText(timenow + value + "\n");
            base.WriteLine(value + "\n");
        }

        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }
    }
}
