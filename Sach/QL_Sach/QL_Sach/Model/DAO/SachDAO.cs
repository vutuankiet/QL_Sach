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
    public class SachDAO : BaseDAO
    {
        public List<Sach> GetAll()
        {
            return db_.Saches.ToList();
        }

        public List<Sach> GetByKeyword(string keyword)
        {
            return db_.Saches.Where(t => t.idSach == keyword || t.TenSach.Contains(keyword)).ToList();
        }
        public Sach GetSingleByID(string IdSach)
        {
            return db_.Saches.Where(t => t.idSach == IdSach).FirstOrDefault();
        }

        public bool Add(Sach info)
        {
            try
            {
                db_.Saches.Add(info);

                db_.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool Edit(Sach info)
        {
            try
            {
                var info0 = GetSingleByID(info.idSach);

                if (info0 != null)
                {
                    info0.TenSach = info.TenSach;
                    info0.LoaiSach = info.LoaiSach;
                    info0.GiaTien = info.GiaTien;
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

        public bool Delete(Sach info)
        {
            try
            {
                var info0 = GetSingleByID(info.idSach);

                if (info0 != null)
                {
                    db_.Saches.Remove(info0);

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

        public bool Delete(string IdSach)
        {
            try
            {
                var info0 = GetSingleByID(IdSach);
                if (info0 != null)
                {
                    db_.Saches.Remove(info0);

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
