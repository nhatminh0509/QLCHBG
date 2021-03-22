using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class LoaiGiay_DTO
    {
        // khai báo các biến cùng với phương thức get set
        public int id { set; get; }
        public string tenLoaiGiay { set; get; }
        public int idHang {set;get;}
        public int trangThai { set; get; }



        // các hàm khởi tạo
        public LoaiGiay_DTO()
        {
            this.id = -1;
            this.tenLoaiGiay = "";
            this.idHang=-1;
            this.trangThai = 1;
        }
        public LoaiGiay_DTO(int id, string tenLoaiGiay,int idHang, int trangThai)
        {
            this.id = id;
            this.tenLoaiGiay = tenLoaiGiay;
            this.idHang = idHang;
            this.trangThai = trangThai;
        }
    }
}
