using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class HienThiGiay_DAO
    {
        public List<HienThiGiay_DTO> LayDanhSach()
        {

            List<HienThiGiay_DTO> listGiay = new List<HienThiGiay_DTO>();

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = @"Select G.id,G.tenGiay,S.sizeGiay,HG.tenHang,LG.tenLoaiGiay,S.giaBan,S.giaNhap,G.giamGia,S.soLuong,G.hinhAnh,S.trangThai from Giay as G,BangSize as S,HangGiay as HG,LoaiGiay as LG where G.id = S.idGiay and G.idHangGiay = HG.id and G.idLoaiGiay = LG.id and S.trangThai = 1 and G.trangThai = 1 Order By G.id";


                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    HienThiGiay_DTO giay = new HienThiGiay_DTO();

                    if (dataReader.IsDBNull(0) != null)
                    {

                        giay.id = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        giay.tenGiay = dataReader["tenGiay"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        giay.size = dataReader["sizeGiay"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        giay.tenHangGiay = dataReader["tenHang"].ToString();
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        giay.tenLoaiGiay = dataReader["tenLoaiGiay"].ToString();
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        giay.giaBan = (int)dataReader["giaBan"];
                    }
                    if (dataReader.IsDBNull(6) != null)
                    {
                        giay.giaNhap = (int)dataReader["giaNhap"];
                    }
                    if (dataReader.IsDBNull(7) != null)
                    {
                        giay.giamGia = (int)dataReader["giamGia"];
                    }
                    if (dataReader.IsDBNull(8) != null)
                    {
                        giay.soLuong = (int)dataReader["soLuong"];
                    }
                    if (dataReader.IsDBNull(9) != null)
                    {
                        giay.hinhAnh = dataReader["hinhAnh"].ToString();
                    }
                    if (dataReader.IsDBNull(10) != null)
                    {
                        giay.trangThai = (int)dataReader["trangThai"];
                    }
                    
                    
                    listGiay.Add(giay);
                }

                dataReader.Close();
                con.Close();
            }
            return listGiay;
        }

        public List<HienThiGiay_DTO> TimSP(string query)
        {

            List<HienThiGiay_DTO> listGiay = new List<HienThiGiay_DTO>();

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = query ;


                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    HienThiGiay_DTO giay = new HienThiGiay_DTO();

                    if (dataReader.IsDBNull(0) != null)
                    {

                        giay.id = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        giay.tenGiay = dataReader["tenGiay"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        giay.size = dataReader["sizeGiay"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        giay.tenHangGiay = dataReader["tenHang"].ToString();
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        giay.tenLoaiGiay = dataReader["tenLoaiGiay"].ToString();
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        giay.giaBan = (int)dataReader["giaBan"];
                    }
                    if (dataReader.IsDBNull(6) != null)
                    {
                        giay.giaNhap = (int)dataReader["giaNhap"];
                    }
                    if (dataReader.IsDBNull(7) != null)
                    {
                        giay.giamGia = (int)dataReader["giamGia"];
                    }
                    if (dataReader.IsDBNull(8) != null)
                    {
                        giay.soLuong = (int)dataReader["soLuong"];
                    }
                    if (dataReader.IsDBNull(9) != null)
                    {
                        giay.hinhAnh = dataReader["hinhAnh"].ToString();
                    }
                    if (dataReader.IsDBNull(10) != null)
                    {
                        giay.trangThai = (int)dataReader["trangThai"];
                    }
                    listGiay.Add(giay);
                }

                dataReader.Close();
                con.Close();
            }
            return listGiay;
        }
    }
}
