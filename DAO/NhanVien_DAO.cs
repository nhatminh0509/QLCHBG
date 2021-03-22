using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class NhanVien_DAO
    {

        public NhanVien_DTO NVGioiNhatThang(int thang)
        {

            NhanVien_DTO nv = new NhanVien_DTO();
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "NhanVienBanGioiNhatThang";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@thang", thang);

            SqlDataReader dataReader = cm.ExecuteReader();

            if (dataReader.Read())
            {
                if (dataReader.IsDBNull(1) != null)
                {

                    nv.idNhanVien = dataReader[1].ToString();
                }
                if (dataReader.IsDBNull(2) != null)
                {
                    nv.matKhau = dataReader["matKhau"].ToString();
                }
                if (dataReader.IsDBNull(3) != null)
                {
                    nv.tenNhanVien = dataReader["tenNhanVien"].ToString();
                }
                if (dataReader.IsDBNull(4) != null)
                {
                    nv.cmnd = dataReader["cmnd"].ToString();
                }
                if (dataReader.IsDBNull(5) != null)
                {
                    nv.sdt = dataReader["sdt"].ToString();
                }
                if (dataReader.IsDBNull(6) != null)
                {
                    nv.ngaySinh = (DateTime)dataReader["ngaySinh"];
                }
                if (dataReader.IsDBNull(7) != null)
                {
                    nv.diaChi = dataReader["diaChi"].ToString();
                }
                if (dataReader.IsDBNull(8) != null)
                {
                    nv.loaiNhanVien = dataReader["loaiNhanVien"].ToString();
                }
                if (dataReader.IsDBNull(9) != null)
                {
                    nv.trangThai = (int)dataReader["trangThai"];
                }
            }
            dataReader.Close();
            con.Close();
            return nv;
        }

        public int SLSPNVGioiNhatThang(int thang)
        {
            int slsp = 0;
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "NhanVienBanGioiNhatThang";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@thang", thang);

            SqlDataReader dataReader = cm.ExecuteReader();

            if (dataReader.Read())
            {
                if (dataReader.IsDBNull(1) != null)
                {

                    slsp = (int)dataReader[0];
                }
            }
            dataReader.Close();
            con.Close();
            return slsp;
        }

        public int CountNV()
        {
            int count = 0;

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = "Select COUNT(idNhanVien) from NhanVien where trangThai = 1";

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
        public List<NhanVien_DTO> TimNV(string query)
        {

            List<NhanVien_DTO> listNV = new List<NhanVien_DTO>();

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = query;

                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    NhanVien_DTO nv = new NhanVien_DTO();

                    if (dataReader.IsDBNull(0) != null)
                    {

                        nv.idNhanVien = dataReader[0].ToString();
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        nv.matKhau = dataReader["matKhau"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        nv.tenNhanVien = dataReader["tenNhanVien"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        nv.cmnd = dataReader["cmnd"].ToString();
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        nv.sdt = dataReader["sdt"].ToString();
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        nv.ngaySinh = (DateTime)dataReader["ngaySinh"];
                    }
                    if (dataReader.IsDBNull(6) != null)
                    {
                        nv.diaChi = dataReader["diaChi"].ToString();
                    }
                    if (dataReader.IsDBNull(7) != null)
                    {
                        nv.loaiNhanVien = dataReader["loaiNhanVien"].ToString();
                    }
                    if (dataReader.IsDBNull(8) != null)
                    {
                        nv.trangThai = (int)dataReader["trangThai"];
                    }
                    listNV.Add(nv);
                }

                dataReader.Close();
                con.Close();
            }
            return listNV;
        }

        public List<NhanVien_DTO> LayDanhSach()
        {

            List<NhanVien_DTO> listNV = new List<NhanVien_DTO>();

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = @"SELECT idNhanVien,matKhau, tenNhanVien, cmnd, sdt, ngaySinh, diaChi, loaiNhanVien, trangThai FROM NHANVIEN WHERE trangThai = 1";


                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    NhanVien_DTO nv = new NhanVien_DTO();

                    if (dataReader.IsDBNull(0) != null)
                    {

                        nv.idNhanVien = dataReader[0].ToString();
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        nv.matKhau = dataReader["matKhau"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        nv.tenNhanVien = dataReader["tenNhanVien"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        nv.cmnd = dataReader["cmnd"].ToString();
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        nv.sdt = dataReader["sdt"].ToString();
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        nv.ngaySinh = (DateTime)dataReader["ngaySinh"];
                    }
                    if (dataReader.IsDBNull(6) != null)
                    {
                        nv.diaChi = dataReader["diaChi"].ToString();
                    }
                    if (dataReader.IsDBNull(7) != null)
                    {
                        nv.loaiNhanVien = dataReader["loaiNhanVien"].ToString();
                    }
                    if (dataReader.IsDBNull(8) != null)
                    {
                        nv.trangThai = (int)dataReader["trangThai"];
                    }
                    listNV.Add(nv);
                }

                dataReader.Close();
                con.Close();
            }
            return listNV;
        }

        public DataTable LayDS()
        {
            DataTable dt = new DataTable();
            SqlConnection con = DataProvider.TaoKetNoi();

            SqlDataAdapter da = new SqlDataAdapter("Select idNhanVien,tenNhanVien,cmnd,sdt,ngaySinh,diaChi,loaiNhanVien From NhanVien Where trangThai = 1", con);

            da.Fill(dt);

            con.Close();

            return dt;
        }

        public bool KiemTra(string id)
        {
            bool kq = false;
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = @"SELECT * FROM NHANVIEN WHERE idNhanVien ='" + id + "'";
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
        public bool DangNhap(string id, string matKhau)
        {
            bool kq = false;
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "DangNhap";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idNhanVien", id);
            cm.Parameters.AddWithValue("@matKhau", matKhau);
            SqlDataReader dataReader = cm.ExecuteReader();
            if (dataReader.Read())
            {
                kq = true;
            }
            dataReader.Close();
            con.Close();
            return kq;
        }

        public NhanVien_DTO LayNV(string id)
        {
            NhanVien_DTO nv = new NhanVien_DTO();
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT * FROM NHANVIEN WHERE idNhanVien ='" + id + "'";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    if (dataReader.IsDBNull(0) != null)
                    {

                        nv.idNhanVien = dataReader[0].ToString();
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        nv.matKhau = dataReader["matKhau"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        nv.tenNhanVien = dataReader["tenNhanVien"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        nv.cmnd = dataReader["cmnd"].ToString();
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        nv.sdt = dataReader["sdt"].ToString();
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        nv.ngaySinh = (DateTime)dataReader["ngaySinh"];
                    }
                    if (dataReader.IsDBNull(6) != null)
                    {
                        nv.diaChi = dataReader["diaChi"].ToString();
                    }
                    if (dataReader.IsDBNull(7) != null)
                    {
                        nv.loaiNhanVien = dataReader["loaiNhanVien"].ToString();
                    }
                    if (dataReader.IsDBNull(8) != null)
                    {
                        nv.trangThai = (int)dataReader["trangThai"];
                    }
                }
                dataReader.Close();
                con.Close();
            }
            return nv;
        }

        public bool ThemNhanVien(NhanVien_DTO nv)
        {

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "ThemNhanVien";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idNhanVien", nv.idNhanVien);
            cm.Parameters.AddWithValue("@matKhau", nv.matKhau);
            cm.Parameters.AddWithValue("@tenNhanVien", nv.tenNhanVien);
            cm.Parameters.AddWithValue("@cmnd", nv.cmnd);
            cm.Parameters.AddWithValue("@ngaySinh", nv.ngaySinh);
            cm.Parameters.AddWithValue("@sdt", nv.sdt);
            cm.Parameters.AddWithValue("@diaChi", nv.diaChi);
            cm.Parameters.AddWithValue("@loaiNhanVien", nv.loaiNhanVien);
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

        public bool XoaNhanVien(string id)
        {

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "XoaNhanVien";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idNhanVien", id);
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

        public bool SuaNhanVien(NhanVien_DTO nv)
        {

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "SuaNhanVien";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@idNhanVien", nv.idNhanVien);
            cm.Parameters.AddWithValue("@matKhau", nv.matKhau);
            cm.Parameters.AddWithValue("@tenNhanVien", nv.tenNhanVien);
            cm.Parameters.AddWithValue("@cmnd", nv.cmnd);
            cm.Parameters.AddWithValue("@ngaySinh", nv.ngaySinh);
            cm.Parameters.AddWithValue("@sdt", nv.sdt);
            cm.Parameters.AddWithValue("@diaChi", nv.diaChi);
            cm.Parameters.AddWithValue("@loaiNhanVien", nv.loaiNhanVien);
            cm.Parameters.AddWithValue("@trangThai", 1);
            int NumOfRow = cm.ExecuteNonQuery();
            
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
