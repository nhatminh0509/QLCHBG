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
    public partial class frmBanHang : Form
    {
        int idGiay = 0;
        int SLTon = 0;
        public frmBanHang()
        {
            
            InitializeComponent();
            LoadHangGiay();
            LoadGiay();
        }


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

        void LoadSL()
        {
            HoaDon_BUS hd_bus = new HoaDon_BUS();
            HoaDon_DTO hd = hd_bus.LayHoaDonChuaThanhToanTheoSDTKH(txtSDTKH.Text);
            HienThiHoaDon_BUS hthd_bus = new HienThiHoaDon_BUS();
            List<HienThiHoaDon_DTO> listHTHD = hthd_bus.LayDanhSachTheoIDHoaDon(hd.id);

            int SoLuong = SLTon;
            
            
            foreach (HienThiHoaDon_DTO item in listHTHD)
            {
                if(item.tenGiay == txtTenGiay.Text && item.size == cbSize.Text  )
                {
                    SoLuong = SLTon - item.soLuong;
                }
            }
            lblSLTon.Text = "Còn:" + SoLuong;
            numSoLuong.Maximum = SoLuong;
            
        }

        void LoadThanhTien()
        {
            int soLuong = int.Parse(numSoLuong.Value.ToString());
            int donGia = int.Parse(txtGia.Text);
            int giamGia = int.Parse(txtGiamGia.Text);
            int thanhTien = (donGia - (donGia*giamGia)/100) * soLuong;
            txtThanhTien.Text = thanhTien.ToString();
        }

        void LoadKH(string sdt)
        {
            KhachHang_BUS kh_bus = new KhachHang_BUS();
            KhachHang_DTO kh = new KhachHang_DTO();
            kh = kh_bus.LayKH(sdt);
            txtTenKhachHang.Text = kh.tenKhachHang;
            txtTongChiTieu.Text = kh.tongChiTieu.ToString();
            if(kh.tongChiTieu>=2500000 && kh.tongChiTieu <5000000)
            {
                numGiamGia.Value = 5;
            }
            else if(kh.tongChiTieu >= 5000000 && kh.tongChiTieu <10000000)
            {
                numGiamGia.Value = 10;
            }
            else if(kh.tongChiTieu>=10000000)
            {
                numGiamGia.Value = 15;
            }
            else
            {
                numGiamGia.Value = 0;
            }
        }

        void ResetKH()
        {
            btnThemKH.Enabled = false;
            txtSDTKH.Text = "";
            txtTenKhachHang.Text = "";
            txtTongChiTieu.Text = "";
            numGiamGia.Value = 0;
        }

        void LoadThanhToan()
        {
            int giamGia = (int)numGiamGia.Value;
            int tongTien = int.Parse(txtTongTien.Text);
            int thanhToan = tongTien - (tongTien * giamGia / 100);
            txtThanhToan.Text = thanhToan.ToString();
        }

        void LoadHD()
        {
            if (txtSDTKH.Text != "")
            {
                HoaDon_BUS hd_bus = new HoaDon_BUS();
                HoaDon_DTO hd = new HoaDon_DTO();
                hd = hd_bus.LayHoaDonChuaThanhToanTheoSDTKH(txtSDTKH.Text);
                lvHoaDon.Tag = hd;
                if(hd.id == -1)
                {
                    lvHoaDon.Items.Clear();
                    btnHuyHoaDon.Enabled = false;
                    btnThanhToan.Enabled = false;
                    txtTongTien.Text = "0";
                }
                else
                {
                    btnHuyHoaDon.Enabled = true;
                    btnThanhToan.Enabled = true;
                    HienThiCTHoaDon(hd.id);
                    txtTongTien.Text = hd.tongTien.ToString();
                }
            }
        }

        void HienThiCTHoaDon(int idHoaDon)
        {
            lvHoaDon.Items.Clear();
            HoaDon_BUS hd_bus = new HoaDon_BUS();
            HienThiHoaDon_BUS hthd_bus = new HienThiHoaDon_BUS();
            List<HienThiHoaDon_DTO> listHTHD = new List<HienThiHoaDon_DTO>();
            listHTHD = hthd_bus.LayDanhSachTheoIDHoaDon(idHoaDon);

            int tongTien = 0;
            foreach (HienThiHoaDon_DTO item in listHTHD)
            {
                ListViewItem lvItem = new ListViewItem(item.tenGiay);
                lvItem.SubItems.Add(item.size);
                lvItem.SubItems.Add(item.soLuong.ToString());
                lvItem.SubItems.Add(item.donGia.ToString());
                lvItem.SubItems.Add(item.giamGia.ToString());
                lvItem.SubItems.Add(item.thanhTien.ToString());
                tongTien = tongTien + item.thanhTien;
                lvHoaDon.Items.Add(lvItem);
            }
            txtTongTien.Text = tongTien.ToString();
            hd_bus.CapNhatTien(idHoaDon,tongTien,(int)numGiamGia.Value,int.Parse(txtThanhToan.Text));
        }

        void ThanhToan(HoaDon_DTO hd)
        {
            KhachHang_BUS kh_bus = new KhachHang_BUS();
            HienThiHoaDon_BUS hthd_bus = new HienThiHoaDon_BUS();
            List<HienThiHoaDon_DTO> listHTHD = hthd_bus.LayDanhSachTheoIDHoaDon(hd.id);
            BangSize_BUS size_bus = new BangSize_BUS();
            int SoLuong = SLTon;

            foreach (HienThiHoaDon_DTO item in listHTHD)
            {
                size_bus.CapNhatSLDaBan(item.idGiay, item.size, item.soLuong);
            }

            HoaDon_BUS hd_bus = new HoaDon_BUS();
            if (hd_bus.ThanhToan(hd.id,int.Parse(txtTongTien.Text),(int)numGiamGia.Value,int.Parse(txtThanhToan.Text)))
            {
                kh_bus.ThanhToan(txtSDTKH.Text, int.Parse(txtThanhToan.Text));
                LoadHD();
                MessageBox.Show("Thanh Toán Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtSDTKH.Enabled = true;
            btnHuyHoaDon.Enabled = false;
            btnThanhToan.Enabled = false;

        }

        void HuyHD(HoaDon_DTO hd)
        {
            HoaDon_BUS hd_bus = new HoaDon_BUS();
            if (hd_bus.Huy(hd.id, int.Parse(txtTongTien.Text), (int)numGiamGia.Value, int.Parse(txtThanhToan.Text)))
            {
                LoadHD();
                MessageBox.Show("Hủy Hóa Đơn Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtSDTKH.Enabled = true;
            btnHuyHoaDon.Enabled = false;
            btnThanhToan.Enabled = false;
        }
        #endregion

        #region Sự Kiện

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmThemNhanhKH f = new frmThemNhanhKH();
            f.Load(txtSDTKH.Text);
            f.ShowDialog();
            btnThemKH.Enabled = false;
            txtSDTKH_Leave(sender, e);
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

        private void txtSDTKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTenKhachHang_TextChanged(object sender, EventArgs e)
        {
            lvHoaDon.Items.Clear();
            if (txtTenKhachHang.Text != "")
            {
                btnThemSP.Enabled = true;
            }
            else
            {
                btnThemSP.Enabled = false;
            }
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            BangSize_DTO size = (cbSize.SelectedItem as BangSize_DTO);
            SLTon = size.soLuong;
            LoadSL();
            txtGia.Text = size.giaBan.ToString();
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
            txtGiamGia.Text = giay.giamGia.ToString();
            picSP.BackgroundImage = Image.FromFile(giay.hinhAnh);
            picSP.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {
            LoadThanhTien();
        }

        private void txtSDTKH_Leave(object sender, EventArgs e)
        {
            if (txtSDTKH.Text != "")
            {
                KhachHang_BUS kh_bus = new KhachHang_BUS();
                if (kh_bus.KiemTra(txtSDTKH.Text))
                {
                    LoadKH(txtSDTKH.Text);
                    LoadHD();
                    btnThemKH.Enabled = false;
                }
                else
                {
                    
                    if (MessageBox.Show("Khách hàng mới, thêm khách hàng", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        btnThemKH.Enabled = true;
                        btnThemKH.PerformClick();
                    }
                    else
                    {
                        ResetKH();
                    }

                }
            }
            else
            {
                ResetKH();
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if(txtTenGiay.Text != "")
            {
                txtSDTKH.Enabled = false;
                HoaDon_BUS hd_bus = new HoaDon_BUS();
                ChiTietHoaDon_BUS cthd_bus = new ChiTietHoaDon_BUS();
                HoaDon_DTO hd = new HoaDon_DTO();
                hd = hd_bus.LayHoaDonChuaThanhToanTheoSDTKH(txtSDTKH.Text);
               
                if (hd.id == -1)
                {
                    HoaDon_DTO hd_moi = new HoaDon_DTO(-1,BienToanCuc.nvDangNhap.idNhanVien,txtSDTKH.Text,DateTime.Now,0,(int)numGiamGia.Value,0,0);
                    if(hd_bus.Them(hd_moi))
                    {
                        ChiTietHoaDon_DTO cthd = new ChiTietHoaDon_DTO(hd_bus.LastID(),idGiay,cbSize.Text,(int)numSoLuong.Value);
                        cthd_bus.Them(cthd);
                        HienThiCTHoaDon(hd_bus.LastID());
                        LoadSL();
                        lvHoaDon.Tag = hd_bus.LayHoaDonChuaThanhToanTheoSDTKH(txtSDTKH.Text);
                        LoadHD();
                    }
                }
                else
                {
                    ChiTietHoaDon_DTO cthd = new ChiTietHoaDon_DTO(hd.id, idGiay, cbSize.Text, (int)numSoLuong.Value);
                    cthd_bus.Them(cthd);
                    HienThiCTHoaDon(hd.id);
                    LoadSL();
                    lvHoaDon.Tag = hd;
                    LoadHD();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm !!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            LoadThanhToan();
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            LoadThanhToan();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn muốn thanh toán cho khách hàng: "+txtTenKhachHang.Text+"\nThanh Toán:"+txtThanhToan.Text+" VND","Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK)
            {
                HoaDon_DTO hd = (lvHoaDon.Tag as HoaDon_DTO);
                ThanhToan(hd);
                ResetKH();
            }
        }
        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn hủy hóa đơn cho khách hàng: "+txtTenKhachHang.Text+" ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                HoaDon_DTO hd = (lvHoaDon.Tag as HoaDon_DTO);
                HuyHD(hd);
                ResetKH();
            }
        }
        private void btnTimTenGiay_Click(object sender, EventArgs e)
        {
            LoadGiayTheoTenGiay(txtTimTheoTenGiay.Text);
        }

        #endregion

        

         
      

        

    }
}
