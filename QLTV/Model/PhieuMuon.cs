using QLTV.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.Model
{
    class PhieuMuon
    {
        public int MaPM { get; set; }
        public DocGia NguoiDoc { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTra { get; set; }
        public ChiTietPM ChiTiet { private set; get; }

        public PhieuMuon ()
        {
            MaPM = 0;
            NguoiDoc = new DocGia();
            NgayMuon = DateTime.Now;
            NgayTra = new DateTime(1900, 1, 1);
            ChiTiet = new ChiTietPM();
        }
        public PhieuMuon (int maPM)
        {
            MaPM = maPM;
            DataTable dt = PhieuMuonControl.layThongTin(maPM);
            NguoiDoc = new DocGia(Convert.ToInt32(dt.Rows[0][1].ToString().Length == 0 ? "0" : dt.Rows[0][1].ToString()));
            NgayMuon = DateTime.Parse(dt.Rows[0][2].ToString());
            NgayTra = DateTime.Parse(dt.Rows[0][3].ToString());
            ChiTiet = new ChiTietPM(MaPM);
        }
    }
}
