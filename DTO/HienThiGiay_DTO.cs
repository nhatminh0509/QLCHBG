using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HienThiGiay_DTO
    {
        // khai báo các biến cùng với phương thức get set
        public int id { set; get; }
        public string tenGiay { set; get; }
        public string size { get; set; }
        public string tenHangGiay { set; get; }
        public string tenLoaiGiay { set; get; }
        public int giaBan { get; set; }
        public int giaNhap { get; set; }
        public int giamGia { set; get; }
        public int soLuong { get; set; }
        public string hinhAnh { get; set; }
        public int trangThai { set; get; }



        // các hàm khởi tạo
        public HienThiGiay_DTO()
        {
            this.id = -1;
            this.tenGiay = "";
            this.size = "";
            this.tenHangGiay = "";
            this.tenLoaiGiay = "";
            this.giaBan = 0;
            this.giaNhap = 0;
            this.giamGia = 0;
            this.soLuong = 0;
            this.hinhAnh = "";
            this.trangThai = 1;
        }
        public HienThiGiay_DTO(int id,string tenGiay,string size,string tenHangGiay,string tenLoaiGiay,int giaBan,int giaNhap,int giamGia,int soLuong,string hinhAnh,int trangThai)
        {
            this.id = id;
            this.tenGiay = tenGiay;
            this.size = size;
            this.tenHangGiay = tenHangGiay;
            this.tenLoaiGiay = tenLoaiGiay;
            this.giaBan = giaBan;
            this.giaNhap = giaNhap;
            this.giamGia = giamGia;
            this.soLuong = soLuong;
            this.hinhAnh = hinhAnh;
            this.trangThai = trangThai;
        }
    }
}
