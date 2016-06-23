using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace TicketPrint
{
    public class Ticket
    {
        //public Ticket() { }

        private PrintDocument pd = new PrintDocument();
        private PrintPreviewDialog ppd = new PrintPreviewDialog();
        private TicketLineBuilder tlb = new TicketLineBuilder();

        readonly Margins margin;
        public Margins Margin { get { return margin; } }
        readonly PaperSize papersize;
        public PaperSize Papersize { get { return papersize; } }


        public Ticket(Margins margin,PaperSize papersize) 
        {
            this.margin = margin;
            this.papersize = papersize;
            PrintSetting();

        }

        public void AddLines(string linetext, Font linefont, StringAlignment textalign)
        {
            tlb.AppendLine(linetext, linefont, textalign);
        }

        public void Print()
        {
            if(tlb.Lines.Count>0)
            {
                pd.Print();

            }
            else
            {
                throw new ArgumentNullException("Lines", "No lines exits!Please add lines before printing.");
            }

        }

        public void PrintTest()
        {
            //ppd.Document = pd;
            if (tlb.Lines.Count > 0)
            {
                ppd.ShowDialog();
            }
            else
            {
                throw new ArgumentNullException("Lines", "No lines exits!Please add lines before printing.");
            }

        }

        private void PrintSetting()
        {
            if (margin == null) { throw new ArgumentNullException(); }

            //this.margin = margin;
            //this.papersize = papersize;

            pd.DefaultPageSettings.Margins = this.margin;
            pd.DefaultPageSettings.PaperSize = this.papersize;
            pd.PrintPage += new PrintPageEventHandler(MyPrintDocument_PrintPage);
            ppd.Document = pd;
            //ppd.ShowDialog();
        }
        
        private void MyPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var sf = new StringFormat();
            float TotalLineHeight = margin.Top;
            foreach (LineInfo li in tlb.Lines)
            {
                //LineInfo.TextAlign = li.Textalign;
                sf.LineAlignment=li.Textalign;
                //e.Graphics.DrawString()
                e.Graphics.DrawString(li.Text, li.Textfont, Brushes.Black, TextX(e.PageBounds.Width, li), TotalLineHeight);
                TotalLineHeight += li.Textfont.Height;
            }
        }

        //private int getInch(double mm)
        //{
        //    return (int)(mm / 25.4);

        //}
        delegate float AlignCalDelegate(int pw, float lw);
        private float TextX(int pagewidth,LineInfo lineinfo)
        {
            AlignCalDelegate aligncaldelegate;
            switch (lineinfo.Textalign)
            {
                case StringAlignment.Near: 
                    aligncaldelegate = new AlignCalDelegate(AlignLeftX);
                    break;
                case StringAlignment.Center:
                    aligncaldelegate = new AlignCalDelegate(AlignCenterX);
                    break;
                case StringAlignment.Far:
                    aligncaldelegate = new AlignCalDelegate(AlignRithtX);
                    break;
                default: 
                    aligncaldelegate = new AlignCalDelegate(AlignLeftX);
                    break;
            }
            Control control=new Control();
            Graphics g=control.CreateGraphics();
            return aligncaldelegate(pagewidth, g.MeasureString(lineinfo.Text, lineinfo.Textfont).Width);

            //return 0;
        }

        private float AlignLeftX(int pagewidth, float linewidth)
        {
            //int w = papersize.Width;

            return (float)margin.Left;
        }
        private float AlignCenterX(int pagewidth, float linewidth)
        {
            return (pagewidth - linewidth - margin.Left - margin.Right) / 2;
        }
        private float AlignRithtX(int pagewidth, float linewidth)
        {
            return (float)(pagewidth - linewidth - margin.Right-margin.Left);
        }
                
    }
}
