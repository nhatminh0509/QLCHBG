using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class HangGiay_BUS
    {
        public List<HangGiay_DTO> LayDanhSach()
        {
            HangGiay_DAO objHangGiay_DAO = new HangGiay_DAO();
            return objHangGiay_DAO.LayDanhSach();
        }
        public bool Them(HangGiay_DTO hg)
        {
            HangGiay_DAO objHangGiay_DAO = new HangGiay_DAO();
            return objHangGiay_DAO.ThemHangGiay(hg);
        }
        public bool Xoa(string id)
        {
            HangGiay_DAO objHangGiay_DAO = new HangGiay_DAO();
            return objHangGiay_DAO.XoaHangGiay(int.Parse(id));
        }
        public bool Sua(HangGiay_DTO hg)
        {
            HangGiay_DAO objHangGiay_DAO = new HangGiay_DAO();
            return objHangGiay_DAO.SuaHangGiay(hg);
        }
        public string LayTenBangID(int id)
        {
            HangGiay_DAO objHangGiay_DAO = new HangGiay_DAO();
            return objHangGiay_DAO.LayTenBangID(id);
        }
        public int LastID()
        {
            HangGiay_DAO objHangGiay_DAO = new HangGiay_DAO();
            return objHangGiay_DAO.LastID();
        }
    }
}
