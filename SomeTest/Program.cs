using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LxbXml;
using TicketPrint;
using GetOrder;
using CallingDB;


namespace SomeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestPrint();
            //TestXMLRead();
            //TestGetOrder();
            TestCallingDB();
        }

        static void TestCallingDB()
        {
            Calling calling = new Calling();
            Console.WriteLine("Before ADD:" + calling.GetNewOrderInfo("A"));
            calling.AddNewCall(new Queue { Q_cometime = DateTime.Now, Q_counter = 0, Q_issms = false, Q_mobile = "", Q_number = "A001", Q_Serial = 0 });
            Console.WriteLine("After ADD:" + calling.GetNewOrderInfo("A"));
            Console.ReadKey();
            //Console.WriteLine(calling.)
        }

        //Test the xml read&write
        static void TestXMLRead()
        {
            try
            {
                XmlNodeList nodelist = XMLHelper.GetXmlNodeListByXpath("Conf\\Layout.xml", "//Formlayout");
                
                if (nodelist != null)
                {
                    foreach (XmlNode node in nodelist)
                    {
                        //node.ChildNodes.Count;
                        Console.WriteLine(string.Format("name: {0},childCount:{1}", node.Name, node.ChildNodes.Count));
                        //XMLHelper.
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        static void TestPrint()
        {
            try
            {
                Ticket ticket = new Ticket(new System.Drawing.Printing.Margins(10, 10, 10, 50), new System.Drawing.Printing.PaperSize("Ticket", getInch(721), 600));
                ticket.AddLines("ANG GUGU", new System.Drawing.Font(new System.Drawing.FontFamily("黑体"), 16), System.Drawing.StringAlignment.Near);
                ticket.AddLines("ANG  GUGUGUGUGGUGUGUGUGGUGUGU", new System.Drawing.Font(new System.Drawing.FontFamily("黑体"), 14), System.Drawing.StringAlignment.Near);
                ticket.AddLines("ANG GUGU", new System.Drawing.Font(new System.Drawing.FontFamily("黑体"), 14), System.Drawing.StringAlignment.Far);
                ticket.AddLines("ANG GUGU", new System.Drawing.Font(new System.Drawing.FontFamily("黑体"), 12), System.Drawing.StringAlignment.Center);

                ticket.PrintTest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.)
                Console.ReadKey();
            }

        }

        static void TestGetOrder()
        {
            Ordering ordering = new Ordering();
            var l = ordering.GetPreFetchOrderByIdcard("440711198102025117", 7);
            var g = ordering.GetPreUnitBusinessByUaccount("2012001000276", 30);

            foreach (var o in l)
            {
                Console.WriteLine(o.ToString());
            }

            foreach (var o in g)
            {
                Console.WriteLine(o.ToString());
            }

            Console.ReadKey();
        }

        private static int getInch(double mm)
        {
            return (int)Math.Round((mm / 25.4) * 10);

        }
    }
}
