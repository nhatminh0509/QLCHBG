using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class DataProvider
    {

        public static string chuoiKetNoi = @"Data Source=.\NHATMINH0509;Initial Catalog=QLCHBG;Integrated Security=True";


        public static SqlConnection TaoKetNoi()
        {

            SqlConnection con = null;
            try
            {

                con = new SqlConnection(chuoiKetNoi);


                con.Open();
            }
            catch (Exception ex)
            {
                return null;
            }

            return con;
        }
    }
}
