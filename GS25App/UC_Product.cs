using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;


using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GS25App
{
    public partial class UC_Product : UserControl
    {
        // KẾT NỐI SQL
        string connectionString =
            @"Server=DESKTOP-SJCLE3H\SQLEXPRESS;Database=GS25;Trusted_Connection=True;";

        int selectedID = -1;

        public UC_Product()
        {
            InitializeComponent();
        }

        // ======================
        // LOAD USER CONTROL
        // ======================
        private void UC_Product_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // ======================
        // HÀM LOAD DỮ LIỆU SQL
        // ======================
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlDataAdapter da =
                        new SqlDataAdapter("SELECT * FROM Products", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = dt;

                    // Đổi tên cột cho đẹp
                    dataGridView1.Columns["ID"].HeaderText = "Mã SP";
                    dataGridView1.Columns["Name"].HeaderText = "Tên sản phẩm";
                    dataGridView1.Columns["Price"].HeaderText = "Giá";
                    dataGridView1.Columns["Quantity"].HeaderText = "Số lượng";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        // ======================
        // NHẤN THÊM
        // ======================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Price", double.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm sản phẩm thành công!");
                    LoadData();
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đúng dữ liệu!");
            }
        }

        // ======================
        // NHẤN SỬA
        // ======================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedID <= 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "UPDATE Products SET Name=@Name, Price=@Price, Quantity=@Quantity WHERE ID=@ID";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@ID", selectedID);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Price", double.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa dữ liệu: " + ex.Message);
            }
        }

        // ======================
        // NHẤN XÓA
        // ======================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedID <= 0)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "DELETE FROM Products WHERE ID=@ID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ID", selectedID);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        // ======================
        // CLICK VẬT TRÊN GRID
        // ======================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0) return;

            selectedID = int.Parse(dataGridView1.Rows[index].Cells["ID"].Value.ToString());

            txtName.Text = dataGridView1.Rows[index].Cells["Name"].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[index].Cells["Price"].Value.ToString();
            txtQuantity.Text = dataGridView1.Rows[index].Cells["Quantity"].Value.ToString();
        }
    }
}