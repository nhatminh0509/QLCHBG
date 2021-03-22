using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class HienThiHoaDonNhap_DAO
    {
        public List<HienThiHoaDonNhap_DTO> LayDanhSachTheoIDHoaDon(int idHoaDonNhap)
        {

            List<HienThiHoaDonNhap_DTO> listHTHD = new List<HienThiHoaDonNhap_DTO>();

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = "Select G.id,G.tenGiay,S.sizeGiay,CTHDNhap.soLuong,CTHDNhap.donGia,CTHDNhap.soLuong * CTHDNhap.donGia as 'thanhTien' from Giay as G,BangSize as S,ChiTietHoaDonNhap as CTHDNhap where G.id = S.idGiay and CTHDNhap.idGiay = G.id and S.sizeGiay = CTHDNhap.sizeGiay and CTHDNhap.idHoaDonNhap = "+ idHoaDonNhap;
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    HienThiHoaDonNhap_DTO hthd = new HienThiHoaDonNhap_DTO();

                    if (dataReader.IsDBNull(0) != null)
                    {
                        hthd.idGiay = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        hthd.tenGiay = dataReader[1].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        hthd.size = dataReader["sizeGiay"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        hthd.soLuong = (int)dataReader["soLuong"];
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        hthd.donGia = (int)dataReader["donGia"];
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        hthd.thanhTien = (int)dataReader["thanhTien"];
                    }
                    listHTHD.Add(hthd);
                }

                dataReader.Close();
                con.Close();
            }
            return listHTHD;
        }
    }
}
