using QLTV.ExtendModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.Control
{
    class PhieuMuonControl
    {
        public static DataTable layDanhSach()
        {
            string query = "select pm.MaPM, dg.TenDG, pm.NgayMuon, pm.NgayTra " 
                + "from PhieuMuon as pm left join DocGia as dg on pm.MaDG = dg.MaDG";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public static int suaDuLieu(int ma, int madg, string ngaymuon, string ngaytra)
        {
            string query = "exec suapm @ma , @madg , @ngaymuon , @ngaytra";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma, madg, ngaymuon, ngaytra});
        }
        public static int xoaDuLieu(int ma)
        {
            string query = "exec xoapm @ma";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma});
        }

        public static DataTable timKiem(string value)
        {
            string str = "%" + value + "%";
            string query = "select pm.MaPM, dg.TenDG, pm.NgayMuon, pm.NgayTra "
                + "from PhieuMuon as pm left join DocGia as dg on pm.MaDG = dg.MaDG"
                + " where dg.TenDG like @docgia or pm.NgayMuon like @muon or pm.NgayTra like @tra";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { str, str, str});
        }

        public static DataTable layThongTin(int ma)
        {
            string query = "select * from PhieuMuon where MaPM = @ma";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { ma});
        }

        public static int themDuLieu(int madg, string ngaymuon, string ngaytra)
        {
            string query = "exec thempm @madg , @ngaymuon , @ngaytra";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { madg, ngaymuon, ngaytra});
        }

        public static int layMaPMMoi()
        {
            string query = "select top(1) MaPM from PhieuMuon order by [MaPM] desc";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count == 0) return 0;
            return Convert.ToInt32(dt.Rows[0]["MaPM"].ToString());
        }
        public static int xoaChiTiet(int mapm)
        {
            string query = "exec xoactpm_all @ma";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mapm});
        }
    }
}
