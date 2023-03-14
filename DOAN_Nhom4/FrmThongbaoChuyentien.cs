﻿using System;
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
    public partial class FrmThongbaoChuyentien : Form
    {
        public NguoiDung kh;
        public TaiKhoangNganHang tknh;
        public GiaoDichChuyenTien gd;
        public FrmThongbaoChuyentien()
        {
            InitializeComponent();
        }

        public FrmThongbaoChuyentien(NguoiDung kh, GiaoDichChuyenTien gd, TaiKhoangNganHang tknh)
        {
            InitializeComponent();
            this.kh = kh;
            this.gd = gd;
            this.tknh = tknh;
        }
        private void FrmThongbaoChuyentien_Load(object sender, EventArgs e)
        {
            lblSotien.Text = gd.SoTien.ToString() + " VNĐ";
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblNguoinhan.Text = gd.TenTK.ToString();
            lblSTK.Text = gd.SoTk.ToString();
            lblNganhang.Text = gd.NganHang.ToString();
            lblNoidung.Text = gd.LoiNhan.ToString();
        }
        private void picBoxQuaylai_Click(object sender, EventArgs e)
        {
            FrmTrangchu frmnguoidung = new FrmTrangchu(kh, tknh, gd);
            this.Hide();
            frmnguoidung.ShowDialog();
            this.Close();
        }

        private void lblQuaylai_Click(object sender, EventArgs e)
        {
            FrmTrangchu frmnguoidung = new FrmTrangchu(kh, tknh, gd);
            this.Hide();
            frmnguoidung.ShowDialog();
            this.Close();
        }
    }
}
