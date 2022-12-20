namespace WarehouseManagement
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LinkLayout = new System.Windows.Forms.Panel();
            this.MainLayout = new System.Windows.Forms.Panel();
            this.mainGridView = new System.Windows.Forms.DataGridView();
            this.MainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // LinkLayout
            // 
            this.LinkLayout.Location = new System.Drawing.Point(12, 30);
            this.LinkLayout.Name = "LinkLayout";
            this.LinkLayout.Size = new System.Drawing.Size(250, 537);
            this.LinkLayout.TabIndex = 0;
            // 
            // MainLayout
            // 
            this.MainLayout.Controls.Add(this.mainGridView);
            this.MainLayout.Location = new System.Drawing.Point(295, 30);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.Size = new System.Drawing.Size(890, 537);
            this.MainLayout.TabIndex = 1;
            // 
            // mainGridView
            // 
            this.mainGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainGridView.Location = new System.Drawing.Point(21, 51);
            this.mainGridView.Name = "mainGridView";
            this.mainGridView.RowHeadersWidth = 51;
            this.mainGridView.RowTemplate.Height = 29;
            this.mainGridView.Size = new System.Drawing.Size(853, 465);
            this.mainGridView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 605);
            this.Controls.Add(this.MainLayout);
            this.Controls.Add(this.LinkLayout);
            this.Name = "MainForm";
            this.Text = "WarehouseManagement";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel LinkLayout;
        private Panel MainLayout;
        private DataGridView mainGridView;
    }
}