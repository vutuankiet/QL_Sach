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
    public partial class ucSach : UserControl
    {
        public ucSach()
        {
            InitializeComponent();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucSach_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }
        private void LoadData()
        {
            SachDAO dao = new SachDAO();
            bdgvSach.DataSource = dao.GetAll();
        }

        private void bbtnSearch_Click(object sender, EventArgs e)
        {
            SachDAO dao = new SachDAO();
            bdgvSach.DataSource = dao.GetByKeyword(btxtKeyword.Text.Trim());
        }

        private void bbtnAdd_Click(object sender, EventArgs e)
        {
            frmSach frm = new frmSach();
            frm.IsAdd = true;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnEdit_Click(object sender, EventArgs e)
        {
            string IdSach = bdgvSach.CurrentRow.Cells["idSach"].Value.ToString();

            frmSach frm = new frmSach();
            frm.IsAdd = false;
            frm.idSach = IdSach;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnDelete_Click(object sender, EventArgs e)
        {
            string IdSach = bdgvSach.CurrentRow.Cells["idSach"].Value.ToString();

            SachDAO dao = new SachDAO();

            if (dao.Delete(IdSach))
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
