using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Sach
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void AddControl(Control Control)
        {
            bpnMain.Controls.Clear();
            bpnMain.Controls.Add(Control);
        }

        private void bbtnNhanVien_Click(object sender, EventArgs e)
        {
            AddControl(new Presenstation.UINhanVien.ucNhanVien());
        }

        private void bbtnDashBoard_Click(object sender, EventArgs e)
        {
            AddControl(new Presenstation.UIDashBoard.ucDashBoard());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void bpnMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bbtbSach_Click(object sender, EventArgs e)
        {
            AddControl(new Presenstation.UISach.ucSach());
        }

        private void bbtnLoaiSach_Click(object sender, EventArgs e)
        {
            AddControl(new Presenstation.UILoaiSach.ucLoaiSach());
        }

        private void bbtnKhachHang_Click(object sender, EventArgs e)
        {
            AddControl(new Presenstation.UIKhachHang.ucKhachHang());
        }

        private void bbtnHoaDon_Click(object sender, EventArgs e)
        {
            AddControl(new Presenstation.UIHoaDon.ucHoaDon());
        }
    }
}
