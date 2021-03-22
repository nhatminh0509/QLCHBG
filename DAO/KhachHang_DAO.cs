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
    public class KhachHang_DAO
    {
        public int CountKH()
        {
            int count = 0;

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = "Select COUNT(sdt) from KhachHang where trangThai = 1";

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
        public KhachHang_DTO LayKH(string sdt)
        {
            KhachHang_DTO kh = new KhachHang_DTO();
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT * FROM KhachHang WHERE sdt ='" + sdt + "'";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    if (dataReader.IsDBNull(0) != null)
                    {

                        kh.sdt = dataReader[0].ToString();
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        kh.tenKhachHang = dataReader["tenKhachHang"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        kh.cmnd = dataReader["cmnd"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        kh.ngaySinh = (DateTime)dataReader["ngaySinh"];
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        kh.diaChi = dataReader["diaChi"].ToString();
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        kh.tongChiTieu = (int)dataReader["tongChiTieu"];
                    }
                    
                }
                dataReader.Close();
                con.Close();
            }
            return kh;
        }

        public List<KhachHang_DTO> LayDanhSach()
        {
            List<KhachHang_DTO> listKH = new List<KhachHang_DTO>();
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT * FROM KhachHang where trangThai = 1";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
               
                while (dataReader.Read())
                {
                    KhachHang_DTO kh = new KhachHang_DTO();
                    if (dataReader.IsDBNull(0) != null)
                    {
                        kh.sdt = dataReader[0].ToString();
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        kh.tenKhachHang = dataReader["tenKhachHang"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        kh.cmnd = dataReader["cmnd"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        kh.ngaySinh = (DateTime)dataReader["ngaySinh"];
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        kh.diaChi = dataReader["diaChi"].ToString();
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        kh.tongChiTieu = (int)dataReader["tongChiTieu"];
                    }
                    if(dataReader.IsDBNull(6)!=null)
                    {
                        kh.trangThai = (int)dataReader["trangThai"];
                    }
                    listKH.Add(kh);
                }
                dataReader.Close();
                con.Close();
            }
            return listKH;
        }

        public List<KhachHang_DTO> TimKH(string query)
        {
            List<KhachHang_DTO> listKH = new List<KhachHang_DTO>();
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();

                command.CommandText = query;
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    KhachHang_DTO kh = new KhachHang_DTO();
                    if (dataReader.IsDBNull(0) != null)
                    {
                        kh.sdt = dataReader[0].ToString();
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        kh.tenKhachHang = dataReader["tenKhachHang"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        kh.cmnd = dataReader["cmnd"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        kh.ngaySinh = (DateTime)dataReader["ngaySinh"];
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        kh.diaChi = dataReader["diaChi"].ToString();
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        kh.tongChiTieu = (int)dataReader["tongChiTieu"];
                    }
                    listKH.Add(kh);
                }
                dataReader.Close();
                con.Close();
            }
            return listKH;
        }

        public bool KiemTra(string sdt)
        {
            bool kq = false;
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = @"SELECT * FROM KhachHang WHERE sdt ='" + sdt + "'";
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

        public bool ThemKhachHang(KhachHang_DTO kh)
        {

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "ThemKhachHang";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@sdt", kh.sdt);
            cm.Parameters.AddWithValue("@tenKhachHang", kh.tenKhachHang);
            cm.Parameters.AddWithValue("@cmnd", kh.cmnd);
            cm.Parameters.AddWithValue("@ngaySinh", kh.ngaySinh);
            cm.Parameters.AddWithValue("@diaChi", kh.diaChi);
            cm.Parameters.AddWithValue("@tongChiTieu", kh.tongChiTieu);
            cm.Parameters.AddWithValue("@trangThai", kh.trangThai);
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

        public bool XoaKhachHang(string sdt)
        {

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "XoaKhachHang";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@sdt", sdt);
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

        public bool SuaKhachHang(KhachHang_DTO kh)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "SuaKhachHang";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@sdt", kh.sdt);
            cm.Parameters.AddWithValue("@tenKhachHang", kh.tenKhachHang);
            cm.Parameters.AddWithValue("@cmnd", kh.cmnd);
            cm.Parameters.AddWithValue("@ngaySinh", kh.ngaySinh);
            cm.Parameters.AddWithValue("@diaChi", kh.diaChi);
            cm.Parameters.AddWithValue("@tongChiTieu", kh.tongChiTieu);
            cm.Parameters.AddWithValue("@trangThai", 1);
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

        public bool ThanhToan(string sdt, int soTien)
        {

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "KHThanhToan";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@sdt", sdt);
            cm.Parameters.AddWithValue("@soTien", soTien);
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
