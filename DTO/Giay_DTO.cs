using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Giay_DTO
    {
        // khai báo các biến cùng với phương thức get set
        public int id { set; get; }
        public string tenGiay { set; get; }
        public int idHangGiay { set; get; }
        public int idLoaiGiay { set; get; }
        public int giamGia { set; get; }
        public string hinhAnh { get; set; }
        public int trangThai    { set; get; }



        // các hàm khởi tạo
        public Giay_DTO()
        {
            this.id = -1;
            this.tenGiay = "";
            this.idHangGiay = -1;
            this.idLoaiGiay = -1;
            this.giamGia = 0;
            this.hinhAnh = "";
            this.trangThai = 1;
        }
        public Giay_DTO(int id, string tenGiay,int idHangGiay,int idLoaiGiay,int giamGia,string hinhAnh, int trangThai)
        {
            this.id = id;
            this.tenGiay = tenGiay;
            this.idHangGiay = idHangGiay;
            this.idLoaiGiay = idLoaiGiay;
            this.giamGia = giamGia;
            this.hinhAnh = hinhAnh;
            this.trangThai = trangThai;
        }
    }
}
