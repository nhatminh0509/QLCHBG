using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class NhaCungCap_DTO
    {
        // khai báo các biến cùng với phương thức get set
        public string maNCC { set; get; }
        public string tenNhaCungCap   { set; get; }
        public string diaChi { set; get; }
        public string email { set; get; }
        public string sdt { set; get; }
        public string website { set; get; }
        public int trangThai { set; get; }

        // các hàm khởi tạo
        public NhaCungCap_DTO()
        {
            this.maNCC = "";
            this.tenNhaCungCap = "";
            this.diaChi = "";
            this.email = "";
            this.sdt = "";
            this.website = "";
            this.trangThai = 1;
            
        }
        public NhaCungCap_DTO(string maNCC,string tenNhaCungCap,string diaChi,string email,string sdt,string website,int trangThai)
        {
            this.maNCC = maNCC;
            this.tenNhaCungCap = tenNhaCungCap;
            this.diaChi = diaChi;
            this.email = email;
            this.sdt = sdt;
            this.website = website;
            this.trangThai = trangThai;
        }
    }
}
