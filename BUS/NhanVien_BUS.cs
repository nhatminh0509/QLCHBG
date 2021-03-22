using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class NhanVien_BUS
    {
        public NhanVien_DTO NhanVienGioiNhatThang(int thang)
        {
            NhanVien_DAO objNhanVien_DAO = new NhanVien_DAO();
            return objNhanVien_DAO.NVGioiNhatThang(thang);
        }
        public int SLSPNhanVienGioiNhatThang(int thang)
        {
            NhanVien_DAO objNhanVien_DAO = new NhanVien_DAO();
            return objNhanVien_DAO.SLSPNVGioiNhatThang(thang);
        }
        public int Count()
        {
            NhanVien_DAO objNhanVien_DAO = new NhanVien_DAO();
            return objNhanVien_DAO.CountNV();
        }
        public List<NhanVien_DTO> LayDanhSach()
        {
            NhanVien_DAO objNhanVien_DAO = new NhanVien_DAO();
            return objNhanVien_DAO.LayDanhSach();
        }
        public List<NhanVien_DTO> Tim(string query)
        {
            NhanVien_DAO objNhanVien_DAO = new NhanVien_DAO();
            return objNhanVien_DAO.TimNV(query);
        }
        public NhanVien_DTO LayNV(string id)
        {
            NhanVien_DAO objNhanVien_DAO = new NhanVien_DAO();
            return objNhanVien_DAO.LayNV(id);
        }
        public bool Them(NhanVien_DTO nv)
        {
            NhanVien_DAO objNhanVien_DAO = new NhanVien_DAO();
            return objNhanVien_DAO.ThemNhanVien(nv);
        }
        public bool Xoa(string id)
        {
            NhanVien_DAO objNhanVien_DAO = new NhanVien_DAO();
            return objNhanVien_DAO.XoaNhanVien(id);
        }
        public bool Sua(NhanVien_DTO nv)
        {
            NhanVien_DAO objNhanVien_DAO = new NhanVien_DAO();
            return objNhanVien_DAO.SuaNhanVien(nv);
        }
        public bool KiemTra(string id)
        {
            NhanVien_DAO objNhanVien_DAO = new NhanVien_DAO();
            return objNhanVien_DAO.KiemTra(id);
        }
        public bool DangNhap(string id, string matKhau)
        {
            NhanVien_DAO objNhanVien_DAO = new NhanVien_DAO();
            return objNhanVien_DAO.DangNhap(id, matKhau);
        }
        public DataTable LayDS()
        {
            NhanVien_DAO objNhanVien_DAO = new NhanVien_DAO();
            return objNhanVien_DAO.LayDS();
        }
    }
}
