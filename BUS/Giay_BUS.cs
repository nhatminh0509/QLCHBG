using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class Giay_BUS
    {
        public int Count()
        {
            Giay_DAO objGiay_DAO = new Giay_DAO();
            return objGiay_DAO.CountGiay();
        }
        public int SLGiayDaBanTheoNgay(int idGiay,string size,DateTime ngayBatDau,DateTime ngayKetThuc)
        {
            Giay_DAO objGiay_DAO = new Giay_DAO();
            return objGiay_DAO.SLGiayDaBanTheoNgay(idGiay,size,ngayBatDau,ngayKetThuc);
        }
        public int SLGiayBanChayNhatTheoThang(int thang)
        {
            Giay_DAO objGiay_DAO = new Giay_DAO();
            return objGiay_DAO.SLGiayBanChayNhatTheoThang(thang);

        }
        public Giay_DTO TimGiayBanChayTheoThang(int thang)
        {
            Giay_DAO objGiay_DAO = new Giay_DAO();
            return objGiay_DAO.TimGiayBanChayTheoThang(thang);
        }
        public List<Giay_DTO> LayDanhSach()
        {
            Giay_DAO objGiay_DAO = new Giay_DAO();
            return objGiay_DAO.LayDanhSach();
        }
        public List<Giay_DTO> Tim(string tenGiay)
        {
            string query = "Select * FROM Giay WHERE trangThai = 1 and tenGiay like '%"+tenGiay+"%'";
            Giay_DAO objGiay_DAO = new Giay_DAO();
            return objGiay_DAO.TimGiay(query);
        }
        public bool Them(Giay_DTO giay)
        {
            Giay_DAO objGiay_DAO = new Giay_DAO();
            return objGiay_DAO.ThemGiay(giay);
        }
        public bool Xoa(int id)
        {
            Giay_DAO objGiay_DAO = new Giay_DAO();
            return objGiay_DAO.XoaGiay(id);
        }
        public bool Sua(Giay_DTO giay)
        {
            Giay_DAO objGiay_DAO = new Giay_DAO();
            return objGiay_DAO.SuaGiay(giay);
        }
        public int LastID()
        {
            Giay_DAO objGiay_DAO = new Giay_DAO();
            return objGiay_DAO.LastID();
        }
    }
}
