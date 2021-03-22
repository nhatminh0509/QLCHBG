using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ChiTietHoaDonNhap_DTO
    {
        // khai báo các biến cùng với phương thức get set
        public int idHoaDonNhap { set; get; }
        public int idGiay { set; get; }
        public string size { get; set; }
        public int soLuong { set; get; }
        public int donGia { set; get; }


        // các hàm khởi tạo
        public ChiTietHoaDonNhap_DTO()
        {
            this.idHoaDonNhap = -1;
            this.idGiay = -1;
            this.size = "";
            this.soLuong = 0;
            this.donGia = 0;
        }
        public ChiTietHoaDonNhap_DTO(int idHoaDonNhap, int idGiay,string size, int soLuong,int donGia)
        {
            this.idHoaDonNhap = idHoaDonNhap;
            this.idGiay = idGiay;
            this.size = size;
            this.soLuong = soLuong;
            this.donGia = donGia;
        }
    }
}
