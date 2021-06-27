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
    public class LoaiSachDAO : BaseDAO
    {
        public List<LoaiSach> GetAll()
        {
            return db_.LoaiSaches.ToList();
        }

        public List<LoaiSach> GetByKeyword(string keyword)
        {
            return db_.LoaiSaches.Where(t => t.idLoaiSach == keyword || t.TenLoaiSach.Contains(keyword)).ToList();
        }
        public LoaiSach GetSingleByID(string IdLoaiSach)
        {
            return db_.LoaiSaches.Where(t => t.idLoaiSach == IdLoaiSach).FirstOrDefault();
        }

        public bool Add(LoaiSach info)
        {
            try
            {
                db_.LoaiSaches.Add(info);

                db_.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool Edit(LoaiSach info)
        {
            try
            {
                var info0 = GetSingleByID(info.idLoaiSach);

                if (info0 != null)
                {
                    info0.TenLoaiSach = info.TenLoaiSach;
                    info0.TenSach = info.TenSach;
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

        public bool Delete(LoaiSach info)
        {
            try
            {
                var info0 = GetSingleByID(info.idLoaiSach);

                if (info0 != null)
                {
                    db_.LoaiSaches.Remove(info0);

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

        public bool Delete(string IdLoaiSach)
        {
            try
            {
                var info0 = GetSingleByID(IdLoaiSach);
                if (info0 != null)
                {
                    db_.LoaiSaches.Remove(info0);

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

