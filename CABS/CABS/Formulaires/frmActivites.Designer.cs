namespace CABS.Formulaires
{
    partial class frmActivites
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
            this.txtNomChamp = new System.Windows.Forms.TextBox();
            this.txtNomActivite = new System.Windows.Forms.TextBox();
            this.txtNomSousChamp = new System.Windows.Forms.TextBox();
            this.lbChamps = new System.Windows.Forms.ListBox();
            this.lbSousChamps = new System.Windows.Forms.ListBox();
            this.lbActivites = new System.Windows.Forms.ListBox();
            this.btnAjouterChamp = new System.Windows.Forms.Button();
            this.btnModifierChamp = new System.Windows.Forms.Button();
            this.btnSupprimerChamp = new System.Windows.Forms.Button();
            this.btnAjouterSousChamp = new System.Windows.Forms.Button();
            this.btnModifierSousChamp = new System.Windows.Forms.Button();
            this.btnSupprimerSousChamp = new System.Windows.Forms.Button();
            this.btnAjouterActivite = new System.Windows.Forms.Button();
            this.btnModifierActivite = new System.Windows.Forms.Button();
            this.btnSupprimerActivite = new System.Windows.Forms.Button();
            this.lblChamps = new System.Windows.Forms.Label();
            this.lblNomChamp = new System.Windows.Forms.Label();
            this.lblSousChamps = new System.Windows.Forms.Label();
            this.lblNomSousChamp = new System.Windows.Forms.Label();
            this.lblActivites = new System.Windows.Forms.Label();
            this.lblNomActivite = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNomChamp
            // 
            this.txtNomChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomChamp.Location = new System.Drawing.Point(129, 234);
            this.txtNomChamp.MaxLength = 256;
            this.txtNomChamp.Name = "txtNomChamp";
            this.txtNomChamp.Size = new System.Drawing.Size(683, 23);
            this.txtNomChamp.TabIndex = 3;
            this.txtNomChamp.TextChanged += new System.EventHandler(this.txtNomChamp_TextChanged);
            // 
            // txtNomActivite
            // 
            this.txtNomActivite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomActivite.Location = new System.Drawing.Point(137, 808);
            this.txtNomActivite.MaxLength = 256;
            this.txtNomActivite.Name = "txtNomActivite";
            this.txtNomActivite.Size = new System.Drawing.Size(675, 23);
            this.txtNomActivite.TabIndex = 17;
            this.txtNomActivite.TextChanged += new System.EventHandler(this.txtNomActivite_TextChanged);
            // 
            // txtNomSousChamp
            // 
            this.txtNomSousChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomSousChamp.Location = new System.Drawing.Point(164, 521);
            this.txtNomSousChamp.MaxLength = 256;
            this.txtNomSousChamp.Name = "txtNomSousChamp";
            this.txtNomSousChamp.Size = new System.Drawing.Size(648, 23);
            this.txtNomSousChamp.TabIndex = 10;
            this.txtNomSousChamp.TextChanged += new System.EventHandler(this.txtNomSousChamp_TextChanged);
            // 
            // lbChamps
            // 
            this.lbChamps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChamps.FormattingEnabled = true;
            this.lbChamps.ItemHeight = 16;
            this.lbChamps.Location = new System.Drawing.Point(12, 29);
            this.lbChamps.Name = "lbChamps";
            this.lbChamps.Size = new System.Drawing.Size(800, 196);
            this.lbChamps.TabIndex = 1;
            this.lbChamps.SelectedIndexChanged += new System.EventHandler(this.lbChamps_SelectedIndexChanged);
            // 
            // lbSousChamps
            // 
            this.lbSousChamps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSousChamps.FormattingEnabled = true;
            this.lbSousChamps.ItemHeight = 16;
            this.lbSousChamps.Location = new System.Drawing.Point(12, 316);
            this.lbSousChamps.Name = "lbSousChamps";
            this.lbSousChamps.Size = new System.Drawing.Size(800, 196);
            this.lbSousChamps.TabIndex = 8;
            this.lbSousChamps.SelectedIndexChanged += new System.EventHandler(this.lbSousChamps_SelectedIndexChanged);
            // 
            // lbActivites
            // 
            this.lbActivites.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbActivites.FormattingEnabled = true;
            this.lbActivites.ItemHeight = 16;
            this.lbActivites.Location = new System.Drawing.Point(12, 603);
            this.lbActivites.Name = "lbActivites";
            this.lbActivites.Size = new System.Drawing.Size(800, 196);
            this.lbActivites.TabIndex = 15;
            this.lbActivites.SelectedIndexChanged += new System.EventHandler(this.lbActivites_SelectedIndexChanged);
            // 
            // btnAjouterChamp
            // 
            this.btnAjouterChamp.Enabled = false;
            this.btnAjouterChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouterChamp.Location = new System.Drawing.Point(12, 263);
            this.btnAjouterChamp.Name = "btnAjouterChamp";
            this.btnAjouterChamp.Size = new System.Drawing.Size(262, 30);
            this.btnAjouterChamp.TabIndex = 4;
            this.btnAjouterChamp.Text = "Ajouter un champ";
            this.btnAjouterChamp.UseVisualStyleBackColor = true;
            this.btnAjouterChamp.Click += new System.EventHandler(this.btnAjouterChamp_Click);
            // 
            // btnModifierChamp
            // 
            this.btnModifierChamp.Enabled = false;
            this.btnModifierChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifierChamp.Location = new System.Drawing.Point(280, 263);
            this.btnModifierChamp.Name = "btnModifierChamp";
            this.btnModifierChamp.Size = new System.Drawing.Size(262, 30);
            this.btnModifierChamp.TabIndex = 5;
            this.btnModifierChamp.Text = "Modifier la champ sélectionné";
            this.btnModifierChamp.UseVisualStyleBackColor = true;
            this.btnModifierChamp.Click += new System.EventHandler(this.btnModifierChamp_Click);
            // 
            // btnSupprimerChamp
            // 
            this.btnSupprimerChamp.Enabled = false;
            this.btnSupprimerChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerChamp.Location = new System.Drawing.Point(548, 263);
            this.btnSupprimerChamp.Name = "btnSupprimerChamp";
            this.btnSupprimerChamp.Size = new System.Drawing.Size(264, 30);
            this.btnSupprimerChamp.TabIndex = 6;
            this.btnSupprimerChamp.Text = "Supprimer la champ sélectionné";
            this.btnSupprimerChamp.UseVisualStyleBackColor = true;
            this.btnSupprimerChamp.Click += new System.EventHandler(this.btnSupprimerChamp_Click);
            // 
            // btnAjouterSousChamp
            // 
            this.btnAjouterSousChamp.Enabled = false;
            this.btnAjouterSousChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouterSousChamp.Location = new System.Drawing.Point(12, 550);
            this.btnAjouterSousChamp.Name = "btnAjouterSousChamp";
            this.btnAjouterSousChamp.Size = new System.Drawing.Size(262, 30);
            this.btnAjouterSousChamp.TabIndex = 11;
            this.btnAjouterSousChamp.Text = "Ajouter un sous-champ";
            this.btnAjouterSousChamp.UseVisualStyleBackColor = true;
            this.btnAjouterSousChamp.Click += new System.EventHandler(this.btnAjouterSousChamp_Click);
            // 
            // btnModifierSousChamp
            // 
            this.btnModifierSousChamp.Enabled = false;
            this.btnModifierSousChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifierSousChamp.Location = new System.Drawing.Point(280, 550);
            this.btnModifierSousChamp.Name = "btnModifierSousChamp";
            this.btnModifierSousChamp.Size = new System.Drawing.Size(262, 30);
            this.btnModifierSousChamp.TabIndex = 12;
            this.btnModifierSousChamp.Text = "Modifier le sous-champ sélectionné";
            this.btnModifierSousChamp.UseVisualStyleBackColor = true;
            this.btnModifierSousChamp.Click += new System.EventHandler(this.btnModifierSousChamp_Click);
            // 
            // btnSupprimerSousChamp
            // 
            this.btnSupprimerSousChamp.Enabled = false;
            this.btnSupprimerSousChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerSousChamp.Location = new System.Drawing.Point(548, 550);
            this.btnSupprimerSousChamp.Name = "btnSupprimerSousChamp";
            this.btnSupprimerSousChamp.Size = new System.Drawing.Size(264, 30);
            this.btnSupprimerSousChamp.TabIndex = 13;
            this.btnSupprimerSousChamp.Text = "Supprimer le sous-champ sélectionné";
            this.btnSupprimerSousChamp.UseVisualStyleBackColor = true;
            this.btnSupprimerSousChamp.Click += new System.EventHandler(this.btnSupprimerSousChamp_Click);
            // 
            // btnAjouterActivite
            // 
            this.btnAjouterActivite.Enabled = false;
            this.btnAjouterActivite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouterActivite.Location = new System.Drawing.Point(12, 837);
            this.btnAjouterActivite.Name = "btnAjouterActivite";
            this.btnAjouterActivite.Size = new System.Drawing.Size(262, 30);
            this.btnAjouterActivite.TabIndex = 18;
            this.btnAjouterActivite.Text = "Ajouter une activité";
            this.btnAjouterActivite.UseVisualStyleBackColor = true;
            this.btnAjouterActivite.Click += new System.EventHandler(this.btnAjouterActivite_Click);
            // 
            // btnModifierActivite
            // 
            this.btnModifierActivite.Enabled = false;
            this.btnModifierActivite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifierActivite.Location = new System.Drawing.Point(280, 837);
            this.btnModifierActivite.Name = "btnModifierActivite";
            this.btnModifierActivite.Size = new System.Drawing.Size(262, 30);
            this.btnModifierActivite.TabIndex = 19;
            this.btnModifierActivite.Text = "Modifier l\'activité sélectionnée";
            this.btnModifierActivite.UseVisualStyleBackColor = true;
            this.btnModifierActivite.Click += new System.EventHandler(this.btnModifierActivite_Click);
            // 
            // btnSupprimerActivite
            // 
            this.btnSupprimerActivite.Enabled = false;
            this.btnSupprimerActivite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerActivite.Location = new System.Drawing.Point(548, 837);
            this.btnSupprimerActivite.Name = "btnSupprimerActivite";
            this.btnSupprimerActivite.Size = new System.Drawing.Size(264, 30);
            this.btnSupprimerActivite.TabIndex = 20;
            this.btnSupprimerActivite.Text = "Supprimer l\'activité sélectionnée";
            this.btnSupprimerActivite.UseVisualStyleBackColor = true;
            this.btnSupprimerActivite.Click += new System.EventHandler(this.btnSupprimerActivite_Click);
            // 
            // lblChamps
            // 
            this.lblChamps.AutoSize = true;
            this.lblChamps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChamps.Location = new System.Drawing.Point(12, 9);
            this.lblChamps.Name = "lblChamps";
            this.lblChamps.Size = new System.Drawing.Size(133, 17);
            this.lblChamps.TabIndex = 0;
            this.lblChamps.Text = "Champs d\'activités :";
            // 
            // lblNomChamp
            // 
            this.lblNomChamp.AutoSize = true;
            this.lblNomChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomChamp.Location = new System.Drawing.Point(12, 237);
            this.lblNomChamp.Name = "lblNomChamp";
            this.lblNomChamp.Size = new System.Drawing.Size(111, 17);
            this.lblNomChamp.TabIndex = 2;
            this.lblNomChamp.Text = "Nom du champ :";
            // 
            // lblSousChamps
            // 
            this.lblSousChamps.AutoSize = true;
            this.lblSousChamps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSousChamps.Location = new System.Drawing.Point(12, 296);
            this.lblSousChamps.Name = "lblSousChamps";
            this.lblSousChamps.Size = new System.Drawing.Size(168, 17);
            this.lblSousChamps.TabIndex = 7;
            this.lblSousChamps.Text = "Sous-champs d\'activités :";
            // 
            // lblNomSousChamp
            // 
            this.lblNomSousChamp.AutoSize = true;
            this.lblNomSousChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomSousChamp.Location = new System.Drawing.Point(12, 524);
            this.lblNomSousChamp.Name = "lblNomSousChamp";
            this.lblNomSousChamp.Size = new System.Drawing.Size(146, 17);
            this.lblNomSousChamp.TabIndex = 9;
            this.lblNomSousChamp.Text = "Nom du sous-champ :";
            // 
            // lblActivites
            // 
            this.lblActivites.AutoSize = true;
            this.lblActivites.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivites.Location = new System.Drawing.Point(12, 583);
            this.lblActivites.Name = "lblActivites";
            this.lblActivites.Size = new System.Drawing.Size(68, 17);
            this.lblActivites.TabIndex = 14;
            this.lblActivites.Text = "Activités :";
            // 
            // lblNomActivite
            // 
            this.lblNomActivite.AutoSize = true;
            this.lblNomActivite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomActivite.Location = new System.Drawing.Point(12, 812);
            this.lblNomActivite.Name = "lblNomActivite";
            this.lblNomActivite.Size = new System.Drawing.Size(119, 17);
            this.lblNomActivite.TabIndex = 16;
            this.lblNomActivite.Text = "Nom de l\'activité :";
            // 
            // frmActivites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 890);
            this.Controls.Add(this.lblNomActivite);
            this.Controls.Add(this.lblActivites);
            this.Controls.Add(this.lblNomSousChamp);
            this.Controls.Add(this.lblSousChamps);
            this.Controls.Add(this.lblNomChamp);
            this.Controls.Add(this.lblChamps);
            this.Controls.Add(this.btnSupprimerActivite);
            this.Controls.Add(this.btnModifierActivite);
            this.Controls.Add(this.btnAjouterActivite);
            this.Controls.Add(this.btnSupprimerSousChamp);
            this.Controls.Add(this.btnModifierSousChamp);
            this.Controls.Add(this.btnAjouterSousChamp);
            this.Controls.Add(this.btnSupprimerChamp);
            this.Controls.Add(this.btnModifierChamp);
            this.Controls.Add(this.btnAjouterChamp);
            this.Controls.Add(this.lbActivites);
            this.Controls.Add(this.lbSousChamps);
            this.Controls.Add(this.lbChamps);
            this.Controls.Add(this.txtNomSousChamp);
            this.Controls.Add(this.txtNomActivite);
            this.Controls.Add(this.txtNomChamp);
            this.Name = "frmActivites";
            this.Text = "frmActivites";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomChamp;
        private System.Windows.Forms.TextBox txtNomActivite;
        private System.Windows.Forms.TextBox txtNomSousChamp;
        private System.Windows.Forms.ListBox lbChamps;
        private System.Windows.Forms.ListBox lbSousChamps;
        private System.Windows.Forms.ListBox lbActivites;
        private System.Windows.Forms.Button btnAjouterChamp;
        private System.Windows.Forms.Button btnModifierChamp;
        private System.Windows.Forms.Button btnSupprimerChamp;
        private System.Windows.Forms.Button btnAjouterSousChamp;
        private System.Windows.Forms.Button btnModifierSousChamp;
        private System.Windows.Forms.Button btnSupprimerSousChamp;
        private System.Windows.Forms.Button btnAjouterActivite;
        private System.Windows.Forms.Button btnModifierActivite;
        private System.Windows.Forms.Button btnSupprimerActivite;
        private System.Windows.Forms.Label lblChamps;
        private System.Windows.Forms.Label lblNomChamp;
        private System.Windows.Forms.Label lblSousChamps;
        private System.Windows.Forms.Label lblNomSousChamp;
        private System.Windows.Forms.Label lblActivites;
        private System.Windows.Forms.Label lblNomActivite;
    }
}