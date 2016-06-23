using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace GetOrder
{
    public class Ordering
    {
        OrderDataClassesDataContext oddc = new OrderDataClassesDataContext();

        public Ordering() { }

        public Array GetPreFetchOrderByIdcard(string idcard, int days)
        {
            var o = from x in oddc.A033PreFetches
                    where x.idCard == idcard && x.isdel==false && x.status == "预审通过" && SqlMethods.DateDiffDay(x.audittime,DateTime.Now)<=days
                    select new { x.areaCode, x.idCard, x.account, x.audittime,x.responsNum };

            return o.ToArray();
        }
        public Array GetPreUnitBusinessByUaccount(string uaccount, int days)
        {
            var o = from x in oddc.View_PreUnitBusinesses
                    where x.uaccount == uaccount && x.isdel == false && x.status == "预审通过" && SqlMethods.DateDiffDay(x.audittime, DateTime.Now) <= days
                    select new { x.areaCode, x.uaccount, x.audittime, x.responsNum };

            return o.ToArray();
        }

        //15位份证转换18位
        private static string Convert15To18ID(string idcard)
        {
            if (idcard.Length == 15)
            {
                int iS = 0;

                //加权因子常数
                int[] iW = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
                //校验码常数
                string LastCode = "10X98765432";
                //新身份证号
                string newIDCard = idcard.Insert(6, "19");

                for (int i = 0; i < 17; i++)
                {
                    iS += int.Parse(newIDCard.Substring(i, 1)) * iW[i];
                }
                //取模运算，得到模值
                int iY = iS % 11;
                //从LastCode中取得以模为索引号的值，加到身份证的最后一位，即为新身份证号。
                newIDCard += LastCode.Substring(iY, 1);
                return newIDCard;
            }
            else if (idcard.Length == 18)
                return idcard;
            else
                return null;
        }

    }
}
