using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0306181057_QLCHBG
{
    public partial class frmQuanLi : Form
    {
        public frmQuanLi()
        {
            InitializeComponent();
        }

        private void frmQuanLi_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            dtpNgaySinh.Value = DateTime.Now.Date;
            dtpNgaySinhKH.Value = DateTime.Now.Date;
            cbLoaiNhanVien.Items.Add("Quản Lí");
            cbLoaiNhanVien.Items.Add("Thu Ngân");
            cbLoaiNhanVien.Items.Add("Kho");
            dtpNgaySinhKH.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            dtpNgaySinhKH.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            CapNhatDSNhanVien();
            CapNhatDSKhachHang();
            LoadHangGiay();
            CapNhapDanhSachGiay();
            CapNhatDSNCC();
            lblThangNamHienTai.Text = "Tháng " + DateTime.Now.Month +" Năm "+DateTime.Now.Year;
            LoadSLNV();
            LoadSLKH();
            LoadSLNCC();
            LoadSLGiay();
            LoadSPBanChayTheoThang();
            LoadTongDoanhThuTheoThang();
            LoadSLNhapTheoThang();
            LoadNVGioiNhatThang();
            LoadDateTimePickerHD();
            LoadDateTimePickerDoanhThu();
            LoadHD();
            LoadDoanhThuTatCa();
            LoadTenGiay();
        }

        private void frmQuanLi_Resize(object sender, EventArgs e)
        {
            frmQuanLi f = (sender as frmQuanLi);

            if (f.Size.Width == 1090 && f.Size.Height == 708)
            {
                pnTV.Size = (new Size(380, 347));
            }
            else
            {
                pnTV.Size = (new Size(500, 347));
            }
        }

        public void ResetThongTin()
        {
            txtID.Text = "";
            txtTenNhanVien.Text = "";
            txtMatKhau.Text = "";
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            cbLoaiNhanVien.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            txtSDT.Text = "";
            txtSDTKH.Text = "";
            txtTenKH.Text = "";
            txtCMNDKH.Text = "";
            txtDiaChiKH.Text = "";
            dtpNgaySinhKH.Value = DateTime.Now;
            txtTim.Text = "";
            txtTimKH.Text = "";
        }

        #region QLNV
        #region Hàm

        public void CapNhatDSNhanVien()
        {
            NhanVien_BUS nv = new NhanVien_BUS();
            dtgvDSNV.AutoGenerateColumns = false;
            dtgvDSNV.DataSource = nv.LayDanhSach();
            dtgvDSNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvDSNV.ReadOnly = true;
        }

        #endregion

        #region Sự Kiện

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO(txtID.Text, txtMatKhau.Text, txtTenNhanVien.Text, txtCMND.Text, txtSDT.Text, dtpNgaySinh.Value, txtDiaChi.Text, cbLoaiNhanVien.Text, 1);
            NhanVien_BUS nv_bus = new NhanVien_BUS();
            if (nv_bus.KiemTra(nv.idNhanVien) != true)
            {
                if (nv_bus.Them(nv))
                {
                    MessageBox.Show("Thêm thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CapNhatDSNhanVien();
                    ResetThongTin();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (MessageBox.Show("ID: " + nv.idNhanVien + " đã tồn tại. Bạn có muốn thay đổi thông tin nhân viên này ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    btnSua.PerformClick();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.idNhanVien = txtID.Text;
            NhanVien_BUS nv_bus = new NhanVien_BUS();
            if (nv_bus.Xoa(nv.idNhanVien))
            {
                MessageBox.Show("Xóa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CapNhatDSNhanVien();
                ResetThongTin();
            }
            else
            {
                MessageBox.Show("Xóa thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO(txtID.Text, txtMatKhau.Text, txtTenNhanVien.Text, txtCMND.Text, txtSDT.Text, dtpNgaySinh.Value, txtDiaChi.Text, cbLoaiNhanVien.Text, 1);
            NhanVien_BUS nv_bus = new NhanVien_BUS();
            if (nv_bus.Sua(nv))
            {
                MessageBox.Show("Sửa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CapNhatDSNhanVien();
                ResetThongTin();
            }
            else
            {
                MessageBox.Show("Sửa thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgvDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NhanVien_BUS nv_bus = new NhanVien_BUS();
            int numrow;
            numrow = e.RowIndex;
            if (numrow != -1)
            {
                if (dtgvDSNV.Rows[numrow].Cells[0].Value.ToString() != "")
                {
                    txtID.Text = dtgvDSNV.Rows[numrow].Cells[0].Value.ToString();
                    txtTenNhanVien.Text = dtgvDSNV.Rows[numrow].Cells[1].Value.ToString();
                    txtCMND.Text = dtgvDSNV.Rows[numrow].Cells[2].Value.ToString();
                    txtSDT.Text = dtgvDSNV.Rows[numrow].Cells[3].Value.ToString();
                    dtpNgaySinh.Value = Convert.ToDateTime(dtgvDSNV.Rows[numrow].Cells[4].Value.ToString());
                    txtDiaChi.Text = dtgvDSNV.Rows[numrow].Cells[5].Value.ToString();
                    cbLoaiNhanVien.Text = dtgvDSNV.Rows[numrow].Cells[6].Value.ToString();
                    txtMatKhau.Text = nv_bus.LayNV(txtID.Text).matKhau;
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            NhanVien_BUS nv_bus = new NhanVien_BUS();
            string query = "SELECT * FROM NhanVien where ";
            if (rdbTatCaNV.Checked)
            {
                txtTim.Text = "";
                CapNhatDSNhanVien();
                return;
            }
            else if(rdbDaXoaNV.Checked)
            {
                query += "trangThai = 0";
            }
            else if (rdbIDNV.Checked)
            {
                query = query + "trangThai = 1 and idNhanVien = N'" + txtTim.Text + "'";
            }
            else if (rdbTenNV.Checked)
            {
                query = query + "trangThai = 1 and tenNhanVien Like N'%" + txtTim.Text + "%'";
            }
            else if (rdbDiaChiNV.Checked)
            {
                query = query + "trangThai = 1 and diaChi Like N'%" + txtTim.Text + "%'";
            }
            else if (rdbLoaiNV.Checked)
            {
                query = query + "trangThai = 1 and loaiNhanVien Like N'%" + txtTim.Text + "%'";
            }
            dtgvDSNV.DataSource = nv_bus.Tim(query);
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            btnTim.PerformClick();
            frmInBaoCao f = new frmInBaoCao();
            List<NhanVien_DTO> listNV = new List<NhanVien_DTO>();

            listNV = (dtgvDSNV.DataSource as List<NhanVien_DTO>);
            if (rdbTatCaNV.Checked)
            {
                f.InNV(listNV, "Tất Cả Nhân Viên");
            }
            else if (rdbIDNV.Checked)
            {
                f.InNV(listNV, "Nhân Viên có ID là " + txtTim.Text);
            }
            else if (rdbTenNV.Checked)
            {
                f.InNV(listNV, "Nhân Viên có tên là " + txtTim.Text);
            }
            else if (rdbDiaChiNV.Checked)
            {
                f.InNV(listNV, "Nhân Viên có địa chỉ ở " + txtTim.Text);
            }
            else if (rdbLoaiNV.Checked)
            {
                f.InNV(listNV, "Nhân Viên có loại nhân viên là " + txtTim.Text);
            }
            if(rdbDaXoaNV.Checked)
            {
                return;
            }
            f.ShowDialog();
            ResetThongTin();
            CapNhatDSNhanVien();
        }
        #endregion

        #endregion

        #region QLKH

        #region Hàm
        public void CapNhatDSKhachHang()
        {
            KhachHang_BUS kh = new KhachHang_BUS();
            dtgvDSKH.AutoGenerateColumns = false;
            dtgvDSKH.DataSource = kh.LayDanhSach();
            dtgvDSKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvDSKH.ReadOnly = true;
        }

        #endregion

        #region Sự Kiện

        private void txtCMNDKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void txtSDTKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        private void dtgvDSKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow != -1)
            {
                if (dtgvDSKH.Rows[numrow].Cells[0].Value.ToString() != "")
                {
                    txtSDTKH.Text = dtgvDSKH.Rows[numrow].Cells[0].Value.ToString();
                    txtTenKH.Text = dtgvDSKH.Rows[numrow].Cells[1].Value.ToString();
                    txtCMNDKH.Text = dtgvDSKH.Rows[numrow].Cells[2].Value.ToString();
                    dtpNgaySinhKH.Value = Convert.ToDateTime(dtgvDSKH.Rows[numrow].Cells[3].Value.ToString());
                    txtDiaChiKH.Text = dtgvDSKH.Rows[numrow].Cells[4].Value.ToString();
                    numTongChiTieuKH.Value = int.Parse(dtgvDSKH.Rows[numrow].Cells[5].Value.ToString());
                }
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (txtSDTKH.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống sđt khách hàng khi thực hiện chức năng xóa !!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            KhachHang_BUS kh_bus = new KhachHang_BUS();
            if (kh_bus.Xoa(txtSDTKH.Text))
            {
                MessageBox.Show("Xóa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CapNhatDSKhachHang();
                ResetThongTin();
            }
            else
            {
                MessageBox.Show("Xóa thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            int tongChiTieu = 0;
            try
            {
                tongChiTieu = int.Parse(numTongChiTieuKH.Value.ToString());
            }
            catch
            {
                MessageBox.Show("Giá trị nhập quá lớn", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            KhachHang_DTO kh = new KhachHang_DTO(txtSDTKH.Text, txtTenKH.Text, txtCMNDKH.Text, dtpNgaySinhKH.Value, txtDiaChiKH.Text, tongChiTieu, 1);
            KhachHang_BUS kh_bus = new KhachHang_BUS();
            if (kh_bus.Sua(kh))
            {
                MessageBox.Show("Sửa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CapNhatDSKhachHang();
                ResetThongTin();
            }
            else
            {
                MessageBox.Show("Sửa thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDSSH_Click(object sender, EventArgs e)
        {
            CapNhatDSKhachHang();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            KhachHang_DTO kh = new KhachHang_DTO(txtSDTKH.Text, txtTenKH.Text, txtCMNDKH.Text, dtpNgaySinhKH.Value, txtDiaChiKH.Text, int.Parse(numTongChiTieuKH.Value.ToString()), 1);
            KhachHang_BUS kh_bus = new KhachHang_BUS();
            if (kh_bus.KiemTra(kh.sdt) != true)
            {
                if (kh_bus.Them(kh))
                {
                    MessageBox.Show("Thêm thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CapNhatDSKhachHang();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                btnSuaKH.PerformClick();
            }
        }

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            KhachHang_BUS kh_bus = new KhachHang_BUS();
            string query = "SELECT * FROM KhachHang where ";
            if (rdbTatCa.Checked)
            {
                txtTimKH.Text = "";
                CapNhatDSKhachHang();
                return;
            }
            else if(rdbDaXoaKH.Checked)
            {
                query += "trangThai = 0";
            }
            else if (rdbSDTKH.Checked)
            {
                query = query + "trangThai = 1 and sdt = N'" + txtTimKH.Text + "'";
            }
            else if (rdbTenKH.Checked)
            {
                query = query + "trangThai = 1 and tenKhachHang Like N'%" + txtTimKH.Text + "%'";
            }
            else if (rdbDiaChiKH.Checked)
            {
                query = query + "trangThai = 1 and diaChi Like N'%" + txtTimKH.Text + "%'";
            }
            else if (rdbTongChiTieu.Checked)
            {
                long tongChiTieu = 0;
                try
                {
                    tongChiTieu = long.Parse(txtTimKH.Text);
                }
                catch
                {
                    MessageBox.Show("Bạn phải nhập định dạng kiểu số", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                query = query + "trangThai = 1 and tongChiTieu >= " + tongChiTieu;
            }
            dtgvDSKH.DataSource = kh_bus.Tim(query);

        }

        private void btnInBaoCaoKH_Click(object sender, EventArgs e)
        {
            btnTimKH.PerformClick();
            frmInBaoCao f = new frmInBaoCao();
            List<KhachHang_DTO> listKH = new List<KhachHang_DTO>();

            listKH = (dtgvDSKH.DataSource as List<KhachHang_DTO>);
            if (rdbTatCa.Checked)
            {
                f.InKH(listKH, "Tất Cả Khách Hàng");
            }
            else if (rdbSDTKH.Checked)
            {
                f.InKH(listKH, "Khách Hàng có sđt là " + txtTimKH.Text);
            }
            else if (rdbTenKH.Checked)
            {
                f.InKH(listKH, "Khách Hàng có tên là " + txtTimKH.Text);
            }
            else if (rdbDiaChiKH.Checked)
            {
                f.InKH(listKH, "Khách Hàng có địa chỉ ở " + txtTimKH.Text);
            }
            else if (rdbTongChiTieu.Checked)
            {
                f.InKH(listKH, "Khách hàng có tổng chỉ tiêu từ " + txtTimKH.Text + " trở lên");
            }
            if(rdbDaXoaKH.Checked)
            {
                return;
            }
            f.ShowDialog();
            ResetThongTin();
            CapNhatDSKhachHang();
        }

        #endregion
        #endregion

        #region QLSP

            #region Hàm

        void LoadHangGiay()
        {
            tvHangGiay.Nodes.Clear();
            List<HangGiay_DTO> listHang = new List<HangGiay_DTO>();
            List<LoaiGiay_DTO> listLoaiGiay = new List<LoaiGiay_DTO>();
            HangGiay_BUS hangGiay_bus = new HangGiay_BUS();
            LoaiGiay_BUS loaiGiay_bus = new LoaiGiay_BUS();

            listHang = hangGiay_bus.LayDanhSach();

            foreach (HangGiay_DTO hang in listHang)
            {
                TreeNode root = new TreeNode();
                root.Text = hang.tenHang;
                root.Tag = hang;

                listLoaiGiay = loaiGiay_bus.LayDanhSachTheoIDHang(hang.id);

                foreach (LoaiGiay_DTO loaigiay in listLoaiGiay)
                {
                    TreeNode nodeLoaiGiay = new TreeNode();
                    nodeLoaiGiay.Text = loaigiay.tenLoaiGiay;
                    nodeLoaiGiay.Tag = loaigiay;

                    root.Nodes.Add(nodeLoaiGiay);
                }
                tvHangGiay.Nodes.Add(root);
            }
            cbHangGiay.DataSource = hangGiay_bus.LayDanhSach();
            cbHangGiay.DisplayMember = "tenHang";
            cbHangGiay.ValueMember = "id";
            cbHangGiay.SelectionStart = 0;
            cbTimTheoHang.DataSource = hangGiay_bus.LayDanhSach();
            cbTimTheoHang.DisplayMember = "tenHang";
            cbTimTheoHang.ValueMember = "id";
            cbTimTheoHang.SelectionStart = 0;
            
        }

        void CapNhapDanhSachGiay()
        {
            HienThiGiay_BUS htgiay_bus = new HienThiGiay_BUS();
            dtgvDSSP.AutoGenerateColumns = false;
            dtgvDSSP.DataSource = htgiay_bus.LayDanhSach();
            dtgvDSSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvDSSP.ReadOnly = true;
        }

            #endregion

            #region Sự Kiện

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (txtIDGiay.Text.Trim() != "" && txtSizeGiay.Text.Trim() == "")
            {
                Giay_BUS giay_bus = new Giay_BUS();
                if (giay_bus.Xoa(int.Parse(txtIDGiay.Text)))
                {
                    MessageBox.Show("Xóa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CapNhapDanhSachGiay();
                    ResetThongTin();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (txtSizeGiay.Text.Trim() != "")
            {
                BangSize_BUS size_bus = new BangSize_BUS();
                if (size_bus.Xoa(int.Parse(txtIDGiay.Text),txtSizeGiay.Text))
                {
                    MessageBox.Show("Xóa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CapNhapDanhSachGiay();
                    ResetThongTin();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtIDHang.Text = "";
            txtTenHangGiay.Text = "";
            txtIDLoaiSP.Text = "";
            txtTenLoaiSP.Text = "";
        }

        private void tvHangGiay_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            txtIDHang.Text = "";
            txtTenHangGiay.Text = "";
            txtIDLoaiSP.Text = "";
            txtTenLoaiSP.Text = "";
            TreeNode node = new TreeNode();
            node = e.Node;
            try
            {
                HangGiay_DTO hanggiay = (node.Tag as HangGiay_DTO);
                txtIDHang.Text = hanggiay.id.ToString();
                txtTenHangGiay.Text = hanggiay.tenHang;
                txtIDLoaiSP.Text = "";
                txtTenLoaiSP.Text = "";
            }
            catch
            {
                TreeNode nodeParent = new TreeNode();
                nodeParent = node.Parent;
                HangGiay_DTO hanggiay = (nodeParent.Tag as HangGiay_DTO);
                txtIDHang.Text = hanggiay.id.ToString();
                txtTenHangGiay.Text = hanggiay.tenHang;
                LoaiGiay_DTO loaigiay = (node.Tag as LoaiGiay_DTO);
                txtIDLoaiSP.Text = loaigiay.id.ToString();
                txtTenLoaiSP.Text = loaigiay.tenLoaiGiay;
            }
        }

        private void btnThemHangGiay_Click(object sender, EventArgs e)
        {
            if (txtIDHang.Text.Trim() == "")
            {
                int a = 0;
                if (txtTenHangGiay.Text.Trim() != "")
                {
                    HangGiay_BUS hanggiay_bus = new HangGiay_BUS();
                    HangGiay_DTO hanggiay = new HangGiay_DTO(-1, txtTenHangGiay.Text, 1);
                    if (hanggiay_bus.Them(hanggiay))
                    {
                        a = 1;
                    }
                    else
                    {
                        a = 0;
                    }
                }
                if (txtIDLoaiSP.Text.Trim() == "")
                {
                    if(txtTenLoaiSP.Text != "")
                    {
                        HangGiay_BUS hanggiay_bus = new HangGiay_BUS();
                        LoaiGiay_BUS loaigiay_bus = new LoaiGiay_BUS();
                        LoaiGiay_DTO loaigiay = new LoaiGiay_DTO(-1, txtTenLoaiSP.Text,hanggiay_bus.LastID(), 1);
                        if (loaigiay_bus.Them(loaigiay))
                        {
                            a = 1;
                        }
                        else
                        {
                            a = 0;
                        }
                    }
                }
                if (a == 1)
                {
                    MessageBox.Show("Thêm thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHangGiay();
                    btnResetGiay.PerformClick();
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (txtIDHang.Text.Trim() != "")
            {
                if (txtIDLoaiSP.Text.Trim() == "")
                {
                    LoaiGiay_BUS loaigiay_bus = new LoaiGiay_BUS();
                    LoaiGiay_DTO loaigiay = new LoaiGiay_DTO(-1, txtTenLoaiSP.Text, int.Parse(txtIDHang.Text), 1);
                    if (loaigiay_bus.Them(loaigiay))
                    {
                        MessageBox.Show("Thêm thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHangGiay();
                        btnResetGiay.PerformClick();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (txtIDLoaiSP.Text.Trim() != "")
                {
                    btnSuaHangGiay.PerformClick();
                }
            }
        }

        private void btnXoaHangGiay_Click(object sender, EventArgs e)
        {
            if (txtIDHang.Text.Trim() != "")
            {
                if (txtIDLoaiSP.Text.Trim() != "")
                {
                    LoaiGiay_BUS loaigiay_bus = new LoaiGiay_BUS();
                    if (loaigiay_bus.Xoa(txtIDLoaiSP.Text.Trim()))
                    {
                        MessageBox.Show("Xóa loại thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHangGiay();
                        btnResetGiay.PerformClick();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa loại thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (txtIDLoaiSP.Text.Trim() == "")
                {
                    HangGiay_BUS hanggiay_bus = new HangGiay_BUS();
                    if (hanggiay_bus.Xoa(txtIDHang.Text.Trim()))
                    {
                        MessageBox.Show("Xóa hãng thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHangGiay();
                        btnResetGiay.PerformClick();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa hãng thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnSuaHangGiay_Click(object sender, EventArgs e)
        {
            if (txtIDHang.Text.Trim() != "")
            {
                if (txtIDLoaiSP.Text.Trim() != "")
                {
                    LoaiGiay_BUS loaigiay_bus = new LoaiGiay_BUS();
                    LoaiGiay_DTO loaigiay = new LoaiGiay_DTO(int.Parse(txtIDLoaiSP.Text), txtTenLoaiSP.Text, int.Parse(txtIDHang.Text), 1);

                    if (loaigiay_bus.Sua(loaigiay))
                    {
                        MessageBox.Show("Sửa loại giày thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHangGiay();
                        btnResetGiay.PerformClick();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Sửa loại giày thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (txtIDLoaiSP.Text.Trim() == "")
                {
                    HangGiay_BUS hanggiay_bus = new HangGiay_BUS();
                    HangGiay_DTO hanggiay = new HangGiay_DTO(int.Parse(txtIDHang.Text), txtTenHangGiay.Text, 1);
                    if (hanggiay_bus.Sua(hanggiay))
                    {
                        MessageBox.Show("Sửa hãng thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHangGiay();
                        btnResetGiay.PerformClick();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Sửa hãng thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtHinhAnh.Text = openFile.FileName;
                pictureSP.BackgroundImageLayout = ImageLayout.Zoom;
                pictureSP.BackgroundImage = Image.FromFile(txtHinhAnh.Text);
            }
        }

        private void cbHangGiay_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            try
            {
                id = int.Parse(cbHangGiay.SelectedValue.ToString());
            }
            catch
            {
                id = 1;
            }
            LoaiGiay_BUS loaigiay_bus = new LoaiGiay_BUS();
            cbLoaiGiay.DataSource = loaigiay_bus.LayDanhSachTheoIDHang(id);
            cbLoaiGiay.DisplayMember = "tenLoaiGiay";
            cbLoaiGiay.ValueMember = "id";
        }

        private void cbTimTheoHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            try
            {
                id = int.Parse(cbTimTheoHang.SelectedValue.ToString());
            }
            catch
            {
                id = 1;
            }
            LoaiGiay_BUS loaigiay_bus = new LoaiGiay_BUS();
            cbTimTheoLoai.DataSource = loaigiay_bus.LayDanhSachTheoIDHang(id);
            cbTimTheoLoai.DisplayMember = "tenLoaiGiay";
            cbTimTheoLoai.ValueMember = "id";
        }


        private void dtgvDSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureSP.BackgroundImageLayout = ImageLayout.Zoom;
            int numrow;
            numrow = e.RowIndex;
            if (numrow != -1)
            {
                if (dtgvDSSP.Rows[numrow].Cells[0].Value.ToString() != "")
                {
                    txtIDGiay.Text = dtgvDSSP.Rows[numrow].Cells[0].Value.ToString();
                    txtTenGiay.Text = dtgvDSSP.Rows[numrow].Cells[1].Value.ToString();
                    txtSizeGiay.Text = dtgvDSSP.Rows[numrow].Cells[2].Value.ToString();
                    cbHangGiay.Text = dtgvDSSP.Rows[numrow].Cells[3].Value.ToString();
                    cbLoaiGiay.Text = dtgvDSSP.Rows[numrow].Cells[4].Value.ToString();
                    numGiaBan.Value = int.Parse(dtgvDSSP.Rows[numrow].Cells[5].Value.ToString());
                    numGiaNhap.Value = int.Parse(dtgvDSSP.Rows[numrow].Cells[6].Value.ToString());
                    numGiamGia.Value = int.Parse(dtgvDSSP.Rows[numrow].Cells[7].Value.ToString());
                    numSoLuongTon.Value = int.Parse(dtgvDSSP.Rows[numrow].Cells[8].Value.ToString());
                    txtHinhAnh.Text = dtgvDSSP.Rows[numrow].Cells[9].Value.ToString();
                    pictureSP.BackgroundImage = Image.FromFile(txtHinhAnh.Text);
                }
            }
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            HienThiGiay_BUS htgiay_bus = new HienThiGiay_BUS();
            string query = "Select G.id,G.tenGiay,S.sizeGiay,HG.tenHang,LG.tenLoaiGiay,S.giaBan,S.giaNhap,G.giamGia,S.soLuong,G.hinhAnh,S.trangThai from HangGiay as HG,LoaiGiay as LG, Giay as G,BangSize as S where G.id = S.idGiay and G.idHangGiay = HG.id and G.idLoaiGiay = LG.id ";
            if (rdbTatCaSP.Checked)
            {
                btnSuDung.Visible = false;
                btnThemSP.Visible = true;
                btnXoaSP.Visible = true;
                btnSuaSP.Visible = true;
                CapNhapDanhSachGiay();
                return;
            }
            else if(rdbDaXoaSP.Checked)
            {
                btnSuDung.Visible = true;
                btnThemSP.Visible = false;
                btnXoaSP.Visible = false;
                btnSuaSP.Visible = false;
                query += " and(S.trangThai = 0 or G.trangThai = 0)";
            }
            else if (rdbHang.Checked)
            {
                btnSuDung.Visible = false;
                btnThemSP.Visible = true;
                btnXoaSP.Visible = true;
                btnSuaSP.Visible = true;
                if(ckbLoai.Checked)
                {

                    query += "and S.trangThai = 1 and G.trangThai = 1 and  idLoaiGiay = " + cbTimTheoLoai.SelectedValue;
                }
                else
                {
                    query += "and S.trangThai = 1 and G.trangThai = 1 and  idHangGiay = " + cbTimTheoHang.SelectedValue;
                }
            }
            else if (rdbTenSP.Checked)
            {
                btnSuDung.Visible = false;
                btnThemSP.Visible = true;
                btnXoaSP.Visible = true;
                btnSuaSP.Visible = true;
                query += "and S.trangThai = 1 and G.trangThai = 1 and  tenGiay Like N'%" + txtTimTheoTen.Text + "%'";
            }
            else if(rdbGia.Checked)
            {
                btnSuDung.Visible = false;
                btnThemSP.Visible = true;
                btnXoaSP.Visible = true;
                btnSuaSP.Visible = true;
                query += "and S.trangThai = 1 and G.trangThai = 1 and  giaBan >= " + numTimTheoGia.Value;
            }
            else if(rdbSLTon.Checked)
            {
                btnSuDung.Visible = false;
                btnThemSP.Visible = true;
                btnXoaSP.Visible = true;
                btnSuaSP.Visible = true;
                query += "and S.trangThai = 1 and G.trangThai = 1 and  soLuong >= " + numTimTheoSLTon.Value; 
            }
            else if(rdbGiamGia.Checked)
            {
                btnSuDung.Visible = false;
                btnThemSP.Visible = true;
                btnXoaSP.Visible = true;
                btnSuaSP.Visible = true;
                query += "and S.trangThai = 1 and G.trangThai = 1 and  giamGia >= " + numTimTheoGiamGia.Value;
            }
            dtgvDSSP.DataSource = htgiay_bus.Tim(query);
        }

        private void btnInBaoCaoSP_Click(object sender, EventArgs e)
        {
            btnTimSP.PerformClick();
            frmInBaoCao f = new frmInBaoCao();
            List<HienThiGiay_DTO> listSP = new List<HienThiGiay_DTO>();

            listSP = (dtgvDSSP.DataSource as List<HienThiGiay_DTO>);

            if (rdbTatCaSP.Checked)
            {
                f.InGiay(listSP, "Tất Cả Sản Phẩm");
            }
            else if (rdbTenSP.Checked)
            {
                f.InGiay(listSP, "Giày có tên là: " + txtTimTheoTen.Text);
            }
            else if (rdbHang.Checked)
            {
                if (ckbLoai.Checked)
                {
                    f.InGiay(listSP, "Giày theo loại: " + cbLoaiGiay.Text);
                }
                else
                {
                    f.InGiay(listSP, "Giày theo hãng" + cbHangGiay.Text);
                }
            }
            else if (rdbGia.Checked)
            {
                f.InGiay(listSP, "Giày có giá từ " + numTimTheoGia.Value+" VNĐ");
            }
            else if (rdbGiamGia.Checked)
            {
                f.InGiay(listSP, "Giày giảm giá từ " + numTimTheoGiamGia.Value+"%");
            }
            else if (rdbSLTon.Checked)
            {
                f.InGiay(listSP, "Giày tồn kho: "+numTimTheoSLTon.Value+" trở lên.");
            }
            if (rdbDaXoaNCC.Checked)
            {
                return;
            }
            f.ShowDialog();
            ResetThongTin();
            CapNhapDanhSachGiay();
        }
       
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if(txtIDGiay.Text.Trim() == "")
            {
                if(txtTenGiay.Text.Trim()!="")
                {
                    Giay_BUS giay_bus = new Giay_BUS();
                    BangSize_BUS size_bus = new BangSize_BUS();
                    Giay_DTO giay = new Giay_DTO(-1,txtTenGiay.Text,int.Parse(cbHangGiay.SelectedValue.ToString()),int.Parse(cbLoaiGiay.SelectedValue.ToString()),int.Parse(numGiamGia.Value.ToString()),txtHinhAnh.Text,1);
                    if (giay_bus.Them(giay))
                    {
                        BangSize_DTO size = new BangSize_DTO(giay_bus.LastID(), txtSizeGiay.Text, int.Parse(numGiaBan.Value.ToString()), 0, 0, 1);
                        if(!size_bus.KiemTra(size))
                        {
                            if(size_bus.Them(size))
                            {
                                MessageBox.Show("Thêm thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CapNhapDanhSachGiay();
                                btnResetGiay.PerformClick();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Thêm Size thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thêm Giày thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                return;
            }
            else if(txtIDGiay.Text.Trim()!= "")
            {
                if(txtSizeGiay.Text.Trim()!="")
                {
                    BangSize_BUS size_bus = new BangSize_BUS();
                    BangSize_DTO size = new BangSize_DTO(int.Parse(txtIDGiay.Text), txtSizeGiay.Text, int.Parse(numGiaBan.Value.ToString()), 0, 0, 1);
                    if (!size_bus.KiemTra(size))
                    {
                        if (size_bus.Them(size))
                        {
                            MessageBox.Show("Thêm thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CapNhapDanhSachGiay();
                            btnResetGiay.PerformClick();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Thêm Size thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            btnSuaSP.PerformClick();
        }


        private void btnResetGiay_Click(object sender, EventArgs e)
        {
            txtIDGiay.Text = "";
            txtTenGiay.Text = "";
            numGiamGia.Value = 0;
            numGiaBan.Value = 0;
            numGiaNhap.Value = 0;
            txtSizeGiay.Text = "";
            txtHinhAnh.Text = "";
            pictureSP.BackgroundImage = Image.FromFile(@"C:\Users\lemin\OneDrive\Máy tính\DoanC\0306181057_QLCHBG\0306181057_QLCHBG\bin\Debug\Data\IMG\logo.png");
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            int a = 0;
            if(txtIDGiay.Text.Trim()!="")
            {
                Giay_DTO giay = new Giay_DTO(int.Parse(txtIDGiay.Text), txtTenGiay.Text, int.Parse(cbHangGiay.SelectedValue.ToString()), int.Parse(cbLoaiGiay.SelectedValue.ToString()), int.Parse(numGiamGia.Value.ToString()), txtHinhAnh.Text, 1);
                Giay_BUS giay_bus = new Giay_BUS();
                if (giay_bus.Sua(giay))
                {
                    a = 1;
                }
                else
                {
                    a = 0;
                }
                if (txtSizeGiay.Text.Trim() != "")
                {
                    BangSize_BUS size_bus = new BangSize_BUS();
                    BangSize_DTO size = new BangSize_DTO(int.Parse(txtIDGiay.Text), txtSizeGiay.Text, int.Parse(numGiaBan.Value.ToString()), int.Parse(numGiaNhap.Value.ToString()), int.Parse(numSoLuongTon.Value.ToString()), 1);
                    if (size_bus.Sua(size))
                    {
                        a = 1;
                    }
                    else
                    {
                        a = 0;
                    }
                }
            }
            
            if(a == 1)
            {
                MessageBox.Show("Sửa giày thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CapNhapDanhSachGiay();
                ResetThongTin();
            }
            else
            {
                MessageBox.Show("Sửa thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuDung_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (txtIDGiay.Text.Trim() != "")
            {
                Giay_DTO giay = new Giay_DTO(int.Parse(txtIDGiay.Text), txtTenGiay.Text, int.Parse(cbHangGiay.SelectedValue.ToString()), int.Parse(cbLoaiGiay.SelectedValue.ToString()), int.Parse(numGiamGia.Value.ToString()), txtHinhAnh.Text, 1);
                Giay_BUS giay_bus = new Giay_BUS();
                if (giay_bus.Sua(giay))
                {
                    a = 1;
                }
                else
                {
                    a = 0;
                }
                if (txtSizeGiay.Text.Trim() != "")
                {
                    BangSize_BUS size_bus = new BangSize_BUS();
                    BangSize_DTO size = new BangSize_DTO(int.Parse(txtIDGiay.Text), txtSizeGiay.Text, int.Parse(numGiaBan.Value.ToString()), int.Parse(numGiaNhap.Value.ToString()), int.Parse(numSoLuongTon.Value.ToString()), 1);
                    if (size_bus.Sua(size))
                    {
                        a = 1;
                    }
                    else
                    {
                        a = 0;
                    }
                }
            }

            if (a == 1)
            {
                MessageBox.Show("Sử dụng trở lại thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSuDung.Visible = false;
                btnThemSP.Visible = true;
                btnXoaSP.Visible = true;
                btnSuaSP.Visible = true;
                CapNhapDanhSachGiay();
                ResetThongTin();
            }
            else
            {
                MessageBox.Show("Sử dụng thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            #endregion

        #endregion

        #region QLNCC

        #region Hàm

        public void CapNhatDSNCC()
        {
            NhaCungCap_BUS ncc = new NhaCungCap_BUS();
            dtgvDSNCC.AutoGenerateColumns = false;
            dtgvDSNCC.DataSource = ncc.LayDanhSach();
            dtgvDSNCC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvDSNCC.ReadOnly = true;
        }

        #endregion 

        #region Sự kiện

        private void btnTimNCC_Click(object sender, EventArgs e)
        {
            NhaCungCap_BUS ncc_bus = new NhaCungCap_BUS();
            string query = "SELECT * FROM NhaCungCap where ";
            if (rdbTatCaNCC.Checked)
            {
                txtTimNCC.Text = "";
                CapNhatDSNCC();
                return;
            }
            else if (rdbDaXoaNCC.Checked)
            {
                query += "trangThai = 0";
            }
            else if (rdbMaNCC.Checked)
            {
                query = query + "trangThai = 1 and maNCC = N'" + txtTimNCC.Text + "'";
            }
            else if (rdbTenNCC.Checked)
            {
                query = query + "trangThai = 1 and tenNhaCungCap Like N'%" + txtTimNCC.Text + "%'";
            }
            else if (rdbDiaChiNCC.Checked)
            {
                query = query + "trangThai = 1 and diaChi Like N'%" + txtTimNCC.Text + "%'";
            }

            dtgvDSNCC.DataSource = ncc_bus.Tim(query);
        }

        private void btnInBaoCaoNCC_Click(object sender, EventArgs e)
        {
            btnTimNCC.PerformClick();
            frmInBaoCao f = new frmInBaoCao();
            List<NhaCungCap_DTO> listNCC = new List<NhaCungCap_DTO>();

            listNCC = (dtgvDSNCC.DataSource as List<NhaCungCap_DTO>);
            if (rdbTatCa.Checked)
            {
                f.InNCC(listNCC, "Tất Cả Nhà Cung Cấp");
            }
            else if (rdbMaNCC.Checked)
            {
                f.InNCC(listNCC, "Nhà Cung Cấp có mã là " + txtTimNCC.Text);
            }
            else if (rdbTenNCC.Checked)
            {
                f.InNCC(listNCC, "Nhà cung cấp có tên là " + txtTimNCC.Text);
            }
            else if (rdbDiaChiNCC.Checked)
            {
                f.InNCC(listNCC, "Nhà Cung Cấp có địa chỉ ở " + txtTimNCC.Text);
            }
            if (rdbDaXoaNCC.Checked)
            {
                return;
            }
            f.ShowDialog();
            ResetThongTin();
            CapNhatDSNCC();
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            NhaCungCap_DTO ncc = new NhaCungCap_DTO(txtMaNCC.Text,txtTenNCC.Text,txtDiaChiNCC.Text,txtEmailNCC.Text,txtSDTNCC.Text,txtWebsiteNCC.Text,1);
            NhaCungCap_BUS ncc_bus = new NhaCungCap_BUS();
            if (ncc_bus.KiemTra(ncc.maNCC) != true)
            {
                if (ncc_bus.Them(ncc))
                {
                    MessageBox.Show("Thêm thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CapNhatDSNCC();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                btnSuaNCC.PerformClick();
            }
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống mã nhà cung cấp khi thực hiện chức năng xóa !!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            NhaCungCap_BUS ncc_bus = new NhaCungCap_BUS();
            if (ncc_bus.Xoa(txtMaNCC.Text))
            {
                MessageBox.Show("Xóa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CapNhatDSNCC();
                ResetThongTin();
            }
            else
            {
                MessageBox.Show("Xóa thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            NhaCungCap_DTO ncc = new NhaCungCap_DTO(txtMaNCC.Text, txtTenNCC.Text, txtDiaChiNCC.Text, txtEmailNCC.Text, txtSDTNCC.Text, txtWebsiteNCC.Text, 1);
            NhaCungCap_BUS ncc_bus = new NhaCungCap_BUS();
            if (ncc_bus.Sua(ncc))
            {
                MessageBox.Show("Sửa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CapNhatDSNCC();
                ResetThongTin();
            }
            else
            {
                MessageBox.Show("Sửa thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion

        #region Thống Kê

        #region Tổng Quan

        #region Hàm

        void LoadSLNV()
        {
            NhanVien_BUS nv_bus = new NhanVien_BUS();
            txtSLNV.Text = nv_bus.Count().ToString();
        }
        void LoadSLKH()
        {
            KhachHang_BUS kh_bus = new KhachHang_BUS();
            txtSLKH.Text = kh_bus.Count().ToString();
        }
        void LoadSLNCC()
        {
            NhaCungCap_BUS ncc_bus = new NhaCungCap_BUS();
            txtSLNCC.Text = ncc_bus.Count().ToString();
        }
        void LoadSLGiay()
        {
            Giay_BUS giay_bus = new Giay_BUS();
            txtSLSP.Text = giay_bus.Count().ToString();
        }
        void LoadSPBanChayTheoThang()
        {
            int thang = DateTime.Now.Month;
            Giay_BUS giay_bus = new Giay_BUS();
            Giay_DTO giay = giay_bus.TimGiayBanChayTheoThang(thang);
            int slDaBan = giay_bus.SLGiayBanChayNhatTheoThang(thang);
            txtSPBanChay.Text = "ID: " + giay.id + " -- Tên Sản Phẩm: " + giay.tenGiay + Environment.NewLine + "Đã Bán: " + slDaBan;
        }
        void LoadTongDoanhThuTheoThang()
        {
            int thang = DateTime.Now.Month;
            HoaDon_BUS hd_bus = new HoaDon_BUS();
            long tongDoanhThu = hd_bus.TongDanhThuTheoThang(thang);
            CultureInfo culture = new CultureInfo("vi-VN");
            txtDoanhThu.Text = tongDoanhThu.ToString("c",culture);
        }
        void LoadSLNhapTheoThang()
        {
            int thang = DateTime.Now.Month;
            HoaDonNhap_BUS hdnhap_bus = new HoaDonNhap_BUS();
            int soLanNhap = hdnhap_bus.SoLanNhapTheoThang(thang);
            txtSoLanNhap.Text = soLanNhap.ToString();
        }
        void LoadNVGioiNhatThang()
        {
            int thang = DateTime.Now.Month;
            NhanVien_BUS nv_bus = new NhanVien_BUS();
            NhanVien_DTO nv = nv_bus.NhanVienGioiNhatThang(thang);
            int slsp = nv_bus.SLSPNhanVienGioiNhatThang(thang);
            txtNVGioiNhat.Text = "Mã NV: " + nv.idNhanVien + " -- Tên Nhân Viên: " + nv.tenNhanVien + Environment.NewLine + "Đã Bán: " + slsp;
        }
        #endregion

        #region Sự Kiện
        private void btnInBaoCaoTongQuan_Click(object sender, EventArgs e)
        {
            frmInBaoCao f = new frmInBaoCao();
            f.InBaoCaoTongQuan("Báo Cáo Tổng Quan " + lblThangNamHienTai.Text, txtSLNV.Text, txtSLKH.Text, txtSLNCC.Text, txtSLSP.Text, txtNVGioiNhat.Text, txtSPBanChay.Text, txtSoLanNhap.Text, txtDoanhThu.Text);
            f.ShowDialog();
        }
        private void tabItemThongKe_Click(object sender, EventArgs e)
        {
            LoadSLGiay();
            LoadSLKH();
            LoadSLNCC();
            LoadSLNV();
            LoadSPBanChayTheoThang();
            LoadTongDoanhThuTheoThang();
            LoadSLNhapTheoThang();
            LoadNVGioiNhatThang();
        }
        private void btnXemKhachHang_Click(object sender, EventArgs e)
        {
            tcQL.SelectedTab = tabItemQLKH;
        }
        private void btnXemNhanVien_Click(object sender, EventArgs e)
        {
            tcQL.SelectedTab = tabItemQLNV;
        }
        private void btnXemNCC_Click(object sender, EventArgs e)
        {
            tcQL.SelectedTab = tabItemQLNCC;
        }
        private void btnXemSP_Click(object sender, EventArgs e)
        {
            tcQL.SelectedTab = tabItemQLSP;
        }
        #endregion

        #endregion

        #region Thống Kê HD

        #region Hàm

        void LoadDateTimePickerHD()
        {
            DateTime today = DateTime.Now;
            dtpNgayBatDauHD.Value = new DateTime(today.Year, today.Month, 1);
            dtpNgayKetThucHD.Value = dtpNgayBatDauHD.Value.AddMonths(1).AddDays(-1);
        }

        void LoadHD()
        {
            lvHoaDon.Items.Clear();
            HoaDon_BUS hd_bus = new HoaDon_BUS();
            NhanVien_BUS nv_bus = new NhanVien_BUS();
            KhachHang_BUS kh_bus = new KhachHang_BUS();
            List<HoaDon_DTO> listHD = new List<HoaDon_DTO>();
            CultureInfo culture = new CultureInfo("vi-VN");
            listHD = hd_bus.LayDSTheoNgay(dtpNgayBatDauHD.Value, dtpNgayKetThucHD.Value);
            foreach(HoaDon_DTO item in listHD)
            {
                KhachHang_DTO kh = new KhachHang_DTO();
                NhanVien_DTO nv = new NhanVien_DTO();
                nv = nv_bus.LayNV(item.idNhanVien);
                kh = kh_bus.LayKH(item.sdtKhachHang);
                ListViewItem lvItem = new ListViewItem(item.id.ToString());
                lvItem.Tag = item;
                lvItem.SubItems.Add(item.idNhanVien.ToString());
                lvItem.SubItems.Add(nv.tenNhanVien);
                lvItem.SubItems.Add(item.sdtKhachHang);
                lvItem.SubItems.Add(kh.tenKhachHang);
                lvItem.SubItems.Add(item.ngayLap.ToString());
                lvItem.SubItems.Add(item.tongTien.ToString("c",culture));
                lvItem.SubItems.Add(item.giamGia.ToString()+"%");
                lvItem.SubItems.Add(item.thanhToan.ToString("c",culture));
                lvHoaDon.Items.Add(lvItem);

            }
        }

        void HienThiCTHD(int idHoaDon)
        {
            lvCTHD.Items.Clear();
            HoaDon_BUS hd_bus = new HoaDon_BUS();
            HienThiHoaDon_BUS hthd_bus = new HienThiHoaDon_BUS();
            List<HienThiHoaDon_DTO> listHTHD = new List<HienThiHoaDon_DTO>();
            listHTHD = hthd_bus.LayDanhSachTheoIDHoaDon(idHoaDon);
            CultureInfo cul = new CultureInfo("vi-VN");
            foreach (HienThiHoaDon_DTO item in listHTHD)
            {
                ListViewItem lvItem = new ListViewItem(item.tenGiay);
                lvItem.SubItems.Add(item.size);
                lvItem.SubItems.Add(item.soLuong.ToString());
                lvItem.SubItems.Add(item.donGia.ToString("c", cul));
                lvItem.SubItems.Add(item.giamGia.ToString() + "%");
                lvItem.SubItems.Add(item.thanhTien.ToString("c", cul));
                lvCTHD.Items.Add(lvItem);
            }
        }

        #endregion

        #region Sự Kiện

        

        private void lvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            HoaDon_DTO hd = new HoaDon_DTO();
            try
            {
                hd = ((lvHoaDon.FocusedItem as ListViewItem).Tag as HoaDon_DTO);
            }
            catch
            {

            }
            HienThiCTHD(hd.id);
        }

        private void btnThongKeHD_Click(object sender, EventArgs e)
        {
            lvCTHD.Items.Clear();
            lvHoaDon.Items.Clear();
            LoadHD();
        }
        #endregion
        #endregion


        #region Doanh Thu

        #region Hàm

        void LoadTenGiay()
        {
            Giay_BUS giay_bus = new Giay_BUS();
            cbTenGiay.DataSource = giay_bus.LayDanhSach();
            cbTenGiay.DisplayMember = "tenGiay";
            cbTenGiay.ValueMember = "id";
        }

        void LoadDateTimePickerDoanhThu()
        {
            DateTime today = DateTime.Now;
            dtpNgayBatDauDoanhThu.Value = new DateTime(today.Year, today.Month, 1);
            dtpNgayKetThucDoanhThu.Value = dtpNgayBatDauDoanhThu.Value.AddMonths(1).AddDays(-1);
        }

        void LoadDoanhThuTatCa()
        {
            lvDoanhThu.Items.Clear();
            HienThiGiay_BUS htg_bus = new HienThiGiay_BUS();
            Giay_BUS giay_bus = new Giay_BUS();
            List<HienThiGiay_DTO> listGiay = new List<HienThiGiay_DTO>();
            listGiay = htg_bus.LayDanhSach();
            CultureInfo cul = new CultureInfo("vi-VN");
            foreach(HienThiGiay_DTO item in listGiay)
            {
                int slDaBan = giay_bus.SLGiayDaBanTheoNgay(item.id,item.size,dtpNgayBatDauDoanhThu.Value,dtpNgayKetThucDoanhThu.Value);
                ListViewItem lvItem = new ListViewItem(item.id.ToString());
                lvItem.SubItems.Add(item.tenGiay);
                lvItem.SubItems.Add(item.size);
                lvItem.SubItems.Add(item.giaNhap.ToString("c",cul));
                lvItem.SubItems.Add(item.giaBan.ToString("c",cul));
                int loiNhuan1sp = item.giaBan-item.giaNhap;
                lvItem.SubItems.Add(loiNhuan1sp.ToString("c",cul));
                lvItem.SubItems.Add(slDaBan.ToString());
                lvItem.SubItems.Add((item.giaBan * slDaBan).ToString("c",cul));
                lvItem.SubItems.Add((loiNhuan1sp * slDaBan).ToString("c",cul));
                lvDoanhThu.Items.Add(lvItem);
            }

        }

        void LoadDoanhThuTenGiay()
        {
            lvDoanhThu.Items.Clear();
            HienThiGiay_BUS htg_bus = new HienThiGiay_BUS();
            Giay_BUS giay_bus = new Giay_BUS();
            List<HienThiGiay_DTO> listGiay = new List<HienThiGiay_DTO>();
            listGiay = htg_bus.LayDanhSach();
            CultureInfo cul = new CultureInfo("vi-VN");
            foreach (HienThiGiay_DTO item in listGiay)
            {
                int slDaBan = giay_bus.SLGiayDaBanTheoNgay(item.id,item.size,dtpNgayBatDauDoanhThu.Value, dtpNgayKetThucDoanhThu.Value);
                int loiNhuan1sp = item.giaBan - item.giaNhap;
                int doanhThu = item.giaBan * slDaBan;
                if(item.tenGiay == cbTenGiay.Text)
                {
                    ListViewItem lvItem = new ListViewItem(item.id.ToString());
                    lvItem.SubItems.Add(item.tenGiay);
                    lvItem.SubItems.Add(item.size);
                    lvItem.SubItems.Add(item.giaNhap.ToString("c", cul));
                    lvItem.SubItems.Add(item.giaBan.ToString("c", cul));
                    lvItem.SubItems.Add(loiNhuan1sp.ToString("c", cul));
                    lvItem.SubItems.Add(slDaBan.ToString());
                    lvItem.SubItems.Add(doanhThu.ToString("c", cul));
                    lvItem.SubItems.Add((loiNhuan1sp * slDaBan).ToString("c", cul));
                    lvDoanhThu.Items.Add(lvItem);
                }
            }
        }
        void LoadDoanhThuSoLuongDaBan()
        {
            lvDoanhThu.Items.Clear();
            HienThiGiay_BUS htg_bus = new HienThiGiay_BUS();
            Giay_BUS giay_bus = new Giay_BUS();
            List<HienThiGiay_DTO> listGiay = new List<HienThiGiay_DTO>();
            listGiay = htg_bus.LayDanhSach();
            CultureInfo cul = new CultureInfo("vi-VN");
            foreach (HienThiGiay_DTO item in listGiay)
            {
                int slDaBan = giay_bus.SLGiayDaBanTheoNgay(item.id,item.size, dtpNgayBatDauDoanhThu.Value, dtpNgayKetThucDoanhThu.Value);
                int loiNhuan1sp = item.giaBan - item.giaNhap;
                int doanhThu = item.giaBan * slDaBan;
                if (slDaBan >= numSLDB.Value)
                {
                    ListViewItem lvItem = new ListViewItem(item.id.ToString());
                    lvItem.SubItems.Add(item.tenGiay);
                    lvItem.SubItems.Add(item.size);
                    lvItem.SubItems.Add(item.giaNhap.ToString("c", cul));
                    lvItem.SubItems.Add(item.giaBan.ToString("c", cul));
                    lvItem.SubItems.Add(loiNhuan1sp.ToString("c", cul));
                    lvItem.SubItems.Add(slDaBan.ToString());
                    lvItem.SubItems.Add(doanhThu.ToString("c", cul));
                    lvItem.SubItems.Add((loiNhuan1sp * slDaBan).ToString("c", cul));
                    lvDoanhThu.Items.Add(lvItem);
                }
            }
        }

        void LoadDoanhThuTheoDoanhThu()
        {
            lvDoanhThu.Items.Clear();
            HienThiGiay_BUS htg_bus = new HienThiGiay_BUS();
            Giay_BUS giay_bus = new Giay_BUS();
            List<HienThiGiay_DTO> listGiay = new List<HienThiGiay_DTO>();
            listGiay = htg_bus.LayDanhSach();
            CultureInfo cul = new CultureInfo("vi-VN");
            foreach (HienThiGiay_DTO item in listGiay)
            {
                int slDaBan = giay_bus.SLGiayDaBanTheoNgay(item.id,item.size, dtpNgayBatDauDoanhThu.Value, dtpNgayKetThucDoanhThu.Value);
                int loiNhuan1sp = item.giaBan - item.giaNhap;
                int doanhThu = item.giaBan * slDaBan;
                if (doanhThu >= numDoanhThu.Value)
                {
                    ListViewItem lvItem = new ListViewItem(item.id.ToString());
                    lvItem.SubItems.Add(item.tenGiay);
                    lvItem.SubItems.Add(item.size);
                    lvItem.SubItems.Add(item.giaNhap.ToString("c", cul));
                    lvItem.SubItems.Add(item.giaBan.ToString("c", cul));
                    lvItem.SubItems.Add(loiNhuan1sp.ToString("c", cul));
                    lvItem.SubItems.Add(slDaBan.ToString());
                    lvItem.SubItems.Add(doanhThu.ToString("c", cul));
                    lvItem.SubItems.Add((loiNhuan1sp * slDaBan).ToString("c", cul));
                    lvDoanhThu.Items.Add(lvItem);
                }
            }
        }


        #endregion

        

        #region Sự Kiện
        private void btnThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            if(rdbTatCaGiay.Checked)
            {
                LoadDoanhThuTatCa();
            }
            else if(rdbTenGiay.Checked)
            {
                LoadDoanhThuTenGiay();
            }
            else if(rdbSoLuongGiay.Checked)
            {
                LoadDoanhThuSoLuongDaBan();
            }
            else if(rdbDoanhThuGiay.Checked)
            {
                LoadDoanhThuTheoDoanhThu();
            }
        }
        #endregion

        private void dtgvDSNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow != -1)
            {
                if (dtgvDSNCC.Rows[numrow].Cells[0].Value.ToString() != "")
                {
                    txtMaNCC.Text = dtgvDSNCC.Rows[numrow].Cells[0].Value.ToString();
                    txtTenNCC.Text = dtgvDSNCC.Rows[numrow].Cells[1].Value.ToString();
                    txtSDTNCC.Text = dtgvDSNCC.Rows[numrow].Cells[2].Value.ToString();
                    txtEmailNCC.Text = dtgvDSNCC.Rows[numrow].Cells[3].Value.ToString();
                    txtDiaChiNCC.Text = dtgvDSNCC.Rows[numrow].Cells[4].Value.ToString();
                    txtWebsiteNCC.Text = dtgvDSNCC.Rows[numrow].Cells[5].Value.ToString();
                }
            }
        }




        #endregion

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = new DataTable();
        //    if (lvDoanhThu.Items.Count > 0)
        //    {
        //        //dt.Columns.Add();
        //        foreach (ListViewItem.ListViewSubItem lvsi in lvDoanhThu.Items[0].SubItems)
        //            dt.Columns.Add(lvsi.Text);
        //        //now we have all the columns that we need, let's add rows
        //        foreach (ListViewItem item in lvDoanhThu.Items)
        //        {
        //            List<string> row = new List<string>();
        //            //row.Add(item.Text);
        //            foreach (var it in item.SubItems)
        //            {
        //                string[] a = it.ToString().Split('{');
        //                a[1] = a[1].Substring(0, a[1].Length - 1);
        //                row.Add(a[1]);
        //            }//Add the row into the DataTable
        //            dt.Rows.Add(row.ToArray());
        //        }
        //    }

        //    DataView dv = new DataView(dt);
        //    dataGridView1.DataSource = dv;
        //}





        #endregion
    }
}