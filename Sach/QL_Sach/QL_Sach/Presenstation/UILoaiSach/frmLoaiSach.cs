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

namespace QL_Sach.Presenstation.UILoaiSach
{
    public partial class frmLoaiSach : Form
    {
        private bool isAdd_ = true;
        public frmLoaiSach()
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

        private string IdLoaiSach_ = "";

        public string idLoaiSach
        {
            set
            {
                IdLoaiSach_ = value;
            }
        }

        private void frmLoaiSach_Load(object sender, EventArgs e)
        {
            if (!isAdd_)
            {
                LoaiSachDAO dao = new LoaiSachDAO();

                var info = dao.GetSingleByID(IdLoaiSach_);

                if (info != null)
                {
                    btxtIdLoaiSach.Text = info.idLoaiSach.Trim();
                    btxtTenLoaiSach.Text = info.TenLoaiSach.Trim();
                    btxtTenSach.Text = info.TenSach.Trim();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private LoaiSach InitLoaiSach()
        {
            LoaiSach loaiSach = new LoaiSach();

            loaiSach.idLoaiSach = btxtIdLoaiSach.Text.Trim();
            loaiSach.TenLoaiSach = btxtTenLoaiSach.Text.Trim();
            loaiSach.TenSach = btxtTenSach.Text.Trim();

            return loaiSach;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoaiSachDAO dao = new LoaiSachDAO();

            LoaiSach info = InitLoaiSach();

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
