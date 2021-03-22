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
    public class HoaDon_DAO
    {
        public HoaDon_DTO LayHoaDonChuaThanhToanTheoSDTKH(string sdt)
        {
            HoaDon_DTO hd = new HoaDon_DTO();
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT * FROM HoaDon WHERE trangThai = 0 and sdtKhachHang = '" + sdt+"'";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    if (dataReader.IsDBNull(0) != null)
                    {
                        hd.id = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        hd.idNhanVien = dataReader["idNhanvien"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        hd.sdtKhachHang = dataReader["sdtKhachHang"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        hd.ngayLap = (DateTime?)dataReader["ngayLap"];
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        hd.tongTien = (int)dataReader["tongTien"];
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        hd.giamGia = (int)dataReader["giamGia"];
                    }
                    if (dataReader.IsDBNull(6) != null)
                    {
                        hd.thanhToan = (int)dataReader["thanhToan"];
                    }
                    if (dataReader.IsDBNull(7) != null)
                    {
                        hd.trangThai = (int)dataReader["trangThai"];
                    }
                }
                dataReader.Close();
                con.Close();
            }
            return hd;
        }

        public List<HoaDon_DTO> LayDanhSachTheoNgay(DateTime ngayBatDau,DateTime ngayKetThuc)
        {
            List<HoaDon_DTO> listhd = new List<HoaDon_DTO>();
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT * FROM HoaDon WHERE trangThai = 1 and ngayLap >= '"+ngayBatDau+"' and ngayLap <= '"+ngayKetThuc+"'";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    HoaDon_DTO hd = new HoaDon_DTO();
                    if (dataReader.IsDBNull(0) != null)
                    {
                        hd.id = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        hd.idNhanVien = dataReader["idNhanvien"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        hd.sdtKhachHang = dataReader["sdtKhachHang"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        hd.ngayLap = (DateTime?)dataReader["ngayLap"];
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        hd.tongTien = (int)dataReader["tongTien"];
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        hd.giamGia = (int)dataReader["giamGia"];
                    }
                    if (dataReader.IsDBNull(6) != null)
                    {
                        hd.thanhToan = (int)dataReader["thanhToan"];
                    }
                    if (dataReader.IsDBNull(7) != null)
                    {
                        hd.trangThai = (int)dataReader["trangThai"];
                    }
                    listhd.Add(hd);
                }
                dataReader.Close();
                con.Close();
            }
            return listhd;
        }

        public bool ThemHD(HoaDon_DTO hd)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "ThemHoaDon";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idNhanVien", hd.idNhanVien);
            cm.Parameters.AddWithValue("@sdtKhachHang", hd.sdtKhachHang);
            cm.Parameters.AddWithValue("@ngayLap", hd.ngayLap);
            cm.Parameters.AddWithValue("@tongTien", hd.tongTien);
            cm.Parameters.AddWithValue("@giamGia", hd.giamGia);
            cm.Parameters.AddWithValue("@thanhToan", hd.thanhToan);
            cm.Parameters.AddWithValue("@trangThai", hd.trangThai);
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

                command.CommandText = @"Select Max(id) FROM HoaDon";

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

        public bool CapNhapTien(int idHoaDon,int tongTien,int giamGia,int thanhToan)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "CapNhapTien";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idHoaDon", idHoaDon);
            cm.Parameters.AddWithValue("@tongTien", tongTien);
            cm.Parameters.AddWithValue("@giamGia", giamGia);
            cm.Parameters.AddWithValue("@thanhToan", thanhToan);
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

        public bool ThanhToan(int idHoaDon, int tongTien, int giamGia, int thanhToan)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "ThanhToanHD";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idHoaDon", idHoaDon);
            cm.Parameters.AddWithValue("@tongTien", tongTien);
            cm.Parameters.AddWithValue("@giamGia", giamGia);
            cm.Parameters.AddWithValue("@thanhToan", thanhToan);
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

        public bool Huy(int idHoaDon, int tongTien, int giamGia, int thanhToan)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "HuyHD";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idHoaDon", idHoaDon);
            cm.Parameters.AddWithValue("@tongTien", tongTien);
            cm.Parameters.AddWithValue("@giamGia", giamGia);
            cm.Parameters.AddWithValue("@thanhToan", thanhToan);
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

        public long TongDoanhThuTheoThang(int thang)
        {
            long tongDoanhThu = 0;

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "TongDoanhThuTheoThang";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@thang", thang);

            SqlDataReader dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                if (dataReader.IsDBNull(0) != null)
                {
                    try
                    {
                        tongDoanhThu = (int)dataReader[0];
                    }
                    catch
                    {

                    }
                }
            }
            dataReader.Close();
            con.Close();

            return tongDoanhThu;

        }
    }
}
