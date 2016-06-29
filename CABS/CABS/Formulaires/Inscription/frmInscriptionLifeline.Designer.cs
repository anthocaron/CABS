namespace CABS.Formulaires.Inscription
{
    partial class frmInscriptionLifeline
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
            this.lblNoUnite = new System.Windows.Forms.Label();
            this.txtNoUnite = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNoUnite
            // 
            this.lblNoUnite.AutoSize = true;
            this.lblNoUnite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoUnite.Location = new System.Drawing.Point(12, 15);
            this.lblNoUnite.Name = "lblNoUnite";
            this.lblNoUnite.Size = new System.Drawing.Size(84, 17);
            this.lblNoUnite.TabIndex = 0;
            this.lblNoUnite.Text = "No. d\'unité :";
            // 
            // txtNoUnite
            // 
            this.txtNoUnite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoUnite.Location = new System.Drawing.Point(102, 12);
            this.txtNoUnite.MaxLength = 64;
            this.txtNoUnite.Name = "txtNoUnite";
            this.txtNoUnite.Size = new System.Drawing.Size(400, 23);
            this.txtNoUnite.TabIndex = 1;
            // 
            // frmInscriptionLifeline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 638);
            this.Controls.Add(this.txtNoUnite);
            this.Controls.Add(this.lblNoUnite);
            this.Name = "frmInscriptionLifeline";
            this.Text = "frmInscriptionLifeline";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNoUnite;
        private System.Windows.Forms.TextBox txtNoUnite;


    }
}