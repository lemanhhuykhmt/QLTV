using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLTV.Control;

namespace QLTV.GUI.UC
{
    public partial class ucDocGia : UserControl
    {
        public ucDocGia()
        {
            InitializeComponent();
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            dgvDanhSach.Rows.Clear();
            DataTable dt = DocGiaControl.layDanhSach();
            for(int i = 0; i < dt.Rows.Count; ++i)
            {
                // 
                dgvDanhSach.Rows.Add(new object[] { dt.Rows[i]["MaDG"], dt.Rows[i]["TenDG"], dt.Rows[i]["GioiTinh"],
                String.Format("{0:MM/dd/yyyy}", dt.Rows[i]["NgaySinh"]), dt.Rows[i]["DiaChi"]});
            }
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvDanhSach.Rows[e.RowIndex].Cells["colMa"].Value.ToString();
            txtTen.Text = dgvDanhSach.Rows[e.RowIndex].Cells["colTen"].Value.ToString();
            txtDiaChi.Text = dgvDanhSach.Rows[e.RowIndex].Cells["colDiaChi"].Value.ToString();
            dtpNgaySinh.Value = DateTime.Parse(dgvDanhSach.Rows[e.RowIndex].Cells["colNgaySinh"].Value.ToString());
            cbGioiTinh.Text = dgvDanhSach.Rows[e.RowIndex].Cells["colGioiTinh"].Value.ToString();
        }

        private void txtTen_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.SelectAll();
        }


        private void txtDiaChi_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.SelectAll();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtTen.Text;
            string gioitinh = cbGioiTinh.Text;
            string diachi = txtDiaChi.Text;
            DateTime ngaysinh = dtpNgaySinh.Value;
            if(true)
            {
                int ketqua = DocGiaControl.themDuLieu(ten, ngaysinh, gioitinh, diachi);
                if(ketqua > 0)
                {
                    MessageBox.Show("thêm thành công");
                    txtTen.Text = txtDiaChi.Text = "";
                    loadDuLieu();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int ma = Convert.ToInt32(txtMa.Text);
            string ten = txtTen.Text;
            string gioitinh = cbGioiTinh.Text;
            string diachi = txtDiaChi.Text;
            string ngaysinh = dtpNgaySinh.Value.ToString();
            if(true)
            {
                int ketqua = DocGiaControl.suaDuLieu(ma, ten, ngaysinh, gioitinh, diachi);
                if(ketqua > 0)
                {
                    MessageBox.Show("sửa thành công");
                    loadDuLieu();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int ma = Convert.ToInt32(txtMa.Text);
            if(DocGiaControl.xoaDuLieu(ma) > 0)
            {
                MessageBox.Show("xoá thành công");
                loadDuLieu();
            }
        }
    }
}
