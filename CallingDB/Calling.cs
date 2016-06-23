using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CallingDB
{
    public class Calling
    {
        DataClasses1DataContext dcdc = null;

        public string ConnectionString { get; private set; }

        public Calling() { }
        public Calling(string connectionstring)
        {
            if (connectionstring != null)
            {
                this.ConnectionString = ConnectionString;
                dcdc = new DataClasses1DataContext(ConnectionString);
            }            
        }

        public void AddNewCall(Queue queue)
        {
            InserQueue(queue);
            InsertHistory(new QueueHist { H_Serial = queue.Q_Serial, H_number = queue.Q_number, H_counter = queue.Q_counter, H_cometime = queue.Q_cometime, H_serveno = "0000", H_endtime = DateTime.Now, H_isdo = false, H_issend = false,H_servetime=queue.Q_cometime });

        }        
        public OrderInfo GetNewOrderInfo(string filter)
        {
            var newordernum = GetNewOrderNum(GetLastestOrderNum(filter));
            return new OrderInfo(orderstring: newordernum == null ? filter + "001" : newordernum, leftnumcount: GetLeftCount(filter));
        }

        private void InserQueue(Queue queue)
        {
            try
            {
                if (dcdc == null) dcdc = new DataClasses1DataContext();

                dcdc.Queues.InsertOnSubmit(queue);
                dcdc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void InsertHistory(QueueHist hist)
        {
            try
            {
                if (dcdc == null) dcdc = new DataClasses1DataContext();
                                 
                dcdc.QueueHists.InsertOnSubmit(hist);
                dcdc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        private string GetLastestOrderNum(string filter)
        {
            try
            {
                if (dcdc == null) dcdc = new DataClasses1DataContext();
                var res = from h in dcdc.QueueHists
                          where SqlMethods.DateDiffDay(h.H_cometime, DateTime.Now) == 0 && h.H_number.IndexOf(filter) == 0
                          select h;

                return res.Max(x => x.H_number);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private string GetNewOrderNum(string oldordernum)
        {
            if (oldordernum != null)
            {
                StringBuilder sb = new StringBuilder(oldordernum.Substring(0, 1));
                var c = Convert.ToInt16(oldordernum.Substring(1)) + 1;

                sb.Append(c >= 100 ? (c / 100).ToString() : "0");
                sb.Append((c <= 100 && c >= 10) ? (c / 10).ToString() : "0");
                sb.Append(c % 10);

                return sb.ToString();
            }
            else
            {
                return null;
            }
            //return null;
        }
        private int GetLeftCount(string filter)
        {
            try
            {
                if (dcdc == null) dcdc = new DataClasses1DataContext();
                var res = from h in dcdc.QueueHists
                          where SqlMethods.DateDiffDay(h.H_cometime, DateTime.Now) == 0 && h.H_number.IndexOf(filter) == 0
                          select h;
                return res.Count(x => x.H_counter == 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
                
    }
}
