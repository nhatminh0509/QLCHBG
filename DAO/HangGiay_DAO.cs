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
    public class HangGiay_DAO
    {
        public List<HangGiay_DTO> LayDanhSach()
        {

            List<HangGiay_DTO> listHG = new List<HangGiay_DTO>();

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = @"Select * FROM HangGiay WHERE trangThai = 1";


                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    HangGiay_DTO hg = new HangGiay_DTO();

                    if (dataReader.IsDBNull(0) != null)
                    {

                        hg.id = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        hg.tenHang = dataReader["tenHang"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        hg.trangThai = (int)dataReader["trangThai"];
                    }
                    listHG.Add(hg);
                }

                dataReader.Close();
                con.Close();
            }
            return listHG;
        }

        public bool ThemHangGiay(HangGiay_DTO hg)
        {

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "ThemHangGiay";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@tenHang", hg.tenHang);
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

        public bool XoaHangGiay(int id)
        {

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "XoaHangGiay";
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

        public bool SuaHangGiay(HangGiay_DTO hg)
        {

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "SuaHangGiay";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@id", hg.id);
            cm.Parameters.AddWithValue("@tenHang", hg.tenHang);
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

        public string LayTenBangID(int id)
        {
            string tenHangGiay="";

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = @"Select tenHang FROM HangGiay WHERE trangThai = 1 and id = " + id;


                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    if (dataReader.IsDBNull(0) != null)
                    {
                        tenHangGiay = dataReader[0].ToString();
                    }
                }
            }
            con.Close();
            return tenHangGiay;
        }

        public int LastID()
        {
            int lastID = -1;
            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = @"Select Max(id) FROM HangGiay WHERE trangThai = 1";

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
