using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Medical.Data
{
    public partial class Utils
    {
        private static SqlConnection con;
        private static SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter adp;

        public Utils()
        {
            con = new SqlConnection("data source =NKOSANA-LT; database=Users; integrated security =SSPI;");
            con.Open();
        }


        public DataTable Select(string sql)
        {
            adp = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            adp.Fill(dt);

            return dt;
        }
        public bool Execute(string sql)
        {
            bool flag = false;
            adp = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
                flag = true;

            return flag;
        }
    }
}
