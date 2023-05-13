namespace TravelExpertsWorkshop1
{
    partial class frmDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetails));
            label1 = new Label();
            label2 = new Label();
            lstSupProd = new ListBox();
            txtPkgID = new TextBox();
            txtPkgName = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            label3 = new Label();
            txtPkgPrice = new TextBox();
            btnClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 20);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(88, 21);
            label1.TabIndex = 2;
            label1.Text = "Package ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 65);
            label2.Name = "label2";
            label2.Size = new Size(115, 21);
            label2.TabIndex = 12;
            label2.Text = "Package Name:";
            // 
            // lstSupProd
            // 
            lstSupProd.FormattingEnabled = true;
            lstSupProd.ItemHeight = 21;
            lstSupProd.Location = new Point(12, 180);
            lstSupProd.Name = "lstSupProd";
            lstSupProd.Size = new Size(500, 256);
            lstSupProd.TabIndex = 14;
            lstSupProd.SelectedIndexChanged += lstSupProd_SelectedIndexChanged;
            // 
            // txtPkgID
            // 
            txtPkgID.Location = new Point(155, 17);
            txtPkgID.Name = "txtPkgID";
            txtPkgID.ReadOnly = true;
            txtPkgID.Size = new Size(304, 29);
            txtPkgID.TabIndex = 15;
            // 
            // txtPkgName
            // 
            txtPkgName.Location = new Point(155, 62);
            txtPkgName.Name = "txtPkgName";
            txtPkgName.ReadOnly = true;
            txtPkgName.Size = new Size(304, 29);
            txtPkgName.TabIndex = 16;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(235, 482);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(67, 29);
            btnAdd.TabIndex = 17;
            btnAdd.Text = "&Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(323, 482);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(67, 29);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "&Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 116);
            label3.Name = "label3";
            label3.Size = new Size(107, 21);
            label3.TabIndex = 19;
            label3.Text = "Package Price:";
            // 
            // txtPkgPrice
            // 
            txtPkgPrice.Location = new Point(155, 113);
            txtPkgPrice.Name = "txtPkgPrice";
            txtPkgPrice.ReadOnly = true;
            txtPkgPrice.Size = new Size(304, 29);
            txtPkgPrice.TabIndex = 20;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(420, 482);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(67, 29);
            btnClose.TabIndex = 21;
            btnClose.Text = "&Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmDetails
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 536);
            Controls.Add(btnClose);
            Controls.Add(txtPkgPrice);
            Controls.Add(label3);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtPkgName);
            Controls.Add(txtPkgID);
            Controls.Add(lstSupProd);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "frmDetails";
            Text = "Details";
            Load += frmDetails_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ListBox lstSupProd;
        private TextBox txtPkgID;
        private TextBox txtPkgName;
        private Button btnAdd;
        private Button btnDelete;
        private Label label3;
        private TextBox txtPkgPrice;
        private Button btnClose;
    }
}