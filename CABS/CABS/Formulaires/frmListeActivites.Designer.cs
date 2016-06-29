namespace CABS.Formulaires
{
    partial class frmListeActivites
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
            this.dtpDeActivites = new System.Windows.Forms.DateTimePicker();
            this.dtpAActivites = new System.Windows.Forms.DateTimePicker();
            this.lblDeActivites = new System.Windows.Forms.Label();
            this.lblAActivites = new System.Windows.Forms.Label();
            this.btnListeActions = new System.Windows.Forms.Button();
            this.btnListeReunions = new System.Windows.Forms.Button();
            this.btnGenererTableauxActivites = new System.Windows.Forms.Button();
            this.lblActivite = new System.Windows.Forms.Label();
            this.lblSousChamp = new System.Windows.Forms.Label();
            this.lblChamp = new System.Windows.Forms.Label();
            this.cmbActivite = new System.Windows.Forms.ComboBox();
            this.cmbSousChamp = new System.Windows.Forms.ComboBox();
            this.cmbChamp = new System.Windows.Forms.ComboBox();
            this.cbSpecifierPeriodeActionsReunions = new System.Windows.Forms.CheckBox();
            this.cbSpecifierPeriodeActivites = new System.Windows.Forms.CheckBox();
            this.gbActionsReunions = new System.Windows.Forms.GroupBox();
            this.lblAActionsReunions = new System.Windows.Forms.Label();
            this.dtpAActionsReunions = new System.Windows.Forms.DateTimePicker();
            this.lblDeActionsReunions = new System.Windows.Forms.Label();
            this.dtpDeActionsReunions = new System.Windows.Forms.DateTimePicker();
            this.gbActivites = new System.Windows.Forms.GroupBox();
            this.cbTotaliserBeneficiairesDifferents = new System.Windows.Forms.CheckBox();
            this.cbTotaliserBenevolesDifferents = new System.Windows.Forms.CheckBox();
            this.gbActionsReunions.SuspendLayout();
            this.gbActivites.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpDeActivites
            // 
            this.dtpDeActivites.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDeActivites.Location = new System.Drawing.Point(287, 22);
            this.dtpDeActivites.Name = "dtpDeActivites";
            this.dtpDeActivites.Size = new System.Drawing.Size(200, 23);
            this.dtpDeActivites.TabIndex = 2;
            // 
            // dtpAActivites
            // 
            this.dtpAActivites.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAActivites.Location = new System.Drawing.Point(524, 22);
            this.dtpAActivites.Name = "dtpAActivites";
            this.dtpAActivites.Size = new System.Drawing.Size(200, 23);
            this.dtpAActivites.TabIndex = 4;
            // 
            // lblDeActivites
            // 
            this.lblDeActivites.AutoSize = true;
            this.lblDeActivites.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeActivites.Location = new System.Drawing.Point(247, 23);
            this.lblDeActivites.Name = "lblDeActivites";
            this.lblDeActivites.Size = new System.Drawing.Size(34, 17);
            this.lblDeActivites.TabIndex = 1;
            this.lblDeActivites.Text = "De :";
            // 
            // lblAActivites
            // 
            this.lblAActivites.AutoSize = true;
            this.lblAActivites.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAActivites.Location = new System.Drawing.Point(493, 23);
            this.lblAActivites.Name = "lblAActivites";
            this.lblAActivites.Size = new System.Drawing.Size(25, 17);
            this.lblAActivites.TabIndex = 3;
            this.lblAActivites.Text = "À :";
            // 
            // btnListeActions
            // 
            this.btnListeActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListeActions.Location = new System.Drawing.Point(9, 140);
            this.btnListeActions.Name = "btnListeActions";
            this.btnListeActions.Size = new System.Drawing.Size(200, 30);
            this.btnListeActions.TabIndex = 11;
            this.btnListeActions.Text = "Liste des actions";
            this.btnListeActions.UseVisualStyleBackColor = true;
            this.btnListeActions.Click += new System.EventHandler(this.btnListeActions_Click);
            // 
            // btnListeReunions
            // 
            this.btnListeReunions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListeReunions.Location = new System.Drawing.Point(215, 140);
            this.btnListeReunions.Name = "btnListeReunions";
            this.btnListeReunions.Size = new System.Drawing.Size(200, 30);
            this.btnListeReunions.TabIndex = 12;
            this.btnListeReunions.Text = "Liste des réunions";
            this.btnListeReunions.UseVisualStyleBackColor = true;
            this.btnListeReunions.Click += new System.EventHandler(this.btnListeReunions_Click);
            // 
            // btnGenererTableauxActivites
            // 
            this.btnGenererTableauxActivites.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenererTableauxActivites.Location = new System.Drawing.Point(9, 105);
            this.btnGenererTableauxActivites.Name = "btnGenererTableauxActivites";
            this.btnGenererTableauxActivites.Size = new System.Drawing.Size(406, 30);
            this.btnGenererTableauxActivites.TabIndex = 7;
            this.btnGenererTableauxActivites.Text = "Générer les tableaux des activités";
            this.btnGenererTableauxActivites.UseVisualStyleBackColor = true;
            this.btnGenererTableauxActivites.Click += new System.EventHandler(this.btnGenererTableauxActivites_Click);
            // 
            // lblActivite
            // 
            this.lblActivite.AutoSize = true;
            this.lblActivite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivite.Location = new System.Drawing.Point(6, 82);
            this.lblActivite.Name = "lblActivite";
            this.lblActivite.Size = new System.Drawing.Size(61, 17);
            this.lblActivite.TabIndex = 4;
            this.lblActivite.Text = "Activité :";
            // 
            // lblSousChamp
            // 
            this.lblSousChamp.AutoSize = true;
            this.lblSousChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSousChamp.Location = new System.Drawing.Point(6, 52);
            this.lblSousChamp.Name = "lblSousChamp";
            this.lblSousChamp.Size = new System.Drawing.Size(161, 17);
            this.lblSousChamp.TabIndex = 2;
            this.lblSousChamp.Text = "Sous-champ d\'activités :";
            // 
            // lblChamp
            // 
            this.lblChamp.AutoSize = true;
            this.lblChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChamp.Location = new System.Drawing.Point(6, 22);
            this.lblChamp.Name = "lblChamp";
            this.lblChamp.Size = new System.Drawing.Size(126, 17);
            this.lblChamp.TabIndex = 0;
            this.lblChamp.Text = "Champ d\'activités :";
            // 
            // cmbActivite
            // 
            this.cmbActivite.DropDownHeight = 200;
            this.cmbActivite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbActivite.FormattingEnabled = true;
            this.cmbActivite.IntegralHeight = false;
            this.cmbActivite.Location = new System.Drawing.Point(173, 79);
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
            this.cmbSousChamp.Location = new System.Drawing.Point(173, 49);
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
            this.cmbChamp.Location = new System.Drawing.Point(173, 19);
            this.cmbChamp.Name = "cmbChamp";
            this.cmbChamp.Size = new System.Drawing.Size(800, 24);
            this.cmbChamp.TabIndex = 1;
            this.cmbChamp.SelectedIndexChanged += new System.EventHandler(this.cmbChamp_SelectedIndexChanged);
            // 
            // cbSpecifierPeriodeActionsReunions
            // 
            this.cbSpecifierPeriodeActionsReunions.AutoSize = true;
            this.cbSpecifierPeriodeActionsReunions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSpecifierPeriodeActionsReunions.Location = new System.Drawing.Point(9, 113);
            this.cbSpecifierPeriodeActionsReunions.Name = "cbSpecifierPeriodeActionsReunions";
            this.cbSpecifierPeriodeActionsReunions.Size = new System.Drawing.Size(232, 21);
            this.cbSpecifierPeriodeActionsReunions.TabIndex = 6;
            this.cbSpecifierPeriodeActionsReunions.Text = "Spécifier une période de temps :";
            this.cbSpecifierPeriodeActionsReunions.UseVisualStyleBackColor = true;
            this.cbSpecifierPeriodeActionsReunions.CheckedChanged += new System.EventHandler(this.cbSpecifierPeriodeActionsReunions_CheckedChanged);
            // 
            // cbSpecifierPeriodeActivites
            // 
            this.cbSpecifierPeriodeActivites.AutoSize = true;
            this.cbSpecifierPeriodeActivites.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSpecifierPeriodeActivites.Location = new System.Drawing.Point(9, 22);
            this.cbSpecifierPeriodeActivites.Name = "cbSpecifierPeriodeActivites";
            this.cbSpecifierPeriodeActivites.Size = new System.Drawing.Size(232, 21);
            this.cbSpecifierPeriodeActivites.TabIndex = 0;
            this.cbSpecifierPeriodeActivites.Text = "Spécifier une période de temps :";
            this.cbSpecifierPeriodeActivites.UseVisualStyleBackColor = true;
            this.cbSpecifierPeriodeActivites.CheckedChanged += new System.EventHandler(this.cbSpecifierPeriodeActivites_CheckedChanged);
            // 
            // gbActionsReunions
            // 
            this.gbActionsReunions.Controls.Add(this.lblAActionsReunions);
            this.gbActionsReunions.Controls.Add(this.lblChamp);
            this.gbActionsReunions.Controls.Add(this.dtpAActionsReunions);
            this.gbActionsReunions.Controls.Add(this.lblDeActionsReunions);
            this.gbActionsReunions.Controls.Add(this.btnListeReunions);
            this.gbActionsReunions.Controls.Add(this.cmbChamp);
            this.gbActionsReunions.Controls.Add(this.cmbSousChamp);
            this.gbActionsReunions.Controls.Add(this.dtpDeActionsReunions);
            this.gbActionsReunions.Controls.Add(this.cmbActivite);
            this.gbActionsReunions.Controls.Add(this.lblSousChamp);
            this.gbActionsReunions.Controls.Add(this.lblActivite);
            this.gbActionsReunions.Controls.Add(this.btnListeActions);
            this.gbActionsReunions.Controls.Add(this.cbSpecifierPeriodeActionsReunions);
            this.gbActionsReunions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbActionsReunions.Location = new System.Drawing.Point(12, 12);
            this.gbActionsReunions.Name = "gbActionsReunions";
            this.gbActionsReunions.Size = new System.Drawing.Size(979, 176);
            this.gbActionsReunions.TabIndex = 0;
            this.gbActionsReunions.TabStop = false;
            this.gbActionsReunions.Text = "Actions / Réunions";
            // 
            // lblAActionsReunions
            // 
            this.lblAActionsReunions.AutoSize = true;
            this.lblAActionsReunions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAActionsReunions.Location = new System.Drawing.Point(493, 114);
            this.lblAActionsReunions.Name = "lblAActionsReunions";
            this.lblAActionsReunions.Size = new System.Drawing.Size(25, 17);
            this.lblAActionsReunions.TabIndex = 9;
            this.lblAActionsReunions.Text = "À :";
            // 
            // dtpAActionsReunions
            // 
            this.dtpAActionsReunions.Enabled = false;
            this.dtpAActionsReunions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAActionsReunions.Location = new System.Drawing.Point(524, 111);
            this.dtpAActionsReunions.Name = "dtpAActionsReunions";
            this.dtpAActionsReunions.Size = new System.Drawing.Size(200, 23);
            this.dtpAActionsReunions.TabIndex = 10;
            // 
            // lblDeActionsReunions
            // 
            this.lblDeActionsReunions.AutoSize = true;
            this.lblDeActionsReunions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeActionsReunions.Location = new System.Drawing.Point(247, 114);
            this.lblDeActionsReunions.Name = "lblDeActionsReunions";
            this.lblDeActionsReunions.Size = new System.Drawing.Size(34, 17);
            this.lblDeActionsReunions.TabIndex = 7;
            this.lblDeActionsReunions.Text = "De :";
            // 
            // dtpDeActionsReunions
            // 
            this.dtpDeActionsReunions.Enabled = false;
            this.dtpDeActionsReunions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDeActionsReunions.Location = new System.Drawing.Point(287, 111);
            this.dtpDeActionsReunions.Name = "dtpDeActionsReunions";
            this.dtpDeActionsReunions.Size = new System.Drawing.Size(200, 23);
            this.dtpDeActionsReunions.TabIndex = 8;
            // 
            // gbActivites
            // 
            this.gbActivites.Controls.Add(this.cbTotaliserBeneficiairesDifferents);
            this.gbActivites.Controls.Add(this.cbTotaliserBenevolesDifferents);
            this.gbActivites.Controls.Add(this.cbSpecifierPeriodeActivites);
            this.gbActivites.Controls.Add(this.lblDeActivites);
            this.gbActivites.Controls.Add(this.btnGenererTableauxActivites);
            this.gbActivites.Controls.Add(this.dtpDeActivites);
            this.gbActivites.Controls.Add(this.dtpAActivites);
            this.gbActivites.Controls.Add(this.lblAActivites);
            this.gbActivites.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbActivites.Location = new System.Drawing.Point(12, 194);
            this.gbActivites.Name = "gbActivites";
            this.gbActivites.Size = new System.Drawing.Size(974, 141);
            this.gbActivites.TabIndex = 1;
            this.gbActivites.TabStop = false;
            this.gbActivites.Text = "Activités";
            // 
            // cbTotaliserBeneficiairesDifferents
            // 
            this.cbTotaliserBeneficiairesDifferents.AutoSize = true;
            this.cbTotaliserBeneficiairesDifferents.Location = new System.Drawing.Point(9, 78);
            this.cbTotaliserBeneficiairesDifferents.Name = "cbTotaliserBeneficiairesDifferents";
            this.cbTotaliserBeneficiairesDifferents.Size = new System.Drawing.Size(251, 21);
            this.cbTotaliserBeneficiairesDifferents.TabIndex = 6;
            this.cbTotaliserBeneficiairesDifferents.Text = "Totaliser les bénéficiaires différents";
            this.cbTotaliserBeneficiairesDifferents.UseVisualStyleBackColor = true;
            // 
            // cbTotaliserBenevolesDifferents
            // 
            this.cbTotaliserBenevolesDifferents.AutoSize = true;
            this.cbTotaliserBenevolesDifferents.Location = new System.Drawing.Point(9, 51);
            this.cbTotaliserBenevolesDifferents.Name = "cbTotaliserBenevolesDifferents";
            this.cbTotaliserBenevolesDifferents.Size = new System.Drawing.Size(236, 21);
            this.cbTotaliserBenevolesDifferents.TabIndex = 5;
            this.cbTotaliserBenevolesDifferents.Text = "Totaliser les bénévoles différents";
            this.cbTotaliserBenevolesDifferents.UseVisualStyleBackColor = true;
            // 
            // frmListeActivites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 689);
            this.Controls.Add(this.gbActivites);
            this.Controls.Add(this.gbActionsReunions);
            this.Name = "frmListeActivites";
            this.Text = "frmListeActivites";
            this.gbActionsReunions.ResumeLayout(false);
            this.gbActionsReunions.PerformLayout();
            this.gbActivites.ResumeLayout(false);
            this.gbActivites.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDeActivites;
        private System.Windows.Forms.DateTimePicker dtpAActivites;
        private System.Windows.Forms.Label lblDeActivites;
        private System.Windows.Forms.Label lblAActivites;
        private System.Windows.Forms.Button btnListeActions;
        private System.Windows.Forms.Button btnListeReunions;
        private System.Windows.Forms.Button btnGenererTableauxActivites;
        private System.Windows.Forms.Label lblActivite;
        private System.Windows.Forms.Label lblSousChamp;
        private System.Windows.Forms.Label lblChamp;
        private System.Windows.Forms.ComboBox cmbActivite;
        private System.Windows.Forms.ComboBox cmbSousChamp;
        private System.Windows.Forms.ComboBox cmbChamp;
        private System.Windows.Forms.CheckBox cbSpecifierPeriodeActionsReunions;
        private System.Windows.Forms.CheckBox cbSpecifierPeriodeActivites;
        private System.Windows.Forms.GroupBox gbActionsReunions;
        private System.Windows.Forms.Label lblAActionsReunions;
        private System.Windows.Forms.DateTimePicker dtpAActionsReunions;
        private System.Windows.Forms.Label lblDeActionsReunions;
        private System.Windows.Forms.DateTimePicker dtpDeActionsReunions;
        private System.Windows.Forms.GroupBox gbActivites;
        private System.Windows.Forms.CheckBox cbTotaliserBeneficiairesDifferents;
        private System.Windows.Forms.CheckBox cbTotaliserBenevolesDifferents;
    }
}