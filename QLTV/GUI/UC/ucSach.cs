using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLTV.Model;
using QLTV.Control;
using QLTV.GUI.Them;

namespace QLTV.GUI.UC
{
    public partial class ucSach : UserControl
    {
        public ucSach()
        {
            InitializeComponent();
            loadDuLieu();
        }

        private void loadDuLieu()
        {
            dgvDanhSach.Rows.Clear();
            DataTable dt = SachControl.layDanhSach();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                // 
                dgvDanhSach.Rows.Add(new object[] { dt.Rows[i]["MaSach"], dt.Rows[i]["TenSach"], dt.Rows[i]["TenLoai"],
                dt.Rows[i]["TenTG"], dt.Rows[i]["NSB"], dt.Rows[i]["GiaTien"], dt.Rows[i]["SoLuong"]});
            }
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            txtMa.Text = dgvDanhSach.Rows[e.RowIndex].Cells["colMa"].Value.ToString();
            txtTen.Text = dgvDanhSach.Rows[e.RowIndex].Cells["colTen"].Value.ToString();
            cbLoai.Text = dgvDanhSach.Rows[e.RowIndex].Cells["colLoai"].Value.ToString();
            txtTacGia.Text = dgvDanhSach.Rows[e.RowIndex].Cells["colTacGia"].Value.ToString();
            txtNSB.Text = dgvDanhSach.Rows[e.RowIndex].Cells["colNSB"].Value.ToString();
            txtGiaTien.Text = dgvDanhSach.Rows[e.RowIndex].Cells["colGiaTien"].Value.ToString();
            txtSoLuong.Text = dgvDanhSach.Rows[e.RowIndex].Cells["colSoLuong"].Value.ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtTen.Text;
            LoaiSach loai = cbLoai.SelectedValue as LoaiSach;
            string tacgia = txtTacGia.Text;
            string nsb = txtNSB.Text;
            double gia = double.Parse(txtGiaTien.Text);
            int soluong = Convert.ToInt32(txtSoLuong.Text);
            if (true)
            {
                int ketqua = SachControl.themDuLieu(ten, loai.MaLoai, tacgia, nsb, gia, soluong);
                if (ketqua > 0)
                {
                    MessageBox.Show("thêm thành công");
                    txtTen.Text = txtTacGia.Text = txtNSB.Text = txtGiaTien.Text = txtSoLuong.Text = "";
                    loadDuLieu();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int ma = Convert.ToInt32(txtMa.Text);
            string ten = txtTen.Text;
            LoaiSach loai = cbLoai.SelectedValue as LoaiSach;
            string tacgia = txtTacGia.Text;
            string nsb = txtNSB.Text;
            double gia = double.Parse(txtGiaTien.Text);
            int soluong = Convert.ToInt32(txtSoLuong.Text);
            if (true)
            {
                int ketqua = SachControl.suaDuLieu(ma, ten, loai.MaLoai, tacgia, nsb, gia, soluong);
                if (ketqua > 0)
                {
                    MessageBox.Show("sửa thành công");
                    loadDuLieu();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int ma = Convert.ToInt32(txtMa.Text);
            if (SachControl.xoaDuLieu(ma) > 0)
            {
                MessageBox.Show("xoá thành công");
                txtTen.Text = txtTacGia.Text = txtNSB.Text = txtGiaTien.Text = txtSoLuong.Text = "";
                loadDuLieu();
            }
        }

        private void loadLoai()
        {
            List<LoaiSach> listSach = new List<LoaiSach>();
            DataTable dt = SachControl.layDanhSachLoai();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                listSach.Add(new LoaiSach()
                {
                    MaLoai = Convert.ToInt32(dt.Rows[i]["MaLoai"].ToString()),
                    TenLoai = dt.Rows[i]["TenLoai"].ToString()
                });
            }

            cbLoai.DataSource = listSach;
            cbLoai.DisplayMember = "TenLoai";
        }
        private void ucSach_Load(object sender, EventArgs e)
        {
            loadLoai();
        }

        private void txtTen_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.SelectAll();
        }

        private void txtTacGia_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.SelectAll();
        }

        private void txtNSB_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.SelectAll();
        }

        private void txtGiaTien_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.SelectAll();
        }

        private void txtSoLuong_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.SelectAll();
        }

        private void txtTimKiem_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.SelectAll();
        }

        private void timKiem()
        {
            string value = txtTimKiem.Text;
            if (value.Length == 0)
            {
                loadDuLieu();
                return;
            }
            dgvDanhSach.Rows.Clear();
            DataTable dt = SachControl.timKiem(value);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                // 
                dgvDanhSach.Rows.Add(new object[] { dt.Rows[i]["MaSach"], dt.Rows[i]["TenSach"], dt.Rows[i]["TenLoai"],
                dt.Rows[i]["TenTG"], dt.Rows[i]["NSB"], dt.Rows[i]["GiaTien"], dt.Rows[i]["SoLuong"]});
            }
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

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            frmLoaiSach f = new frmLoaiSach();
            f.ShowDialog();
            loadLoai();
        }
    }
}
