namespace CABS.Formulaires
{
    partial class frmGestionRoutes
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
            this.tvRoutesBeneficiaires = new System.Windows.Forms.TreeView();
            this.lblRoutesBeneficiaires = new System.Windows.Forms.Label();
            this.lblBeneficiaires = new System.Windows.Forms.Label();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.txtNouvelleRoute = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.lbBeneficiaires = new System.Windows.Forms.ListBox();
            this.btnInclure = new System.Windows.Forms.Button();
            this.btnRetirer = new System.Windows.Forms.Button();
            this.btnMonter = new System.Windows.Forms.Button();
            this.btnBaisser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tvRoutesBeneficiaires
            // 
            this.tvRoutesBeneficiaires.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvRoutesBeneficiaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvRoutesBeneficiaires.HideSelection = false;
            this.tvRoutesBeneficiaires.Location = new System.Drawing.Point(472, 29);
            this.tvRoutesBeneficiaires.Name = "tvRoutesBeneficiaires";
            this.tvRoutesBeneficiaires.Size = new System.Drawing.Size(400, 355);
            this.tvRoutesBeneficiaires.TabIndex = 7;
            this.tvRoutesBeneficiaires.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.tvRoutesBeneficiaires_DrawNode);
            this.tvRoutesBeneficiaires.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRoutesBeneficiaires_AfterSelect);
            // 
            // lblRoutesBeneficiaires
            // 
            this.lblRoutesBeneficiaires.AutoSize = true;
            this.lblRoutesBeneficiaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoutesBeneficiaires.Location = new System.Drawing.Point(469, 9);
            this.lblRoutesBeneficiaires.Name = "lblRoutesBeneficiaires";
            this.lblRoutesBeneficiaires.Size = new System.Drawing.Size(154, 17);
            this.lblRoutesBeneficiaires.TabIndex = 6;
            this.lblRoutesBeneficiaires.Text = "Routes / Bénéficiaires :";
            // 
            // lblBeneficiaires
            // 
            this.lblBeneficiaires.AutoSize = true;
            this.lblBeneficiaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiaires.Location = new System.Drawing.Point(12, 9);
            this.lblBeneficiaires.Name = "lblBeneficiaires";
            this.lblBeneficiaires.Size = new System.Drawing.Size(174, 17);
            this.lblBeneficiaires.TabIndex = 0;
            this.lblBeneficiaires.Text = "Bénéficiares non-classés :";
            // 
            // btnAjouter
            // 
            this.btnAjouter.Enabled = false;
            this.btnAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(472, 419);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(400, 50);
            this.btnAjouter.TabIndex = 10;
            this.btnAjouter.Text = "Ajouter nouvelle route";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Enabled = false;
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.Location = new System.Drawing.Point(472, 475);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(400, 50);
            this.btnSupprimer.TabIndex = 11;
            this.btnSupprimer.Text = "Supprimer route";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // txtNouvelleRoute
            // 
            this.txtNouvelleRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNouvelleRoute.Location = new System.Drawing.Point(520, 390);
            this.txtNouvelleRoute.MaxLength = 64;
            this.txtNouvelleRoute.Name = "txtNouvelleRoute";
            this.txtNouvelleRoute.Size = new System.Drawing.Size(352, 23);
            this.txtNouvelleRoute.TabIndex = 9;
            this.txtNouvelleRoute.TextChanged += new System.EventHandler(this.txtNouvelleRoute_TextChanged);
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(469, 393);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(45, 17);
            this.lblNom.TabIndex = 8;
            this.lblNom.Text = "Nom :";
            // 
            // lbBeneficiaires
            // 
            this.lbBeneficiaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBeneficiaires.FormattingEnabled = true;
            this.lbBeneficiaires.ItemHeight = 16;
            this.lbBeneficiaires.Location = new System.Drawing.Point(12, 29);
            this.lbBeneficiaires.Name = "lbBeneficiaires";
            this.lbBeneficiaires.Size = new System.Drawing.Size(350, 356);
            this.lbBeneficiaires.Sorted = true;
            this.lbBeneficiaires.TabIndex = 1;
            this.lbBeneficiaires.SelectedIndexChanged += new System.EventHandler(this.lbBeneficiaires_SelectedIndexChanged);
            // 
            // btnInclure
            // 
            this.btnInclure.Enabled = false;
            this.btnInclure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInclure.Location = new System.Drawing.Point(368, 25);
            this.btnInclure.Name = "btnInclure";
            this.btnInclure.Size = new System.Drawing.Size(98, 75);
            this.btnInclure.TabIndex = 2;
            this.btnInclure.Text = "Inclure >>>";
            this.btnInclure.UseVisualStyleBackColor = true;
            this.btnInclure.Click += new System.EventHandler(this.btnInclure_Click);
            // 
            // btnRetirer
            // 
            this.btnRetirer.Enabled = false;
            this.btnRetirer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirer.Location = new System.Drawing.Point(368, 106);
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(98, 75);
            this.btnRetirer.TabIndex = 3;
            this.btnRetirer.Text = "Retirer <<<";
            this.btnRetirer.UseVisualStyleBackColor = true;
            this.btnRetirer.Click += new System.EventHandler(this.btnRetirer_Click);
            // 
            // btnMonter
            // 
            this.btnMonter.Enabled = false;
            this.btnMonter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonter.Location = new System.Drawing.Point(368, 187);
            this.btnMonter.Name = "btnMonter";
            this.btnMonter.Size = new System.Drawing.Size(98, 75);
            this.btnMonter.TabIndex = 4;
            this.btnMonter.Text = "Monter";
            this.btnMonter.UseVisualStyleBackColor = true;
            this.btnMonter.Click += new System.EventHandler(this.btnMonter_Click);
            // 
            // btnBaisser
            // 
            this.btnBaisser.Enabled = false;
            this.btnBaisser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaisser.Location = new System.Drawing.Point(368, 268);
            this.btnBaisser.Name = "btnBaisser";
            this.btnBaisser.Size = new System.Drawing.Size(98, 75);
            this.btnBaisser.TabIndex = 5;
            this.btnBaisser.Text = "Baisser";
            this.btnBaisser.UseVisualStyleBackColor = true;
            this.btnBaisser.Click += new System.EventHandler(this.btnBaisser_Click);
            // 
            // frmGestionRoutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.btnBaisser);
            this.Controls.Add(this.btnMonter);
            this.Controls.Add(this.btnRetirer);
            this.Controls.Add(this.btnInclure);
            this.Controls.Add(this.lbBeneficiaires);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.txtNouvelleRoute);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.lblBeneficiaires);
            this.Controls.Add(this.lblRoutesBeneficiaires);
            this.Controls.Add(this.tvRoutesBeneficiaires);
            this.Name = "frmGestionRoutes";
            this.Text = "frmGestionRoutes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvRoutesBeneficiaires;
        private System.Windows.Forms.Label lblRoutesBeneficiaires;
        private System.Windows.Forms.Label lblBeneficiaires;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.TextBox txtNouvelleRoute;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.ListBox lbBeneficiaires;
        private System.Windows.Forms.Button btnInclure;
        private System.Windows.Forms.Button btnRetirer;
        private System.Windows.Forms.Button btnMonter;
        private System.Windows.Forms.Button btnBaisser;
    }
}