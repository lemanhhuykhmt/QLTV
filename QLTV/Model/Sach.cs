using QLTV.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.Model
{
    class Sach
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public LoaiSach Loai { get; set; }
        public string TenTG { get; set; }
        public string NSB { get; set; }
        public double GiaTien { get; set; }
        public int SoLuong { get; set; }

        public Sach()
        {
            MaSach = 0;
            TenSach = "";
            Loai = new LoaiSach(0);
            TenTG = "";
            NSB = "";
            GiaTien = 0;
            SoLuong = 0;
        }
        public Sach(int id)
        {
            MaSach = id;
            DataTable dt = SachControl.layThongTin(id);
            TenSach = dt.Rows[0]["TenSach"].ToString();
            Loai = new LoaiSach(Convert.ToInt32(dt.Rows[0]["Loai"].ToString()));
            TenTG = dt.Rows[0]["TenTG"].ToString();
            NSB = dt.Rows[0]["NSB"].ToString();
            GiaTien = double.Parse(dt.Rows[0]["GiaTien"].ToString());
            SoLuong = Convert.ToInt32(dt.Rows[0]["SoLuong"].ToString());
        }
    }
}
