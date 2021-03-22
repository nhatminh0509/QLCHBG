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
    public class HienThiHoaDon_DAO
    {
        public List<HienThiHoaDon_DTO> LayDanhSachTheoIDHoaDon(int idHoaDon)
        {

            List<HienThiHoaDon_DTO> listHTHD = new List<HienThiHoaDon_DTO>();

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = @"Select G.tenGiay, CTHD.sizeGiay, CTHD.soLuong,S.giaBan,G.giamGia, CTHD.soLuong * (S.giaBan - (S.giaBan * G.giamGia)/100) as thanhTien,S.idGiay from Giay as G, BangSize as S, ChiTietHoaDon as CTHD where G.id = S.idGiay and G.id = CTHD.idGiay and S.sizeGiay = CTHD.sizeGiay and CTHD.idHoaDon = " + idHoaDon;

                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    HienThiHoaDon_DTO hthd = new HienThiHoaDon_DTO();

                    if (dataReader.IsDBNull(0) != null)
                    {
                        hthd.tenGiay = dataReader[0].ToString();
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        hthd.size = dataReader["sizeGiay"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        hthd.soLuong = (int)dataReader["soLuong"];
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        hthd.donGia = (int)dataReader["giaBan"];
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        hthd.giamGia = (int)dataReader["giamGia"];
                    } 
                    if (dataReader.IsDBNull(5) != null)
                    {
                        hthd.thanhTien = (int)dataReader["thanhTien"];
                    }
                    if (dataReader.IsDBNull(6) != null)
                    {
                        hthd.idGiay = (int)dataReader["idGiay"];
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
