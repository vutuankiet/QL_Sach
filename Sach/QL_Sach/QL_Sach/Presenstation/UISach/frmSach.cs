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

namespace QL_Sach.Presenstation.UISach
{
    public partial class frmSach : Form
    {
        private bool isAdd_ = true;
        public frmSach()
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

        private string IdSach_ = "";

        public string idSach
        {
            set
            {
                IdSach_ = value;
            }
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            if (!isAdd_)
            {
                SachDAO dao = new SachDAO();

                var info = dao.GetSingleByID(IdSach_);

                if (info != null)
                {
                    btxtIdSach.Text = info.idSach.Trim();
                    btxtTenSach.Text = info.TenSach.Trim();
                    btxtLoaiSach.Text = info.LoaiSach.Trim();
                    btxtGiaTien.Text = info.GiaTien.Trim();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private Sach InitSach()
        {
            Sach sach = new Sach();

            sach.idSach = btxtIdSach.Text.Trim();
            sach.TenSach = btxtTenSach.Text.Trim();
            sach.LoaiSach = btxtLoaiSach.Text.Trim();
            sach.GiaTien = btxtGiaTien.Text.Trim();

            return sach;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SachDAO dao = new SachDAO();

            Sach info = InitSach();

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
