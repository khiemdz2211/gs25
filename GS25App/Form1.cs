using System;
using System.Windows.Forms;
using GS25App.Supplier;   // dùng các UserControl trong thư mục Supplier

namespace GS25App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadControl(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        // =========================
        //     XỬ LÝ NÚT TRONG MENU
        // =========================

        private void btnProduct_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_Product());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_Supplier());   // <-- CHÍNH XÁC NHẤT
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm f = new LoginForm();
            f.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã đăng xuất!");
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Khách hàng đang phát triển.");
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Đơn hàng đang phát triển.");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Nhập hàng đang phát triển.");
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Nhân viên đang phát triển.");
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Báo cáo đang phát triển.");
        }

        private void btnCustomer_Click_1(object sender, EventArgs e)
        {

        }

    }
}
