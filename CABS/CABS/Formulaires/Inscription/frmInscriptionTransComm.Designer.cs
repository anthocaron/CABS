namespace CABS.Formulaires.Inscription
{
    partial class frmInscriptionTransComm
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
            this.cbVuDDN = new System.Windows.Forms.CheckBox();
            this.lbl65ans = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbVuDDN
            // 
            this.cbVuDDN.AutoSize = true;
            this.cbVuDDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVuDDN.Location = new System.Drawing.Point(125, 14);
            this.cbVuDDN.Margin = new System.Windows.Forms.Padding(5);
            this.cbVuDDN.Name = "cbVuDDN";
            this.cbVuDDN.Size = new System.Drawing.Size(78, 21);
            this.cbVuDDN.TabIndex = 1;
            this.cbVuDDN.Text = "Vu DDN";
            this.cbVuDDN.UseVisualStyleBackColor = true;
            // 
            // lbl65ans
            // 
            this.lbl65ans.AutoSize = true;
            this.lbl65ans.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl65ans.Location = new System.Drawing.Point(12, 15);
            this.lbl65ans.Name = "lbl65ans";
            this.lbl65ans.Size = new System.Drawing.Size(105, 17);
            this.lbl65ans.TabIndex = 0;
            this.lbl65ans.Text = "65 ans et plus :";
            // 
            // frmInscriptionTransComm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 638);
            this.Controls.Add(this.lbl65ans);
            this.Controls.Add(this.cbVuDDN);
            this.Name = "frmInscriptionTransComm";
            this.Text = "frmInscriptionLifeline";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbVuDDN;
        private System.Windows.Forms.Label lbl65ans;



    }
}