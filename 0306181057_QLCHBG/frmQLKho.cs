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
    public partial class frmQLKho : Form
    {
        int idGiay = 0;
        public frmQLKho()
        {
            InitializeComponent();
            LoadHangGiay();
            LoadGiay();
            CapNhapDanhSachTonKho();
        }
        #region Phieu Nhap
        #region Hàm

        public void LoadHangGiay()
        {

            tvHangGiay.Nodes.Clear();
            List<HangGiay_DTO> listHang = new List<HangGiay_DTO>();
            List<LoaiGiay_DTO> listLoaiGiay = new List<LoaiGiay_DTO>();
            HangGiay_BUS hangGiay_bus = new HangGiay_BUS();
            LoaiGiay_BUS loaiGiay_bus = new LoaiGiay_BUS();

            listHang = hangGiay_bus.LayDanhSach();
            

            tvHangGiay.Nodes.Add("Tất Cả");
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
            tvHangGiay.ExpandAll();
            cbHangGiay.DataSource = listHang;
            cbHangGiay.DisplayMember = "tenHang";
            cbHangGiay.ValueMember = "id";
        }

        public void LoadGiay()
        {
            flpGiay.Controls.Clear();
            Giay_BUS giay_bus = new Giay_BUS();
            List<Giay_DTO> listGiay = giay_bus.LayDanhSach();
            foreach (Giay_DTO item in listGiay)
            {
                Button btn = new Button() { Width = 150, Height = 150 };
                btn.Text = item.tenGiay;
                btn.Tag = item;
                btn.Click += btn_Click;
                btn.BackgroundImage = Image.FromFile(item.hinhAnh);
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.TextAlign = ContentAlignment.BottomCenter;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Transparent;
                flpGiay.Controls.Add(btn);

            }
        }

        public void LoadGiayTheoHang(int idHang)
        {
            flpGiay.Controls.Clear();
            Giay_BUS giay_bus = new Giay_BUS();
            List<Giay_DTO> listGiay = giay_bus.LayDanhSach();
            foreach (Giay_DTO item in listGiay)
            {
                if (item.idHangGiay == idHang)
                {
                    Button btn = new Button() { Width = 150, Height = 150 };
                    btn.Text = item.tenGiay;
                    btn.Tag = item;
                    btn.Click += btn_Click;
                    btn.BackgroundImage = Image.FromFile(item.hinhAnh);
                    btn.BackgroundImageLayout = ImageLayout.Zoom;
                    btn.TextAlign = ContentAlignment.BottomCenter;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = Color.Transparent;
                    flpGiay.Controls.Add(btn);
                }
            }
        }

        public void LoadGiayTheoLoaiGiay(int idLoaiGiay)
        {
            flpGiay.Controls.Clear();
            Giay_BUS giay_bus = new Giay_BUS();
            List<Giay_DTO> listGiay = giay_bus.LayDanhSach();
            foreach (Giay_DTO item in listGiay)
            {
                if (item.idLoaiGiay == idLoaiGiay)
                {
                    Button btn = new Button() { Width = 150, Height = 150 };
                    btn.Text = item.tenGiay;
                    btn.Tag = item;
                    btn.Click += btn_Click;
                    btn.BackgroundImage = Image.FromFile(item.hinhAnh);
                    btn.BackgroundImageLayout = ImageLayout.Zoom;
                    btn.TextAlign = ContentAlignment.BottomCenter;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = Color.Transparent;
                    flpGiay.Controls.Add(btn);
                }
            }
        }

        public void LoadGiayTheoTenGiay(string tenGiay)
        {
            flpGiay.Controls.Clear();
            Giay_BUS giay_bus = new Giay_BUS();
            List<Giay_DTO> listGiay = giay_bus.Tim(tenGiay);
            foreach (Giay_DTO item in listGiay)
            {
                Button btn = new Button() { Width = 150, Height = 150 };
                btn.Text = item.tenGiay;
                btn.Tag = item;
                btn.Click += btn_Click;
                btn.BackgroundImage = Image.FromFile(item.hinhAnh);
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.TextAlign = ContentAlignment.BottomCenter;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Transparent;
                flpGiay.Controls.Add(btn);
            }
        }

        void LoadSize(int idGiay)
        {
            BangSize_BUS size_bus = new BangSize_BUS();
            cbSize.DataSource = size_bus.LayDanhSachTheoIDGiay(idGiay);
            cbSize.DisplayMember = "sizeGiay";
            cbSize.ValueMember = "soLuong";
            cbSize.SelectedIndex = 0;
        }

        void LoadThanhTien()
        {
            long soLuongNhap;
            long donGiaNhap;
            try
            {
                soLuongNhap = long.Parse(txtSoLuongNhap.Text);
            }
            catch
            {
                soLuongNhap = 0;
            }
            try
            {
                donGiaNhap = long.Parse(txtGiaNhap.Text);
            }
            catch
            {
                donGiaNhap = 0;
            }
            long thanhTien = soLuongNhap * donGiaNhap;
            txtThanhTien.Text = thanhTien.ToString();
        }

        void LoadHDNhap()
        {
            if (txtMaNCC.Text != "")
            {
                HoaDonNhap_BUS hdnhap_bus = new HoaDonNhap_BUS();
                HoaDonNhap_DTO hd_nhap = new HoaDonNhap_DTO();
                hd_nhap = hdnhap_bus.LayHoaDonChuaNhapTheoMaNCC(txtMaNCC.Text);
                lvHoaDon.Tag = hd_nhap;
                if (hd_nhap.id == -1)
                {
                    lvHoaDon.Items.Clear();
                    btnHuyHoaDon.Enabled = false;
                    btnNhapKho.Enabled = false;
                    txtTongTien.Text = "0";
                }
                else
                {
                    btnHuyHoaDon.Enabled = true;
                    btnNhapKho.Enabled = true;
                    HienThiCTHoaDonNhap(hd_nhap.id);
                    txtTongTien.Text = hd_nhap.tongTien.ToString();
                }
            }
        }

        void LoadNCC(string maNCC)
        {
            NhaCungCap_BUS ncc_bus = new NhaCungCap_BUS();
            NhaCungCap_DTO ncc = new NhaCungCap_DTO();
            ncc = ncc_bus.LayNCC(maNCC);
            txtTenNCC.Text = ncc.tenNhaCungCap;
            txtDiaChiNCC.Text = ncc.diaChi;
        }

        void ResetNCC()
        {
            btnThemNCC.Enabled = false;
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChiNCC.Text = "";
        }

        void HienThiCTHoaDonNhap(int idHoaDonNhap)
        {
            lvHoaDon.Items.Clear();
            HoaDonNhap_BUS hdnhap_bus = new HoaDonNhap_BUS();
            HienThiHoaDonNhap_BUS hthdnhap_bus = new HienThiHoaDonNhap_BUS();
            List<HienThiHoaDonNhap_DTO> listHTHD = new List<HienThiHoaDonNhap_DTO>();
            listHTHD = hthdnhap_bus.LayDanhSachTheoIDHoaDonNhap(idHoaDonNhap);

            int tongTien = 0;
            foreach (HienThiHoaDonNhap_DTO item in listHTHD)
            {
                ListViewItem lvItem = new ListViewItem(item.tenGiay);
                lvItem.SubItems.Add(item.size);
                lvItem.SubItems.Add(item.soLuong.ToString());
                lvItem.SubItems.Add(item.donGia.ToString());
                lvItem.SubItems.Add(item.thanhTien.ToString());
                tongTien = tongTien + item.thanhTien;
                lvHoaDon.Items.Add(lvItem);
            }
            txtTongTien.Text = tongTien.ToString();
            hdnhap_bus.CapNhatTien(idHoaDonNhap, tongTien);
        }

        void NhapKho(HoaDonNhap_DTO hd_nhap)
        {
            HienThiHoaDonNhap_BUS hthdnhap_bus = new HienThiHoaDonNhap_BUS();
            List<HienThiHoaDonNhap_DTO> listHTHD = hthdnhap_bus.LayDanhSachTheoIDHoaDonNhap(hd_nhap.id);
            BangSize_BUS size_bus = new BangSize_BUS();

            foreach (HienThiHoaDonNhap_DTO item in listHTHD)
            {
                size_bus.CapNhatKho(item.idGiay, item.size, item.soLuong, item.donGia);
            }

            HoaDonNhap_BUS hd_bus = new HoaDonNhap_BUS();
            if (hd_bus.NhapKho(hd_nhap.id, int.Parse(txtTongTien.Text)))
            {
                LoadHDNhap();
                MessageBox.Show("Thanh Toán Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtMaNCC.Enabled = true;
            btnHuyHoaDon.Enabled = false;
            btnNhapKho.Enabled = false;
        }

        void HuyNhap(HoaDonNhap_DTO hd_nhap)
        {
            HoaDonNhap_BUS hd_bus = new HoaDonNhap_BUS();
            if (hd_bus.Huy(hd_nhap.id, int.Parse(txtTongTien.Text)))
            {
                LoadHDNhap();
                MessageBox.Show("Hủy Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtMaNCC.Enabled = true;
            btnHuyHoaDon.Enabled = false;
            btnNhapKho.Enabled = false;

        }

        void ResetSP()
        {
            txtTenGiay.Text = "";
            txtTenHang.Text = "";
            txtLoaiGiay.Text = "";
            txtSoLuongNhap.Text = "0";
            txtGiaNhap.Text = "0";

        }
        #endregion

        #region Sự Kiện

        private void frmQLKho_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            HangGiay_BUS hang_bus = new HangGiay_BUS();
            LoaiGiay_BUS loaigiay_bus = new LoaiGiay_BUS();
            Giay_DTO giay = ((sender as Button).Tag) as Giay_DTO;
            idGiay = giay.id;
            txtTenGiay.Text = giay.tenGiay;
            txtTenHang.Text = hang_bus.LayTenBangID(giay.idHangGiay);
            txtLoaiGiay.Text = loaigiay_bus.LayTenBangID(giay.idLoaiGiay);
            LoadSize(giay.id);
            picSP.BackgroundImage = Image.FromFile(giay.hinhAnh);
            picSP.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void tvHangGiay_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = new TreeNode();
            node = e.Node;
            if (node.Text == "Tất Cả")
            {
                LoadGiay();
                return;
            }
            try
            {
                HangGiay_DTO hanggiay = (node.Tag as HangGiay_DTO);
                LoadGiayTheoHang(hanggiay.id);
            }
            catch
            {
                LoaiGiay_DTO loaigiay = (node.Tag as LoaiGiay_DTO);
                LoadGiayTheoLoaiGiay(loaigiay.id);
            }
        }

        private void txtSoLuongNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && char.IsControl('-'))
            {
                e.Handled = true;
            }
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTenNCC_TextChanged(object sender, EventArgs e)
        {
            lvHoaDon.Items.Clear();
            if (txtTenNCC.Text != "")
            {
                btnThemSP.Enabled = true;
            }
            else
            {
                btnThemSP.Enabled = false;
            }
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn nhập hàng từ nhà cung cấp: " + txtTenNCC.Text + "\nVới tổng giá trị hàng là:" + txtTongTien.Text + " VND", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                HoaDonNhap_DTO hd_nhap = (lvHoaDon.Tag as HoaDonNhap_DTO);
                NhapKho(hd_nhap);
                ResetNCC();
            }
        }

        private void txtMaNCC_Leave(object sender, EventArgs e)
        {
            if (txtMaNCC.Text != "")
            {
                NhaCungCap_BUS ncc_bus = new NhaCungCap_BUS();
                if (ncc_bus.KiemTra(txtMaNCC.Text))
                {
                    LoadNCC(txtMaNCC.Text);
                    LoadHDNhap();
                    btnThemNCC.Enabled = false;
                }
                else
                {

                    if (MessageBox.Show("Nhà cung cấp mới, thêm nhà cung cấp", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        btnThemNCC.Enabled = true;
                        btnThemNCC.PerformClick();
                    }
                    else
                    {
                        ResetNCC();
                    }

                }
            }
            else
            {
                ResetNCC();
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            frmThemNhanhNCC f = new frmThemNhanhNCC();
            f.Load(txtMaNCC.Text);
            f.ShowDialog();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if(txtTenGiay.Text != "")
            {
                txtMaNCC.Enabled = false;
                HoaDonNhap_BUS hdnhap_bus = new HoaDonNhap_BUS();
                ChiTietHoaDonNhap_BUS cthdnhap_bus = new ChiTietHoaDonNhap_BUS();
                HoaDonNhap_DTO hd_nhap = new HoaDonNhap_DTO();
                hd_nhap = hdnhap_bus.LayHoaDonChuaNhapTheoMaNCC(txtMaNCC.Text);
               
                if (hd_nhap.id == -1)
                {
                    HoaDonNhap_DTO hdnhap_moi = new HoaDonNhap_DTO(-1, BienToanCuc.nvDangNhap.idNhanVien, txtMaNCC.Text, DateTime.Now, 0, 0);
                    if(hdnhap_bus.Them(hdnhap_moi))
                    {
                        ChiTietHoaDonNhap_DTO cthd_nhap = new ChiTietHoaDonNhap_DTO(hdnhap_bus.LastID(),idGiay,cbSize.Text,int.Parse(txtSoLuongNhap.Text),int.Parse(txtGiaNhap.Text));
                        cthdnhap_bus.Them(cthd_nhap);
                        HienThiCTHoaDonNhap(hdnhap_bus.LastID());
                        lvHoaDon.Tag = hdnhap_bus.LayHoaDonChuaNhapTheoMaNCC(txtMaNCC.Text);
                        LoadHDNhap();
                    }
                }
                else
                {
                    ChiTietHoaDonNhap_DTO cthd_nhap = new ChiTietHoaDonNhap_DTO(hd_nhap.id, idGiay, cbSize.Text, int.Parse(txtSoLuongNhap.Text),int.Parse(txtGiaNhap.Text));
                    cthdnhap_bus.Them(cthd_nhap);
                    HienThiCTHoaDonNhap(hd_nhap.id);
                    lvHoaDon.Tag = hd_nhap;
                    LoadHDNhap();
                }
                ResetSP();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm !!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSoLuongNhap_TextChanged(object sender, EventArgs e)
        {
            LoadThanhTien();
        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            LoadThanhTien();
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy hóa đơn nhập này ??", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                HoaDonNhap_DTO hd_nhap = (lvHoaDon.Tag as HoaDonNhap_DTO);
                HuyNhap(hd_nhap);
                ResetNCC();
            }
        }

        private void btnTimTenGiay_Click(object sender, EventArgs e)
        {
            LoadGiayTheoTenGiay(txtTimTheoTenGiay.Text);
        }
        #endregion

        #endregion

        #region Tồn Kho

        #region Hàm

        void CapNhapDanhSachTonKho()
        {
            lvTonKho.Items.Clear();
            List<HienThiGiay_DTO> listGiay = new List<HienThiGiay_DTO>();
            HienThiGiay_BUS htgiay_bus = new HienThiGiay_BUS();
            listGiay = htgiay_bus.LayDanhSach();
            lvTonKho.Tag = listGiay;
            foreach (HienThiGiay_DTO item in listGiay)
            {
                ListViewItem lvItem = new ListViewItem(item.tenGiay);
                lvItem.SubItems.Add(item.tenHangGiay);
                lvItem.SubItems.Add(item.tenLoaiGiay);
                lvItem.SubItems.Add(item.size);
                lvItem.SubItems.Add(item.soLuong.ToString());
                lvItem.SubItems.Add(item.giaNhap.ToString());
                lvTonKho.Items.Add(lvItem);
            }
        }

        #endregion    

        #region Sự kiện

        private void cbHangGiay_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idHang;
            LoaiGiay_BUS loaiGiay_bus = new LoaiGiay_BUS();
            try
            {
                idHang = (int)cbHangGiay.SelectedValue;
            }
            catch
            {
                idHang = 1;
            }
            cbLoaiGiay.DataSource = loaiGiay_bus.LayDanhSachTheoIDHang(idHang);
            cbLoaiGiay.DisplayMember = "tenLoaiGiay";
            cbLoaiGiay.ValueMember = "id";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            List<HienThiGiay_DTO> listGiay = new List<HienThiGiay_DTO>();
            HienThiGiay_BUS htgiay_bus = new HienThiGiay_BUS();
            string query = "Select G.id,G.tenGiay,S.sizeGiay,HG.tenHang,LG.tenLoaiGiay,S.giaBan,S.giaNhap,G.giamGia,S.soLuong,G.hinhAnh,S.trangThai from HangGiay as HG,LoaiGiay as LG, Giay as G,BangSize as S where G.id = S.idGiay and G.idHangGiay = HG.id and G.idLoaiGiay = LG.id ";
            if (rdbTatCa.Checked)
            {
                CapNhapDanhSachTonKho();
                return;
            }
            else if (rdbTimTheoHangGiay.Checked)
            {
                if (ckcTimTheoLoaiGiay.Checked)
                {

                    query += "and S.trangThai = 1 and G.trangThai = 1 and  idLoaiGiay = " + cbLoaiGiay.SelectedValue;
                }
                else
                {
                    query += "and S.trangThai = 1 and G.trangThai = 1 and  idHangGiay = " + cbHangGiay.SelectedValue;
                }
            }
            else if (rdbTimTheoTenGiay.Checked)
            {
                query += "and S.trangThai = 1 and G.trangThai = 1 and  tenGiay Like N'%" + txtTimTenGiay.Text + "%'";
            }
            else if (rdbSLTon.Checked)
            {
                query += "and S.trangThai = 1 and G.trangThai = 1 and  soLuong >= " + numSLTon.Value;
            }
            listGiay = htgiay_bus.Tim(query);
            lvTonKho.Tag = listGiay;
            lvTonKho.Items.Clear();
            foreach (HienThiGiay_DTO item in listGiay)
            {
                ListViewItem lvItem = new ListViewItem(item.tenGiay);
                lvItem.SubItems.Add(item.tenHangGiay);
                lvItem.SubItems.Add(item.tenLoaiGiay);
                lvItem.SubItems.Add(item.size);
                lvItem.SubItems.Add(item.soLuong.ToString());
                lvItem.SubItems.Add(item.giaNhap.ToString());
                lvTonKho.Items.Add(lvItem);
            }
        }

        #endregion

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            btnTim.PerformClick();
            List<HienThiGiay_DTO> listGiay = new List<HienThiGiay_DTO>();
            listGiay = (lvTonKho.Tag as List<HienThiGiay_DTO>);

            
            frmInBaoCao f = new frmInBaoCao();
            if (rdbTatCa.Checked)
            {
                f.InTonKho(listGiay, "Tất Cả Giày Tồn Kho");
            }
            else if (rdbTimTheoTenGiay.Checked)
            {
                f.InTonKho(listGiay, "Giày có tên là: " + txtTimTenGiay.Text);
            }
            else if (rdbTimTheoHangGiay.Checked)
            {
                if(ckcTimTheoLoaiGiay.Checked)
                {
                    f.InTonKho(listGiay, "Giày Theo Loại: " + cbLoaiGiay.Text);
                }
                f.InTonKho(listGiay, "Giày Theo Hãng: " + cbHangGiay.Text);
            }
            else if (rdbSLTon.Checked)
            {
                f.InTonKho(listGiay, "Giày tồn kho trên: " + numSLTon.Value+" sản phẩm");
            }
            f.ShowDialog();
            
        }

       

        #endregion

    }
}
