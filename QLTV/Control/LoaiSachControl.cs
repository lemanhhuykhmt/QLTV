using QLTV.ExtendModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.Control
{
    class LoaiSachControl
    {
        public static int themDuLieu(string ten)
        {
            string query = "exec themloai @ten";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ten});
        }
        public static DataTable layThongTin(int ma)
        {
            string query = "select * from LoaiSach where MaLoai = @ma";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { ma});
        }
    }
}
