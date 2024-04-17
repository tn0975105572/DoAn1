using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CSDL_DAL
    {
        public string diachi = @"Data Source=DUYTUAN;Initial Catalog=Doan1;Integrated Security=True;";

        public SqlConnection kn;
        public SqlCommand cm;
        public SqlDataReader dtrd;
        public DataTable dttb;
        public SqlDataAdapter dtadt;

        public void ketnoi()
        {
            kn = new SqlConnection(diachi);
            if (kn.State == ConnectionState.Closed)
                kn.Open();
        }
        public void ngatketnoi()
        {
            kn = new SqlConnection(diachi);
            if (kn.State == ConnectionState.Closed)
                kn.Close();
        }

        public void chaycodesql(string masql)
        {
            ketnoi();
            cm.CommandText = masql;
            cm.ExecuteNonQuery();
            ngatketnoi();
        }
        public int Dem(string count)
        {
            chaycodesql(count);
            ketnoi();
            int dem = (int)cm.ExecuteScalar();
            ngatketnoi();
            return dem;
        }
        public DataTable getData(string sql)
        {
            ketnoi();
            dtadt = new SqlDataAdapter(sql, kn);
            dttb = new DataTable();
            dtadt.Fill(dttb);
            ngatketnoi();
            return dttb;
        }
        public int KiemTraMaTrung(string ma, string sql)
        {
            ketnoi();
            int i;
            cm = new SqlCommand(sql, kn);
            i = (int)cm.ExecuteScalar();
            ngatketnoi();
            return i;
        }
       
    }
}
