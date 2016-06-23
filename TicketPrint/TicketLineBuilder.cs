using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace TicketPrint
{
    class TicketLineBuilder
    {
        public TicketLineBuilder() { }

        private List<LineInfo> lines=new List<LineInfo>();
        public List<LineInfo> Lines { get { return lines; } }

        public void AppendLine(string linestext, Font font, StringAlignment textalign)
        {
            lines.Add(new LineInfo(text: linestext, textfont: font, textalign: textalign));            

        }

    }
}
