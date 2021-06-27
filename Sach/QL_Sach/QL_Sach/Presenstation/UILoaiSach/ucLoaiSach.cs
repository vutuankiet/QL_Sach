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
    public partial class ucLoaiSach : UserControl
    {
        public ucLoaiSach()
        {
            InitializeComponent();
        }

        private void bdgvLoaiSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucLoaiSach_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }
        private void LoadData()
        {
            LoaiSachDAO dao = new LoaiSachDAO();
            bdgvLoaiSach.DataSource = dao.GetAll();

        }
        private void bbtnSearch_Click(object sender, EventArgs e)
        {
            LoaiSachDAO dao = new LoaiSachDAO();
            bdgvLoaiSach.DataSource = dao.GetByKeyword(btxtKeyword.Text.Trim());
        }

        private void bbtnAdd_Click(object sender, EventArgs e)
        {
            frmLoaiSach frm = new frmLoaiSach();
            frm.IsAdd = true;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnEdit_Click(object sender, EventArgs e)
        {
            string IdLoaiSach = bdgvLoaiSach.CurrentRow.Cells["idLoaiSach"].Value.ToString();

            frmLoaiSach frm = new frmLoaiSach();
            frm.IsAdd = false;
            frm.idLoaiSach = IdLoaiSach;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnDelete_Click(object sender, EventArgs e)
        {
            string IdLoaiSach = bdgvLoaiSach.CurrentRow.Cells["idLoaiSach"].Value.ToString();

            LoaiSachDAO dao = new LoaiSachDAO();

            if (dao.Delete(IdLoaiSach))
            {
                MessageBox.Show("Xoa thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            else
            {
                MessageBox.Show("Xoa that bai!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
