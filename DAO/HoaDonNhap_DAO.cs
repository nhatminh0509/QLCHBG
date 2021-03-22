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
    public class HoaDonNhap_DAO
    {
        public HoaDonNhap_DTO LayHoaDonChuaNhapTheoMaNCC(string maNCC)
        {
            HoaDonNhap_DTO hd_nhap = new HoaDonNhap_DTO();
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT * FROM HoaDonNhap WHERE trangThai = 0 and maNCC = '" + maNCC + "'";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    if (dataReader.IsDBNull(0) != null)
                    {
                        hd_nhap.id = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        hd_nhap.idNhanVien = dataReader["idNhanvien"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        hd_nhap.maNCC = dataReader["maNCC"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        hd_nhap.ngayNhap = (DateTime?)dataReader["ngayNhap"];
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        hd_nhap.tongTien = (int)dataReader["tongTien"];
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        hd_nhap.trangThai = (int)dataReader["trangThai"];
                    }
                }
                dataReader.Close();
                con.Close();
            }
            return hd_nhap;
        }

        public bool ThemHD(HoaDonNhap_DTO hd)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "ThemHoaDonNhap";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idNhanVien", hd.idNhanVien);
            cm.Parameters.AddWithValue("@maNCC", hd.maNCC);
            cm.Parameters.AddWithValue("@ngayNhap", hd.ngayNhap);
            cm.Parameters.AddWithValue("@tongTien", hd.tongTien);
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

                command.CommandText = @"Select Max(id) FROM HoaDonNhap";

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

        public bool CapNhapTien(int idHoaDonNhap, int tongTien)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "CapNhapTienHDNhap";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idHoaDonNhap", idHoaDonNhap);
            cm.Parameters.AddWithValue("@tongTien", tongTien);
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

        public bool ThanhToan(int idHoaDonNhap, int tongTien)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "ThanhToanHDNhap";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idHoaDonNhap", idHoaDonNhap);
            cm.Parameters.AddWithValue("@tongTien", tongTien);
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

        public bool Huy(int idHoaDonNhap, int tongTien)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "HuyHDNhap";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idHoaDonNhap", idHoaDonNhap);
            cm.Parameters.AddWithValue("@tongTien", tongTien);
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
        public int SoLanNhapHangTheoThang(int thang)
        {
            int soLanNhap = 0;

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "SoLanNhapTheoThang";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@thang", thang);

            SqlDataReader dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                if (dataReader.IsDBNull(0) != null)
                {
                    soLanNhap = (int)dataReader[0];
                }
            }
            dataReader.Close();
            con.Close();

            return soLanNhap;

        }
    }
}
