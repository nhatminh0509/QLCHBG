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
    public class BangSize_DAO
    {
        public List<BangSize_DTO> LayDanhSach(int id)
        {

            List<BangSize_DTO> listSizeGiay = new List<BangSize_DTO>();

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = @"Select * FROM BangSize WHERE trangThai = 1 and idGiay = " + id;


                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    BangSize_DTO bangSize = new BangSize_DTO();

                    if (dataReader.IsDBNull(0) != null)
                    {

                        bangSize.idGiay = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        bangSize.sizeGiay = dataReader["sizeGiay"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        bangSize.giaBan = (int)dataReader["giaBan"];
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        bangSize.giaNhap = (int)dataReader["giaNhap"];
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        bangSize.soLuong = (int)dataReader["soLuong"];
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        bangSize.trangThai = (int)dataReader["trangThai"];
                    }
                    listSizeGiay.Add(bangSize);
                }

                dataReader.Close();
                con.Close();
            }
            return listSizeGiay;
        }

        public bool KiemTra(int idGiay, string size)
        {

            bool kq = false;

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = @"Select * FROM BangSize WHERE trangThai = 1 and idGiay = " + idGiay +" and sizeGiay = N'"+size+"'";


                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    kq = true;
                }

                dataReader.Close();
                con.Close();
            }
            return kq;
        }

        public bool ThemSize(BangSize_DTO size)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "ThemSize";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idGiay", size.idGiay);
            cm.Parameters.AddWithValue("@sizeGiay", size.sizeGiay);
            cm.Parameters.AddWithValue("@giaBan", size.giaBan);
            cm.Parameters.AddWithValue("@giaNhap", size.giaNhap);
            cm.Parameters.AddWithValue("@soLuong", size.soLuong);
            cm.Parameters.AddWithValue("@trangThai", size.trangThai);
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

        public bool XoaSize(int idgiay,string size)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "XoaSize";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idgiay", idgiay);
            cm.Parameters.AddWithValue("@sizeGiay", size);
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

        public bool SuaSize(BangSize_DTO size)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "SuaSize";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idGiay", size.idGiay);
            cm.Parameters.AddWithValue("@sizeGiay", size.sizeGiay);
            cm.Parameters.AddWithValue("@giaBan", size.giaBan);
            cm.Parameters.AddWithValue("@giaNhap", size.giaNhap);
            cm.Parameters.AddWithValue("@soLuong", size.soLuong);
            cm.Parameters.AddWithValue("@trangThai", size.trangThai);
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

        public bool CapNhatSLDaBan(int idGiay, string sizeGiay, int soLuong)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "CapNhatSoLuongDaBan";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idGiay", idGiay);
            cm.Parameters.AddWithValue("@sizeGiay", sizeGiay);
            cm.Parameters.AddWithValue("@soLuongDaBan", soLuong);
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

        public bool CapNhatKho(int idGiay, string sizeGiay, int soLuong,int giaNhap)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "CapNhatKho";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idGiay", idGiay);
            cm.Parameters.AddWithValue("@sizeGiay", sizeGiay);
            cm.Parameters.AddWithValue("@soLuongDaNhap", soLuong);
            cm.Parameters.AddWithValue("@giaNhap", giaNhap);
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
