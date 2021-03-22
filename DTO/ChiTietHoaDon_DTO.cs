using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ChiTietHoaDon_DTO
    {
        // khai báo các biến cùng với phương thức get set
        public int idHoaDon { set; get; }
        public int idGiay { set; get; }
        public string size { get; set; }
        public int soLuong{set;get;}


        // các hàm khởi tạo
        public ChiTietHoaDon_DTO()
        {
            this.idHoaDon = -1;
            this.idGiay = -1;
            this.size = "";
            this.soLuong = 0;
        }
        public ChiTietHoaDon_DTO(int idHoaDon, int idGiay,string size,int soLuong)
        {
            this.idHoaDon = idHoaDon;
            this.idGiay = idGiay;
            this.size = size;
            this.soLuong = soLuong;
        }
    }
}
