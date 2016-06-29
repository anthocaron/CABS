namespace CABS.Outils
{
    partial class GrilleTable
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvGrille = new System.Windows.Forms.DataGridView();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrille)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrille
            // 
            this.dgvGrille.AllowUserToAddRows = false;
            this.dgvGrille.AllowUserToDeleteRows = false;
            this.dgvGrille.AllowUserToResizeColumns = false;
            this.dgvGrille.AllowUserToResizeRows = false;
            this.dgvGrille.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGrille.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrille.Location = new System.Drawing.Point(0, 20);
            this.dgvGrille.Margin = new System.Windows.Forms.Padding(0);
            this.dgvGrille.MultiSelect = false;
            this.dgvGrille.Name = "dgvGrille";
            this.dgvGrille.ReadOnly = true;
            this.dgvGrille.RowHeadersVisible = false;
            this.dgvGrille.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrille.Size = new System.Drawing.Size(348, 256);
            this.dgvGrille.TabIndex = 1;
            this.dgvGrille.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrille_CellDoubleClick);
            // 
            // txtRecherche
            // 
            this.txtRecherche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecherche.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRecherche.Location = new System.Drawing.Point(0, 0);
            this.txtRecherche.Margin = new System.Windows.Forms.Padding(0);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(348, 20);
            this.txtRecherche.TabIndex = 0;
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);
            // 
            // GrilleTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.dgvGrille);
            this.Name = "GrilleTable";
            this.Size = new System.Drawing.Size(348, 276);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrille)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrille;
        private System.Windows.Forms.TextBox txtRecherche;
    }
}
