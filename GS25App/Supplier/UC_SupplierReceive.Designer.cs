namespace GS25App.Supplier
{
    partial class UC_SupplierReceive
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.DataGridView dgvReceiveList;

        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblNote;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.dgvReceiveList = new System.Windows.Forms.DataGridView();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiveList)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSupplier
            // 
            this.cbSupplier.Location = new System.Drawing.Point(130, 18);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(260, 21);
            this.cbSupplier.TabIndex = 5;
            this.cbSupplier.SelectedIndexChanged += new System.EventHandler(this.cbSupplier_SelectedIndexChanged);
            // 
            // cbProduct
            // 
            this.cbProduct.Location = new System.Drawing.Point(130, 58);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(260, 21);
            this.cbProduct.TabIndex = 6;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(130, 98);
            this.numQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 20);
            this.numQuantity.TabIndex = 7;
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(130, 138);
            this.numPrice.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(120, 20);
            this.numPrice.TabIndex = 8;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(130, 178);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(260, 20);
            this.txtNote.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 220);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(130, 220);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 30);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "Xóa";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(240, 220);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(180, 30);
            this.btnComplete.TabIndex = 12;
            this.btnComplete.Text = "Hoàn tất nhập hàng";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // dgvReceiveList
            // 
            this.dgvReceiveList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceiveList.BackgroundColor = System.Drawing.Color.White;
            this.dgvReceiveList.Location = new System.Drawing.Point(20, 270);
            this.dgvReceiveList.Name = "dgvReceiveList";
            this.dgvReceiveList.Size = new System.Drawing.Size(850, 300);
            this.dgvReceiveList.TabIndex = 13;
            // 
            // lblSupplier
            // 
            this.lblSupplier.Location = new System.Drawing.Point(20, 20);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(120, 25);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Nhà cung cấp:";
            // 
            // lblProduct
            // 
            this.lblProduct.Location = new System.Drawing.Point(20, 60);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(120, 25);
            this.lblProduct.TabIndex = 1;
            this.lblProduct.Text = "Sản phẩm:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(20, 100);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(120, 25);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "Số lượng:";
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(20, 140);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(120, 25);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "Đơn giá:";
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(20, 180);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(120, 25);
            this.lblNote.TabIndex = 4;
            this.lblNote.Text = "Ghi chú:";
            // 
            // UC_SupplierReceive
            // 
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.cbSupplier);
            this.Controls.Add(this.cbProduct);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.dgvReceiveList);
            this.Name = "UC_SupplierReceive";
            this.Size = new System.Drawing.Size(900, 600);
            this.Load += new System.EventHandler(this.UC_SupplierReceive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiveList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
