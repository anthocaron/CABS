namespace CABS.Formulaires.Inscription
{
    partial class frmDisponibiliteServicesBenevoles
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
            this.gbBenevole = new System.Windows.Forms.GroupBox();
            this.lblNomValeur = new System.Windows.Forms.Label();
            this.lblPrenomValeur = new System.Windows.Forms.Label();
            this.btnChoisirBenevole = new System.Windows.Forms.Button();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.btnRetirerDispo = new System.Windows.Forms.Button();
            this.btnEntrerDispo = new System.Windows.Forms.Button();
            this.gbBenevole.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBenevole
            // 
            this.gbBenevole.Controls.Add(this.lblNomValeur);
            this.gbBenevole.Controls.Add(this.lblPrenomValeur);
            this.gbBenevole.Controls.Add(this.btnChoisirBenevole);
            this.gbBenevole.Controls.Add(this.lblNom);
            this.gbBenevole.Controls.Add(this.lblPrenom);
            this.gbBenevole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBenevole.Location = new System.Drawing.Point(12, 12);
            this.gbBenevole.Name = "gbBenevole";
            this.gbBenevole.Size = new System.Drawing.Size(608, 51);
            this.gbBenevole.TabIndex = 0;
            this.gbBenevole.TabStop = false;
            this.gbBenevole.Text = "Bénévole";
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
            // btnChoisirBenevole
            // 
            this.btnChoisirBenevole.Image = global::CABS.Properties.Resources._16px_Magnifying_glass_icon;
            this.btnChoisirBenevole.Location = new System.Drawing.Point(572, 18);
            this.btnChoisirBenevole.Name = "btnChoisirBenevole";
            this.btnChoisirBenevole.Size = new System.Drawing.Size(30, 30);
            this.btnChoisirBenevole.TabIndex = 4;
            this.btnChoisirBenevole.UseVisualStyleBackColor = true;
            this.btnChoisirBenevole.Click += new System.EventHandler(this.btnChoisirBenevole_Click);
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
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblService.Location = new System.Drawing.Point(12, 76);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(63, 17);
            this.lblService.TabIndex = 1;
            this.lblService.Text = "Service :";
            // 
            // cmbService
            // 
            this.cmbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Location = new System.Drawing.Point(81, 73);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(175, 24);
            this.cmbService.TabIndex = 2;
            this.cmbService.SelectedIndexChanged += new System.EventHandler(this.cmbService_SelectedIndexChanged);
            // 
            // btnRetirerDispo
            // 
            this.btnRetirerDispo.Enabled = false;
            this.btnRetirerDispo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirerDispo.Location = new System.Drawing.Point(443, 69);
            this.btnRetirerDispo.Name = "btnRetirerDispo";
            this.btnRetirerDispo.Size = new System.Drawing.Size(177, 30);
            this.btnRetirerDispo.TabIndex = 4;
            this.btnRetirerDispo.Text = "Retirer la disponibilité";
            this.btnRetirerDispo.UseVisualStyleBackColor = true;
            this.btnRetirerDispo.Click += new System.EventHandler(this.btnRetirerDispo_Click);
            // 
            // btnEntrerDispo
            // 
            this.btnEntrerDispo.Enabled = false;
            this.btnEntrerDispo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrerDispo.Location = new System.Drawing.Point(262, 69);
            this.btnEntrerDispo.Name = "btnEntrerDispo";
            this.btnEntrerDispo.Size = new System.Drawing.Size(175, 30);
            this.btnEntrerDispo.TabIndex = 3;
            this.btnEntrerDispo.Text = "Entrer la disponibilité";
            this.btnEntrerDispo.UseVisualStyleBackColor = true;
            this.btnEntrerDispo.Click += new System.EventHandler(this.btnEntrerDispo_Click);
            // 
            // frmDisponibiliteServicesBenevoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 565);
            this.Controls.Add(this.btnRetirerDispo);
            this.Controls.Add(this.btnEntrerDispo);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.cmbService);
            this.Controls.Add(this.gbBenevole);
            this.Name = "frmDisponibiliteServicesBenevoles";
            this.Text = "frmDisponibiliteServicesBenevoles";
            this.gbBenevole.ResumeLayout(false);
            this.gbBenevole.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBenevole;
        private System.Windows.Forms.Label lblNomValeur;
        private System.Windows.Forms.Label lblPrenomValeur;
        private System.Windows.Forms.Button btnChoisirBenevole;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Button btnRetirerDispo;
        private System.Windows.Forms.Button btnEntrerDispo;
    }
}