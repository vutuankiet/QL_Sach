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
    public class NhanVienDAO : BaseDAO
    {
        public List<NhanVien> GetAll()
        {
            return db_.NhanViens.ToList();
        }

        public List<NhanVien> GetByKeyword(string keyword)
        {
            return db_.NhanViens.Where(t => t.idNV == keyword || t.TenNV.Contains(keyword)).ToList();
        }

        public NhanVien GetSingleByID(string IdNhanVien)
        {
            return db_.NhanViens.Where(t => t.idNV == IdNhanVien).FirstOrDefault();
        }

        public bool Add(NhanVien info)
        {
            try
            {
                db_.NhanViens.Add(info);

                db_.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool Edit(NhanVien info)
        {
            try
            {
                var info0 = GetSingleByID(info.idNV);

                if (info0 != null)
                {
                    info0.TenNV = info.TenNV;
                    info0.GioiTinh = info.GioiTinh;
                    info0.NgaySinh = info.NgaySinh;
                    info0.QueQuan = info.QueQuan;
                    info0.DiaChi = info.DiaChi;
                    info0.Email = info.Email;
                    info0.SDT = info.SDT;

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

        public bool Delete(NhanVien info)
        {
            try
            {
                var info0 = GetSingleByID(info.idNV);

                if (info0 != null)
                {
                    db_.NhanViens.Remove(info0);

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

        public bool Delete(string IdNhanVien)
        {
            try
            {
                var info0 = GetSingleByID(IdNhanVien);
                if (info0 != null)
                {
                    db_.NhanViens.Remove(info0);

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
