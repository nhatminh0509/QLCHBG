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
    public class LoaiGiay_DAO
    {
        public List<LoaiGiay_DTO> LayDanhSach(int id)
        {

            List<LoaiGiay_DTO> listLG = new List<LoaiGiay_DTO>();

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = @"Select * FROM LoaiGiay WHERE trangThai = 1 and idHang = "+id;


                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    LoaiGiay_DTO lg = new LoaiGiay_DTO();

                    if (dataReader.IsDBNull(0) != null)
                    {

                        lg.id = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        lg.tenLoaiGiay = dataReader["tenLoaiGiay"].ToString();
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        lg.idHang = (int)dataReader["idHang"];
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        lg.trangThai = (int)dataReader["trangThai"];
                    }
                    listLG.Add(lg);
                }

                dataReader.Close();
                con.Close();
            }
            return listLG;
        }

        public bool ThemLoaiGiay(LoaiGiay_DTO lg)
        {

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "ThemLoaiGiay";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@tenLoaiGiay", lg.tenLoaiGiay);
            cm.Parameters.AddWithValue("@idHang", lg.idHang);
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

        public bool XoaLoaiGiay(int id)
        {

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "XoaLoaiGiay";
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

        public bool SuaLoaiGiay(LoaiGiay_DTO lg)
        {

            SqlConnection con = DataProvider.TaoKetNoi();

            string query = "SuaLoaiGiay";
            SqlCommand cm = new SqlCommand(query, con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@id", lg.id);
            cm.Parameters.AddWithValue("@tenLoaiGiay", lg.tenLoaiGiay);
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
            string tenLoai = "";

            SqlConnection con = DataProvider.TaoKetNoi();

            if (con != null)
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = @"Select tenLoaiGiay FROM LoaiGiay WHERE trangThai = 1 and id = " + id;


                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    if (dataReader.IsDBNull(0) != null)
                    {
                        tenLoai = dataReader[0].ToString();
                    }
                }
            }
            con.Close();
            return tenLoai;
        }
    }
}
