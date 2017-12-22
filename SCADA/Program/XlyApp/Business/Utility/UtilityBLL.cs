using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Easy4net.Entity;
using System.Data.SqlClient;

namespace Business
{

    public class UtilityBLL
    {
        Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
 
        /// <summary>
        /// 生成一个不重复的序列号
        /// </summary>
        /// <param name="cate"></param>
        /// <returns></returns>
        public string GenerateSeq(SequenceType cate)
        {
            string startWith = cate.ToString(); 
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@MaintainCate", SqlDbType.VarChar, 2),
                new SqlParameter("@MaintainNo", SqlDbType.VarChar, 100)
            };
            paras[0].Value = startWith;
            paras[1].Direction = ParameterDirection.Output;
            dbhelper.ExcuteStoredProcReturnString("Com_GetMaintainSeq", paras);
            return paras[1].Value.ToString();
        }
        public DataTable GetReport(string execsql)
        {
            DataSet ds = dbhelper.ExcuteSQLReturnDataSet(execsql);
            return ds.Tables[0];
        }
    }
}
