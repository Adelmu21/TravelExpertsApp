namespace TravelExpertsWorkshop1
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            btnSupplier = new Button();
            btnProduct = new Button();
            btnPackage = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnSupplier
            // 
            btnSupplier.Anchor = AnchorStyles.None;
            btnSupplier.AutoSize = true;
            btnSupplier.BackColor = Color.Orange;
            btnSupplier.ForeColor = SystemColors.Control;
            btnSupplier.Location = new Point(517, 187);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Size = new Size(172, 42);
            btnSupplier.TabIndex = 0;
            btnSupplier.Text = "View Suppliers";
            btnSupplier.UseVisualStyleBackColor = false;
            btnSupplier.Click += btnSupplier_Click;
            // 
            // btnProduct
            // 
            btnProduct.Anchor = AnchorStyles.None;
            btnProduct.AutoSize = true;
            btnProduct.BackColor = Color.Orange;
            btnProduct.ForeColor = SystemColors.Control;
            btnProduct.Location = new Point(469, 271);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(172, 42);
            btnProduct.TabIndex = 1;
            btnProduct.Text = "Add Product";
            btnProduct.UseVisualStyleBackColor = false;
            btnProduct.Click += btnProduct_Click;
            // 
            // btnPackage
            // 
            btnPackage.Anchor = AnchorStyles.None;
            btnPackage.AutoSize = true;
            btnPackage.BackColor = Color.Orange;
            btnPackage.ForeColor = SystemColors.Control;
            btnPackage.Location = new Point(12, 187);
            btnPackage.Name = "btnPackage";
            btnPackage.Size = new Size(172, 42);
            btnPackage.TabIndex = 2;
            btnPackage.Text = "View Packages";
            btnPackage.UseVisualStyleBackColor = false;
            btnPackage.Click += btnPackage_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tw Cen MT", 18F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(232, 105);
            label1.Name = "label1";
            label1.Size = new Size(146, 28);
            label1.TabIndex = 3;
            label1.Text = "Travel Experts";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(701, 342);
            Controls.Add(label1);
            Controls.Add(btnPackage);
            Controls.Add(btnProduct);
            Controls.Add(btnSupplier);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "frmMain";
            Text = "Travel Experts";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSupplier;
        private Button btnProduct;
        private Button btnPackage;
        private Label label1;
    }
}