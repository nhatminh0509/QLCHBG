namespace _0306181057_QLCHBG
{
    partial class frmInBaoCao
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
            this.rpView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpView
            // 
            this.rpView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpView.Location = new System.Drawing.Point(0, 0);
            this.rpView.Name = "rpView";
            this.rpView.Size = new System.Drawing.Size(1226, 639);
            this.rpView.TabIndex = 0;
            // 
            // frmInBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1226, 639);
            this.Controls.Add(this.rpView);
            this.Name = "frmInBaoCao";
            this.Text = "In";
            this.Load += new System.EventHandler(this.frmInBaoCao_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpView;

    }
}