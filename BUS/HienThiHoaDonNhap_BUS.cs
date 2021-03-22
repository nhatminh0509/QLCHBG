using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class HienThiHoaDonNhap_BUS
    {
        public List<HienThiHoaDonNhap_DTO> LayDanhSachTheoIDHoaDonNhap(int idHoaDonNhap)
        {
            HienThiHoaDonNhap_DAO objHienThiHoaDonNhap_DAO = new HienThiHoaDonNhap_DAO();
            return objHienThiHoaDonNhap_DAO.LayDanhSachTheoIDHoaDon(idHoaDonNhap);
        }
    }
}
