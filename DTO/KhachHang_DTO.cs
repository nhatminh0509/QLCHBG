using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class KhachHang_DTO
    {
        // khai báo các biến cùng với phương thức get set
        public string sdt { set; get; }
        public string tenKhachHang { set; get; }
        public string cmnd { set; get; }
        public DateTime? ngaySinh { get; set; }
        public string diaChi { set; get; }
        public int tongChiTieu { set; get; }
        public int trangThai { get; set; }

        // các hàm khởi tạo
        public KhachHang_DTO()
        {
            this.sdt = "";
            this.tenKhachHang = "";
            this.cmnd = "";
            this.ngaySinh = DateTime.Now.Date;
            this.diaChi = "";
            this.tongChiTieu = 0;
            this.trangThai = 1;

        }
        public KhachHang_DTO(string sdt, string tenKhachHang,string cmnd,DateTime? ngaySinh,string diaChi, int tongChiTieu,int trangThai)
        {
            this.sdt = sdt;
            this.tenKhachHang = tenKhachHang;
            this.cmnd = cmnd;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.tongChiTieu = tongChiTieu;
            this.trangThai = trangThai;
        }
    }
}
