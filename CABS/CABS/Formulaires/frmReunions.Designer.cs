namespace CABS.Formulaires
{
    partial class frmReunions
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
            this.btnAnnulerReunion = new System.Windows.Forms.Button();
            this.btnConfirmerReunion = new System.Windows.Forms.Button();
            this.btnSupprimerReunion = new System.Windows.Forms.Button();
            this.btnModifierReunion = new System.Windows.Forms.Button();
            this.btnAjouterReunion = new System.Windows.Forms.Button();
            this.btnRetirerBenevole = new System.Windows.Forms.Button();
            this.btnRetirerEmploye = new System.Windows.Forms.Button();
            this.lblBenevolesInclus = new System.Windows.Forms.Label();
            this.lblEmployesInclus = new System.Windows.Forms.Label();
            this.lblBenevoles = new System.Windows.Forms.Label();
            this.lblEmployes = new System.Windows.Forms.Label();
            this.lblNombreHeuresBenevole = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReunion = new System.Windows.Forms.Label();
            this.lblActivite = new System.Windows.Forms.Label();
            this.lblSousChamp = new System.Windows.Forms.Label();
            this.lblChamp = new System.Windows.Forms.Label();
            this.cmbReunion = new System.Windows.Forms.ComboBox();
            this.nudNombreHeuresBenevole = new System.Windows.Forms.NumericUpDown();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbActivite = new System.Windows.Forms.ComboBox();
            this.cmbSousChamp = new System.Windows.Forms.ComboBox();
            this.cmbChamp = new System.Windows.Forms.ComboBox();
            this.lbBenevolesInclus = new System.Windows.Forms.ListBox();
            this.lbEmployesInclus = new System.Windows.Forms.ListBox();
            this.gtBenevoles = new CABS.Outils.GrilleTable();
            this.gtEmployes = new CABS.Outils.GrilleTable();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblNombreHeuresEmploye = new System.Windows.Forms.Label();
            this.nudNombreHeuresEmploye = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudNombreHeuresBenevole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNombreHeuresEmploye)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnnulerReunion
            // 
            this.btnAnnulerReunion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnulerReunion.Location = new System.Drawing.Point(751, 138);
            this.btnAnnulerReunion.Name = "btnAnnulerReunion";
            this.btnAnnulerReunion.Size = new System.Drawing.Size(228, 30);
            this.btnAnnulerReunion.TabIndex = 16;
            this.btnAnnulerReunion.Text = "Annuler";
            this.btnAnnulerReunion.UseVisualStyleBackColor = true;
            this.btnAnnulerReunion.Click += new System.EventHandler(this.btnAnnulerReunion_Click);
            // 
            // btnConfirmerReunion
            // 
            this.btnConfirmerReunion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmerReunion.Location = new System.Drawing.Point(517, 138);
            this.btnConfirmerReunion.Name = "btnConfirmerReunion";
            this.btnConfirmerReunion.Size = new System.Drawing.Size(228, 30);
            this.btnConfirmerReunion.TabIndex = 15;
            this.btnConfirmerReunion.Text = "Confirmer";
            this.btnConfirmerReunion.UseVisualStyleBackColor = true;
            this.btnConfirmerReunion.Click += new System.EventHandler(this.btnConfirmerReunion_Click);
            // 
            // btnSupprimerReunion
            // 
            this.btnSupprimerReunion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerReunion.Location = new System.Drawing.Point(829, 102);
            this.btnSupprimerReunion.Name = "btnSupprimerReunion";
            this.btnSupprimerReunion.Size = new System.Drawing.Size(150, 30);
            this.btnSupprimerReunion.TabIndex = 14;
            this.btnSupprimerReunion.Text = "Supprimer la réunion";
            this.btnSupprimerReunion.UseVisualStyleBackColor = true;
            this.btnSupprimerReunion.Click += new System.EventHandler(this.btnSupprimerReunion_Click);
            // 
            // btnModifierReunion
            // 
            this.btnModifierReunion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifierReunion.Location = new System.Drawing.Point(673, 102);
            this.btnModifierReunion.Name = "btnModifierReunion";
            this.btnModifierReunion.Size = new System.Drawing.Size(150, 30);
            this.btnModifierReunion.TabIndex = 13;
            this.btnModifierReunion.Text = "Modifier la réunion";
            this.btnModifierReunion.UseVisualStyleBackColor = true;
            this.btnModifierReunion.Click += new System.EventHandler(this.btnModifierReunion_Click);
            // 
            // btnAjouterReunion
            // 
            this.btnAjouterReunion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouterReunion.Location = new System.Drawing.Point(517, 102);
            this.btnAjouterReunion.Name = "btnAjouterReunion";
            this.btnAjouterReunion.Size = new System.Drawing.Size(150, 30);
            this.btnAjouterReunion.TabIndex = 12;
            this.btnAjouterReunion.Text = "Ajouter une réunion";
            this.btnAjouterReunion.UseVisualStyleBackColor = true;
            this.btnAjouterReunion.Click += new System.EventHandler(this.btnAjouterReunion_Click);
            // 
            // btnRetirerBenevole
            // 
            this.btnRetirerBenevole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirerBenevole.Location = new System.Drawing.Point(15, 731);
            this.btnRetirerBenevole.Name = "btnRetirerBenevole";
            this.btnRetirerBenevole.Size = new System.Drawing.Size(473, 30);
            this.btnRetirerBenevole.TabIndex = 25;
            this.btnRetirerBenevole.Text = "Retirer le bénévole";
            this.btnRetirerBenevole.UseVisualStyleBackColor = true;
            this.btnRetirerBenevole.Click += new System.EventHandler(this.btnRetirerBenevole_Click);
            // 
            // btnRetirerEmploye
            // 
            this.btnRetirerEmploye.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirerEmploye.Location = new System.Drawing.Point(496, 731);
            this.btnRetirerEmploye.Name = "btnRetirerEmploye";
            this.btnRetirerEmploye.Size = new System.Drawing.Size(505, 30);
            this.btnRetirerEmploye.TabIndex = 30;
            this.btnRetirerEmploye.Text = "Retirer l\'employé";
            this.btnRetirerEmploye.UseVisualStyleBackColor = true;
            this.btnRetirerEmploye.Click += new System.EventHandler(this.btnRetirerEmploye_Click);
            // 
            // lblBenevolesInclus
            // 
            this.lblBenevolesInclus.AutoSize = true;
            this.lblBenevolesInclus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBenevolesInclus.Location = new System.Drawing.Point(12, 541);
            this.lblBenevolesInclus.Name = "lblBenevolesInclus";
            this.lblBenevolesInclus.Size = new System.Drawing.Size(122, 17);
            this.lblBenevolesInclus.TabIndex = 23;
            this.lblBenevolesInclus.Text = "Bénévoles inclus :";
            // 
            // lblEmployesInclus
            // 
            this.lblEmployesInclus.AutoSize = true;
            this.lblEmployesInclus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployesInclus.Location = new System.Drawing.Point(493, 541);
            this.lblEmployesInclus.Name = "lblEmployesInclus";
            this.lblEmployesInclus.Size = new System.Drawing.Size(117, 17);
            this.lblEmployesInclus.TabIndex = 28;
            this.lblEmployesInclus.Text = "Employés inclus :";
            // 
            // lblBenevoles
            // 
            this.lblBenevoles.AutoSize = true;
            this.lblBenevoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBenevoles.Location = new System.Drawing.Point(12, 187);
            this.lblBenevoles.Name = "lblBenevoles";
            this.lblBenevoles.Size = new System.Drawing.Size(82, 17);
            this.lblBenevoles.TabIndex = 17;
            this.lblBenevoles.Text = "Bénévoles :";
            // 
            // lblEmployes
            // 
            this.lblEmployes.AutoSize = true;
            this.lblEmployes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployes.Location = new System.Drawing.Point(493, 187);
            this.lblEmployes.Name = "lblEmployes";
            this.lblEmployes.Size = new System.Drawing.Size(77, 17);
            this.lblEmployes.TabIndex = 19;
            this.lblEmployes.Text = "Employés :";
            // 
            // lblNombreHeuresBenevole
            // 
            this.lblNombreHeuresBenevole.AutoSize = true;
            this.lblNombreHeuresBenevole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreHeuresBenevole.Location = new System.Drawing.Point(12, 517);
            this.lblNombreHeuresBenevole.Name = "lblNombreHeuresBenevole";
            this.lblNombreHeuresBenevole.Size = new System.Drawing.Size(125, 17);
            this.lblNombreHeuresBenevole.TabIndex = 21;
            this.lblNombreHeuresBenevole.Text = "Nombre d\'heures :";
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
            // lblReunion
            // 
            this.lblReunion.AutoSize = true;
            this.lblReunion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReunion.Location = new System.Drawing.Point(12, 105);
            this.lblReunion.Name = "lblReunion";
            this.lblReunion.Size = new System.Drawing.Size(69, 17);
            this.lblReunion.TabIndex = 6;
            this.lblReunion.Text = "Réunion :";
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
            // cmbReunion
            // 
            this.cmbReunion.DropDownHeight = 200;
            this.cmbReunion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReunion.DropDownWidth = 1000;
            this.cmbReunion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReunion.FormattingEnabled = true;
            this.cmbReunion.IntegralHeight = false;
            this.cmbReunion.Location = new System.Drawing.Point(179, 102);
            this.cmbReunion.Name = "cmbReunion";
            this.cmbReunion.Size = new System.Drawing.Size(332, 24);
            this.cmbReunion.TabIndex = 7;
            this.cmbReunion.SelectedIndexChanged += new System.EventHandler(this.cmbReunion_SelectedIndexChanged);
            // 
            // nudNombreHeuresBenevole
            // 
            this.nudNombreHeuresBenevole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNombreHeuresBenevole.Location = new System.Drawing.Point(143, 515);
            this.nudNombreHeuresBenevole.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.nudNombreHeuresBenevole.Name = "nudNombreHeuresBenevole";
            this.nudNombreHeuresBenevole.Size = new System.Drawing.Size(39, 23);
            this.nudNombreHeuresBenevole.TabIndex = 22;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(179, 132);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDate.TabIndex = 9;
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
            // lbBenevolesInclus
            // 
            this.lbBenevolesInclus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBenevolesInclus.FormattingEnabled = true;
            this.lbBenevolesInclus.ItemHeight = 16;
            this.lbBenevolesInclus.Location = new System.Drawing.Point(15, 561);
            this.lbBenevolesInclus.Name = "lbBenevolesInclus";
            this.lbBenevolesInclus.Size = new System.Drawing.Size(473, 164);
            this.lbBenevolesInclus.TabIndex = 24;
            this.lbBenevolesInclus.SelectedIndexChanged += new System.EventHandler(this.lbBenevolesInclus_SelectedIndexChanged);
            // 
            // lbEmployesInclus
            // 
            this.lbEmployesInclus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmployesInclus.FormattingEnabled = true;
            this.lbEmployesInclus.ItemHeight = 16;
            this.lbEmployesInclus.Location = new System.Drawing.Point(496, 561);
            this.lbEmployesInclus.Name = "lbEmployesInclus";
            this.lbEmployesInclus.Size = new System.Drawing.Size(505, 164);
            this.lbEmployesInclus.TabIndex = 29;
            this.lbEmployesInclus.SelectedIndexChanged += new System.EventHandler(this.lbEmployesInclus_SelectedIndexChanged);
            // 
            // gtBenevoles
            // 
            this.gtBenevoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtBenevoles.Location = new System.Drawing.Point(15, 208);
            this.gtBenevoles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gtBenevoles.Name = "gtBenevoles";
            this.gtBenevoles.Size = new System.Drawing.Size(473, 300);
            this.gtBenevoles.TabIndex = 18;
            this.gtBenevoles.RowDoubleClick += new CABS.Outils.GrilleTable.RowDoubleClickEventHandler(this.gtBenevoles_RowDoubleClick);
            // 
            // gtEmployes
            // 
            this.gtEmployes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtEmployes.Location = new System.Drawing.Point(496, 208);
            this.gtEmployes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gtEmployes.Name = "gtEmployes";
            this.gtEmployes.Size = new System.Drawing.Size(505, 300);
            this.gtEmployes.TabIndex = 20;
            this.gtEmployes.RowDoubleClick += new CABS.Outils.GrilleTable.RowDoubleClickEventHandler(this.gtEmployes_RowDoubleClick);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(86, 164);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(87, 17);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Description :";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(179, 161);
            this.txtDescription.MaxLength = 256;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(332, 23);
            this.txtDescription.TabIndex = 11;
            // 
            // lblNombreHeuresEmploye
            // 
            this.lblNombreHeuresEmploye.AutoSize = true;
            this.lblNombreHeuresEmploye.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreHeuresEmploye.Location = new System.Drawing.Point(493, 517);
            this.lblNombreHeuresEmploye.Name = "lblNombreHeuresEmploye";
            this.lblNombreHeuresEmploye.Size = new System.Drawing.Size(125, 17);
            this.lblNombreHeuresEmploye.TabIndex = 26;
            this.lblNombreHeuresEmploye.Text = "Nombre d\'heures :";
            // 
            // nudNombreHeuresEmploye
            // 
            this.nudNombreHeuresEmploye.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNombreHeuresEmploye.Location = new System.Drawing.Point(624, 515);
            this.nudNombreHeuresEmploye.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.nudNombreHeuresEmploye.Name = "nudNombreHeuresEmploye";
            this.nudNombreHeuresEmploye.Size = new System.Drawing.Size(39, 23);
            this.nudNombreHeuresEmploye.TabIndex = 27;
            // 
            // frmReunions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 788);
            this.Controls.Add(this.lblNombreHeuresEmploye);
            this.Controls.Add(this.nudNombreHeuresEmploye);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnAnnulerReunion);
            this.Controls.Add(this.btnConfirmerReunion);
            this.Controls.Add(this.btnSupprimerReunion);
            this.Controls.Add(this.btnModifierReunion);
            this.Controls.Add(this.btnAjouterReunion);
            this.Controls.Add(this.btnRetirerBenevole);
            this.Controls.Add(this.btnRetirerEmploye);
            this.Controls.Add(this.lblBenevolesInclus);
            this.Controls.Add(this.lblEmployesInclus);
            this.Controls.Add(this.lblBenevoles);
            this.Controls.Add(this.lblEmployes);
            this.Controls.Add(this.lblNombreHeuresBenevole);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblReunion);
            this.Controls.Add(this.lblActivite);
            this.Controls.Add(this.lblSousChamp);
            this.Controls.Add(this.lblChamp);
            this.Controls.Add(this.cmbReunion);
            this.Controls.Add(this.nudNombreHeuresBenevole);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbActivite);
            this.Controls.Add(this.cmbSousChamp);
            this.Controls.Add(this.cmbChamp);
            this.Controls.Add(this.lbBenevolesInclus);
            this.Controls.Add(this.lbEmployesInclus);
            this.Controls.Add(this.gtBenevoles);
            this.Controls.Add(this.gtEmployes);
            this.Name = "frmReunions";
            this.Text = "frmReunions";
            ((System.ComponentModel.ISupportInitialize)(this.nudNombreHeuresBenevole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNombreHeuresEmploye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnnulerReunion;
        private System.Windows.Forms.Button btnConfirmerReunion;
        private System.Windows.Forms.Button btnSupprimerReunion;
        private System.Windows.Forms.Button btnModifierReunion;
        private System.Windows.Forms.Button btnAjouterReunion;
        private System.Windows.Forms.Button btnRetirerBenevole;
        private System.Windows.Forms.Button btnRetirerEmploye;
        private System.Windows.Forms.Label lblBenevolesInclus;
        private System.Windows.Forms.Label lblEmployesInclus;
        private System.Windows.Forms.Label lblBenevoles;
        private System.Windows.Forms.Label lblEmployes;
        private System.Windows.Forms.Label lblNombreHeuresBenevole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReunion;
        private System.Windows.Forms.Label lblActivite;
        private System.Windows.Forms.Label lblSousChamp;
        private System.Windows.Forms.Label lblChamp;
        private System.Windows.Forms.ComboBox cmbReunion;
        private System.Windows.Forms.NumericUpDown nudNombreHeuresBenevole;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbActivite;
        private System.Windows.Forms.ComboBox cmbSousChamp;
        private System.Windows.Forms.ComboBox cmbChamp;
        private System.Windows.Forms.ListBox lbBenevolesInclus;
        private System.Windows.Forms.ListBox lbEmployesInclus;
        private Outils.GrilleTable gtBenevoles;
        private Outils.GrilleTable gtEmployes;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblNombreHeuresEmploye;
        private System.Windows.Forms.NumericUpDown nudNombreHeuresEmploye;

    }
}