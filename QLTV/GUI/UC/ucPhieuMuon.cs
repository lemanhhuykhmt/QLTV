﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLTV.Control;
using QLTV.GUI.Them;

namespace QLTV.GUI.UC
{
    public partial class ucPhieuMuon : UserControl
    {
        public ucPhieuMuon()
        {
            InitializeComponent();
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            dgvDanhSach.Rows.Clear();
            DataTable dt = PhieuMuonControl.layDanhSach();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                string ngayMuon = String.Format("{0:dd/MM/yyyy}", dt.Rows[i][2]);
                string ngayTra = String.Format("{0:dd/MM/yyyy}", dt.Rows[i][3]);
                dgvDanhSach.Rows.Add(new object[] { false, dt.Rows[i][0], dt.Rows[i][1], ngayMuon, ngayTra});
            }
        }
        private void btnNhap_Click(object sender, EventArgs e)
        {
            frmThemCTPM f = new frmThemCTPM();
            f.ShowDialog();
            loadDuLieu();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            //int ketQua = 0;
            //for (int i = 0; i < dgvDanhSach.Rows.Count - 1; ++i)
            //{
            //    if (Convert.ToBoolean(dgvDanhSach.Rows[i].Cells["colCheck"].Value.ToString()))
            //    {
            //        ketQua += GiaoVienControl.xoaThongTin(Convert.ToInt32(dgvDanhSach.Rows[i].Cells["colMa"].Value.ToString()));
            //    }
            //}
            //if (ketQua > 0)
            //{
            //    MessageBox.Show("xóa thành công " + ketQua);
            //    loadDuLieu();
            //}
            //else
            //{
            //    MessageBox.Show("xóa thất bại");
            //}
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            timKiem();
        }
        private void timKiem()
        {
            // get text
            string value = txtTimKiem.Text;
            if (value.Length == 0)
            {
                loadDuLieu();
                return;
            }
            dgvDanhSach.Rows.Clear();
            DataTable dt = PhieuMuonControl.timKiem(value);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                string ngayMuon = String.Format("{0:dd/MM/yyyy}", dt.Rows[i][2]);
                string ngayTra = String.Format("{0:dd/MM/yyyy}", dt.Rows[i][3]);
                dgvDanhSach.Rows.Add(new object[] { false, dt.Rows[i][0], dt.Rows[i][1], ngayMuon, ngayTra });
            }
        }
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSach.Rows.Count == e.RowIndex + 1 || e.RowIndex == -1) return;
            int id = Convert.ToInt32(dgvDanhSach.Rows[e.RowIndex].Cells["colMa"].Value.ToString());
            if (e.ColumnIndex == dgvDanhSach.Columns["colSua"].Index)
            {
                frmThemCTPM f = new frmThemCTPM(id);
                f.ShowDialog();
                loadDuLieu();
            }
            else if (e.ColumnIndex == dgvDanhSach.Columns["colXoa"].Index)
            {
                int ketQua = PhieuMuonControl.xoaDuLieu(id);
                if (ketQua <= 0)
                {
                    MessageBox.Show("Thực hiện thất bại");
                }
                else
                {
                    loadDuLieu();
                }
            }
            //else if (e.ColumnIndex == dgvDanhSach.Columns["colChiTiet"].Index)
            //{
            //    //
            //}
        }

        private void txtTimKiem_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                timKiem();
            }
            else if (e.KeyValue == 27)
            {
                txtTimKiem.Text = "";
            }
        }
    }
}
