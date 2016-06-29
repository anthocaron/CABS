namespace CABS.Formulaires
{
    partial class frmPrincipal
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.msOptions = new System.Windows.Forms.MenuStrip();
            this.tsmFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSauvegarderDonnees = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAide = new System.Windows.Forms.ToolStripMenuItem();
            this.ssInfos = new System.Windows.Forms.StatusStrip();
            this.tsslConnexion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslIndication = new System.Windows.Forms.ToolStripStatusLabel();
            this.spcVertical = new System.Windows.Forms.SplitContainer();
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.tvSections = new System.Windows.Forms.TreeView();
            this.gbFormulaires = new System.Windows.Forms.GroupBox();
            this.tbcFormulaires = new System.Windows.Forms.TabControl();
            this.btnPrecedent = new System.Windows.Forms.Button();
            this.btnSuivant = new System.Windows.Forms.Button();
            this.msOptions.SuspendLayout();
            this.ssInfos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcVertical)).BeginInit();
            this.spcVertical.Panel1.SuspendLayout();
            this.spcVertical.Panel2.SuspendLayout();
            this.spcVertical.SuspendLayout();
            this.gbMenu.SuspendLayout();
            this.gbFormulaires.SuspendLayout();
            this.SuspendLayout();
            // 
            // msOptions
            // 
            this.msOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFichier});
            this.msOptions.Location = new System.Drawing.Point(0, 0);
            this.msOptions.Name = "msOptions";
            this.msOptions.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.msOptions.Size = new System.Drawing.Size(1045, 24);
            this.msOptions.TabIndex = 0;
            this.msOptions.Text = "msOptions";
            // 
            // tsmFichier
            // 
            this.tsmFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSauvegarderDonnees,
            this.tsmQuitter});
            this.tsmFichier.Name = "tsmFichier";
            this.tsmFichier.Size = new System.Drawing.Size(54, 20);
            this.tsmFichier.Text = "Fichier";
            // 
            // tsmSauvegarderDonnees
            // 
            this.tsmSauvegarderDonnees.Name = "tsmSauvegarderDonnees";
            this.tsmSauvegarderDonnees.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmSauvegarderDonnees.Size = new System.Drawing.Size(253, 22);
            this.tsmSauvegarderDonnees.Text = "Sauvegarder les données...";
            this.tsmSauvegarderDonnees.Click += new System.EventHandler(this.tsmSauvegarderDonnees_Click);
            // 
            // tsmQuitter
            // 
            this.tsmQuitter.Name = "tsmQuitter";
            this.tsmQuitter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.tsmQuitter.Size = new System.Drawing.Size(253, 22);
            this.tsmQuitter.Text = "Quitter";
            this.tsmQuitter.Click += new System.EventHandler(this.tsmQuitter_Click);
            // 
            // tsmOptions
            // 
            this.tsmOptions.Name = "tsmOptions";
            this.tsmOptions.Size = new System.Drawing.Size(61, 20);
            this.tsmOptions.Text = "Options";
            // 
            // tsmAide
            // 
            this.tsmAide.Name = "tsmAide";
            this.tsmAide.Size = new System.Drawing.Size(24, 20);
            this.tsmAide.Text = "?";
            // 
            // ssInfos
            // 
            this.ssInfos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ssInfos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslConnexion,
            this.tsslIndication});
            this.ssInfos.Location = new System.Drawing.Point(0, 670);
            this.ssInfos.Name = "ssInfos";
            this.ssInfos.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.ssInfos.Size = new System.Drawing.Size(1045, 22);
            this.ssInfos.TabIndex = 3;
            // 
            // tsslConnexion
            // 
            this.tsslConnexion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslConnexion.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.tsslConnexion.Name = "tsslConnexion";
            this.tsslConnexion.Size = new System.Drawing.Size(4, 17);
            // 
            // tsslIndication
            // 
            this.tsslIndication.Name = "tsslIndication";
            this.tsslIndication.Size = new System.Drawing.Size(0, 17);
            // 
            // spcVertical
            // 
            this.spcVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcVertical.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spcVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spcVertical.Location = new System.Drawing.Point(0, 73);
            this.spcVertical.Margin = new System.Windows.Forms.Padding(4);
            this.spcVertical.Name = "spcVertical";
            // 
            // spcVertical.Panel1
            // 
            this.spcVertical.Panel1.Controls.Add(this.gbMenu);
            // 
            // spcVertical.Panel2
            // 
            this.spcVertical.Panel2.Controls.Add(this.gbFormulaires);
            this.spcVertical.Size = new System.Drawing.Size(1045, 592);
            this.spcVertical.SplitterDistance = 330;
            this.spcVertical.SplitterWidth = 5;
            this.spcVertical.TabIndex = 2;
            // 
            // gbMenu
            // 
            this.gbMenu.Controls.Add(this.tvSections);
            this.gbMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMenu.Location = new System.Drawing.Point(0, 0);
            this.gbMenu.Margin = new System.Windows.Forms.Padding(4);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Padding = new System.Windows.Forms.Padding(4);
            this.gbMenu.Size = new System.Drawing.Size(328, 590);
            this.gbMenu.TabIndex = 0;
            this.gbMenu.TabStop = false;
            this.gbMenu.Text = "Menu";
            // 
            // tvSections
            // 
            this.tvSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSections.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvSections.Indent = 20;
            this.tvSections.ItemHeight = 20;
            this.tvSections.Location = new System.Drawing.Point(4, 20);
            this.tvSections.Margin = new System.Windows.Forms.Padding(4);
            this.tvSections.Name = "tvSections";
            this.tvSections.Size = new System.Drawing.Size(320, 566);
            this.tvSections.TabIndex = 0;
            this.tvSections.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvSections_BeforeSelect);
            // 
            // gbFormulaires
            // 
            this.gbFormulaires.Controls.Add(this.tbcFormulaires);
            this.gbFormulaires.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFormulaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFormulaires.Location = new System.Drawing.Point(0, 0);
            this.gbFormulaires.Margin = new System.Windows.Forms.Padding(4);
            this.gbFormulaires.Name = "gbFormulaires";
            this.gbFormulaires.Padding = new System.Windows.Forms.Padding(4);
            this.gbFormulaires.Size = new System.Drawing.Size(708, 590);
            this.gbFormulaires.TabIndex = 0;
            this.gbFormulaires.TabStop = false;
            this.gbFormulaires.Text = "Formulaires";
            // 
            // tbcFormulaires
            // 
            this.tbcFormulaires.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcFormulaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcFormulaires.Location = new System.Drawing.Point(4, 20);
            this.tbcFormulaires.Name = "tbcFormulaires";
            this.tbcFormulaires.SelectedIndex = 0;
            this.tbcFormulaires.Size = new System.Drawing.Size(700, 566);
            this.tbcFormulaires.TabIndex = 0;
            this.tbcFormulaires.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcFormulaires_Selected);
            this.tbcFormulaires.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbcFormulaires_Deselecting);
            // 
            // btnPrecedent
            // 
            this.btnPrecedent.Enabled = false;
            this.btnPrecedent.Location = new System.Drawing.Point(13, 28);
            this.btnPrecedent.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrecedent.Name = "btnPrecedent";
            this.btnPrecedent.Size = new System.Drawing.Size(160, 37);
            this.btnPrecedent.TabIndex = 1;
            this.btnPrecedent.Text = "Précédent";
            this.btnPrecedent.UseVisualStyleBackColor = true;
            this.btnPrecedent.Click += new System.EventHandler(this.btnPrecedent_Click);
            // 
            // btnSuivant
            // 
            this.btnSuivant.Enabled = false;
            this.btnSuivant.Location = new System.Drawing.Point(181, 28);
            this.btnSuivant.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuivant.Name = "btnSuivant";
            this.btnSuivant.Size = new System.Drawing.Size(160, 37);
            this.btnSuivant.TabIndex = 2;
            this.btnSuivant.Text = "Suivant";
            this.btnSuivant.UseVisualStyleBackColor = true;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 692);
            this.Controls.Add(this.btnSuivant);
            this.Controls.Add(this.btnPrecedent);
            this.Controls.Add(this.spcVertical);
            this.Controls.Add(this.ssInfos);
            this.Controls.Add(this.msOptions);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msOptions;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CABS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.msOptions.ResumeLayout(false);
            this.msOptions.PerformLayout();
            this.ssInfos.ResumeLayout(false);
            this.ssInfos.PerformLayout();
            this.spcVertical.Panel1.ResumeLayout(false);
            this.spcVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcVertical)).EndInit();
            this.spcVertical.ResumeLayout(false);
            this.gbMenu.ResumeLayout(false);
            this.gbFormulaires.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmAide;
        private System.Windows.Forms.StatusStrip ssInfos;
        private System.Windows.Forms.SplitContainer spcVertical;
        private System.Windows.Forms.GroupBox gbMenu;
        private System.Windows.Forms.TreeView tvSections;
        private System.Windows.Forms.GroupBox gbFormulaires;
        private System.Windows.Forms.TabControl tbcFormulaires;
        private System.Windows.Forms.ToolStripMenuItem tsmFichier;
        private System.Windows.Forms.ToolStripMenuItem tsmSauvegarderDonnees;
        private System.Windows.Forms.ToolStripMenuItem tsmQuitter;
        private System.Windows.Forms.ToolStripStatusLabel tsslConnexion;
        private System.Windows.Forms.Button btnPrecedent;
        private System.Windows.Forms.Button btnSuivant;
        private System.Windows.Forms.ToolStripStatusLabel tsslIndication;



    }
}

