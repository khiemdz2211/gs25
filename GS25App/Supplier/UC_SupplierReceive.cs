using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GS25App.Supplier
{
    public partial class UC_SupplierReceive : UserControl
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=GS25;Integrated Security=True";

        DataTable receiveTable;  // bảng dữ liệu tạm để hiển thị trong grid

        public UC_SupplierReceive()
        {
            InitializeComponent();
            receiveTable = new DataTable();

            // tạo cột cho bảng tạm
            receiveTable.Columns.Add("ProductID");
            receiveTable.Columns.Add("ProductName");
            receiveTable.Columns.Add("Quantity");
            receiveTable.Columns.Add("Price");
            receiveTable.Columns.Add("Total");

            dgvReceiveList.DataSource = receiveTable;
        }

        private void UC_SupplierReceive_Load(object sender, EventArgs e)
        {
            LoadSupplier();
            LoadProductAutoComplete();
        }

        // ============================
        //  LOAD SUPPLIER
        // ============================
        void LoadSupplier()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT SupplierID, SupplierName FROM Supplier", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbSupplier.DataSource = dt;
                cbSupplier.DisplayMember = "SupplierName";
                cbSupplier.ValueMember = "SupplierID";
            }
        }

        // ============================
        //  LOAD PRODUCT AUTO COMPLETE
        // ============================
        void LoadProductAutoComplete()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Products", conn);
                SqlDataReader rd = cmd.ExecuteReader();

                AutoCompleteStringCollection list = new AutoCompleteStringCollection();
                while (rd.Read())
                {
                    list.Add(rd.GetString(0));
                }

                txtProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtProduct.AutoCompleteCustomSource = list;
            }
        }

        // ============================
        //  THÊM SẢN PHẨM VÀO GRID
        // ============================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProduct.Text == "")
            {
                MessageBox.Show("Nhập tên sản phẩm!");
                return;
            }

            string productName = txtProduct.Text;
            int quantity = (int)numQuantity.Value;
            float price = (float)numPrice.Value;
            float total = quantity * price;

            // lấy ProductID từ DB
            int productID = GetProductID(productName);

            if (productID == -1)
            {
                MessageBox.Show("Không tìm thấy sản phẩm này trong kho!");
                return;
            }

            receiveTable.Rows.Add(productID, productName, quantity, price, total);
        }

        int GetProductID(string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID FROM Products WHERE Name = @name", conn);
                cmd.Parameters.AddWithValue("@name", name);

                object result = cmd.ExecuteScalar();
                return result == null ? -1 : Convert.ToInt32(result);
            }
        }

        // ============================
        //  XÓA DÒNG
        // ============================
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvReceiveList.SelectedRows.Count > 0)
                dgvReceiveList.Rows.RemoveAt(dgvReceiveList.SelectedRows[0].Index);
        }

        // ============================
        //  HOÀN TẤT NHẬP HÀNG
        // ============================
        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (receiveTable.Rows.Count == 0)
            {
                MessageBox.Show("Danh sách trống!");
                return;
            }

            int supplierID = Convert.ToInt32(cbSupplier.SelectedValue);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1. Tạo phiếu nhập
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO ReceiveOrders (SupplierID, TotalAmount) OUTPUT INSERTED.ReceiveID VALUES (@sup, 0)",
                        conn, trans);
                    cmd.Parameters.AddWithValue("@sup", supplierID);

                    int receiveID = (int)cmd.ExecuteScalar();

                    float totalAmount = 0;

                    // 2. Lưu từng sản phẩm trong phiếu nhập
                    foreach (DataRow row in receiveTable.Rows)
                    {
                        int productID = Convert.ToInt32(row["ProductID"]);
                        int quantity = Convert.ToInt32(row["Quantity"]);
                        float price = float.Parse(row["Price"].ToString());
                        float total = float.Parse(row["Total"].ToString());

                        totalAmount += total;

                        SqlCommand cmd2 = new SqlCommand(
                            @"INSERT INTO ReceiveOrderDetails
                              (ReceiveID, ProductID, Quantity, Price, Total)
                              VALUES (@rid, @pid, @qty, @price, @total)",
                              conn, trans);

                        cmd2.Parameters.AddWithValue("@rid", receiveID);
                        cmd2.Parameters.AddWithValue("@pid", productID);
                        cmd2.Parameters.AddWithValue("@qty", quantity);
                        cmd2.Parameters.AddWithValue("@price", price);
                        cmd2.Parameters.AddWithValue("@total", total);
                        cmd2.ExecuteNonQuery();

                        // 3. Cập nhật tăng số lượng tồn kho
                        SqlCommand cmd3 = new SqlCommand(
                            "UPDATE Products SET Quantity = Quantity + @qty WHERE ID = @pid",
                            conn, trans);

                        cmd3.Parameters.AddWithValue("@qty", quantity);
                        cmd3.Parameters.AddWithValue("@pid", productID);
                        cmd3.ExecuteNonQuery();
                    }

                    // 4. Cập nhật tổng tiền vào phiếu nhập
                    SqlCommand cmdTotal = new SqlCommand(
                        "UPDATE ReceiveOrders SET TotalAmount = @t WHERE ReceiveID = @rid",
                        conn, trans);

                    cmdTotal.Parameters.AddWithValue("@t", totalAmount);
                    cmdTotal.Parameters.AddWithValue("@rid", receiveID);
                    cmdTotal.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Nhập hàng thành công!");

                    receiveTable.Rows.Clear();
                }
                catch
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi khi nhập hàng!");
                }
            }
        }

        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
