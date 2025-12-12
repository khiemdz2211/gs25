using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GS25App.Supplier
{
    public partial class UC_SupplierList : UserControl
    {
        string connectionString =
            @"Data Source=DESKTOP-SJCLB3H\SQLEXPRESS;Initial Catalog=GS25;Integrated Security=True";

        public UC_SupplierList()
        {
            InitializeComponent();
            LoadSupplier();
        }

        private void LoadSupplier(string search = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT SupplierID, SupplierName, Phone, Address, Email FROM Supplier";

                if (!string.IsNullOrEmpty(search))
                {
                    query += " WHERE SupplierName LIKE @Search OR Phone LIKE @Search";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(search))
                    cmd.Parameters.AddWithValue("@Search", "%" + search + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSupplierList.DataSource = dt;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSupplier(txtSearch.Text);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadSupplier();
        }
    }
}
