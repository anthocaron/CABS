namespace CABS.Outils
{
    partial class frmSelectionTable
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.gtChoix = new CABS.Outils.GrilleTable();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(0, 416);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(142, 40);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuler.Location = new System.Drawing.Point(148, 416);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(142, 40);
            this.btnAnnuler.TabIndex = 2;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // gtChoix
            // 
            this.gtChoix.Dock = System.Windows.Forms.DockStyle.Top;
            this.gtChoix.Location = new System.Drawing.Point(0, 0);
            this.gtChoix.Margin = new System.Windows.Forms.Padding(0);
            this.gtChoix.Name = "gtChoix";
            this.gtChoix.Size = new System.Drawing.Size(290, 418);
            this.gtChoix.TabIndex = 0;
            this.gtChoix.RowDoubleClick += new CABS.Outils.GrilleTable.RowDoubleClickEventHandler(this.gtChoix_RowDoubleClick);
            // 
            // frmSelectionTable
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(290, 468);
            this.Controls.Add(this.gtChoix);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectionTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSelectionTable_FormClosing);
            this.Load += new System.EventHandler(this.frmSelectionTable_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAnnuler;
        private GrilleTable gtChoix;
    }
}