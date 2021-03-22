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
    public partial class frmThemNhanhNCC : Form
    {
        public frmThemNhanhNCC()
        {
            InitializeComponent();
        }

        public void Load(string maNCC)
        {
            txtMaNCC.Text = maNCC;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhaCungCap_DTO ncc = new NhaCungCap_DTO(txtMaNCC.Text, txtTenNCC.Text, txtDiaChiNCC.Text, txtEmail.Text, txtSDT.Text, txtWebsite.Text, 1);
            NhaCungCap_BUS ncc_bus = new NhaCungCap_BUS();
            if (ncc_bus.Them(ncc))
            {
                MessageBox.Show("Thêm thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
