using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class LoaiGiay_BUS
    {
        public List<LoaiGiay_DTO> LayDanhSachTheoIDHang(int idHang)
        {
            LoaiGiay_DAO objLoaiGiay_DAO = new LoaiGiay_DAO();
            return objLoaiGiay_DAO.LayDanhSach(idHang);
        }
        public bool Them(LoaiGiay_DTO lg)
        {
            LoaiGiay_DAO objLoaiGiay_DAO = new LoaiGiay_DAO();
            return objLoaiGiay_DAO.ThemLoaiGiay(lg);
        }
        public bool Xoa(string id)
        {
            LoaiGiay_DAO objLoaiGiay_DAO = new LoaiGiay_DAO();
            return objLoaiGiay_DAO.XoaLoaiGiay(int.Parse(id));
        }
        public bool Sua(LoaiGiay_DTO lg)
        {
            LoaiGiay_DAO objLoaiGiay_DAO = new LoaiGiay_DAO();
            return objLoaiGiay_DAO.SuaLoaiGiay(lg);
        }
        public string LayTenBangID(int id)
        {
            LoaiGiay_DAO objLoaiGiay_DAO = new LoaiGiay_DAO();
            return objLoaiGiay_DAO.LayTenBangID(id);
        }
    }
}
