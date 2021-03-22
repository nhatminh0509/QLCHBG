using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HoaDonNhap_DTO
    {
        // khai báo các biến cùng với phương thức get set
        public int id { set; get; }
        public string idNhanVien { set; get; }
        public string maNCC { set; get; }
        public DateTime? ngayNhap { set; get; }
        public int tongTien { get; set; }
        public int trangThai { set; get; }



        // các hàm khởi tạo
        public HoaDonNhap_DTO()
        {
            this.id = -1;
            this.idNhanVien = "";
            this.maNCC = "";
            this.ngayNhap = DateTime.Now;
            this.tongTien = 0;
            this.trangThai = 1;
        }
        public HoaDonNhap_DTO(int id, string idNhanVien, string maNCC, DateTime? ngayNhap, int tongTien, int trangThai)
        {
            this.id = id;
            this.idNhanVien = idNhanVien;
            this.maNCC = maNCC;
            this.ngayNhap = ngayNhap;
            this.tongTien = tongTien;
            this.trangThai = trangThai;
        }
    }
}
