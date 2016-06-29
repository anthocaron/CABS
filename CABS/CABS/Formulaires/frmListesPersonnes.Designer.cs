namespace CABS.Formulaires
{
    partial class frmListesPersonnes
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
            this.btnListeBeneficiaires = new System.Windows.Forms.Button();
            this.btnListeBenevoles = new System.Windows.Forms.Button();
            this.btnListeEmployes = new System.Windows.Forms.Button();
            this.cbBeneficiairesParServices = new System.Windows.Forms.CheckBox();
            this.cbBeneficiairesService = new System.Windows.Forms.CheckBox();
            this.cbBenevolesParServices = new System.Windows.Forms.CheckBox();
            this.cbBenevolesService = new System.Windows.Forms.CheckBox();
            this.cmbServiceBeneficiaires = new System.Windows.Forms.ComboBox();
            this.cmbServiceBenevoles = new System.Windows.Forms.ComboBox();
            this.cbExclureCommentaires = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnListeBeneficiaires
            // 
            this.btnListeBeneficiaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListeBeneficiaires.Location = new System.Drawing.Point(12, 12);
            this.btnListeBeneficiaires.Name = "btnListeBeneficiaires";
            this.btnListeBeneficiaires.Size = new System.Drawing.Size(300, 50);
            this.btnListeBeneficiaires.TabIndex = 0;
            this.btnListeBeneficiaires.Text = "Liste des bénéficiaires";
            this.btnListeBeneficiaires.UseVisualStyleBackColor = true;
            this.btnListeBeneficiaires.Click += new System.EventHandler(this.btnListeBeneficiaires_Click);
            // 
            // btnListeBenevoles
            // 
            this.btnListeBenevoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListeBenevoles.Location = new System.Drawing.Point(12, 68);
            this.btnListeBenevoles.Name = "btnListeBenevoles";
            this.btnListeBenevoles.Size = new System.Drawing.Size(300, 50);
            this.btnListeBenevoles.TabIndex = 4;
            this.btnListeBenevoles.Text = "Liste des bénévoles";
            this.btnListeBenevoles.UseVisualStyleBackColor = true;
            this.btnListeBenevoles.Click += new System.EventHandler(this.btnListeBenevoles_Click);
            // 
            // btnListeEmployes
            // 
            this.btnListeEmployes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListeEmployes.Location = new System.Drawing.Point(12, 124);
            this.btnListeEmployes.Name = "btnListeEmployes";
            this.btnListeEmployes.Size = new System.Drawing.Size(300, 50);
            this.btnListeEmployes.TabIndex = 8;
            this.btnListeEmployes.Text = "Liste des employés";
            this.btnListeEmployes.UseVisualStyleBackColor = true;
            this.btnListeEmployes.Click += new System.EventHandler(this.btnListeEmployes_Click);
            // 
            // cbBeneficiairesParServices
            // 
            this.cbBeneficiairesParServices.AutoSize = true;
            this.cbBeneficiairesParServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBeneficiairesParServices.Location = new System.Drawing.Point(318, 12);
            this.cbBeneficiairesParServices.Name = "cbBeneficiairesParServices";
            this.cbBeneficiairesParServices.Size = new System.Drawing.Size(105, 21);
            this.cbBeneficiairesParServices.TabIndex = 1;
            this.cbBeneficiairesParServices.Text = "Par services";
            this.cbBeneficiairesParServices.UseVisualStyleBackColor = true;
            this.cbBeneficiairesParServices.CheckedChanged += new System.EventHandler(this.cbBeneficiairesParServices_CheckedChanged);
            // 
            // cbBeneficiairesService
            // 
            this.cbBeneficiairesService.AutoSize = true;
            this.cbBeneficiairesService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBeneficiairesService.Location = new System.Drawing.Point(318, 39);
            this.cbBeneficiairesService.Name = "cbBeneficiairesService";
            this.cbBeneficiairesService.Size = new System.Drawing.Size(129, 21);
            this.cbBeneficiairesService.TabIndex = 2;
            this.cbBeneficiairesService.Text = "Pour le service :";
            this.cbBeneficiairesService.UseVisualStyleBackColor = true;
            this.cbBeneficiairesService.CheckedChanged += new System.EventHandler(this.cbBeneficiairesService_CheckedChanged);
            // 
            // cbBenevolesParServices
            // 
            this.cbBenevolesParServices.AutoSize = true;
            this.cbBenevolesParServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBenevolesParServices.Location = new System.Drawing.Point(318, 68);
            this.cbBenevolesParServices.Name = "cbBenevolesParServices";
            this.cbBenevolesParServices.Size = new System.Drawing.Size(105, 21);
            this.cbBenevolesParServices.TabIndex = 5;
            this.cbBenevolesParServices.Text = "Par services";
            this.cbBenevolesParServices.UseVisualStyleBackColor = true;
            this.cbBenevolesParServices.CheckedChanged += new System.EventHandler(this.cbBenevolesParServices_CheckedChanged);
            // 
            // cbBenevolesService
            // 
            this.cbBenevolesService.AutoSize = true;
            this.cbBenevolesService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBenevolesService.Location = new System.Drawing.Point(318, 95);
            this.cbBenevolesService.Name = "cbBenevolesService";
            this.cbBenevolesService.Size = new System.Drawing.Size(129, 21);
            this.cbBenevolesService.TabIndex = 6;
            this.cbBenevolesService.Text = "Pour le service :";
            this.cbBenevolesService.UseVisualStyleBackColor = true;
            this.cbBenevolesService.CheckedChanged += new System.EventHandler(this.cbBenevolesService_CheckedChanged);
            // 
            // cmbServiceBeneficiaires
            // 
            this.cmbServiceBeneficiaires.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceBeneficiaires.Enabled = false;
            this.cmbServiceBeneficiaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbServiceBeneficiaires.FormattingEnabled = true;
            this.cmbServiceBeneficiaires.Location = new System.Drawing.Point(453, 37);
            this.cmbServiceBeneficiaires.Name = "cmbServiceBeneficiaires";
            this.cmbServiceBeneficiaires.Size = new System.Drawing.Size(250, 24);
            this.cmbServiceBeneficiaires.TabIndex = 3;
            // 
            // cmbServiceBenevoles
            // 
            this.cmbServiceBenevoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceBenevoles.Enabled = false;
            this.cmbServiceBenevoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbServiceBenevoles.FormattingEnabled = true;
            this.cmbServiceBenevoles.Location = new System.Drawing.Point(453, 93);
            this.cmbServiceBenevoles.Name = "cmbServiceBenevoles";
            this.cmbServiceBenevoles.Size = new System.Drawing.Size(250, 24);
            this.cmbServiceBenevoles.TabIndex = 7;
            // 
            // cbExclureCommentaires
            // 
            this.cbExclureCommentaires.AutoSize = true;
            this.cbExclureCommentaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbExclureCommentaires.Location = new System.Drawing.Point(12, 180);
            this.cbExclureCommentaires.Name = "cbExclureCommentaires";
            this.cbExclureCommentaires.Size = new System.Drawing.Size(187, 21);
            this.cbExclureCommentaires.TabIndex = 9;
            this.cbExclureCommentaires.Text = "Exclure les commentaires";
            this.cbExclureCommentaires.UseVisualStyleBackColor = true;
            // 
            // frmListesPersonnes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 300);
            this.Controls.Add(this.cbExclureCommentaires);
            this.Controls.Add(this.cmbServiceBenevoles);
            this.Controls.Add(this.cmbServiceBeneficiaires);
            this.Controls.Add(this.cbBenevolesService);
            this.Controls.Add(this.cbBenevolesParServices);
            this.Controls.Add(this.cbBeneficiairesService);
            this.Controls.Add(this.cbBeneficiairesParServices);
            this.Controls.Add(this.btnListeEmployes);
            this.Controls.Add(this.btnListeBenevoles);
            this.Controls.Add(this.btnListeBeneficiaires);
            this.Name = "frmListesPersonnes";
            this.Text = "frmListesPersonnes";
            this.Load += new System.EventHandler(this.frmListesPersonnes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListeBeneficiaires;
        private System.Windows.Forms.Button btnListeBenevoles;
        private System.Windows.Forms.Button btnListeEmployes;
        private System.Windows.Forms.CheckBox cbBeneficiairesParServices;
        private System.Windows.Forms.CheckBox cbBeneficiairesService;
        private System.Windows.Forms.CheckBox cbBenevolesParServices;
        private System.Windows.Forms.CheckBox cbBenevolesService;
        private System.Windows.Forms.ComboBox cmbServiceBeneficiaires;
        private System.Windows.Forms.ComboBox cmbServiceBenevoles;
        private System.Windows.Forms.CheckBox cbExclureCommentaires;
    }
}