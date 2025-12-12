using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GS25App
{
    public class Staff
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public DateTime Birth { get; set; }
    }
    
    public partial class UC_Staff : UserControl
    {
        private DataTable dtStaff;
        List<Staff> staffList = new List<Staff>();
        private int selectedStaffIndex = -1;
        public UC_Staff()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                var staff = new Staff()
                {
                    ID = i,
                    Name = "Nhân viên " + (i + 1),
                    Role = "Chức vụ " + (i + 1),
                    Phone = "090000000" + i,
                    Birth = DateTime.Now.AddYears(-20).AddDays(i)
                };
                staffList.Add(staff);
            }
            LoadData();
        }
        
        private void LoadData()
        {
            // TODO: Viết code lấy dữ liệu từ SQL tại đây
            // Ví dụ giả lập dữ liệu:
            dtStaff = new DataTable();
            dtStaff.Columns.Add("MaNV");
            dtStaff.Columns.Add("TenNV");
            dtStaff.Columns.Add("ChucVu");
            dtStaff.Columns.Add("SoDienThoai");
            dtStaff.Columns.Add("NgaySinh");
            
            foreach (var staff in staffList)
            {
                dtStaff.Rows.Add(staff.ID, staff.Name, staff.Role, staff.Phone, staff.Birth);
            }

            // Gán vào DataGridView (giả sử bạn đã kéo thả 1 Grid tên là dgvStaff)
            dgvStaff.DataSource = dtStaff; 
            Console.WriteLine("Đã tải dữ liệu nhân viên.");
        }

        // Hàm làm sạch các ô nhập liệu
        private void ResetInputFields()
        {
            selectedStaffIndex = -1;
            nameTxt.Text = "";
            countryTxt.Text = "";
            phoneTxt.Text = "";
            roleTxt.Text = "";
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var staff = new Staff()
            {
                ID = staffList.Count,
                Name = nameTxt.Text,
                Role = roleTxt.Text,
                Phone = phoneTxt.Text,
                Birth = birthPicker.Value
            };
            staffList.Add(staff);
            LoadData();
            ResetInputFields();
            Console.WriteLine("Add button clicked");
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (selectedStaffIndex < 0 || selectedStaffIndex >= staffList.Count)
                return;
            var staff = staffList[selectedStaffIndex];
            staff.Name = nameTxt.Text;
            staff.Role = roleTxt.Text;
            staff.Phone = phoneTxt.Text;
            staff.Birth = birthPicker.Value;
            LoadData();
            ResetInputFields();
            Console.WriteLine("Edit button clicked");
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedStaffIndex < 0 || selectedStaffIndex >= staffList.Count)
                return;
            staffList.RemoveAt(selectedStaffIndex);
            LoadData();
            ResetInputFields();
            Console.WriteLine("Delete button clicked");
        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvStaff.Rows[e.RowIndex];
                selectedStaffIndex = row.Cells["MaNV"].Value != null ? Convert.ToInt32(row.Cells["MaNV"].Value) : -1;
                nameTxt.Text = row.Cells["TenNV"].Value.ToString();
                countryTxt.Text = row.Cells["ChucVu"].Value.ToString();
                phoneTxt.Text = row.Cells["SoDienThoai"].Value.ToString();
                var birthStr = row.Cells["NgaySinh"].Value.ToString();
                var birth = DateTime.Parse(birthStr);
                birthPicker.Value = birth;
            }
        }
    }
}