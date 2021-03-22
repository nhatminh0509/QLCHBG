using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class KhachHang_BUS
    {
        public int Count()
        {
            KhachHang_DAO objKhachHang_DAO = new KhachHang_DAO();
            return objKhachHang_DAO.CountKH();
        }
        public KhachHang_DTO LayKH(string sdt)
        {
            KhachHang_DAO objKhachHang_DAO = new KhachHang_DAO();
            return objKhachHang_DAO.LayKH(sdt);
        }
        public List<KhachHang_DTO> LayDanhSach()
        {
            KhachHang_DAO objKhachHang_DAO = new KhachHang_DAO();
            return objKhachHang_DAO.LayDanhSach();
        }
        public List<KhachHang_DTO> Tim(string query)
        {
            KhachHang_DAO objKhachHang_DAO = new KhachHang_DAO();
            return objKhachHang_DAO.TimKH(query);
        }
        public bool KiemTra(string sdt)
        {
            KhachHang_DAO objKhachHang_DAO = new KhachHang_DAO();
            return objKhachHang_DAO.KiemTra(sdt);
        }
        public bool Them(KhachHang_DTO kh)
        {
            KhachHang_DAO objKhachHang_DAO = new KhachHang_DAO();
            return objKhachHang_DAO.ThemKhachHang(kh);
        }
        public bool Xoa(string sdt)
        {
            KhachHang_DAO objKhachHang_DAO = new KhachHang_DAO();
            return objKhachHang_DAO.XoaKhachHang(sdt);
        }
        public bool Sua(KhachHang_DTO kh)
        {
            KhachHang_DAO objKhachHang_DAO = new KhachHang_DAO();
            return objKhachHang_DAO.SuaKhachHang(kh);
        }
        public bool ThanhToan(string sdt, int soTien)
        {
            KhachHang_DAO objKhachHang_DAO = new KhachHang_DAO();
            return objKhachHang_DAO.ThanhToan(sdt, soTien);
        }
    }
}
