using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HoaDon_DTO
    {
        // khai báo các biến cùng với phương thức get set
        public int id { set; get; }
        public string idNhanVien { set; get; }
        public string sdtKhachHang { set; get; }
        public DateTime? ngayLap { set; get; }
        public int tongTien { set; get; }
        public int giamGia { set; get; }
        public int thanhToan{set;get;}
        public int trangThai { set; get; }



        // các hàm khởi tạo
        public HoaDon_DTO()
        {
            this.id = -1;
            this.idNhanVien = "";
            this.sdtKhachHang = "";
            this.ngayLap = DateTime.Now;
            this.tongTien = 0;
            this.giamGia = 0;
            this.thanhToan = 0;
            this.trangThai = 1;
        }
        public HoaDon_DTO(int id, string idNhanVien, string sdtKhachHang, DateTime? ngayLap, int tongTien,int giamGia,int thanhToan, int trangThai)
        {
            this.id = id;
            this.idNhanVien = idNhanVien;
            this.sdtKhachHang = sdtKhachHang;
            this.ngayLap = ngayLap;
            this.tongTien = tongTien;
            this.giamGia = giamGia;
            this.thanhToan = thanhToan;
            this.trangThai = trangThai;
        }
    }
}
