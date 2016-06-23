using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace TicketPrint
{
    public class LineInfo
    {
        readonly string text;
        public string Text { get { return text; } }
        readonly Font textfont;
        public Font Textfont { get { return textfont; } }
        //readonly TextAlign textalign;
        //public TextAlign Textalign { get { return textalign; } }
        readonly StringAlignment textalign;
        public StringAlignment Textalign { get { return textalign; } }

        public LineInfo() { }

        public LineInfo(string text, Font textfont, StringAlignment textalign)
        {
            this.text = text;
            this.textfont = textfont;
            this.textalign = textalign;
        }

        //public enum TextAlign { Left, Middle, right }
    }
}
