namespace CABS.Formulaires.Inscription
{
    partial class frmInscriptionServicesBeneficiaires
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
            this.gbBeneficiaire = new System.Windows.Forms.GroupBox();
            this.lblNomValeur = new System.Windows.Forms.Label();
            this.lblPrenomValeur = new System.Windows.Forms.Label();
            this.btnChoisirBeneficiaire = new System.Windows.Forms.Button();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.lblService = new System.Windows.Forms.Label();
            this.btnInscrire = new System.Windows.Forms.Button();
            this.panFormulaireInscription = new System.Windows.Forms.Panel();
            this.btnDesinscrire = new System.Windows.Forms.Button();
            this.txtCommentaires = new System.Windows.Forms.TextBox();
            this.lblCommentaires = new System.Windows.Forms.Label();
            this.lblDateDemande = new System.Windows.Forms.Label();
            this.btnModifierInfos = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.dtpDateDemande = new System.Windows.Forms.DateTimePicker();
            this.cbSuspendu = new System.Windows.Forms.CheckBox();
            this.btnFicheBeneficiaire = new System.Windows.Forms.Button();
            this.gbBeneficiaire.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBeneficiaire
            // 
            this.gbBeneficiaire.Controls.Add(this.lblNomValeur);
            this.gbBeneficiaire.Controls.Add(this.lblPrenomValeur);
            this.gbBeneficiaire.Controls.Add(this.btnChoisirBeneficiaire);
            this.gbBeneficiaire.Controls.Add(this.lblNom);
            this.gbBeneficiaire.Controls.Add(this.lblPrenom);
            this.gbBeneficiaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBeneficiaire.Location = new System.Drawing.Point(12, 12);
            this.gbBeneficiaire.Name = "gbBeneficiaire";
            this.gbBeneficiaire.Size = new System.Drawing.Size(608, 51);
            this.gbBeneficiaire.TabIndex = 0;
            this.gbBeneficiaire.TabStop = false;
            this.gbBeneficiaire.Text = "Bénéficiaire";
            // 
            // lblNomValeur
            // 
            this.lblNomValeur.BackColor = System.Drawing.Color.White;
            this.lblNomValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNomValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomValeur.Location = new System.Drawing.Point(350, 22);
            this.lblNomValeur.Margin = new System.Windows.Forms.Padding(3);
            this.lblNomValeur.Name = "lblNomValeur";
            this.lblNomValeur.Size = new System.Drawing.Size(216, 23);
            this.lblNomValeur.TabIndex = 3;
            this.lblNomValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrenomValeur
            // 
            this.lblPrenomValeur.BackColor = System.Drawing.Color.White;
            this.lblPrenomValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPrenomValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrenomValeur.Location = new System.Drawing.Point(77, 22);
            this.lblPrenomValeur.Margin = new System.Windows.Forms.Padding(3);
            this.lblPrenomValeur.Name = "lblPrenomValeur";
            this.lblPrenomValeur.Size = new System.Drawing.Size(216, 23);
            this.lblPrenomValeur.TabIndex = 1;
            this.lblPrenomValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChoisirBeneficiaire
            // 
            this.btnChoisirBeneficiaire.Image = global::CABS.Properties.Resources._16px_Magnifying_glass_icon;
            this.btnChoisirBeneficiaire.Location = new System.Drawing.Point(572, 18);
            this.btnChoisirBeneficiaire.Name = "btnChoisirBeneficiaire";
            this.btnChoisirBeneficiaire.Size = new System.Drawing.Size(30, 30);
            this.btnChoisirBeneficiaire.TabIndex = 4;
            this.btnChoisirBeneficiaire.UseVisualStyleBackColor = true;
            this.btnChoisirBeneficiaire.Click += new System.EventHandler(this.btnChoisirBeneficiaire_Click);
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(299, 25);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(45, 17);
            this.lblNom.TabIndex = 2;
            this.lblNom.Text = "Nom :";
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(6, 25);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(65, 17);
            this.lblPrenom.TabIndex = 0;
            this.lblPrenom.Text = "Prénom :";
            // 
            // cmbService
            // 
            this.cmbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Location = new System.Drawing.Point(81, 69);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(175, 24);
            this.cmbService.TabIndex = 2;
            this.cmbService.SelectedIndexChanged += new System.EventHandler(this.cmbService_SelectedIndexChanged);
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblService.Location = new System.Drawing.Point(12, 72);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(63, 17);
            this.lblService.TabIndex = 1;
            this.lblService.Text = "Service :";
            // 
            // btnInscrire
            // 
            this.btnInscrire.Enabled = false;
            this.btnInscrire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInscrire.Location = new System.Drawing.Point(12, 788);
            this.btnInscrire.Name = "btnInscrire";
            this.btnInscrire.Size = new System.Drawing.Size(117, 60);
            this.btnInscrire.TabIndex = 9;
            this.btnInscrire.Text = "Inscrire";
            this.btnInscrire.UseVisualStyleBackColor = true;
            this.btnInscrire.Click += new System.EventHandler(this.btnInscrireService_Click);
            // 
            // panFormulaireInscription
            // 
            this.panFormulaireInscription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panFormulaireInscription.Location = new System.Drawing.Point(12, 99);
            this.panFormulaireInscription.Name = "panFormulaireInscription";
            this.panFormulaireInscription.Size = new System.Drawing.Size(608, 560);
            this.panFormulaireInscription.TabIndex = 6;
            // 
            // btnDesinscrire
            // 
            this.btnDesinscrire.Enabled = false;
            this.btnDesinscrire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesinscrire.Location = new System.Drawing.Point(135, 788);
            this.btnDesinscrire.Name = "btnDesinscrire";
            this.btnDesinscrire.Size = new System.Drawing.Size(117, 60);
            this.btnDesinscrire.TabIndex = 10;
            this.btnDesinscrire.Text = "Désinscrire";
            this.btnDesinscrire.UseVisualStyleBackColor = true;
            this.btnDesinscrire.Click += new System.EventHandler(this.btnDesinscrireService_Click);
            // 
            // txtCommentaires
            // 
            this.txtCommentaires.Enabled = false;
            this.txtCommentaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommentaires.Location = new System.Drawing.Point(12, 682);
            this.txtCommentaires.Multiline = true;
            this.txtCommentaires.Name = "txtCommentaires";
            this.txtCommentaires.Size = new System.Drawing.Size(608, 100);
            this.txtCommentaires.TabIndex = 8;
            // 
            // lblCommentaires
            // 
            this.lblCommentaires.AutoSize = true;
            this.lblCommentaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentaires.Location = new System.Drawing.Point(12, 662);
            this.lblCommentaires.Name = "lblCommentaires";
            this.lblCommentaires.Size = new System.Drawing.Size(106, 17);
            this.lblCommentaires.TabIndex = 7;
            this.lblCommentaires.Text = "Commentaires :";
            // 
            // lblDateDemande
            // 
            this.lblDateDemande.AutoSize = true;
            this.lblDateDemande.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateDemande.Location = new System.Drawing.Point(262, 72);
            this.lblDateDemande.Name = "lblDateDemande";
            this.lblDateDemande.Size = new System.Drawing.Size(109, 17);
            this.lblDateDemande.TabIndex = 3;
            this.lblDateDemande.Text = "Date demande :";
            // 
            // btnModifierInfos
            // 
            this.btnModifierInfos.Enabled = false;
            this.btnModifierInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifierInfos.Location = new System.Drawing.Point(258, 788);
            this.btnModifierInfos.Name = "btnModifierInfos";
            this.btnModifierInfos.Size = new System.Drawing.Size(117, 60);
            this.btnModifierInfos.TabIndex = 11;
            this.btnModifierInfos.Text = "Modifier infos";
            this.btnModifierInfos.UseVisualStyleBackColor = true;
            this.btnModifierInfos.Click += new System.EventHandler(this.btnModifierInscription_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Enabled = false;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Location = new System.Drawing.Point(381, 788);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(117, 60);
            this.btnEnregistrer.TabIndex = 12;
            this.btnEnregistrer.Text = "Enregistrer infos";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrerModification_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Enabled = false;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(504, 788);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(116, 60);
            this.btnAnnuler.TabIndex = 13;
            this.btnAnnuler.Text = "Annuler infos";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // dtpDateDemande
            // 
            this.dtpDateDemande.Enabled = false;
            this.dtpDateDemande.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateDemande.Location = new System.Drawing.Point(377, 69);
            this.dtpDateDemande.Name = "dtpDateDemande";
            this.dtpDateDemande.Size = new System.Drawing.Size(136, 23);
            this.dtpDateDemande.TabIndex = 4;
            // 
            // cbSuspendu
            // 
            this.cbSuspendu.AutoSize = true;
            this.cbSuspendu.Enabled = false;
            this.cbSuspendu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSuspendu.Location = new System.Drawing.Point(521, 71);
            this.cbSuspendu.Margin = new System.Windows.Forms.Padding(5);
            this.cbSuspendu.Name = "cbSuspendu";
            this.cbSuspendu.Size = new System.Drawing.Size(99, 21);
            this.cbSuspendu.TabIndex = 5;
            this.cbSuspendu.Text = "Suspendu";
            this.cbSuspendu.UseVisualStyleBackColor = true;
            this.cbSuspendu.CheckedChanged += new System.EventHandler(this.cbSuspendu_CheckedChanged);
            // 
            // btnFicheBeneficiaire
            // 
            this.btnFicheBeneficiaire.Enabled = false;
            this.btnFicheBeneficiaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFicheBeneficiaire.Location = new System.Drawing.Point(12, 854);
            this.btnFicheBeneficiaire.Name = "btnFicheBeneficiaire";
            this.btnFicheBeneficiaire.Size = new System.Drawing.Size(608, 60);
            this.btnFicheBeneficiaire.TabIndex = 14;
            this.btnFicheBeneficiaire.Text = "Fiche du bénéficiaire...";
            this.btnFicheBeneficiaire.UseVisualStyleBackColor = true;
            this.btnFicheBeneficiaire.Click += new System.EventHandler(this.btnFicheBeneficiaire_Click);
            // 
            // frmInscriptionServicesBeneficiaires
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 951);
            this.Controls.Add(this.btnFicheBeneficiaire);
            this.Controls.Add(this.cbSuspendu);
            this.Controls.Add(this.dtpDateDemande);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnModifierInfos);
            this.Controls.Add(this.lblDateDemande);
            this.Controls.Add(this.txtCommentaires);
            this.Controls.Add(this.lblCommentaires);
            this.Controls.Add(this.btnDesinscrire);
            this.Controls.Add(this.panFormulaireInscription);
            this.Controls.Add(this.btnInscrire);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.cmbService);
            this.Controls.Add(this.gbBeneficiaire);
            this.Name = "frmInscriptionServicesBeneficiaires";
            this.Text = "frmInscriptionServices";
            this.gbBeneficiaire.ResumeLayout(false);
            this.gbBeneficiaire.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBeneficiaire;
        private System.Windows.Forms.Label lblNomValeur;
        private System.Windows.Forms.Label lblPrenomValeur;
        private System.Windows.Forms.Button btnChoisirBeneficiaire;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Button btnInscrire;
        private System.Windows.Forms.Panel panFormulaireInscription;
        private System.Windows.Forms.Button btnDesinscrire;
        private System.Windows.Forms.TextBox txtCommentaires;
        private System.Windows.Forms.Label lblCommentaires;
        private System.Windows.Forms.Label lblDateDemande;
        private System.Windows.Forms.Button btnModifierInfos;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.DateTimePicker dtpDateDemande;
        private System.Windows.Forms.CheckBox cbSuspendu;
        private System.Windows.Forms.Button btnFicheBeneficiaire;
    }
}