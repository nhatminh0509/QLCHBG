using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class ChiTietHoaDon_BUS
    {
        public bool Them(ChiTietHoaDon_DTO cthd)
        {
            ChiTietHoaDon_DAO objChiTietHoaDon_DAO = new ChiTietHoaDon_DAO();
            return objChiTietHoaDon_DAO.ThemCTHD(cthd);
        }
    }
}
