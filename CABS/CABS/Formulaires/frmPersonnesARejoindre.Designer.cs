namespace CABS.Formulaires
{
    partial class frmPersonnesARejoindre
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
            this.gbPersonne = new System.Windows.Forms.GroupBox();
            this.lblNomValeur = new System.Windows.Forms.Label();
            this.lblPrenomValeur = new System.Windows.Forms.Label();
            this.btnChoisirPersonne = new System.Windows.Forms.Button();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.dgvPersonnesARejoindre = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephone = new JThomas.Controls.DataGridViewMaskedTextColumn();
            this.btnVider = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.gbPersonne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnesARejoindre)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPersonne
            // 
            this.gbPersonne.Controls.Add(this.lblNomValeur);
            this.gbPersonne.Controls.Add(this.lblPrenomValeur);
            this.gbPersonne.Controls.Add(this.btnChoisirPersonne);
            this.gbPersonne.Controls.Add(this.lblNom);
            this.gbPersonne.Controls.Add(this.lblPrenom);
            this.gbPersonne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPersonne.Location = new System.Drawing.Point(12, 12);
            this.gbPersonne.Name = "gbPersonne";
            this.gbPersonne.Size = new System.Drawing.Size(576, 51);
            this.gbPersonne.TabIndex = 0;
            this.gbPersonne.TabStop = false;
            this.gbPersonne.Text = "Personne";
            // 
            // lblNomValeur
            // 
            this.lblNomValeur.BackColor = System.Drawing.Color.White;
            this.lblNomValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNomValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomValeur.Location = new System.Drawing.Point(334, 22);
            this.lblNomValeur.Margin = new System.Windows.Forms.Padding(3);
            this.lblNomValeur.Name = "lblNomValeur";
            this.lblNomValeur.Size = new System.Drawing.Size(200, 23);
            this.lblNomValeur.TabIndex = 3;
            this.lblNomValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrenomValeur
            // 
            this.lblPrenomValeur.BackColor = System.Drawing.Color.White;
            this.lblPrenomValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPrenomValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrenomValeur.Location = new System.Drawing.Point(77, 22);
            this.lblPrenomValeur.Margin = new System.Windows.Forms.Padding(3);
            this.lblPrenomValeur.Name = "lblPrenomValeur";
            this.lblPrenomValeur.Size = new System.Drawing.Size(200, 23);
            this.lblPrenomValeur.TabIndex = 1;
            this.lblPrenomValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChoisirPersonne
            // 
            this.btnChoisirPersonne.Image = global::CABS.Properties.Resources._16px_Magnifying_glass_icon;
            this.btnChoisirPersonne.Location = new System.Drawing.Point(540, 18);
            this.btnChoisirPersonne.Name = "btnChoisirPersonne";
            this.btnChoisirPersonne.Size = new System.Drawing.Size(30, 30);
            this.btnChoisirPersonne.TabIndex = 4;
            this.btnChoisirPersonne.UseVisualStyleBackColor = true;
            this.btnChoisirPersonne.Click += new System.EventHandler(this.btnChoisirPersonne_Click);
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(283, 25);
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
            // dgvPersonnesARejoindre
            // 
            this.dgvPersonnesARejoindre.AllowUserToResizeColumns = false;
            this.dgvPersonnesARejoindre.AllowUserToResizeRows = false;
            this.dgvPersonnesARejoindre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonnesARejoindre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.prenom,
            this.nom,
            this.lien,
            this.telephone});
            this.dgvPersonnesARejoindre.Location = new System.Drawing.Point(12, 73);
            this.dgvPersonnesARejoindre.MultiSelect = false;
            this.dgvPersonnesARejoindre.Name = "dgvPersonnesARejoindre";
            this.dgvPersonnesARejoindre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonnesARejoindre.Size = new System.Drawing.Size(719, 230);
            this.dgvPersonnesARejoindre.TabIndex = 2;
            this.dgvPersonnesARejoindre.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonnesARejoindre_CellValueChanged);
            this.dgvPersonnesARejoindre.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvPersonnesARejoindre_UserAddedRow);
            this.dgvPersonnesARejoindre.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvPersonnesARejoindre_UserDeletingRow);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // prenom
            // 
            this.prenom.HeaderText = "Prénom";
            this.prenom.MaxInputLength = 64;
            this.prenom.Name = "prenom";
            this.prenom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.prenom.Width = 200;
            // 
            // nom
            // 
            this.nom.HeaderText = "Nom";
            this.nom.MaxInputLength = 64;
            this.nom.Name = "nom";
            this.nom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.nom.Width = 200;
            // 
            // lien
            // 
            this.lien.HeaderText = "Lien";
            this.lien.Name = "lien";
            this.lien.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lien.Width = 126;
            // 
            // telephone
            // 
            this.telephone.HeaderText = "Téléphone";
            this.telephone.Mask = "( 000 ) 000-0000";
            this.telephone.Name = "telephone";
            this.telephone.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.telephone.Width = 150;
            // 
            // btnVider
            // 
            this.btnVider.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVider.Location = new System.Drawing.Point(594, 12);
            this.btnVider.Name = "btnVider";
            this.btnVider.Size = new System.Drawing.Size(137, 55);
            this.btnVider.TabIndex = 1;
            this.btnVider.Text = "Vider la table";
            this.btnVider.UseVisualStyleBackColor = true;
            this.btnVider.Click += new System.EventHandler(this.btnVider_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Enabled = false;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Location = new System.Drawing.Point(12, 309);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(356, 50);
            this.btnEnregistrer.TabIndex = 3;
            this.btnEnregistrer.Text = "Enregistrer les modifications";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Enabled = false;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(374, 309);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(357, 50);
            this.btnAnnuler.TabIndex = 4;
            this.btnAnnuler.Text = "Annuler les modifications";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // frmPersonnesARejoindre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 531);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnVider);
            this.Controls.Add(this.dgvPersonnesARejoindre);
            this.Controls.Add(this.gbPersonne);
            this.Name = "frmPersonnesARejoindre";
            this.Text = "Personnes à rejoindre";
            this.gbPersonne.ResumeLayout(false);
            this.gbPersonne.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnesARejoindre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPersonne;
        private System.Windows.Forms.Button btnChoisirPersonne;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.DataGridView dgvPersonnesARejoindre;
        private System.Windows.Forms.Button btnVider;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Label lblNomValeur;
        private System.Windows.Forms.Label lblPrenomValeur;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn prenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn lien;
        private JThomas.Controls.DataGridViewMaskedTextColumn telephone;
    }
}