using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class HoaDon_BUS
    {
        public List<HoaDon_DTO> LayDSTheoNgay(DateTime ngayBatDau,DateTime ngayKetThuc)
        {
            HoaDon_DAO objHoaDon_DAO = new HoaDon_DAO();
            return objHoaDon_DAO.LayDanhSachTheoNgay(ngayBatDau,ngayKetThuc);
        }
        public long TongDanhThuTheoThang(int thang)
        {
            HoaDon_DAO objHoaDon_DAO = new HoaDon_DAO();
            return objHoaDon_DAO.TongDoanhThuTheoThang(thang);
        }
        public HoaDon_DTO LayHoaDonChuaThanhToanTheoSDTKH(string sdt)
        {
            HoaDon_DAO objHoaDon_DAO = new HoaDon_DAO();
            return objHoaDon_DAO.LayHoaDonChuaThanhToanTheoSDTKH(sdt);
        }
        public bool Them(HoaDon_DTO hd)
        {
            HoaDon_DAO objHoaDon_DAO = new HoaDon_DAO();
            return objHoaDon_DAO.ThemHD(hd);
        }
        public int LastID()
        {
            HoaDon_DAO objHoaDon_DAO = new HoaDon_DAO();
            return objHoaDon_DAO.LastID();
        }
        public bool CapNhatTien(int idHoaDon,int tongTien,int giamGia,int thanhToan)
        {
            HoaDon_DAO objHoaDon_DAO = new HoaDon_DAO();
            return objHoaDon_DAO.CapNhapTien(idHoaDon,tongTien,giamGia,thanhToan);
        }
        public bool ThanhToan(int idHoaDon,int tongTien,int giamGia,int thanhToan)
        {
            HoaDon_DAO objHoaDon_DAO = new HoaDon_DAO();
            return objHoaDon_DAO.ThanhToan(idHoaDon,tongTien,giamGia,thanhToan);
        }
        public bool Huy(int idHoaDon, int tongTien, int giamGia, int thanhToan)
        {
            HoaDon_DAO objHoaDon_DAO = new HoaDon_DAO();
            return objHoaDon_DAO.Huy(idHoaDon, tongTien, giamGia, thanhToan);
        }
    }
}
