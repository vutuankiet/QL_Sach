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
    public partial class ucHoaDon : UserControl
    {
        public ucHoaDon()
        {
            InitializeComponent();
        }

        private void bdgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucHoaDon_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }
        private void LoadData()
        {
            HoaDonDAO dao = new HoaDonDAO();
            bdgvHoaDon.DataSource = dao.GetAll();
        }

        private void bbtnSearch_Click(object sender, EventArgs e)
        {
            HoaDonDAO dao = new HoaDonDAO();
            bdgvHoaDon.DataSource = dao.GetByKeyword(btxtKeyword.Text.Trim());
        }

        private void bbtnAdd_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon();
            frm.IsAdd = true;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnEdit_Click(object sender, EventArgs e)
        {
            string IdHoaDon = bdgvHoaDon.CurrentRow.Cells["idHoaDon"].Value.ToString();

            frmHoaDon frm = new frmHoaDon();
            frm.IsAdd = false;
            frm.idHoaDon = IdHoaDon;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void bbtnDelete_Click(object sender, EventArgs e)
        {
            string IdHoaDon = bdgvHoaDon.CurrentRow.Cells["idHoaDon"].Value.ToString();

            HoaDonDAO dao = new HoaDonDAO();

            if (dao.Delete(IdHoaDon))
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
