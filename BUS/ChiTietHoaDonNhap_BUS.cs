using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class ChiTietHoaDonNhap_BUS
    {
        public bool Them(ChiTietHoaDonNhap_DTO cthd_nhap)
        {
            ChiTietHoaDonNhap_DAO objChiTietHoaDonNhap_DAO = new ChiTietHoaDonNhap_DAO();
            return objChiTietHoaDonNhap_DAO.ThemCTHDNhap(cthd_nhap);
        }
    }
}
