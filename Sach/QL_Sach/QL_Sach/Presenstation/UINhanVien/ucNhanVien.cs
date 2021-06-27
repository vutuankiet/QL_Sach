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
    public partial class ucNhanVien : UserControl
    {
        public ucNhanVien()
        {
            InitializeComponent();
        }

        private void ucNhanVien_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }
        private void LoadData()
        {
            NhanVienDAO dao = new NhanVienDAO();
            bdgvNhanVien.DataSource = dao.GetAll();
        }

        private void bbtnSearch_Click(object sender, EventArgs e)
        {
            NhanVienDAO dao = new NhanVienDAO();
            bdgvNhanVien.DataSource = dao.GetByKeyword(btxtKeyword.Text.Trim());
        }

        private void bbtnAdd_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.IsAdd = true;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnEdit_Click(object sender, EventArgs e)
        {
            string IdNV = bdgvNhanVien.CurrentRow.Cells["idNV"].Value.ToString();

            frmNhanVien frm = new frmNhanVien();
            frm.IsAdd = false;
            frm.idNV = IdNV;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnDelete_Click(object sender, EventArgs e)
        {
            string IdNV = bdgvNhanVien.CurrentRow.Cells["idNV"].Value.ToString();

            NhanVienDAO dao = new NhanVienDAO();

            if (dao.Delete(IdNV))
            {
                MessageBox.Show("Xoa thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            else
            {
                MessageBox.Show("Xoa that bai!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bdgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
