using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class HienThiGiay_BUS
    {
        public List<HienThiGiay_DTO> LayDanhSach()
        {
            HienThiGiay_DAO objHienThiGiay_DAO = new HienThiGiay_DAO();
            return objHienThiGiay_DAO.LayDanhSach();
        }
        public List<HienThiGiay_DTO> Tim(string query)
        {
            HienThiGiay_DAO objHienThiGiay_DAO = new HienThiGiay_DAO();
            return objHienThiGiay_DAO.TimSP(query);
        }
    }
}
