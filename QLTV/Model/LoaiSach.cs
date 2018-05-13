using QLTV.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.Model
{
    class LoaiSach
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }

        public LoaiSach()
        {
            MaLoai = 0;
            TenLoai = "";
        }
        public LoaiSach(int ma)
        {
            MaLoai = ma;
            if (ma == 0)
            {
                TenLoai = "None";
                return;
            }
            DataTable dt = LoaiSachControl.layThongTin(ma);
            TenLoai = dt.Rows[0]["TenLoai"].ToString();
        }
    }
}
