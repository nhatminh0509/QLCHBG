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
    public class Giay_DAO
    {
        public int CountGiay()
        {
            int count = 0;

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = "Select COUNT(id) from Giay where trangThai = 1";

                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    if (dataReader.IsDBNull(0) != null)
                    {

                        count = (int)dataReader[0];
                    }
                }
            }
            con.Close();
            return count;
        }
        public List<Giay_DTO> LayDanhSach()
        {

            List<Giay_DTO> listGiay = new List<Giay_DTO>();

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = @"Select * FROM Giay WHERE trangThai = 1";


                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Giay_DTO giay = new Giay_DTO();

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
                        giay.idHangGiay = (int)dataReader["idHangGiay"];
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        giay.idLoaiGiay = (int)dataReader["idLoaiGiay"];
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        giay.giamGia = (int)dataReader["giamGia"];
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        giay.hinhAnh = dataReader["hinhAnh"].ToString();
                    }
                    if (dataReader.IsDBNull(6) != null)
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

        public Giay_DTO TimGiayBanChayTheoThang(int thang)
        {
            Giay_DTO giay = new Giay_DTO();

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "TimSPBanChayTheoThang";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@thang", thang);

            SqlDataReader dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                if (dataReader.IsDBNull(1) != null)
                {

                    giay.id = (int)dataReader[1];
                }
                if (dataReader.IsDBNull(2) != null)
                {
                    giay.tenGiay = dataReader["tenGiay"].ToString();
                }
                if (dataReader.IsDBNull(3) != null)
                {
                    giay.idHangGiay = (int)dataReader["idHangGiay"];
                }
                if (dataReader.IsDBNull(4) != null)
                {
                    giay.idLoaiGiay = (int)dataReader["idLoaiGiay"];
                }
                if (dataReader.IsDBNull(5) != null)
                {
                    giay.giamGia = (int)dataReader["giamGia"];
                }
                if (dataReader.IsDBNull(6) != null)
                {
                    giay.hinhAnh = dataReader["hinhAnh"].ToString();
                }
                if (dataReader.IsDBNull(7) != null)
                {
                    giay.trangThai = (int)dataReader["trangThai"];
                }
            }
            dataReader.Close();
            con.Close();

            return giay;
        
        }

        public int SLGiayBanChayNhatTheoThang(int thang)
        {
            int slgiay = 0;
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "TimSPBanChayTheoThang";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@thang", thang);

            SqlDataReader dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                if (dataReader.IsDBNull(0) != null)
                {
                    slgiay = (int)dataReader[0];
                }
                
            }
            dataReader.Close();
            con.Close();

            return slgiay;

        }

        public int SLGiayDaBanTheoNgay(int idGiay,string size,DateTime ngayBatDau,DateTime ngayKetThuc)
        {
            int slgiay = 0;
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "SLGiayDaBanTheoNgay";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idGiay", idGiay);
            cm.Parameters.AddWithValue("@sizeGiay", size);
            cm.Parameters.AddWithValue("@ngayBatDau", ngayBatDau);
            cm.Parameters.AddWithValue("@ngayKetThuc", ngayKetThuc);

            SqlDataReader dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                if (dataReader.IsDBNull(0) != null)
                {
                    try
                    {
                        slgiay = (int)dataReader[0];
                    }
                    catch
                    {
                        slgiay = 0;
                    }
                }

            }
            dataReader.Close();
            con.Close();

            return slgiay;

        }

        public List<Giay_DTO> TimGiay(string query)
        {

            List<Giay_DTO> listGiay = new List<Giay_DTO>();

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = query;


                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Giay_DTO giay = new Giay_DTO();

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
                        giay.idHangGiay = (int)dataReader["idHangGiay"];
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        giay.idLoaiGiay = (int)dataReader["idLoaiGiay"];
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        giay.giamGia = (int)dataReader["giamGia"];
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        giay.hinhAnh = dataReader["hinhAnh"].ToString();
                    }
                    if (dataReader.IsDBNull(6) != null)
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

        public bool ThemGiay(Giay_DTO giay)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "ThemGiay";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@tenGiay", giay.tenGiay);
            cm.Parameters.AddWithValue("@idHang", giay.idHangGiay);
            cm.Parameters.AddWithValue("@idLoai", giay.idLoaiGiay);
            cm.Parameters.AddWithValue("@giamGia", giay.giamGia);
            cm.Parameters.AddWithValue("@hinhAnh", giay.hinhAnh);
            cm.Parameters.AddWithValue("@trangThai", giay.trangThai);
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

        public bool SuaGiay(Giay_DTO giay)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "SuaGiay";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@id", giay.id);            
            cm.Parameters.AddWithValue("@tenGiay", giay.tenGiay);
            cm.Parameters.AddWithValue("@idHang", giay.idHangGiay);
            cm.Parameters.AddWithValue("@idLoai", giay.idLoaiGiay);
            cm.Parameters.AddWithValue("@giamGia", giay.giamGia);
            cm.Parameters.AddWithValue("@hinhAnh", giay.hinhAnh);
            cm.Parameters.AddWithValue("@trangThai", giay.trangThai);
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

        public bool XoaGiay(int id)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "XoaGiay";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@id", id);
            
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

        public int LastID()
        {
            int lastID = -1;
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = @"Select Max(id) FROM Giay WHERE trangThai = 1";

                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    if (dataReader.IsDBNull(0) != null)
                    {

                        lastID = (int)dataReader[0];
                    }
                }
            }
            con.Close();
            return lastID;
        }
    }
}
