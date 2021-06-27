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
    public partial class ucKhachHang : UserControl
    {
        public ucKhachHang()
        {
            InitializeComponent();
        }

        private void bdgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucKhachHang_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }
        private void LoadData()
        {
            KhachHangDAO dao = new KhachHangDAO();
            bdgvKhachHang.DataSource = dao.GetAll();
        }

        private void bbtnSearch_Click(object sender, EventArgs e)
        {
            KhachHangDAO dao = new KhachHangDAO();
            bdgvKhachHang.DataSource = dao.GetByKeyword(btxtKeyword.Text.Trim());
        }

        private void bbtnAdd_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.IsAdd = true;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnEdit_Click(object sender, EventArgs e)
        {
            string IdKhachHang = bdgvKhachHang.CurrentRow.Cells["idKhachHang"].Value.ToString();

            frmKhachHang frm = new frmKhachHang();
            frm.IsAdd = false;
            frm.idKhachHang = IdKhachHang;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnDelete_Click(object sender, EventArgs e)
        {
            string IdKhachHang = bdgvKhachHang.CurrentRow.Cells["idKhachHang"].Value.ToString();

            KhachHangDAO dao = new KhachHangDAO();

            if (dao.Delete(IdKhachHang))
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
