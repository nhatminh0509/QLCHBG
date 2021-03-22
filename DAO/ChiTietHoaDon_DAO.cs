using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChiTietHoaDon_DAO
    {
        public bool ThemCTHD(ChiTietHoaDon_DTO cthd)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "ThemCTHD";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idHoaDon", cthd.idHoaDon);
            cm.Parameters.AddWithValue("@idGiay", cthd.idGiay);
            cm.Parameters.AddWithValue("@sizeGiay", cthd.size);
            cm.Parameters.AddWithValue("@soLuong", cthd.soLuong);
            int NumOfRow = cm.ExecuteNonQuery();
            con.Close();
            if (NumOfRow > 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}
