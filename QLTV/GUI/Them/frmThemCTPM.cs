﻿using QLTV.Control;
using QLTV.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV.GUI.Them
{
    public partial class frmThemCTPM : Form
    {
        private PhieuMuon PM;
        public frmThemCTPM()
        {
            InitializeComponent();
            PM = new PhieuMuon();
            loadSach();
        }
        public frmThemCTPM(int maPM)
        {
            InitializeComponent();
            PM = new PhieuMuon(maPM);

        }

        private void loadSach()
        {
            dgvSach.Rows.Clear();
            DataTable dt = ChiTietPMControl.layDanhSachSach();
            for(int i = 0; i < dt.Rows.Count; ++i)
            {
                int soluong = 0;
                int vitri = PM.ChiTiet.isContain(Convert.ToInt32(dt.Rows[i]["MaSach"].ToString()));
                if(vitri != -1)
                {
                    soluong = Convert.ToInt32(dt.Rows[i]["SoLuong"].ToString()) - PM.ChiTiet.ListSach[vitri].SoLuong;
                }
                else
                {
                    soluong = Convert.ToInt32(dt.Rows[i]["SoLuong"].ToString());
                }
                dgvSach.Rows.Add(new object[] { dt.Rows[i]["MaSach"], dt.Rows[i]["TenSach"], dt.Rows[i]["TenTG"], soluong});
            }
        }
        private void loadChiTiet()
        {
            dgvChiTiet.Rows.Clear();
            for(int i = 0; i < PM.ChiTiet.ListSach.Count; ++i)
            {
                dgvChiTiet.Rows.Add(new object[] { PM.ChiTiet.ListSach[i].TenSach, PM.ChiTiet.ListSach[i].SoLuong});

                dgvChiTiet.Rows[dgvChiTiet.Rows.Count - 2].Tag = PM.ChiTiet.ListSach[i].MaSach;
            }

        }

        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if(e.ColumnIndex == dgvSach.Columns["colChon"].Index)
            {
                int soluong = Convert.ToInt32(dgvSach.Rows[e.RowIndex].Cells["colSoLuong"].Value.ToString());
                if (soluong == 0) return;
                int maSach = Convert.ToInt32(dgvSach.Rows[e.RowIndex].Cells["colMa"].Value.ToString());
                PM.ChiTiet.ThemSach(maSach);
                dgvSach.Rows[e.RowIndex].Cells["colSoLuong"].Value = soluong - 1;
                loadChiTiet();
            }
        }

        private void dgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == dgvChiTiet.Columns["colTang"].Index)
            {
                int soluong = Convert.ToInt32(dgvSach.Rows[e.RowIndex].Cells["colSoLuong"].Value.ToString());
                if (soluong == 0) return;
                int maSach = Convert.ToInt32(dgvChiTiet.Rows[e.RowIndex].Tag.ToString());
                PM.ChiTiet.ThemSach(maSach);
                loadChiTiet();
                loadSach();
            }
            else if(e.ColumnIndex == dgvChiTiet.Columns["colGiam"].Index)
            {
                int soluong = Convert.ToInt32(dgvSach.Rows[e.RowIndex].Cells["colSoLuong"].Value.ToString());
                int maSach = Convert.ToInt32(dgvChiTiet.Rows[e.RowIndex].Tag.ToString());
                PM.ChiTiet.GiamSach(maSach);
                loadChiTiet();
                loadSach();
            }
            else if(e.ColumnIndex == dgvChiTiet.Columns["colXoa"].Index)
            {
                int maSach = Convert.ToInt32(dgvChiTiet.Rows[e.RowIndex].Tag.ToString());
                PM.ChiTiet.xoaSach(maSach);
                loadChiTiet();
                loadSach();
            }
        }
    }
}
