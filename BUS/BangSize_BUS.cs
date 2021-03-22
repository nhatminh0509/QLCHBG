using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BangSize_BUS
    {
        public bool KiemTra(BangSize_DTO size)
        {
            BangSize_DAO bangsize_dao = new BangSize_DAO();
            return bangsize_dao.KiemTra(size.idGiay,size.sizeGiay);
        }
        public List<BangSize_DTO> LayDanhSachTheoIDGiay(int idGiay)
        {
            BangSize_DAO objBangSize_DAO = new BangSize_DAO();
            return objBangSize_DAO.LayDanhSach(idGiay);
        }
        public bool Them(BangSize_DTO size)
        {
            BangSize_DAO objBangSize_DAO = new BangSize_DAO();
            return objBangSize_DAO.ThemSize(size);
        }
        public bool Xoa(int idGiay,string size)
        {
            BangSize_DAO objBangSize_DAO = new BangSize_DAO();
            return objBangSize_DAO.XoaSize(idGiay,size);
        }
        public bool Sua(BangSize_DTO size)
        {
            BangSize_DAO objBangSize_DAO = new BangSize_DAO();
            return objBangSize_DAO.SuaSize(size);
        }
        public bool CapNhatSLDaBan(int idGiay,string size,int soLuongDaBan)
        {
            BangSize_DAO objBangSize_DAO = new BangSize_DAO();
            return objBangSize_DAO.CapNhatSLDaBan(idGiay, size, soLuongDaBan);
        }
        public bool CapNhatKho(int idGiay, string size, int soLuongDaNhap,int giaNhap)
        {
            BangSize_DAO objBangSize_DAO = new BangSize_DAO();
            return objBangSize_DAO.CapNhatKho(idGiay, size, soLuongDaNhap,giaNhap);
        }
    }
}
