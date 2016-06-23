using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Lxb.DAL;
using GJJCallingSys.Models;

namespace GJJCallingSys.DLL
{
    class PreExaminations
    {
        Confg conncfg;
        public PreExaminations()
        {
            conncfg = GetConfigurations.GetConnectionConfigurationsFromXml("Conf\\Application.xml").Where(p => p.Name == "WebBusinessSystem").ToList<Confg>()[0];
            //conncfg=conncfg.
        }

        public PreFetchInfo GetPreFetchInfoByIdcard(string idcard)
        {
            return GetPreFetchInfoByIdcard(conncfg.Configurations["connectionString"], idcard);
        }

        public PreFetchInfo GetPreFetchInfoByResponsNum(string responsnum)
        {
            return GetPreFetchInfoByResponsNum(conncfg.Configurations["connectionString"], responsnum);
        }

        private PreFetchInfo GetPreFetchInfoByIdcard(string connectionstring, string idcard)
        {
            string sql = @"select name,idcard,auditime,responsNum from A033PreFetch where status='预审通过' and isnull(isdel,0)=0 and idcard='" + idcard + "' order by auditime desc";
            DataTable dt=new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(connectionstring, CommandType.Text, sql));                
            }
            catch(SqlException ex)
            {
                throw ex;
            }

            if (dt.Rows.Count > 0)
            {
                return new PreFetchInfo(name: dt.Rows[0]["name"].ToString(), idcard: dt.Rows[0]["idcard"].ToString(), auditime: Convert.ToDateTime(dt.Rows[0]["auditime"]), responsnum: dt.Rows[0]["responsNum"].ToString());
            }
            else
            { 
                return new PreFetchInfo(null, null, Convert.ToDateTime("1900-1-1"), null);
            }
        }

        private PreFetchInfo GetPreFetchInfoByResponsNum(string connectionstring, string responsnum)
        {
            string sql = @"select name,idcard,auditime,responsNum from A033PreFetch where status='预审通过' and isnull(isdel,0)=0 and responsNum='" + responsnum + "'";
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(connectionstring, CommandType.Text, sql));
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            if (dt.Rows.Count > 0)
            {
                return new PreFetchInfo(name: dt.Rows[0]["name"].ToString(), idcard: dt.Rows[0]["idcard"].ToString(), auditime: Convert.ToDateTime(dt.Rows[0]["auditime"]), responsnum: dt.Rows[0]["responsNum"].ToString());
            }
            else
            {
                return new PreFetchInfo(null, null, Convert.ToDateTime("1900-1-1"), null);
            }
        }

    }
}
