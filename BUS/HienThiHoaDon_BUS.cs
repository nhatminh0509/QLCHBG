using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class HienThiHoaDon_BUS
    {
        public List<HienThiHoaDon_DTO> LayDanhSachTheoIDHoaDon(int idHoaDon)
        {
            HienThiHoaDon_DAO objHienThiHoaDon_DAO = new HienThiHoaDon_DAO();
            return objHienThiHoaDon_DAO.LayDanhSachTheoIDHoaDon(idHoaDon);
        }
    }
}
