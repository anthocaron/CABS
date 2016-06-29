namespace CABS.Formulaires.Inscription
{
    partial class frmInscriptionPopote
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
            this.nudSolde = new System.Windows.Forms.NumericUpDown();
            this.lblSolde = new System.Windows.Forms.Label();
            this.cbConjointDiabetique = new System.Windows.Forms.CheckBox();
            this.cbDiabetique = new System.Windows.Forms.CheckBox();
            this.txtIndicationsLivraison = new System.Windows.Forms.TextBox();
            this.txtAllergiesConjoint = new System.Windows.Forms.TextBox();
            this.txtAllergies = new System.Windows.Forms.TextBox();
            this.lblIndicationsLivraison = new System.Windows.Forms.Label();
            this.lblAllergiesConjoint = new System.Windows.Forms.Label();
            this.lblAllergies = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSolde)).BeginInit();
            this.SuspendLayout();
            // 
            // nudSolde
            // 
            this.nudSolde.DecimalPlaces = 2;
            this.nudSolde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSolde.Location = new System.Drawing.Point(70, 12);
            this.nudSolde.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            131072});
            this.nudSolde.Name = "nudSolde";
            this.nudSolde.Size = new System.Drawing.Size(120, 23);
            this.nudSolde.TabIndex = 1;
            this.nudSolde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSolde.ThousandsSeparator = true;
            this.nudSolde.Click += new System.EventHandler(this.nudSolde_Click);
            this.nudSolde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudSolde_KeyPress);
            // 
            // lblSolde
            // 
            this.lblSolde.AutoSize = true;
            this.lblSolde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolde.Location = new System.Drawing.Point(12, 14);
            this.lblSolde.Name = "lblSolde";
            this.lblSolde.Size = new System.Drawing.Size(52, 17);
            this.lblSolde.TabIndex = 0;
            this.lblSolde.Text = "Solde :";
            // 
            // cbConjointDiabetique
            // 
            this.cbConjointDiabetique.AutoSize = true;
            this.cbConjointDiabetique.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConjointDiabetique.Location = new System.Drawing.Point(318, 41);
            this.cbConjointDiabetique.Name = "cbConjointDiabetique";
            this.cbConjointDiabetique.Size = new System.Drawing.Size(166, 21);
            this.cbConjointDiabetique.TabIndex = 3;
            this.cbConjointDiabetique.Text = "Conjoint(e) diabètique";
            this.cbConjointDiabetique.UseVisualStyleBackColor = true;
            // 
            // cbDiabetique
            // 
            this.cbDiabetique.AutoSize = true;
            this.cbDiabetique.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDiabetique.Location = new System.Drawing.Point(12, 41);
            this.cbDiabetique.Name = "cbDiabetique";
            this.cbDiabetique.Size = new System.Drawing.Size(95, 21);
            this.cbDiabetique.TabIndex = 2;
            this.cbDiabetique.Text = "Diabètique";
            this.cbDiabetique.UseVisualStyleBackColor = true;
            // 
            // txtIndicationsLivraison
            // 
            this.txtIndicationsLivraison.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndicationsLivraison.Location = new System.Drawing.Point(12, 258);
            this.txtIndicationsLivraison.Multiline = true;
            this.txtIndicationsLivraison.Name = "txtIndicationsLivraison";
            this.txtIndicationsLivraison.Size = new System.Drawing.Size(300, 150);
            this.txtIndicationsLivraison.TabIndex = 9;
            // 
            // txtAllergiesConjoint
            // 
            this.txtAllergiesConjoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllergiesConjoint.Location = new System.Drawing.Point(318, 85);
            this.txtAllergiesConjoint.Multiline = true;
            this.txtAllergiesConjoint.Name = "txtAllergiesConjoint";
            this.txtAllergiesConjoint.Size = new System.Drawing.Size(300, 150);
            this.txtAllergiesConjoint.TabIndex = 7;
            // 
            // txtAllergies
            // 
            this.txtAllergies.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllergies.Location = new System.Drawing.Point(12, 85);
            this.txtAllergies.Multiline = true;
            this.txtAllergies.Name = "txtAllergies";
            this.txtAllergies.Size = new System.Drawing.Size(300, 150);
            this.txtAllergies.TabIndex = 5;
            // 
            // lblIndicationsLivraison
            // 
            this.lblIndicationsLivraison.AutoSize = true;
            this.lblIndicationsLivraison.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicationsLivraison.Location = new System.Drawing.Point(12, 238);
            this.lblIndicationsLivraison.Name = "lblIndicationsLivraison";
            this.lblIndicationsLivraison.Size = new System.Drawing.Size(139, 17);
            this.lblIndicationsLivraison.TabIndex = 8;
            this.lblIndicationsLivraison.Text = "Indications livraison :";
            // 
            // lblAllergiesConjoint
            // 
            this.lblAllergiesConjoint.AutoSize = true;
            this.lblAllergiesConjoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllergiesConjoint.Location = new System.Drawing.Point(315, 65);
            this.lblAllergiesConjoint.Name = "lblAllergiesConjoint";
            this.lblAllergiesConjoint.Size = new System.Drawing.Size(161, 17);
            this.lblAllergiesConjoint.TabIndex = 6;
            this.lblAllergiesConjoint.Text = "Allergies du conjoint(e) :";
            // 
            // lblAllergies
            // 
            this.lblAllergies.AutoSize = true;
            this.lblAllergies.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllergies.Location = new System.Drawing.Point(12, 65);
            this.lblAllergies.Name = "lblAllergies";
            this.lblAllergies.Size = new System.Drawing.Size(70, 17);
            this.lblAllergies.TabIndex = 4;
            this.lblAllergies.Text = "Allergies :";
            // 
            // frmInscriptionPopote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 638);
            this.Controls.Add(this.nudSolde);
            this.Controls.Add(this.lblSolde);
            this.Controls.Add(this.cbConjointDiabetique);
            this.Controls.Add(this.cbDiabetique);
            this.Controls.Add(this.txtIndicationsLivraison);
            this.Controls.Add(this.txtAllergiesConjoint);
            this.Controls.Add(this.txtAllergies);
            this.Controls.Add(this.lblIndicationsLivraison);
            this.Controls.Add(this.lblAllergiesConjoint);
            this.Controls.Add(this.lblAllergies);
            this.Name = "frmInscriptionPopote";
            this.Text = "frmInscriptionPopotte";
            ((System.ComponentModel.ISupportInitialize)(this.nudSolde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAllergies;
        private System.Windows.Forms.Label lblAllergiesConjoint;
        private System.Windows.Forms.Label lblIndicationsLivraison;
        private System.Windows.Forms.TextBox txtAllergies;
        private System.Windows.Forms.TextBox txtAllergiesConjoint;
        private System.Windows.Forms.TextBox txtIndicationsLivraison;
        private System.Windows.Forms.CheckBox cbDiabetique;
        private System.Windows.Forms.CheckBox cbConjointDiabetique;
        private System.Windows.Forms.Label lblSolde;
        private System.Windows.Forms.NumericUpDown nudSolde;

    }
}