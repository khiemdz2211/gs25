using System.Windows.Forms;

namespace GS25App
{
    public class Customer
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
    public partial class UC_Customer : UserControl
    {
        public UC_Customer()
        {
            InitializeComponent();
        }
        
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}