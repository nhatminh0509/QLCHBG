using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HoaDonNhap_BUS
    {
        public int SoLanNhapTheoThang(int thang)
        {
            HoaDonNhap_DAO objHoaDonNhap_DAO = new HoaDonNhap_DAO();
            return objHoaDonNhap_DAO.SoLanNhapHangTheoThang(thang);
        }
        public HoaDonNhap_DTO LayHoaDonChuaNhapTheoMaNCC(string maNCC)
        {
            HoaDonNhap_DAO objHoaDonNhap_DAO = new HoaDonNhap_DAO();
            return objHoaDonNhap_DAO.LayHoaDonChuaNhapTheoMaNCC(maNCC);
        }
        public bool Them(HoaDonNhap_DTO hd_nhap)
        {
            HoaDonNhap_DAO objHoaDonNhap_DAO = new HoaDonNhap_DAO();
            return objHoaDonNhap_DAO.ThemHD(hd_nhap);
        }
        public int LastID()
        {
            HoaDonNhap_DAO objHoaDonNhap_DAO = new HoaDonNhap_DAO();
            return objHoaDonNhap_DAO.LastID();
        }
        public bool CapNhatTien(int idHoaDonNhap, int tongTien)
        {
            HoaDonNhap_DAO objHoaDonNhap_DAO = new HoaDonNhap_DAO();
            return objHoaDonNhap_DAO.CapNhapTien(idHoaDonNhap, tongTien);
        }
        public bool NhapKho(int idHoaDonNhap, int tongTien)
        {
            HoaDonNhap_DAO objHoaDonNhap_DAO = new HoaDonNhap_DAO();
            return objHoaDonNhap_DAO.ThanhToan(idHoaDonNhap, tongTien);
        }
        public bool Huy(int idHoaDonNhap, int tongTien)
        {
            HoaDonNhap_DAO objHoaDonNhap_DAO = new HoaDonNhap_DAO();
            return objHoaDonNhap_DAO.Huy(idHoaDonNhap,tongTien);
        }
    }
}
