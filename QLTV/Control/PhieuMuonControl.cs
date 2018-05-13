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
    }
}
