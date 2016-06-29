namespace CABS.Formulaires
{
    partial class frmGestionDossiers
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
            this.lblStatut = new System.Windows.Forms.Label();
            this.lblDateOuverture = new System.Windows.Forms.Label();
            this.lblDateFermeture = new System.Windows.Forms.Label();
            this.lblDateDerniereMajValeur = new System.Windows.Forms.Label();
            this.lblDateDerniereMaj = new System.Windows.Forms.Label();
            this.lblStatutValeur = new System.Windows.Forms.Label();
            this.lblDateOuvertureValeur = new System.Windows.Forms.Label();
            this.lblDateFermetureValeur = new System.Windows.Forms.Label();
            this.lblDateInactiviteValeur = new System.Windows.Forms.Label();
            this.lblDateInactivite = new System.Windows.Forms.Label();
            this.btnOuvrirDossier = new System.Windows.Forms.Button();
            this.btnRendreInactif = new System.Windows.Forms.Button();
            this.btnFermerDossier = new System.Windows.Forms.Button();
            this.cbDateSpecOuverture = new System.Windows.Forms.CheckBox();
            this.dtpDateSpecOuverture = new System.Windows.Forms.DateTimePicker();
            this.dtpDateSpecInactivite = new System.Windows.Forms.DateTimePicker();
            this.cbDateSpecInactivite = new System.Windows.Forms.CheckBox();
            this.dtpDateSpecFermeture = new System.Windows.Forms.DateTimePicker();
            this.cbDateSpecFermeture = new System.Windows.Forms.CheckBox();
            this.gbPersonne = new System.Windows.Forms.GroupBox();
            this.lblNomValeur = new System.Windows.Forms.Label();
            this.lblPrenomValeur = new System.Windows.Forms.Label();
            this.btnChoisirPersonne = new System.Windows.Forms.Button();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gtPersonnesInactives = new CABS.Outils.GrilleTable();
            this.gbPersonne.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatut
            // 
            this.lblStatut.AutoSize = true;
            this.lblStatut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatut.Location = new System.Drawing.Point(12, 311);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(53, 17);
            this.lblStatut.TabIndex = 3;
            this.lblStatut.Text = "Statut :";
            // 
            // lblDateOuverture
            // 
            this.lblDateOuverture.AutoSize = true;
            this.lblDateOuverture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOuverture.Location = new System.Drawing.Point(12, 377);
            this.lblDateOuverture.Name = "lblDateOuverture";
            this.lblDateOuverture.Size = new System.Drawing.Size(111, 17);
            this.lblDateOuverture.TabIndex = 13;
            this.lblDateOuverture.Text = "Date ouverture :";
            // 
            // lblDateFermeture
            // 
            this.lblDateFermeture.AutoSize = true;
            this.lblDateFermeture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFermeture.Location = new System.Drawing.Point(12, 443);
            this.lblDateFermeture.Name = "lblDateFermeture";
            this.lblDateFermeture.Size = new System.Drawing.Size(111, 17);
            this.lblDateFermeture.TabIndex = 20;
            this.lblDateFermeture.Text = "Date fermeture :";
            // 
            // lblDateDerniereMajValeur
            // 
            this.lblDateDerniereMajValeur.BackColor = System.Drawing.Color.White;
            this.lblDateDerniereMajValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateDerniereMajValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateDerniereMajValeur.Location = new System.Drawing.Point(149, 341);
            this.lblDateDerniereMajValeur.Margin = new System.Windows.Forms.Padding(5);
            this.lblDateDerniereMajValeur.Name = "lblDateDerniereMajValeur";
            this.lblDateDerniereMajValeur.Size = new System.Drawing.Size(150, 23);
            this.lblDateDerniereMajValeur.TabIndex = 9;
            this.lblDateDerniereMajValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateDerniereMaj
            // 
            this.lblDateDerniereMaj.AutoSize = true;
            this.lblDateDerniereMaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateDerniereMaj.Location = new System.Drawing.Point(12, 344);
            this.lblDateDerniereMaj.Name = "lblDateDerniereMaj";
            this.lblDateDerniereMaj.Size = new System.Drawing.Size(129, 17);
            this.lblDateDerniereMaj.TabIndex = 8;
            this.lblDateDerniereMaj.Text = "Date dernière màj :";
            // 
            // lblStatutValeur
            // 
            this.lblStatutValeur.BackColor = System.Drawing.Color.White;
            this.lblStatutValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatutValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatutValeur.Location = new System.Drawing.Point(149, 308);
            this.lblStatutValeur.Margin = new System.Windows.Forms.Padding(5);
            this.lblStatutValeur.Name = "lblStatutValeur";
            this.lblStatutValeur.Size = new System.Drawing.Size(150, 23);
            this.lblStatutValeur.TabIndex = 4;
            this.lblStatutValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateOuvertureValeur
            // 
            this.lblDateOuvertureValeur.BackColor = System.Drawing.Color.White;
            this.lblDateOuvertureValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateOuvertureValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOuvertureValeur.Location = new System.Drawing.Point(149, 374);
            this.lblDateOuvertureValeur.Margin = new System.Windows.Forms.Padding(5);
            this.lblDateOuvertureValeur.Name = "lblDateOuvertureValeur";
            this.lblDateOuvertureValeur.Size = new System.Drawing.Size(150, 23);
            this.lblDateOuvertureValeur.TabIndex = 14;
            this.lblDateOuvertureValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateFermetureValeur
            // 
            this.lblDateFermetureValeur.BackColor = System.Drawing.Color.White;
            this.lblDateFermetureValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateFermetureValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFermetureValeur.Location = new System.Drawing.Point(149, 440);
            this.lblDateFermetureValeur.Margin = new System.Windows.Forms.Padding(5);
            this.lblDateFermetureValeur.Name = "lblDateFermetureValeur";
            this.lblDateFermetureValeur.Size = new System.Drawing.Size(150, 23);
            this.lblDateFermetureValeur.TabIndex = 21;
            this.lblDateFermetureValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateInactiviteValeur
            // 
            this.lblDateInactiviteValeur.BackColor = System.Drawing.Color.White;
            this.lblDateInactiviteValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateInactiviteValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateInactiviteValeur.Location = new System.Drawing.Point(149, 407);
            this.lblDateInactiviteValeur.Margin = new System.Windows.Forms.Padding(5);
            this.lblDateInactiviteValeur.Name = "lblDateInactiviteValeur";
            this.lblDateInactiviteValeur.Size = new System.Drawing.Size(150, 23);
            this.lblDateInactiviteValeur.TabIndex = 19;
            this.lblDateInactiviteValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateInactivite
            // 
            this.lblDateInactivite.AutoSize = true;
            this.lblDateInactivite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateInactivite.Location = new System.Drawing.Point(12, 410);
            this.lblDateInactivite.Name = "lblDateInactivite";
            this.lblDateInactivite.Size = new System.Drawing.Size(116, 17);
            this.lblDateInactivite.TabIndex = 18;
            this.lblDateInactivite.Text = "Date d\'inactivité :";
            // 
            // btnOuvrirDossier
            // 
            this.btnOuvrirDossier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOuvrirDossier.Location = new System.Drawing.Point(307, 308);
            this.btnOuvrirDossier.Name = "btnOuvrirDossier";
            this.btnOuvrirDossier.Size = new System.Drawing.Size(190, 30);
            this.btnOuvrirDossier.TabIndex = 5;
            this.btnOuvrirDossier.Text = "Ouvrir/Réouvrir le dossier";
            this.btnOuvrirDossier.UseVisualStyleBackColor = true;
            this.btnOuvrirDossier.Click += new System.EventHandler(this.btnOuvrirDossier_Click);
            // 
            // btnRendreInactif
            // 
            this.btnRendreInactif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRendreInactif.Location = new System.Drawing.Point(307, 344);
            this.btnRendreInactif.Name = "btnRendreInactif";
            this.btnRendreInactif.Size = new System.Drawing.Size(190, 30);
            this.btnRendreInactif.TabIndex = 10;
            this.btnRendreInactif.Text = "Rendre le dossier inactif";
            this.btnRendreInactif.UseVisualStyleBackColor = true;
            this.btnRendreInactif.Click += new System.EventHandler(this.btnRendreInactif_Click);
            // 
            // btnFermerDossier
            // 
            this.btnFermerDossier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFermerDossier.Location = new System.Drawing.Point(307, 380);
            this.btnFermerDossier.Name = "btnFermerDossier";
            this.btnFermerDossier.Size = new System.Drawing.Size(190, 30);
            this.btnFermerDossier.TabIndex = 15;
            this.btnFermerDossier.Text = "Fermer le dossier";
            this.btnFermerDossier.UseVisualStyleBackColor = true;
            this.btnFermerDossier.Click += new System.EventHandler(this.btnFermerDossier_Click);
            // 
            // cbDateSpecOuverture
            // 
            this.cbDateSpecOuverture.AutoSize = true;
            this.cbDateSpecOuverture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDateSpecOuverture.Location = new System.Drawing.Point(503, 314);
            this.cbDateSpecOuverture.Name = "cbDateSpecOuverture";
            this.cbDateSpecOuverture.Size = new System.Drawing.Size(101, 21);
            this.cbDateSpecOuverture.TabIndex = 6;
            this.cbDateSpecOuverture.Text = "Autre date :";
            this.cbDateSpecOuverture.UseVisualStyleBackColor = true;
            this.cbDateSpecOuverture.CheckedChanged += new System.EventHandler(this.cbDateSpecOuverture_CheckedChanged);
            // 
            // dtpDateSpecOuverture
            // 
            this.dtpDateSpecOuverture.Enabled = false;
            this.dtpDateSpecOuverture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateSpecOuverture.Location = new System.Drawing.Point(610, 314);
            this.dtpDateSpecOuverture.Name = "dtpDateSpecOuverture";
            this.dtpDateSpecOuverture.Size = new System.Drawing.Size(150, 23);
            this.dtpDateSpecOuverture.TabIndex = 7;
            // 
            // dtpDateSpecInactivite
            // 
            this.dtpDateSpecInactivite.Enabled = false;
            this.dtpDateSpecInactivite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateSpecInactivite.Location = new System.Drawing.Point(610, 350);
            this.dtpDateSpecInactivite.Name = "dtpDateSpecInactivite";
            this.dtpDateSpecInactivite.Size = new System.Drawing.Size(150, 23);
            this.dtpDateSpecInactivite.TabIndex = 12;
            // 
            // cbDateSpecInactivite
            // 
            this.cbDateSpecInactivite.AutoSize = true;
            this.cbDateSpecInactivite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDateSpecInactivite.Location = new System.Drawing.Point(503, 350);
            this.cbDateSpecInactivite.Name = "cbDateSpecInactivite";
            this.cbDateSpecInactivite.Size = new System.Drawing.Size(101, 21);
            this.cbDateSpecInactivite.TabIndex = 11;
            this.cbDateSpecInactivite.Text = "Autre date :";
            this.cbDateSpecInactivite.UseVisualStyleBackColor = true;
            this.cbDateSpecInactivite.CheckedChanged += new System.EventHandler(this.cbDateSpecInactivite_CheckedChanged);
            // 
            // dtpDateSpecFermeture
            // 
            this.dtpDateSpecFermeture.Enabled = false;
            this.dtpDateSpecFermeture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateSpecFermeture.Location = new System.Drawing.Point(610, 386);
            this.dtpDateSpecFermeture.Name = "dtpDateSpecFermeture";
            this.dtpDateSpecFermeture.Size = new System.Drawing.Size(150, 23);
            this.dtpDateSpecFermeture.TabIndex = 17;
            // 
            // cbDateSpecFermeture
            // 
            this.cbDateSpecFermeture.AutoSize = true;
            this.cbDateSpecFermeture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDateSpecFermeture.Location = new System.Drawing.Point(503, 386);
            this.cbDateSpecFermeture.Name = "cbDateSpecFermeture";
            this.cbDateSpecFermeture.Size = new System.Drawing.Size(101, 21);
            this.cbDateSpecFermeture.TabIndex = 16;
            this.cbDateSpecFermeture.Text = "Autre date :";
            this.cbDateSpecFermeture.UseVisualStyleBackColor = true;
            this.cbDateSpecFermeture.CheckedChanged += new System.EventHandler(this.cbDateSpecFermeture_CheckedChanged);
            // 
            // gbPersonne
            // 
            this.gbPersonne.Controls.Add(this.lblNomValeur);
            this.gbPersonne.Controls.Add(this.lblPrenomValeur);
            this.gbPersonne.Controls.Add(this.btnChoisirPersonne);
            this.gbPersonne.Controls.Add(this.lblNom);
            this.gbPersonne.Controls.Add(this.lblPrenom);
            this.gbPersonne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPersonne.Location = new System.Drawing.Point(12, 249);
            this.gbPersonne.Name = "gbPersonne";
            this.gbPersonne.Size = new System.Drawing.Size(748, 51);
            this.gbPersonne.TabIndex = 2;
            this.gbPersonne.TabStop = false;
            this.gbPersonne.Text = "Personne";
            // 
            // lblNomValeur
            // 
            this.lblNomValeur.BackColor = System.Drawing.Color.White;
            this.lblNomValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNomValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomValeur.Location = new System.Drawing.Point(420, 22);
            this.lblNomValeur.Margin = new System.Windows.Forms.Padding(3);
            this.lblNomValeur.Name = "lblNomValeur";
            this.lblNomValeur.Size = new System.Drawing.Size(286, 23);
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
            this.lblPrenomValeur.Size = new System.Drawing.Size(286, 23);
            this.lblPrenomValeur.TabIndex = 1;
            this.lblPrenomValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChoisirPersonne
            // 
            this.btnChoisirPersonne.Image = global::CABS.Properties.Resources._16px_Magnifying_glass_icon;
            this.btnChoisirPersonne.Location = new System.Drawing.Point(712, 18);
            this.btnChoisirPersonne.Name = "btnChoisirPersonne";
            this.btnChoisirPersonne.Size = new System.Drawing.Size(30, 30);
            this.btnChoisirPersonne.TabIndex = 4;
            this.btnChoisirPersonne.UseVisualStyleBackColor = true;
            this.btnChoisirPersonne.Click += new System.EventHandler(this.btnChoisirPersonne_Click);
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(369, 25);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Personnes susceptibles d\'être inactives :";
            // 
            // gtPersonnesInactives
            // 
            this.gtPersonnesInactives.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtPersonnesInactives.Location = new System.Drawing.Point(12, 29);
            this.gtPersonnesInactives.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gtPersonnesInactives.Name = "gtPersonnesInactives";
            this.gtPersonnesInactives.Size = new System.Drawing.Size(748, 214);
            this.gtPersonnesInactives.TabIndex = 1;
            this.gtPersonnesInactives.RowDoubleClick += new CABS.Outils.GrilleTable.RowDoubleClickEventHandler(this.gtPersonnesInactives_RowDoubleClick);
            // 
            // frmGestionDossiers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 607);
            this.Controls.Add(this.gtPersonnesInactives);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbPersonne);
            this.Controls.Add(this.dtpDateSpecFermeture);
            this.Controls.Add(this.cbDateSpecFermeture);
            this.Controls.Add(this.dtpDateSpecInactivite);
            this.Controls.Add(this.cbDateSpecInactivite);
            this.Controls.Add(this.dtpDateSpecOuverture);
            this.Controls.Add(this.cbDateSpecOuverture);
            this.Controls.Add(this.btnFermerDossier);
            this.Controls.Add(this.btnRendreInactif);
            this.Controls.Add(this.btnOuvrirDossier);
            this.Controls.Add(this.lblDateInactiviteValeur);
            this.Controls.Add(this.lblDateInactivite);
            this.Controls.Add(this.lblDateFermetureValeur);
            this.Controls.Add(this.lblDateOuvertureValeur);
            this.Controls.Add(this.lblStatutValeur);
            this.Controls.Add(this.lblDateDerniereMajValeur);
            this.Controls.Add(this.lblDateDerniereMaj);
            this.Controls.Add(this.lblDateFermeture);
            this.Controls.Add(this.lblDateOuverture);
            this.Controls.Add(this.lblStatut);
            this.Name = "frmGestionDossiers";
            this.Text = "frmGestionDossiers";
            this.gbPersonne.ResumeLayout(false);
            this.gbPersonne.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.Label lblDateOuverture;
        private System.Windows.Forms.Label lblDateFermeture;
        private System.Windows.Forms.Label lblDateDerniereMajValeur;
        private System.Windows.Forms.Label lblDateDerniereMaj;
        private System.Windows.Forms.Label lblStatutValeur;
        private System.Windows.Forms.Label lblDateOuvertureValeur;
        private System.Windows.Forms.Label lblDateFermetureValeur;
        private System.Windows.Forms.Label lblDateInactiviteValeur;
        private System.Windows.Forms.Label lblDateInactivite;
        private System.Windows.Forms.Button btnOuvrirDossier;
        private System.Windows.Forms.Button btnRendreInactif;
        private System.Windows.Forms.Button btnFermerDossier;
        private System.Windows.Forms.CheckBox cbDateSpecOuverture;
        private System.Windows.Forms.DateTimePicker dtpDateSpecOuverture;
        private System.Windows.Forms.DateTimePicker dtpDateSpecInactivite;
        private System.Windows.Forms.CheckBox cbDateSpecInactivite;
        private System.Windows.Forms.DateTimePicker dtpDateSpecFermeture;
        private System.Windows.Forms.CheckBox cbDateSpecFermeture;
        private System.Windows.Forms.GroupBox gbPersonne;
        private System.Windows.Forms.Label lblNomValeur;
        private System.Windows.Forms.Label lblPrenomValeur;
        private System.Windows.Forms.Button btnChoisirPersonne;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label label1;
        private Outils.GrilleTable gtPersonnesInactives;
    }
}