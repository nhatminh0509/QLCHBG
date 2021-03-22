using DTO;
using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace _0306181057_QLCHBG
{
    public partial class frmInBaoCao : Form
    {
        public frmInBaoCao()
        {
            InitializeComponent();
        }

        private void frmInBaoCao_Load(object sender, EventArgs e)
        {


            
        }
        public void InKH(List<KhachHang_DTO> listKH,string pa)
        {
            this.rpView.LocalReport.ReportEmbeddedResource = "_0306181057_QLCHBG.rpKhachHang.rdlc";
            this.rpView.LocalReport.DataSources.Add(new ReportDataSource("KhachHang_DTO", listKH));
            this.rpView.LocalReport.SetParameters(new ReportParameter("paLoai", pa));
            this.rpView.RefreshReport();
        }

        public void InNCC(List<NhaCungCap_DTO> listNCC, string pa)
        {
            this.rpView.LocalReport.ReportEmbeddedResource = "_0306181057_QLCHBG.rpNhaCungCap.rdlc";
            this.rpView.LocalReport.DataSources.Add(new ReportDataSource("NhaCungCap_DTO", listNCC));
            this.rpView.LocalReport.SetParameters(new ReportParameter("paLoai", pa));
            this.rpView.RefreshReport();
        }

        public void InGiay(List<HienThiGiay_DTO> listGiay, string pa)
        {
            this.rpView.LocalReport.ReportEmbeddedResource = "_0306181057_QLCHBG.rpGiay.rdlc";
            this.rpView.LocalReport.DataSources.Add(new ReportDataSource("HienThiGiay_DTO", listGiay));
            this.rpView.LocalReport.SetParameters(new ReportParameter("paLoai", pa));
            this.rpView.RefreshReport();
        }

        public void InBaoCaoTongQuan(string patieuDe, string paSLNV,string paSLKH,string paSLNCC,string paSLSP,string paNVGN,string paSPBC,string paSLNH,string paTongDoanhThu)
        {
            this.rpView.LocalReport.ReportEmbeddedResource = "_0306181057_QLCHBG.rpTongQuan.rdlc";
            this.rpView.LocalReport.SetParameters(new ReportParameter("paTieuDe", patieuDe));
            this.rpView.LocalReport.SetParameters(new ReportParameter("paSLNV", paSLNV));
            this.rpView.LocalReport.SetParameters(new ReportParameter("paSLKH", paSLKH));
            this.rpView.LocalReport.SetParameters(new ReportParameter("paSLNCC", paSLNCC));
            this.rpView.LocalReport.SetParameters(new ReportParameter("paSLSP", paSLSP));
            this.rpView.LocalReport.SetParameters(new ReportParameter("paNVGN", paNVGN));
            this.rpView.LocalReport.SetParameters(new ReportParameter("paSPBC", paSPBC));
            this.rpView.LocalReport.SetParameters(new ReportParameter("paSLNH", paSLNH));
            this.rpView.LocalReport.SetParameters(new ReportParameter("paTongDoanhThu", paTongDoanhThu));
            this.rpView.RefreshReport();
        }

        public void InTonKho(List<HienThiGiay_DTO> listGiay, string pa)
        {
            this.rpView.LocalReport.ReportEmbeddedResource = "_0306181057_QLCHBG.rpTonKho.rdlc";
            this.rpView.LocalReport.DataSources.Add(new ReportDataSource("HienThiGiay_DTO", listGiay));
            this.rpView.LocalReport.SetParameters(new ReportParameter("paLoai", pa));
            this.rpView.RefreshReport();
        }

        public void InNV(List<NhanVien_DTO> listNV, string pa)
        {
            this.rpView.LocalReport.ReportEmbeddedResource = "_0306181057_QLCHBG.rpNhanVien.rdlc";
            this.rpView.LocalReport.DataSources.Add(new ReportDataSource("NhanVien_DTO", listNV));
            this.rpView.LocalReport.SetParameters(new ReportParameter("paLoai", pa));
            this.rpView.RefreshReport();
        }
    }
}
