using QLTV.GUI.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV.GUI
{
    public partial class frmChinh : Form
    { 
        public frmChinh()
        {
            InitializeComponent();
        }


        private void frmChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn thực sự có muốn thoát?", "Thông báo!", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                // thoát
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnGiaoVien_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            ucDocGia frm = new ucDocGia();
            frm.Size = new Size(pnlNoiDung.Width, pnlNoiDung.Height);
            frm.Visible = true;
            pnlNoiDung.Controls.Add(frm);
            
        }

        private void btnHocSinh_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            ucSach frm = new ucSach();
            frm.Size = new Size(pnlNoiDung.Width, pnlNoiDung.Height);
            frm.Visible = true;
            pnlNoiDung.Controls.Add(frm);
        }
    }
}
