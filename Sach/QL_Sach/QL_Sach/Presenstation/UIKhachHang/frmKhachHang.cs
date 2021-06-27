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

namespace QL_Sach.Presenstation.UIKhachHang
{
    public partial class frmKhachHang : Form
    {
        private bool isAdd_ = true;
        public frmKhachHang()
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

        private string IdKhachHang_ = "";

        public string idKhachHang
        {
            set
            {
                IdKhachHang_ = value;
            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            if (!isAdd_)
            {
                KhachHangDAO dao = new KhachHangDAO();

                var info = dao.GetSingleByID(IdKhachHang_);

                if (info != null)
                {
                    btxtIdKhachHang.Text = info.idKhachHang.Trim();
                    btxtTenKhachHang.Text = info.TenKhachHang.Trim();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private KhachHang InitKhachHang()
        {
            KhachHang KhachHang = new KhachHang();

            KhachHang.idKhachHang = btxtIdKhachHang.Text.Trim();
            KhachHang.TenKhachHang = btxtTenKhachHang.Text.Trim();

            return KhachHang;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            KhachHangDAO dao = new KhachHangDAO();

            KhachHang info = InitKhachHang();

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
