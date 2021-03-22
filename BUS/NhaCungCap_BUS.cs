using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class NhaCungCap_BUS
    {
        public int Count()
        {
            NhaCungCap_DAO objNCC_DAO = new NhaCungCap_DAO();
            return objNCC_DAO.CountNCC();
        
        }
        public NhaCungCap_DTO LayNCC(string maNCC)
        {
            NhaCungCap_DAO objNCC_DAO = new NhaCungCap_DAO();
            return objNCC_DAO.LayNCC(maNCC);
        }
        public List<NhaCungCap_DTO> LayDanhSach()
        {
            NhaCungCap_DAO objNCC_DAO = new NhaCungCap_DAO();
            return objNCC_DAO.LayDanhSach();
        }
        public List<NhaCungCap_DTO> Tim(string query)
        {
            NhaCungCap_DAO objNCC_DAO = new NhaCungCap_DAO();
            return objNCC_DAO.TimNCC(query);
        }
        public bool KiemTra(string maNCC)
        {
            NhaCungCap_DAO objNCC_DAO = new NhaCungCap_DAO();
            return objNCC_DAO.KiemTra(maNCC);
        }
        public bool Them(NhaCungCap_DTO ncc)
        {
            NhaCungCap_DAO objNCC_DAO = new NhaCungCap_DAO();
            return objNCC_DAO.ThemNCC(ncc);
        }
        public bool Xoa(string maNCC)
        {
            NhaCungCap_DAO objNCC_DAO = new NhaCungCap_DAO();
            return objNCC_DAO.XoaNCC(maNCC);
        }
        public bool Sua(NhaCungCap_DTO ncc)
        {
            NhaCungCap_DAO objNCC_DAO = new NhaCungCap_DAO();
            return objNCC_DAO.SuaNCC(ncc);
        }
    }
}
