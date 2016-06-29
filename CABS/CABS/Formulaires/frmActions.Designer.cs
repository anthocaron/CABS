namespace CABS.Formulaires
{
    partial class frmActions
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
            this.gtBeneficiaires = new CABS.Outils.GrilleTable();
            this.gtBenevoles = new CABS.Outils.GrilleTable();
            this.lbBeneficiairesInclus = new System.Windows.Forms.ListBox();
            this.lbBenevolesInclus = new System.Windows.Forms.ListBox();
            this.cmbChamp = new System.Windows.Forms.ComboBox();
            this.cmbSousChamp = new System.Windows.Forms.ComboBox();
            this.cmbActivite = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.nudNombreHeures = new System.Windows.Forms.NumericUpDown();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.lblChamp = new System.Windows.Forms.Label();
            this.lblSousChamp = new System.Windows.Forms.Label();
            this.lblActivite = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNombreHeures = new System.Windows.Forms.Label();
            this.lblBeneficiaires = new System.Windows.Forms.Label();
            this.lblBenevoles = new System.Windows.Forms.Label();
            this.lblBeneficiairesInclus = new System.Windows.Forms.Label();
            this.lblBenevolesInclus = new System.Windows.Forms.Label();
            this.btnRetirerBeneficiaire = new System.Windows.Forms.Button();
            this.btnRetirerBenevole = new System.Windows.Forms.Button();
            this.btnAjouterAction = new System.Windows.Forms.Button();
            this.btnModifierAction = new System.Windows.Forms.Button();
            this.btnSupprimerAction = new System.Windows.Forms.Button();
            this.btnConfirmerAction = new System.Windows.Forms.Button();
            this.btnAnnulerAction = new System.Windows.Forms.Button();
            this.nudBenevolesNonInscrits = new System.Windows.Forms.NumericUpDown();
            this.lblBenevolesNonInscrits = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudNombreHeures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBenevolesNonInscrits)).BeginInit();
            this.SuspendLayout();
            // 
            // gtBeneficiaires
            // 
            this.gtBeneficiaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtBeneficiaires.Location = new System.Drawing.Point(425, 208);
            this.gtBeneficiaires.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gtBeneficiaires.Name = "gtBeneficiaires";
            this.gtBeneficiaires.Size = new System.Drawing.Size(404, 300);
            this.gtBeneficiaires.TabIndex = 18;
            this.gtBeneficiaires.RowDoubleClick += new CABS.Outils.GrilleTable.RowDoubleClickEventHandler(this.gtBeneficiaires_RowDoubleClick);
            // 
            // gtBenevoles
            // 
            this.gtBenevoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtBenevoles.Location = new System.Drawing.Point(13, 208);
            this.gtBenevoles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gtBenevoles.Name = "gtBenevoles";
            this.gtBenevoles.Size = new System.Drawing.Size(404, 300);
            this.gtBenevoles.TabIndex = 16;
            this.gtBenevoles.RowDoubleClick += new CABS.Outils.GrilleTable.RowDoubleClickEventHandler(this.gtBenevoles_RowDoubleClick);
            // 
            // lbBeneficiairesInclus
            // 
            this.lbBeneficiairesInclus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBeneficiairesInclus.FormattingEnabled = true;
            this.lbBeneficiairesInclus.ItemHeight = 16;
            this.lbBeneficiairesInclus.Location = new System.Drawing.Point(425, 561);
            this.lbBeneficiairesInclus.Name = "lbBeneficiairesInclus";
            this.lbBeneficiairesInclus.Size = new System.Drawing.Size(404, 196);
            this.lbBeneficiairesInclus.TabIndex = 25;
            this.lbBeneficiairesInclus.SelectedIndexChanged += new System.EventHandler(this.lbBeneficiairesInclus_SelectedIndexChanged);
            // 
            // lbBenevolesInclus
            // 
            this.lbBenevolesInclus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBenevolesInclus.FormattingEnabled = true;
            this.lbBenevolesInclus.ItemHeight = 16;
            this.lbBenevolesInclus.Location = new System.Drawing.Point(13, 561);
            this.lbBenevolesInclus.Name = "lbBenevolesInclus";
            this.lbBenevolesInclus.Size = new System.Drawing.Size(406, 196);
            this.lbBenevolesInclus.TabIndex = 22;
            this.lbBenevolesInclus.SelectedIndexChanged += new System.EventHandler(this.lbBenevolesInclus_SelectedIndexChanged);
            // 
            // cmbChamp
            // 
            this.cmbChamp.DropDownHeight = 200;
            this.cmbChamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChamp.FormattingEnabled = true;
            this.cmbChamp.IntegralHeight = false;
            this.cmbChamp.Location = new System.Drawing.Point(179, 12);
            this.cmbChamp.Name = "cmbChamp";
            this.cmbChamp.Size = new System.Drawing.Size(800, 24);
            this.cmbChamp.TabIndex = 1;
            this.cmbChamp.SelectedIndexChanged += new System.EventHandler(this.cmbChamp_SelectedIndexChanged);
            // 
            // cmbSousChamp
            // 
            this.cmbSousChamp.DropDownHeight = 200;
            this.cmbSousChamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSousChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSousChamp.FormattingEnabled = true;
            this.cmbSousChamp.IntegralHeight = false;
            this.cmbSousChamp.Location = new System.Drawing.Point(179, 42);
            this.cmbSousChamp.Name = "cmbSousChamp";
            this.cmbSousChamp.Size = new System.Drawing.Size(800, 24);
            this.cmbSousChamp.TabIndex = 3;
            this.cmbSousChamp.SelectedIndexChanged += new System.EventHandler(this.cmbSousChamp_SelectedIndexChanged);
            // 
            // cmbActivite
            // 
            this.cmbActivite.DropDownHeight = 200;
            this.cmbActivite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbActivite.FormattingEnabled = true;
            this.cmbActivite.IntegralHeight = false;
            this.cmbActivite.Location = new System.Drawing.Point(179, 72);
            this.cmbActivite.Name = "cmbActivite";
            this.cmbActivite.Size = new System.Drawing.Size(800, 24);
            this.cmbActivite.TabIndex = 5;
            this.cmbActivite.SelectedIndexChanged += new System.EventHandler(this.cmbActivite_SelectedIndexChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(179, 132);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDate.TabIndex = 9;
            // 
            // nudNombreHeures
            // 
            this.nudNombreHeures.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNombreHeures.Location = new System.Drawing.Point(141, 515);
            this.nudNombreHeures.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.nudNombreHeures.Name = "nudNombreHeures";
            this.nudNombreHeures.Size = new System.Drawing.Size(39, 23);
            this.nudNombreHeures.TabIndex = 20;
            // 
            // cmbAction
            // 
            this.cmbAction.DropDownHeight = 200;
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.DropDownWidth = 1000;
            this.cmbAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.IntegralHeight = false;
            this.cmbAction.Location = new System.Drawing.Point(179, 102);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(200, 24);
            this.cmbAction.TabIndex = 7;
            this.cmbAction.SelectedIndexChanged += new System.EventHandler(this.cmbAction_SelectedIndexChanged);
            // 
            // lblChamp
            // 
            this.lblChamp.AutoSize = true;
            this.lblChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChamp.Location = new System.Drawing.Point(12, 15);
            this.lblChamp.Name = "lblChamp";
            this.lblChamp.Size = new System.Drawing.Size(126, 17);
            this.lblChamp.TabIndex = 0;
            this.lblChamp.Text = "Champ d\'activités :";
            // 
            // lblSousChamp
            // 
            this.lblSousChamp.AutoSize = true;
            this.lblSousChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSousChamp.Location = new System.Drawing.Point(12, 45);
            this.lblSousChamp.Name = "lblSousChamp";
            this.lblSousChamp.Size = new System.Drawing.Size(161, 17);
            this.lblSousChamp.TabIndex = 2;
            this.lblSousChamp.Text = "Sous-champ d\'activités :";
            // 
            // lblActivite
            // 
            this.lblActivite.AutoSize = true;
            this.lblActivite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivite.Location = new System.Drawing.Point(12, 75);
            this.lblActivite.Name = "lblActivite";
            this.lblActivite.Size = new System.Drawing.Size(61, 17);
            this.lblActivite.TabIndex = 4;
            this.lblActivite.Text = "Activité :";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.Location = new System.Drawing.Point(12, 105);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(55, 17);
            this.lblAction.TabIndex = 6;
            this.lblAction.Text = "Action :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(123, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Date : ";
            // 
            // lblNombreHeures
            // 
            this.lblNombreHeures.AutoSize = true;
            this.lblNombreHeures.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreHeures.Location = new System.Drawing.Point(10, 517);
            this.lblNombreHeures.Name = "lblNombreHeures";
            this.lblNombreHeures.Size = new System.Drawing.Size(125, 17);
            this.lblNombreHeures.TabIndex = 19;
            this.lblNombreHeures.Text = "Nombre d\'heures :";
            // 
            // lblBeneficiaires
            // 
            this.lblBeneficiaires.AutoSize = true;
            this.lblBeneficiaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiaires.Location = new System.Drawing.Point(422, 187);
            this.lblBeneficiaires.Name = "lblBeneficiaires";
            this.lblBeneficiaires.Size = new System.Drawing.Size(97, 17);
            this.lblBeneficiaires.TabIndex = 17;
            this.lblBeneficiaires.Text = "Bénéficiaires :";
            // 
            // lblBenevoles
            // 
            this.lblBenevoles.AutoSize = true;
            this.lblBenevoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBenevoles.Location = new System.Drawing.Point(10, 187);
            this.lblBenevoles.Name = "lblBenevoles";
            this.lblBenevoles.Size = new System.Drawing.Size(82, 17);
            this.lblBenevoles.TabIndex = 15;
            this.lblBenevoles.Text = "Bénévoles :";
            // 
            // lblBeneficiairesInclus
            // 
            this.lblBeneficiairesInclus.AutoSize = true;
            this.lblBeneficiairesInclus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiairesInclus.Location = new System.Drawing.Point(422, 541);
            this.lblBeneficiairesInclus.Name = "lblBeneficiairesInclus";
            this.lblBeneficiairesInclus.Size = new System.Drawing.Size(137, 17);
            this.lblBeneficiairesInclus.TabIndex = 24;
            this.lblBeneficiairesInclus.Text = "Bénéficiaires inclus :";
            // 
            // lblBenevolesInclus
            // 
            this.lblBenevolesInclus.AutoSize = true;
            this.lblBenevolesInclus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBenevolesInclus.Location = new System.Drawing.Point(10, 541);
            this.lblBenevolesInclus.Name = "lblBenevolesInclus";
            this.lblBenevolesInclus.Size = new System.Drawing.Size(122, 17);
            this.lblBenevolesInclus.TabIndex = 21;
            this.lblBenevolesInclus.Text = "Bénévoles inclus :";
            // 
            // btnRetirerBeneficiaire
            // 
            this.btnRetirerBeneficiaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirerBeneficiaire.Location = new System.Drawing.Point(425, 763);
            this.btnRetirerBeneficiaire.Name = "btnRetirerBeneficiaire";
            this.btnRetirerBeneficiaire.Size = new System.Drawing.Size(404, 30);
            this.btnRetirerBeneficiaire.TabIndex = 26;
            this.btnRetirerBeneficiaire.Text = "Retirer le bénéficiaire";
            this.btnRetirerBeneficiaire.UseVisualStyleBackColor = true;
            this.btnRetirerBeneficiaire.Click += new System.EventHandler(this.btnRetirerBeneficiaire_Click);
            // 
            // btnRetirerBenevole
            // 
            this.btnRetirerBenevole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirerBenevole.Location = new System.Drawing.Point(13, 763);
            this.btnRetirerBenevole.Name = "btnRetirerBenevole";
            this.btnRetirerBenevole.Size = new System.Drawing.Size(406, 30);
            this.btnRetirerBenevole.TabIndex = 23;
            this.btnRetirerBenevole.Text = "Retirer le bénévole";
            this.btnRetirerBenevole.UseVisualStyleBackColor = true;
            this.btnRetirerBenevole.Click += new System.EventHandler(this.btnRetirerBenevole_Click);
            // 
            // btnAjouterAction
            // 
            this.btnAjouterAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouterAction.Location = new System.Drawing.Point(385, 102);
            this.btnAjouterAction.Name = "btnAjouterAction";
            this.btnAjouterAction.Size = new System.Drawing.Size(150, 30);
            this.btnAjouterAction.TabIndex = 10;
            this.btnAjouterAction.Text = "Ajouter une action";
            this.btnAjouterAction.UseVisualStyleBackColor = true;
            this.btnAjouterAction.Click += new System.EventHandler(this.btnAjouterAction_Click);
            // 
            // btnModifierAction
            // 
            this.btnModifierAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifierAction.Location = new System.Drawing.Point(541, 102);
            this.btnModifierAction.Name = "btnModifierAction";
            this.btnModifierAction.Size = new System.Drawing.Size(150, 30);
            this.btnModifierAction.TabIndex = 11;
            this.btnModifierAction.Text = "Modifier l\'action";
            this.btnModifierAction.UseVisualStyleBackColor = true;
            this.btnModifierAction.Click += new System.EventHandler(this.btnModifierAction_Click);
            // 
            // btnSupprimerAction
            // 
            this.btnSupprimerAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerAction.Location = new System.Drawing.Point(697, 102);
            this.btnSupprimerAction.Name = "btnSupprimerAction";
            this.btnSupprimerAction.Size = new System.Drawing.Size(150, 30);
            this.btnSupprimerAction.TabIndex = 12;
            this.btnSupprimerAction.Text = "Supprimer l\'action";
            this.btnSupprimerAction.UseVisualStyleBackColor = true;
            this.btnSupprimerAction.Click += new System.EventHandler(this.btnSupprimerAction_Click);
            // 
            // btnConfirmerAction
            // 
            this.btnConfirmerAction.Enabled = false;
            this.btnConfirmerAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmerAction.Location = new System.Drawing.Point(385, 138);
            this.btnConfirmerAction.Name = "btnConfirmerAction";
            this.btnConfirmerAction.Size = new System.Drawing.Size(228, 30);
            this.btnConfirmerAction.TabIndex = 13;
            this.btnConfirmerAction.Text = "Confirmer";
            this.btnConfirmerAction.UseVisualStyleBackColor = true;
            this.btnConfirmerAction.Click += new System.EventHandler(this.btnConfirmerAction_Click);
            // 
            // btnAnnulerAction
            // 
            this.btnAnnulerAction.Enabled = false;
            this.btnAnnulerAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnulerAction.Location = new System.Drawing.Point(619, 138);
            this.btnAnnulerAction.Name = "btnAnnulerAction";
            this.btnAnnulerAction.Size = new System.Drawing.Size(228, 30);
            this.btnAnnulerAction.TabIndex = 14;
            this.btnAnnulerAction.Text = "Annuler";
            this.btnAnnulerAction.UseVisualStyleBackColor = true;
            this.btnAnnulerAction.Click += new System.EventHandler(this.btnAnnulerAction_Click);
            // 
            // nudBenevolesNonInscrits
            // 
            this.nudBenevolesNonInscrits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBenevolesNonInscrits.Location = new System.Drawing.Point(288, 161);
            this.nudBenevolesNonInscrits.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nudBenevolesNonInscrits.Name = "nudBenevolesNonInscrits";
            this.nudBenevolesNonInscrits.Size = new System.Drawing.Size(91, 23);
            this.nudBenevolesNonInscrits.TabIndex = 27;
            // 
            // lblBenevolesNonInscrits
            // 
            this.lblBenevolesNonInscrits.AutoSize = true;
            this.lblBenevolesNonInscrits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBenevolesNonInscrits.Location = new System.Drawing.Point(123, 163);
            this.lblBenevolesNonInscrits.Name = "lblBenevolesNonInscrits";
            this.lblBenevolesNonInscrits.Size = new System.Drawing.Size(159, 17);
            this.lblBenevolesNonInscrits.TabIndex = 28;
            this.lblBenevolesNonInscrits.Text = "Bénévoles non-inscrits :";
            // 
            // frmActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 826);
            this.Controls.Add(this.lblBenevolesNonInscrits);
            this.Controls.Add(this.nudBenevolesNonInscrits);
            this.Controls.Add(this.btnAnnulerAction);
            this.Controls.Add(this.btnConfirmerAction);
            this.Controls.Add(this.btnSupprimerAction);
            this.Controls.Add(this.btnModifierAction);
            this.Controls.Add(this.btnAjouterAction);
            this.Controls.Add(this.btnRetirerBenevole);
            this.Controls.Add(this.btnRetirerBeneficiaire);
            this.Controls.Add(this.lblBenevolesInclus);
            this.Controls.Add(this.lblBeneficiairesInclus);
            this.Controls.Add(this.lblBenevoles);
            this.Controls.Add(this.lblBeneficiaires);
            this.Controls.Add(this.lblNombreHeures);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.lblActivite);
            this.Controls.Add(this.lblSousChamp);
            this.Controls.Add(this.lblChamp);
            this.Controls.Add(this.cmbAction);
            this.Controls.Add(this.nudNombreHeures);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbActivite);
            this.Controls.Add(this.cmbSousChamp);
            this.Controls.Add(this.cmbChamp);
            this.Controls.Add(this.lbBenevolesInclus);
            this.Controls.Add(this.lbBeneficiairesInclus);
            this.Controls.Add(this.gtBenevoles);
            this.Controls.Add(this.gtBeneficiaires);
            this.Name = "frmActions";
            this.Text = "frmActions";
            ((System.ComponentModel.ISupportInitialize)(this.nudNombreHeures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBenevolesNonInscrits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Outils.GrilleTable gtBeneficiaires;
        private Outils.GrilleTable gtBenevoles;
        private System.Windows.Forms.ListBox lbBeneficiairesInclus;
        private System.Windows.Forms.ListBox lbBenevolesInclus;
        private System.Windows.Forms.ComboBox cmbChamp;
        private System.Windows.Forms.ComboBox cmbSousChamp;
        private System.Windows.Forms.ComboBox cmbActivite;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.NumericUpDown nudNombreHeures;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.Label lblChamp;
        private System.Windows.Forms.Label lblSousChamp;
        private System.Windows.Forms.Label lblActivite;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNombreHeures;
        private System.Windows.Forms.Label lblBeneficiaires;
        private System.Windows.Forms.Label lblBenevoles;
        private System.Windows.Forms.Label lblBeneficiairesInclus;
        private System.Windows.Forms.Label lblBenevolesInclus;
        private System.Windows.Forms.Button btnRetirerBeneficiaire;
        private System.Windows.Forms.Button btnRetirerBenevole;
        private System.Windows.Forms.Button btnAjouterAction;
        private System.Windows.Forms.Button btnModifierAction;
        private System.Windows.Forms.Button btnSupprimerAction;
        private System.Windows.Forms.Button btnConfirmerAction;
        private System.Windows.Forms.Button btnAnnulerAction;
        private System.Windows.Forms.NumericUpDown nudBenevolesNonInscrits;
        private System.Windows.Forms.Label lblBenevolesNonInscrits;
    }
}