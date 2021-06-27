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

namespace QL_Sach.Presenstation.UINhanVien
{
    public partial class frmNhanVien : Form
    {
        private bool isAdd_ = true;
        public frmNhanVien()
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

        private string IdNV_;

        public string idNV
        {
            set
            {
                IdNV_ = value;
            }
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            if (!isAdd_)
            {
                NhanVienDAO dao = new NhanVienDAO();

                var info = dao.GetSingleByID(IdNV_);

                if (info != null)
                {
                    btxtIdNhanVien.Text = info.idNV.Trim();
                    btxtTenNhanVien.Text = info.TenNV.Trim();
                    bckbGioiTinh.Text = info.GioiTinh.Trim();
                    bdtpNgaySinh.Value = (DateTime)info.NgaySinh;
                    btxtQueQuan.Text = info.QueQuan.Trim();
                    btxtDiaChi.Text = info.DiaChi.Trim();
                    btxtEmail.Text = info.Email.Trim();
                    btxtSoDienThoai.Text = info.SDT.Trim();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private NhanVien InitNhanVien()
        {
            NhanVien nhanVien = new NhanVien();

            nhanVien.idNV = btxtIdNhanVien.Text.Trim();
            nhanVien.TenNV = btxtTenNhanVien.Text.Trim();
            nhanVien.GioiTinh = bckbGioiTinh.Text.Trim();
            //nhanVien.GioiTinh = bckbGioiTinh.Checked;
            nhanVien.NgaySinh = bdtpNgaySinh.Value;
            nhanVien.QueQuan = btxtQueQuan.Text.Trim();
            nhanVien.DiaChi = btxtDiaChi.Text.Trim();
            nhanVien.Email = btxtEmail.Text.Trim();
            nhanVien.SDT = btxtSoDienThoai.Text.Trim();

            return nhanVien;
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NhanVienDAO dao = new NhanVienDAO();

            NhanVien info = InitNhanVien();

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
