using QLTV.Control;
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
            loadDSDocGia();
        }
        public frmThemCTPM(int maPM)
        {
            InitializeComponent();
            PM = new PhieuMuon(maPM);
            loadDSDocGia();
            loadSach();
            loadChiTiet();
            loadThongTin();
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
        private void loadDSDocGia()
        {
            List<DocGia> listDG = new List<DocGia>();
            DataTable dt = ChiTietPMControl.layDanhSachDG();
            for(int i = 0; i < dt.Rows.Count; ++i)
            {
                listDG.Add(new DocGia() { MaDG = Convert.ToInt32(dt.Rows[i]["MaDG"].ToString()), TenDG = dt.Rows[i]["TenDG"].ToString()});
            }
            cbDocGia.DataSource = listDG;
            cbDocGia.DisplayMember = "TenDG";
        }
        private void loadThongTin()
        {
            DataTable dt = PhieuMuonControl.layThongTin(PM.MaPM);
            PM.NguoiDoc = new DocGia(dt.Rows[0]["MaDG"].ToString().Length == 0 ? 0 : Convert.ToInt32(dt.Rows[0]["MaDG"].ToString()));
            cbDocGia.Text = PM.NguoiDoc.TenDG;
            dtpNgayMuon.Value = PM.NgayMuon;
            if(!PM.NgayTra.ToString().Equals(new DateTime(1900, 1, 1).ToString()))
            {
                dtpNgayTra.Enabled = true;
                ckbNgayTra.Checked = true;
                dtpNgayTra.Value = PM.NgayTra;
            }
            else
            {
                dtpNgayTra.Enabled = false;
                ckbNgayTra.Checked = false;
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

        private void ckbNgayTra_CheckedChanged(object sender, EventArgs e)
        {
            dtpNgayTra.Enabled = ckbNgayTra.Checked;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(PM.MaPM == 0)
            {
                string ngaytra = "";
                if (ckbNgayTra.Checked == false)
                {
                    ngaytra = "";
                }
                else
                {
                    ngaytra = dtpNgayTra.Text;
                }
                int ketqua = PhieuMuonControl.themDuLieu(PM.NguoiDoc.MaDG, PM.NgayMuon.ToString(), ngaytra);
                if(ketqua <= 0)
                {
                    return;
                }
                ketqua = 0;
                PM.MaPM = PhieuMuonControl.layMaPMMoi();
                if (PM.MaPM == 0) return;
                for (int i = 0; i < PM.ChiTiet.ListSach.Count; ++i)
                {
                    ketqua += ChiTietPMControl.themDuLieu(PM.MaPM, PM.ChiTiet.ListSach[i].MaSach, PM.ChiTiet.ListSach[i].SoLuong);
                }
                if (ketqua > 0)
                {
                    MessageBox.Show("them thanh cong");
                    this.Close();
                }
            }
            else
            {
                //
                int docgia = PM.NguoiDoc.MaDG;
                string ngaymuon = dtpNgayMuon.Text;
                string ngaytra = "";
                if (ckbNgayTra.Checked == true)
                {
                    ngaytra = dtpNgayTra.Text;
                }
                int ketqua = PhieuMuonControl.suaDuLieu(PM.MaPM, docgia, ngaymuon, ngaytra);
                if(ketqua <= 0)
                {
                    return;
                }
                //
                PhieuMuonControl.xoaChiTiet(PM.MaPM);
                //
                ketqua = 0;
                for (int i = 0; i < PM.ChiTiet.ListSach.Count; ++i)
                {
                    ketqua += ChiTietPMControl.themDuLieu(PM.MaPM, PM.ChiTiet.ListSach[i].MaSach, PM.ChiTiet.ListSach[i].SoLuong);
                }
                if (ketqua > 0)
                {
                    MessageBox.Show("sua thanh cong");
                    this.Close();
                }
            }
        }

        private void cbDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            PM.NguoiDoc = cbDocGia.SelectedValue as DocGia;
        }
    }
}
