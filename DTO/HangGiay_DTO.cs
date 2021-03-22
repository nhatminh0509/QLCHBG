using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HangGiay_DTO
    {
        // khai báo các biến cùng với phương thức get set
        public int id { set; get; }
        public string tenHang { set; get; }
        public int trangThai { set; get; }
        


        // các hàm khởi tạo
        public HangGiay_DTO()
        {
            this.id = -1;
            this.tenHang = "";
            this.trangThai = 1;
        }
        public HangGiay_DTO(int id, string tenHang, int trangThai)
        {
            this.id = id;
            this.tenHang = tenHang;
            this.trangThai = trangThai;
        }
    }
}
