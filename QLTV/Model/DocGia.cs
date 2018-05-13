using QLTV.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.Model
{
    class DocGia
    {
        public int MaDG { get; set; }
        public string TenDG { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }

        public DocGia ()
        {
            MaDG = 0;
            TenDG = "";
            NgaySinh = DateTime.Now;
            GioiTinh = "";
            DiaChi = "";
        }
        public DocGia(int ma)
        {
            MaDG = ma;
            DataTable dt = DocGiaControl.layThongTin(ma);
            TenDG = dt.Rows[0][1].ToString();
            NgaySinh = DateTime.Parse(dt.Rows[0][2].ToString());
            GioiTinh = dt.Rows[0][3].ToString();
            DiaChi = dt.Rows[0][4].ToString();
        }
    }
}
