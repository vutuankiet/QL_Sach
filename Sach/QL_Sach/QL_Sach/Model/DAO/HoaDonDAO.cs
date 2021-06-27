using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_Sach.Model.EF;
using QL_Sach.Model.DAO;

namespace QL_Sach.Model.DAO
{
    public class HoaDonDAO : BaseDAO
    {
        public List<HoaDon> GetAll()
        {
            return db_.HoaDons.ToList();
        }

        public List<HoaDon> GetByKeyword(string keyword)
        {
            return db_.HoaDons.Where(t => t.idHoaDon == keyword || t.TenKhachHang.Contains(keyword)).ToList();
        }
        public HoaDon GetSingleByID(string IdHoaDon)
        {
            return db_.HoaDons.Where(t => t.idHoaDon == IdHoaDon).FirstOrDefault();
        }

        public bool Add(HoaDon info)
        {
            try
            {
                db_.HoaDons.Add(info);

                db_.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool Edit(HoaDon info)
        {
            try
            {
                var info0 = GetSingleByID(info.idHoaDon);

                if (info0 != null)
                {
                    info0.TenKhachHang = info.TenKhachHang;
                    info0.TenSach = info.TenSach;
                    info0.TrangThai = info.TrangThai;
                    info0.TongTien = info.TongTien;
                    //info0.DanhSach = info.DanhSach;
                    //info0.HoaDon = info.HoaDon;

                    db_.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool Delete(HoaDon info)
        {
            try
            {
                var info0 = GetSingleByID(info.idHoaDon);

                if (info0 != null)
                {
                    db_.HoaDons.Remove(info0);

                    db_.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool Delete(string IdHoaDon)
        {
            try
            {
                var info0 = GetSingleByID(IdHoaDon);
                if (info0 != null)
                {
                    db_.HoaDons.Remove(info0);

                    db_.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
    }
}
