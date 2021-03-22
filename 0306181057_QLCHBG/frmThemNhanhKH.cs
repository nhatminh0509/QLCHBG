using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0306181057_QLCHBG
{
    public partial class frmThemNhanhKH : Form
    {
        public frmThemNhanhKH()
        {
            InitializeComponent();
            dtpNgaySinhKH.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            dtpNgaySinhKH.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinhKH.Value = DateTime.Now.Date;
        }

        public void Load(string sdt)
        {
            txtSDTKH.Text = sdt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhachHang_DTO kh = new KhachHang_DTO(txtSDTKH.Text, txtTenKH.Text, txtCMNDKH.Text, dtpNgaySinhKH.Value, txtDiaChiKH.Text, 0, 1);
            KhachHang_BUS kh_bus = new KhachHang_BUS();
            if (kh_bus.Them(kh))
            {
                MessageBox.Show("Thêm thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void txtCMNDKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
