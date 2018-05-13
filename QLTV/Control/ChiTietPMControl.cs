using QLTV.ExtendModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.Control
{
    class ChiTietPMControl
    {
        public static int themDuLieu(int mapm, int masach, int soluong)
        {
            string query = "exec themctpm @mapm , @masach , @soluong";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mapm, masach, soluong});
        }
        public static DataTable layDanhSachSach() // lấy tất cả thông tin sách
        {
            string query = "select s.MaSach, s.TenSach, ls.TenLoai, s.TenTG, s.NSB, s.GiaTien, s.SoLuong "
                + "from Sach as s left join LoaiSach as ls on s.Loai = ls.MaLoai";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public static DataTable layDanhSachSach(int id) // lấy tất cả mã sách trong phiếu mượn
        {
            string query = "select s.MaSach, s.TenSach , b.SoLuong from Sach as s, " 
                + " (select ct.MaSach, ct.SoLuong from ChiTietPM as ct where MaPM = @ma ) as b " 
                + " where b.MaSach = s.MaSach";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id});
        }
        public static DataTable layDanhSachDG()
        {
            string query = "select MaDG, TenDG from DocGia";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
