using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class BangSize_DTO
    {
        // khai báo các biến cùng với phương thức get set
        public int idGiay { set; get; }
        public string sizeGiay { set; get; }
        public int giaBan { set; get; }
        public int giaNhap { set; get; }
        public int soLuong { set; get; }
        public int trangThai { set; get; }



        // các hàm khởi tạo
        public BangSize_DTO()
        {
            this.idGiay = -1;
            this.sizeGiay = "";
            this.giaBan = 0;
            this.giaNhap = 0;
            this.soLuong = 0;
            this.trangThai = 1;
        }
        public BangSize_DTO(int idGiay, string sizeGiay, int giaBan, int giaNhap,int soLuong, int trangThai)
        {
            this.idGiay = idGiay;
            this.sizeGiay = sizeGiay;
            this.giaBan = giaBan;
            this.giaNhap = giaNhap;
            this.soLuong = soLuong;
            this.trangThai = trangThai;
        }
    }
}
