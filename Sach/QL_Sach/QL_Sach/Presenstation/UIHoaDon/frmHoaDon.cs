using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_Sach.Model.DAO;
using QL_Sach.Model.EF;

namespace QL_Sach.Presenstation.UIHoaDon
{
    public partial class frmHoaDon : Form
    {
        private bool isAdd_ = true;
        public frmHoaDon()
        {
            InitializeComponent();
        }
        public bool IsAdd
        {
            set
            {
                isAdd_ = value;
            }
        }

        private bool result_;

        public bool Result
        {
            get
            {
                return result_;
            }
        }

        private string IdHoaDon_ = "";

        public string idHoaDon
        {
            set
            {
                IdHoaDon_ = value;
            }
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            if (!isAdd_)
            {
                HoaDonDAO dao = new HoaDonDAO();

                var info = dao.GetSingleByID(IdHoaDon_);

                if (info != null)
                {
                    btxtIdHoaDon.Text = info.idHoaDon.Trim();
                    btxtKhachHang.Text = info.TenKhachHang.Trim();
                    btxtTenSach.Text = info.TenSach.Trim();
                    btxtTrangThai.Text = info.TrangThai.Trim();
                    btxtTongTien.Text = info.TongTien.Trim();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private HoaDon InitHoaDon()
        {
            HoaDon hoaDon = new HoaDon();

            hoaDon.idHoaDon = btxtIdHoaDon.Text.Trim();
            hoaDon.TenKhachHang = btxtKhachHang.Text.Trim();
            hoaDon.TenSach = btxtTenSach.Text.Trim();
            hoaDon.TrangThai = btxtTrangThai.Text.Trim();
            hoaDon.TongTien = btxtTongTien.Text.Trim();

            return hoaDon;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HoaDonDAO dao = new HoaDonDAO();

            HoaDon info = InitHoaDon();

            if (isAdd_)
            {
                if (dao.Add(info))
                {
                    MessageBox.Show("Them thang cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    result_ = true;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Them that bai!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (dao.Edit(info))
                {
                    MessageBox.Show("Them thang cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    result_ = true;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Them that bai!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
