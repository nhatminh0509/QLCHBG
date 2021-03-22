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
    public class ChiTietHoaDonNhap_DAO
    {
        public bool ThemCTHDNhap(ChiTietHoaDonNhap_DTO cthd_nhap)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "ThemCTHDNhap";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idHoaDonNhap", cthd_nhap.idHoaDonNhap);
            cm.Parameters.AddWithValue("@idGiay", cthd_nhap.idGiay);
            cm.Parameters.AddWithValue("@sizeGiay", cthd_nhap.size);
            cm.Parameters.AddWithValue("@soLuong", cthd_nhap.soLuong);
            cm.Parameters.AddWithValue("@donGia", cthd_nhap.donGia);
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
