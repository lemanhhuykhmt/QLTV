using QLTV.Control;
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
    public partial class frmLoaiSach : Form
    {
        public frmLoaiSach()
        {
            InitializeComponent();
        }


        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string tenloai = txtTenLoai.Text;
            if(true)
            {
                int ketqua = LoaiSachControl.themDuLieu(tenloai);
                if(ketqua > 0)
                {
                    MessageBox.Show("thêm thành công");
                    this.Close();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
