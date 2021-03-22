using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HienThiHoaDon_DTO
    {
        public int idGiay { get; set; }
        public string tenGiay {get;set;}
        public string size { set; get; }
        public int soLuong{set;get;}
        public int donGia{get;set;}
        public int giamGia{get;set;}
        public int thanhTien{get;set;}



        // các hàm khởi tạo
        public HienThiHoaDon_DTO()
        {
            this.idGiay = -1;
            this.tenGiay="";
            this.size="";
            this.soLuong=0;
            this.donGia=0;
            this.giamGia=0;
            this.thanhTien = 0;
        }
        public HienThiHoaDon_DTO(int idGiay,string tenGiay, string size, int soLuong,int donGia,int giamGia,int thanhTien)
        {
            this.idGiay = idGiay;
            this.tenGiay = tenGiay;
            this.size = size;
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.giamGia = giamGia;
            this.thanhTien = thanhTien;
        }
    }
}

