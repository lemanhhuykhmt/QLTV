using QLTV.ExtendModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.Control
{
    class SachControl
    {
        public static DataTable layDanhSach()
        {
            string query = "select s.MaSach, s.TenSach, ls.TenLoai, s.TenTG, s.NSB, s.GiaTien, s.SoLuong " 
                + "from Sach as s left join LoaiSach as ls on s.Loai = ls.MaLoai";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public static int themDuLieu(string ten, DateTime ngaysinh, string gioitinh, string diachi)
        {
            string query = "exec themdg @ten , @ngay , @gioitinh , @diachi";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ten, ngaysinh, gioitinh, diachi });
        }

        public static int suaDuLieu(int ma, string ten, string ngaysinh, string gioitinh, string diachi)
        {
            string query = "exec suadg @ma , @ten , @ngaysinh , @gioitinh , @diachi";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma, ten, ngaysinh, gioitinh, diachi });
        }

        public static int xoaDuLieu(int ma)
        {
            string query = "exec xoadg @ma";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma });
        }

        public static DataTable layDanhSachLoai()
        {
            string query = "select * from LoaiSach";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }

}
