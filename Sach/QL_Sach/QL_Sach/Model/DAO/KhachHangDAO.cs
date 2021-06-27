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
    public class KhachHangDAO : BaseDAO
    {
        public List<KhachHang> GetAll()
        {
            return db_.KhachHangs.ToList();
        }

        public List<KhachHang> GetByKeyword(string keyword)
        {
            return db_.KhachHangs.Where(t => t.idKhachHang == keyword || t.TenKhachHang.Contains(keyword)).ToList();
        }
        public KhachHang GetSingleByID(string IdKhachHang)
        {
            return db_.KhachHangs.Where(t => t.idKhachHang == IdKhachHang).FirstOrDefault();
        }

        public bool Add(KhachHang info)
        {
            try
            {
                db_.KhachHangs.Add(info);

                db_.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool Edit(KhachHang info)
        {
            try
            {
                var info0 = GetSingleByID(info.idKhachHang);

                if (info0 != null)
                {
                    info0.TenKhachHang = info.TenKhachHang;
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

        public bool Delete(KhachHang info)
        {
            try
            {
                var info0 = GetSingleByID(info.idKhachHang);

                if (info0 != null)
                {
                    db_.KhachHangs.Remove(info0);

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

        public bool Delete(string IdKhachHang)
        {
            try
            {
                var info0 = GetSingleByID(IdKhachHang);
                if (info0 != null)
                {
                    db_.KhachHangs.Remove(info0);

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
