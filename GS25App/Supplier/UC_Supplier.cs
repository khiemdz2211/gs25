using System;
using System.Windows.Forms;
using GS25App.Supplier;   // Quan trọng để dùng các UC con

namespace GS25App
{
    public partial class UC_Supplier : UserControl
    {
        public UC_Supplier()
        {
            InitializeComponent();
        }

        // Hàm load UC con vào panelContent
        private void LoadContent(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        // ============================
        //   XỬ LÝ 3 NÚT MENU BÊN TRÁI
        // ============================

        // DANH SÁCH NHÀ CUNG CẤP
        private void btnList_Click(object sender, EventArgs e)
        {
            LoadContent(new UC_SupplierList());
        }

        // NHẬP HÀNG
        private void btnReceive_Click(object sender, EventArgs e)
        {
            LoadContent(new UC_SupplierReceive());
        }

        // TRẢ HÀNG
        private void btnReturn_Click(object sender, EventArgs e)
        {
            LoadContent(new UC_SupplierReturn());
        }
    }
}
