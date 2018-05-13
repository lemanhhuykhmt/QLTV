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
        public static int themDuLieu(string ten, int loai, string tacgia, string nsb, double gia, int soluong)
        {
            string query = "exec themsach @ten , @loai , @tacgia , @nsb , @gia , @soluong";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ten, loai, tacgia, nsb, gia, soluong });
        }

        public static int suaDuLieu(int ma, string ten, int loai, string tacgia, string nsb, double gia, int soluong)
        {
            string query = "exec suasach @ma , @ten , @loai , @tacgia , @nsb , @gia , @soluong";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma, ten, loai, tacgia, nsb, gia, soluong });
        }

        public static int xoaDuLieu(int ma)
        {
            string query = "exec xoasach @ma";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma });
        }

        public static DataTable timKiem(string value)
        {
            string str = "%" + value + "%";
            string query = "select s.MaSach, s.TenSach, ls.TenLoai, s.TenTG, s.NSB, s.GiaTien, s.SoLuong "
                + "from Sach as s left join LoaiSach as ls on s.Loai = ls.MaLoai " 
                + " where s.TenSach like @ten or ls.TenLoai like @loai or s.TenTG like @tacgin or s.NSB like @nsb";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { str, str, str, str});
        }

        public static DataTable layDanhSachLoai()
        {
            string query = "select * from LoaiSach";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public static DataTable layThongTin (int id)
        {
            string query = "select * from Sach where MaSach = @ma";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id});
        }
    }

}
