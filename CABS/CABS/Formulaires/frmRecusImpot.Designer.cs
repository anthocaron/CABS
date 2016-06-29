namespace CABS.Formulaires
{
    partial class frmRecusImpot
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
            this.btnCalculerRecus = new System.Windows.Forms.Button();
            this.lblDu = new System.Windows.Forms.Label();
            this.lblAu = new System.Windows.Forms.Label();
            this.dtpDu = new System.Windows.Forms.DateTimePicker();
            this.dtpAu = new System.Windows.Forms.DateTimePicker();
            this.lblAgeMinimum = new System.Windows.Forms.Label();
            this.lblPourcentageRemboursement = new System.Windows.Forms.Label();
            this.nudAgeMinimum = new System.Windows.Forms.NumericUpDown();
            this.nudPourcentageRemboursement = new System.Windows.Forms.NumericUpDown();
            this.gbRecus = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIndexCourant = new System.Windows.Forms.Label();
            this.lblBeneficiaireCourantValeur = new System.Windows.Forms.Label();
            this.btnGenererRecu = new System.Windows.Forms.Button();
            this.btnSuivant10 = new System.Windows.Forms.Button();
            this.btnSuivant = new System.Windows.Forms.Button();
            this.btnPrecedent = new System.Windows.Forms.Button();
            this.btnPrecedent10 = new System.Windows.Forms.Button();
            this.dtpDateEmission = new System.Windows.Forms.DateTimePicker();
            this.lblDateEmission = new System.Windows.Forms.Label();
            this.lblAvertissement = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeMinimum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPourcentageRemboursement)).BeginInit();
            this.gbRecus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalculerRecus
            // 
            this.btnCalculerRecus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculerRecus.Location = new System.Drawing.Point(13, 145);
            this.btnCalculerRecus.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalculerRecus.Name = "btnCalculerRecus";
            this.btnCalculerRecus.Size = new System.Drawing.Size(200, 28);
            this.btnCalculerRecus.TabIndex = 0;
            this.btnCalculerRecus.Text = "Calculer les reçus d\'impôt";
            this.btnCalculerRecus.UseVisualStyleBackColor = true;
            this.btnCalculerRecus.Click += new System.EventHandler(this.btnCalculerRecus_Click);
            // 
            // lblDu
            // 
            this.lblDu.AutoSize = true;
            this.lblDu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDu.Location = new System.Drawing.Point(14, 18);
            this.lblDu.Margin = new System.Windows.Forms.Padding(5);
            this.lblDu.Name = "lblDu";
            this.lblDu.Size = new System.Drawing.Size(34, 17);
            this.lblDu.TabIndex = 1;
            this.lblDu.Text = "Du :";
            // 
            // lblAu
            // 
            this.lblAu.AutoSize = true;
            this.lblAu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAu.Location = new System.Drawing.Point(14, 52);
            this.lblAu.Margin = new System.Windows.Forms.Padding(5);
            this.lblAu.Name = "lblAu";
            this.lblAu.Size = new System.Drawing.Size(33, 17);
            this.lblAu.TabIndex = 2;
            this.lblAu.Text = "Au :";
            // 
            // dtpDu
            // 
            this.dtpDu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDu.Location = new System.Drawing.Point(58, 14);
            this.dtpDu.Margin = new System.Windows.Forms.Padding(5);
            this.dtpDu.Name = "dtpDu";
            this.dtpDu.Size = new System.Drawing.Size(183, 23);
            this.dtpDu.TabIndex = 3;
            // 
            // dtpAu
            // 
            this.dtpAu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAu.Location = new System.Drawing.Point(57, 47);
            this.dtpAu.Margin = new System.Windows.Forms.Padding(5);
            this.dtpAu.Name = "dtpAu";
            this.dtpAu.Size = new System.Drawing.Size(183, 23);
            this.dtpAu.TabIndex = 4;
            // 
            // lblAgeMinimum
            // 
            this.lblAgeMinimum.AutoSize = true;
            this.lblAgeMinimum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgeMinimum.Location = new System.Drawing.Point(14, 82);
            this.lblAgeMinimum.Margin = new System.Windows.Forms.Padding(5);
            this.lblAgeMinimum.Name = "lblAgeMinimum";
            this.lblAgeMinimum.Size = new System.Drawing.Size(100, 17);
            this.lblAgeMinimum.TabIndex = 5;
            this.lblAgeMinimum.Text = "Âge minimum :";
            // 
            // lblPourcentageRemboursement
            // 
            this.lblPourcentageRemboursement.AutoSize = true;
            this.lblPourcentageRemboursement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPourcentageRemboursement.Location = new System.Drawing.Point(14, 115);
            this.lblPourcentageRemboursement.Margin = new System.Windows.Forms.Padding(5);
            this.lblPourcentageRemboursement.Name = "lblPourcentageRemboursement";
            this.lblPourcentageRemboursement.Size = new System.Drawing.Size(200, 17);
            this.lblPourcentageRemboursement.TabIndex = 6;
            this.lblPourcentageRemboursement.Text = "Pourcentage remboursement :";
            // 
            // nudAgeMinimum
            // 
            this.nudAgeMinimum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAgeMinimum.Location = new System.Drawing.Point(224, 80);
            this.nudAgeMinimum.Margin = new System.Windows.Forms.Padding(5);
            this.nudAgeMinimum.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudAgeMinimum.Name = "nudAgeMinimum";
            this.nudAgeMinimum.Size = new System.Drawing.Size(46, 23);
            this.nudAgeMinimum.TabIndex = 7;
            this.nudAgeMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAgeMinimum.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            // 
            // nudPourcentageRemboursement
            // 
            this.nudPourcentageRemboursement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPourcentageRemboursement.Location = new System.Drawing.Point(224, 113);
            this.nudPourcentageRemboursement.Margin = new System.Windows.Forms.Padding(5);
            this.nudPourcentageRemboursement.Name = "nudPourcentageRemboursement";
            this.nudPourcentageRemboursement.Size = new System.Drawing.Size(46, 23);
            this.nudPourcentageRemboursement.TabIndex = 8;
            this.nudPourcentageRemboursement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPourcentageRemboursement.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // gbRecus
            // 
            this.gbRecus.Controls.Add(this.label2);
            this.gbRecus.Controls.Add(this.lblIndexCourant);
            this.gbRecus.Controls.Add(this.lblBeneficiaireCourantValeur);
            this.gbRecus.Controls.Add(this.btnGenererRecu);
            this.gbRecus.Controls.Add(this.btnSuivant10);
            this.gbRecus.Controls.Add(this.btnSuivant);
            this.gbRecus.Controls.Add(this.btnPrecedent);
            this.gbRecus.Controls.Add(this.btnPrecedent10);
            this.gbRecus.Location = new System.Drawing.Point(14, 196);
            this.gbRecus.Margin = new System.Windows.Forms.Padding(5);
            this.gbRecus.Name = "gbRecus";
            this.gbRecus.Size = new System.Drawing.Size(436, 131);
            this.gbRecus.TabIndex = 9;
            this.gbRecus.TabStop = false;
            this.gbRecus.Text = "Reçus à générer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bénéficiare courant :";
            // 
            // lblIndexCourant
            // 
            this.lblIndexCourant.Location = new System.Drawing.Point(178, 24);
            this.lblIndexCourant.Margin = new System.Windows.Forms.Padding(5);
            this.lblIndexCourant.Name = "lblIndexCourant";
            this.lblIndexCourant.Size = new System.Drawing.Size(80, 28);
            this.lblIndexCourant.TabIndex = 6;
            this.lblIndexCourant.Text = "0 de 0";
            this.lblIndexCourant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBeneficiaireCourantValeur
            // 
            this.lblBeneficiaireCourantValeur.BackColor = System.Drawing.Color.White;
            this.lblBeneficiaireCourantValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBeneficiaireCourantValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiaireCourantValeur.Location = new System.Drawing.Point(157, 62);
            this.lblBeneficiaireCourantValeur.Margin = new System.Windows.Forms.Padding(5);
            this.lblBeneficiaireCourantValeur.Name = "lblBeneficiaireCourantValeur";
            this.lblBeneficiaireCourantValeur.Size = new System.Drawing.Size(271, 23);
            this.lblBeneficiaireCourantValeur.TabIndex = 5;
            this.lblBeneficiaireCourantValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGenererRecu
            // 
            this.btnGenererRecu.Location = new System.Drawing.Point(8, 95);
            this.btnGenererRecu.Margin = new System.Windows.Forms.Padding(5);
            this.btnGenererRecu.Name = "btnGenererRecu";
            this.btnGenererRecu.Size = new System.Drawing.Size(420, 28);
            this.btnGenererRecu.TabIndex = 4;
            this.btnGenererRecu.Text = "Générer le reçu d\'impôt du bénéficiaire";
            this.btnGenererRecu.UseVisualStyleBackColor = true;
            this.btnGenererRecu.Click += new System.EventHandler(this.btnGenererRecu_Click);
            // 
            // btnSuivant10
            // 
            this.btnSuivant10.Location = new System.Drawing.Point(353, 24);
            this.btnSuivant10.Margin = new System.Windows.Forms.Padding(5);
            this.btnSuivant10.Name = "btnSuivant10";
            this.btnSuivant10.Size = new System.Drawing.Size(75, 28);
            this.btnSuivant10.TabIndex = 3;
            this.btnSuivant10.Text = ">> x10";
            this.btnSuivant10.UseVisualStyleBackColor = true;
            this.btnSuivant10.Click += new System.EventHandler(this.btnSuivant10_Click);
            // 
            // btnSuivant
            // 
            this.btnSuivant.Location = new System.Drawing.Point(268, 24);
            this.btnSuivant.Margin = new System.Windows.Forms.Padding(5);
            this.btnSuivant.Name = "btnSuivant";
            this.btnSuivant.Size = new System.Drawing.Size(75, 28);
            this.btnSuivant.TabIndex = 2;
            this.btnSuivant.Text = ">>";
            this.btnSuivant.UseVisualStyleBackColor = true;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            // 
            // btnPrecedent
            // 
            this.btnPrecedent.Location = new System.Drawing.Point(93, 24);
            this.btnPrecedent.Margin = new System.Windows.Forms.Padding(5);
            this.btnPrecedent.Name = "btnPrecedent";
            this.btnPrecedent.Size = new System.Drawing.Size(75, 28);
            this.btnPrecedent.TabIndex = 1;
            this.btnPrecedent.Text = "<<";
            this.btnPrecedent.UseVisualStyleBackColor = true;
            this.btnPrecedent.Click += new System.EventHandler(this.btnPrecedent_Click);
            // 
            // btnPrecedent10
            // 
            this.btnPrecedent10.Location = new System.Drawing.Point(8, 24);
            this.btnPrecedent10.Margin = new System.Windows.Forms.Padding(5);
            this.btnPrecedent10.Name = "btnPrecedent10";
            this.btnPrecedent10.Size = new System.Drawing.Size(75, 28);
            this.btnPrecedent10.TabIndex = 0;
            this.btnPrecedent10.Text = "<< x10";
            this.btnPrecedent10.UseVisualStyleBackColor = true;
            this.btnPrecedent10.Click += new System.EventHandler(this.btnPrecedent10_Click);
            // 
            // dtpDateEmission
            // 
            this.dtpDateEmission.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateEmission.Location = new System.Drawing.Point(377, 14);
            this.dtpDateEmission.Margin = new System.Windows.Forms.Padding(5);
            this.dtpDateEmission.Name = "dtpDateEmission";
            this.dtpDateEmission.Size = new System.Drawing.Size(183, 23);
            this.dtpDateEmission.TabIndex = 11;
            // 
            // lblDateEmission
            // 
            this.lblDateEmission.AutoSize = true;
            this.lblDateEmission.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateEmission.Location = new System.Drawing.Point(251, 18);
            this.lblDateEmission.Margin = new System.Windows.Forms.Padding(5);
            this.lblDateEmission.Name = "lblDateEmission";
            this.lblDateEmission.Size = new System.Drawing.Size(116, 17);
            this.lblDateEmission.TabIndex = 10;
            this.lblDateEmission.Text = "Date d\'émission :";
            // 
            // lblAvertissement
            // 
            this.lblAvertissement.ForeColor = System.Drawing.Color.Red;
            this.lblAvertissement.Location = new System.Drawing.Point(222, 146);
            this.lblAvertissement.Margin = new System.Windows.Forms.Padding(5);
            this.lblAvertissement.Name = "lblAvertissement";
            this.lblAvertissement.Size = new System.Drawing.Size(305, 40);
            this.lblAvertissement.TabIndex = 12;
            this.lblAvertissement.Text = "Avertissement : Des paramètres ont été modifiés, mais les reçus n\'ont pas été cal" +
    "culés de nouveau";
            this.lblAvertissement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAvertissement.Visible = false;
            // 
            // frmRecusImpot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 477);
            this.Controls.Add(this.lblAvertissement);
            this.Controls.Add(this.dtpDateEmission);
            this.Controls.Add(this.lblDateEmission);
            this.Controls.Add(this.gbRecus);
            this.Controls.Add(this.nudPourcentageRemboursement);
            this.Controls.Add(this.nudAgeMinimum);
            this.Controls.Add(this.lblPourcentageRemboursement);
            this.Controls.Add(this.lblAgeMinimum);
            this.Controls.Add(this.dtpAu);
            this.Controls.Add(this.dtpDu);
            this.Controls.Add(this.lblAu);
            this.Controls.Add(this.lblDu);
            this.Controls.Add(this.btnCalculerRecus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRecusImpot";
            this.Text = "frmRecusImpot";
            this.Load += new System.EventHandler(this.frmRecusImpot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeMinimum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPourcentageRemboursement)).EndInit();
            this.gbRecus.ResumeLayout(false);
            this.gbRecus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculerRecus;
        private System.Windows.Forms.Label lblDu;
        private System.Windows.Forms.Label lblAu;
        private System.Windows.Forms.DateTimePicker dtpDu;
        private System.Windows.Forms.DateTimePicker dtpAu;
        private System.Windows.Forms.Label lblAgeMinimum;
        private System.Windows.Forms.Label lblPourcentageRemboursement;
        private System.Windows.Forms.NumericUpDown nudAgeMinimum;
        private System.Windows.Forms.NumericUpDown nudPourcentageRemboursement;
        private System.Windows.Forms.GroupBox gbRecus;
        private System.Windows.Forms.Label lblBeneficiaireCourantValeur;
        private System.Windows.Forms.Button btnGenererRecu;
        private System.Windows.Forms.Button btnSuivant10;
        private System.Windows.Forms.Button btnSuivant;
        private System.Windows.Forms.Button btnPrecedent;
        private System.Windows.Forms.Button btnPrecedent10;
        private System.Windows.Forms.DateTimePicker dtpDateEmission;
        private System.Windows.Forms.Label lblDateEmission;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIndexCourant;
        private System.Windows.Forms.Label lblAvertissement;
    }
}