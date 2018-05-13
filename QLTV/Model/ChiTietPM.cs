using QLTV.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.Model
{
    class ChiTietPM
    {
        public List<Sach> ListSach { private set; get; }

        public ChiTietPM()
        {
            ListSach = new List<Sach>();
        }
        public ChiTietPM(int ma)
        {
            DataTable dt = ChiTietPMControl.layDanhSachSach(ma);
            ListSach = new List<Sach>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                Sach sanPham = new Sach() {
                    MaSach = Convert.ToInt32(dt.Rows[i]["MaSach"].ToString()),
                    TenSach = dt.Rows[i]["TenSach"].ToString(),
                    SoLuong = Convert.ToInt32(dt.Rows[i]["SoLuong"].ToString())};
                ListSach.Add(sanPham);
            }
        }
        public void ThemSach(int id)
        {
            int vitri = isContain(id);
            if (vitri != -1) // nếu đã có sản phẩm trong list
            {
                ListSach[vitri].SoLuong++;
                return;
            }


            Sach s = new Sach(id);
            s.SoLuong = 1;
            ListSach.Add(s);
        }
        public void GiamSach(int id)
        {
            int vitri = isContain(id);
            if (vitri != -1) // nếu đã có sản phẩm trong list
            {
                ListSach[vitri].SoLuong--;
                if(ListSach[vitri].SoLuong == 0)
                {
                    ListSach.RemoveAt(vitri);
                }
                return;
            }
        }
        public void xoaSach(int id)
        {
            int vitri = isContain(id);
            if (vitri != -1)
            {
                ListSach.RemoveAt(vitri);
            }
        }
        public int isContain(int id)// kiểm tra danh sách có mã id chưa, nếu đúng trả về vị trị của nó trong list
        {
            for (int i = 0; i < ListSach.Count; ++i)
            {
                if (id == ListSach[i].MaSach)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
