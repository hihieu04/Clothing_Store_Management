﻿using DOAN_Nhom4.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_Nhom4
{
    public partial class FrmXacNhanGIaoDichTinDung : Form
    {
        private KhachHang kh;
        private TaiKhoanNganHang tknh;
        private Panel pnlNguoiDung;
        private TaiKhoanTinDung tttd;
        private ThongTinTinDungDAO tttdDAO = new ThongTinTinDungDAO();
        private TaiKhoanNganHangDAO tknhDAO = new TaiKhoanNganHangDAO();
        private LichSuGiaoDichDAO lsgdDAO = new LichSuGiaoDichDAO();
        public FrmXacNhanGIaoDichTinDung()
        {
            InitializeComponent();
        }

        public FrmXacNhanGIaoDichTinDung(KhachHang kh, TaiKhoanNganHang tknh, Panel pnlNguoiDung, TaiKhoanTinDung tttd)
        {
            InitializeComponent();
            this.kh = kh;
            this.tknh = tknh;
            this.pnlNguoiDung = pnlNguoiDung;
            this.tttd = tttd;
        }

        private void FrmXacNhanGIaoDichTinDung_Load(object sender, EventArgs e)
        {
            lblHienThiTKNguon.Text = tknh.SoTk;
            lblHienThiTKTinDung.Text = tttd.SoTktinDung;
            lblHienThiTienDaSuDung.Text = tttd.SoTienDaSuDung.Value.ToString("0");
            txt_NgayGiaoDich.Value = DateTime.Now;
            lblHienThiPhiTraCham.Text = tttd.PhiTraCham.Value.ToString("0");
            lblHienThiPhiPhat.Text = tttd.PhiPhat.Value.ToString("0");
            lblHienThiTongSoTien.Text = (tttd.PhiTraCham + tttd.PhiPhat + tttd.SoTienDaSuDung).Value.ToString("0");
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (tknh.SoDu >= Int64.Parse(lblHienThiTongSoTien.Text))
            {
                LichSuGiaoDich gd = new LichSuGiaoDich()
                {
                    LoaiGd = "Tin Dung",
                    NganHangGui = tknh.TenNh,
                    SoTkgui = tknh.SoTk,
                    TenTkgui = kh.TenKh,
                    NganHangNhan = "HHB",
                    TenTknhan = tttd.HoTen,
                    SoTknhan = tttd.SoTktinDung,
                    ThoiGian = DateTime.Now,
                    SoTien = decimal.Parse(lblHienThiTongSoTien.Text),
                    LoiNhan = "Thanh toan tien tinh dung"
                };
                lsgdDAO.Them(gd);
                tknhDAO.RutTien(tknh, gd);
                tttdDAO.CapNhatTinDungHangThang(tttd);
                tttdDAO.Sua(tttd);
                tknh = tknhDAO.LayTaiKhoanNganHang(gd.SoTkgui, gd.NganHangGui);
                FrmThongbaoChuyentien frmThongbaoChuyentien = new FrmThongbaoChuyentien(kh, gd, tknh, pnlNguoiDung);
                frmThongbaoChuyentien.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Số dư của bạn không đủ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            FrmThongTinTaiKhoanTinDung frmThongTinTaiKhoangTinDung = new FrmThongTinTaiKhoanTinDung(kh, tknh, pnlNguoiDung, tttd);
            Utility.addForm(frmThongTinTaiKhoangTinDung, pnlNguoiDung);
        }
    }
}
