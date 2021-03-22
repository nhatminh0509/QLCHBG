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
    public class NhaCungCap_DAO
    {
        public int CountNCC()
        {
            int count = 0;

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = "Select COUNT(maNCC) from NhaCungCap where trangThai = 1";

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

        public NhaCungCap_DTO LayNCC(string maNCC)
        {
            NhaCungCap_DTO ncc = new NhaCungCap_DTO();
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT * FROM NhaCungCap WHERE maNCC = N'" + maNCC + "' and trangThai = 1";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    if (dataReader.IsDBNull(0) != null)
                    {

                        ncc.maNCC = dataReader[0].ToString();
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        ncc.tenNhaCungCap = dataReader["tenNhaCungCap"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        ncc.sdt = dataReader["sdt"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        ncc.email = dataReader["email"].ToString();
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        ncc.diaChi = dataReader["diaChi"].ToString();
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        ncc.website = dataReader["website"].ToString();
                    }

                }
                dataReader.Close();
                con.Close();
            }
            return ncc;
        }

        public List<NhaCungCap_DTO> LayDanhSach()
        {
            List<NhaCungCap_DTO> listNCC = new List<NhaCungCap_DTO>();
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT * FROM NhaCungCap where trangThai = 1";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    NhaCungCap_DTO ncc = new NhaCungCap_DTO();
                    if (dataReader.IsDBNull(0) != null)
                    {

                        ncc.maNCC = dataReader[0].ToString();
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        ncc.tenNhaCungCap = dataReader["tenNhaCungCap"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        ncc.sdt = dataReader["sdt"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        ncc.email = dataReader["email"].ToString();
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        ncc.diaChi = dataReader["diaChi"].ToString();
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        ncc.website = dataReader["website"].ToString();
                    }
                    listNCC.Add(ncc);
                }
                dataReader.Close();
                con.Close();
            }
            return listNCC;
        }

        public List<NhaCungCap_DTO> TimNCC(string query)
        {
            List<NhaCungCap_DTO> listNCC = new List<NhaCungCap_DTO>();
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();

                command.CommandText = query;
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    NhaCungCap_DTO ncc = new NhaCungCap_DTO();
                    if (dataReader.IsDBNull(0) != null)
                    {

                        ncc.maNCC = dataReader[0].ToString();
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        ncc.tenNhaCungCap = dataReader["tenNhaCungCap"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        ncc.sdt = dataReader["sdt"].ToString();
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        ncc.email = dataReader["email"].ToString();
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        ncc.diaChi = dataReader["diaChi"].ToString();
                    }
                    if (dataReader.IsDBNull(5) != null)
                    {
                        ncc.website = dataReader["website"].ToString();
                    }
                    listNCC.Add(ncc);
                }
                dataReader.Close();
                con.Close();
            }
            return listNCC;
        }

        public bool KiemTra(string maNCC)
        {
            bool kq = false;
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = @"SELECT * FROM NhaCungCap WHERE maNCC = N'" + maNCC + "'";
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

        public bool ThemNCC(NhaCungCap_DTO ncc)
        {

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "ThemNCC";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@maNCC", ncc.maNCC);
            cm.Parameters.AddWithValue("@tenNCC", ncc.tenNhaCungCap);
            cm.Parameters.AddWithValue("@sdt", ncc.sdt);
            cm.Parameters.AddWithValue("@email", ncc.email);
            cm.Parameters.AddWithValue("@diaChi", ncc.diaChi);
            cm.Parameters.AddWithValue("@website", ncc.website);
            cm.Parameters.AddWithValue("@trangThai", ncc.trangThai);
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

        public bool XoaNCC(string maNCC)
        {

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "XoaNCC";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@maNCC", maNCC);
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

        public bool SuaNCC(NhaCungCap_DTO ncc)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "SuaNCC";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@maNCC", ncc.maNCC);
            cm.Parameters.AddWithValue("@tenNCC", ncc.tenNhaCungCap);
            cm.Parameters.AddWithValue("@sdt", ncc.sdt);
            cm.Parameters.AddWithValue("@email", ncc.email);
            cm.Parameters.AddWithValue("@diaChi", ncc.diaChi);
            cm.Parameters.AddWithValue("@website", ncc.website);
            cm.Parameters.AddWithValue("@trangThai", ncc.trangThai);
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
