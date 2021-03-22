using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class NhanVien_DTO
    {
        // khai báo các biến cùng với phương thức get set
        public string idNhanVien { set; get; }
        public string matKhau { get; set; }
        public string tenNhanVien { set; get; }
        public string cmnd { set; get; }
        public string sdt { set; get; }
        public DateTime ngaySinh { set; get; }
        public string diaChi { set; get; }
        public string loaiNhanVien { set; get; }
        public int trangThai { set; get; }
        // các hàm khởi tạo
        public NhanVien_DTO()
        {
            this.idNhanVien = "";
            this.matKhau = "";
            this.tenNhanVien = "";
            this.cmnd = "";
            this.sdt = "";
            this.diaChi = "";
            ngaySinh = DateTime.Now.Date;
            this.loaiNhanVien = "";
            this.trangThai = 1;
        }
        public NhanVien_DTO(string idNhanVien, string matKhau, string tenNhanVien, string cmnd, string sdt, DateTime ngaySinh, string diaChi, string loaiNhanVien, int trangThai)
        {
            this.idNhanVien = idNhanVien;
            this.matKhau = matKhau;
            this.tenNhanVien = tenNhanVien;
            this.cmnd = cmnd;
            this.sdt = sdt;
            this.diaChi = diaChi;
            this.loaiNhanVien = loaiNhanVien;
            this.trangThai = trangThai;
            this.ngaySinh = ngaySinh;
        }
    }
}
