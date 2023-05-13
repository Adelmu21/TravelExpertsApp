namespace TravelExpertsWorkshop1
{
    partial class frmAddProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddProduct));
            label1 = new Label();
            txtProductID = new TextBox();
            label2 = new Label();
            txtProductName = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 45);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 19);
            label1.TabIndex = 1;
            label1.Text = "Product ID:";
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(163, 42);
            txtProductID.Margin = new Padding(2);
            txtProductID.Name = "txtProductID";
            txtProductID.Size = new Size(92, 25);
            txtProductID.TabIndex = 3;
            txtProductID.Tag = "Supplier ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 90);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 19);
            label2.TabIndex = 4;
            label2.Text = "Product Name:";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(163, 87);
            txtProductName.Margin = new Padding(2);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(190, 25);
            txtProductName.TabIndex = 5;
            txtProductName.Tag = "Supplier Name";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.Location = new Point(276, 149);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(59, 27);
            btnSave.TabIndex = 6;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.Location = new Point(339, 149);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(59, 27);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmAddProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 187);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtProductName);
            Controls.Add(label2);
            Controls.Add(txtProductID);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAddProduct";
            Text = "Add Product";
            Load += frmAddProduct_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtProductID;
        private Label label2;
        private TextBox txtProductName;
        private Button btnSave;
        private Button btnCancel;
    }
}