namespace CABS.Formulaires
{
    partial class frmFeuillesRoute
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
            this.btnGenererFeuille = new System.Windows.Forms.Button();
            this.clbRoutes = new System.Windows.Forms.CheckedListBox();
            this.mcDateLivraisons = new CustomControls.MonthCalendar();
            this.gbSections = new System.Windows.Forms.GroupBox();
            this.cbSommaireLivraisons = new System.Windows.Forms.CheckBox();
            this.cbSommaireRoute = new System.Windows.Forms.CheckBox();
            this.cbDetailRoute = new System.Windows.Forms.CheckBox();
            this.cbBeneficiairesNonClasses = new System.Windows.Forms.CheckBox();
            this.gbSections.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenererFeuille
            // 
            this.btnGenererFeuille.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenererFeuille.Location = new System.Drawing.Point(405, 191);
            this.btnGenererFeuille.Margin = new System.Windows.Forms.Padding(10);
            this.btnGenererFeuille.Name = "btnGenererFeuille";
            this.btnGenererFeuille.Size = new System.Drawing.Size(188, 95);
            this.btnGenererFeuille.TabIndex = 4;
            this.btnGenererFeuille.Text = "Générer la feuille de route";
            this.btnGenererFeuille.UseVisualStyleBackColor = true;
            this.btnGenererFeuille.Click += new System.EventHandler(this.btnGenererFeuille_Click);
            // 
            // clbRoutes
            // 
            this.clbRoutes.CheckOnClick = true;
            this.clbRoutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbRoutes.FormattingEnabled = true;
            this.clbRoutes.Location = new System.Drawing.Point(405, 19);
            this.clbRoutes.Margin = new System.Windows.Forms.Padding(10);
            this.clbRoutes.Name = "clbRoutes";
            this.clbRoutes.Size = new System.Drawing.Size(188, 148);
            this.clbRoutes.TabIndex = 1;
            // 
            // mcDateLivraisons
            // 
            this.mcDateLivraisons.CalendarDimensions = new System.Drawing.Size(2, 1);
            this.mcDateLivraisons.ColorTable.Border = System.Drawing.Color.DodgerBlue;
            this.mcDateLivraisons.ColorTable.DayActiveGradientBegin = System.Drawing.Color.DodgerBlue;
            this.mcDateLivraisons.ColorTable.DayActiveTodayCircleBorder = System.Drawing.Color.Transparent;
            this.mcDateLivraisons.ColorTable.DaySelectedGradientBegin = System.Drawing.Color.DodgerBlue;
            this.mcDateLivraisons.ColorTable.DaySelectedText = System.Drawing.Color.White;
            this.mcDateLivraisons.ColorTable.DaySelectedTodayCircleBorder = System.Drawing.Color.Transparent;
            this.mcDateLivraisons.ColorTable.DayTodayCircleBorder = System.Drawing.Color.Transparent;
            this.mcDateLivraisons.ColorTable.FooterTodayCircleBorder = System.Drawing.Color.Transparent;
            this.mcDateLivraisons.ColorTable.HeaderActiveGradientBegin = System.Drawing.Color.DodgerBlue;
            this.mcDateLivraisons.ColorTable.HeaderArrow = System.Drawing.Color.White;
            this.mcDateLivraisons.ColorTable.HeaderGradientBegin = System.Drawing.Color.DodgerBlue;
            this.mcDateLivraisons.ColorTable.HeaderText = System.Drawing.Color.White;
            this.mcDateLivraisons.ColorTable.MonthSeparator = System.Drawing.Color.DodgerBlue;
            this.mcDateLivraisons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mcDateLivraisons.Location = new System.Drawing.Point(19, 19);
            this.mcDateLivraisons.Margin = new System.Windows.Forms.Padding(10);
            this.mcDateLivraisons.Name = "mcDateLivraisons";
            this.mcDateLivraisons.SelectionMode = CustomControls.MonthCalendarSelectionMode.Day;
            this.mcDateLivraisons.SelectionRange = new System.Windows.Forms.SelectionRange(new System.DateTime(2015, 7, 23, 0, 0, 0, 0), new System.DateTime(2015, 7, 23, 0, 0, 0, 0));
            this.mcDateLivraisons.ShowFooter = false;
            this.mcDateLivraisons.ShowWeekHeader = false;
            this.mcDateLivraisons.TabIndex = 0;
            // 
            // gbSections
            // 
            this.gbSections.Controls.Add(this.cbSommaireLivraisons);
            this.gbSections.Controls.Add(this.cbSommaireRoute);
            this.gbSections.Controls.Add(this.cbDetailRoute);
            this.gbSections.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSections.Location = new System.Drawing.Point(19, 191);
            this.gbSections.Margin = new System.Windows.Forms.Padding(10);
            this.gbSections.Name = "gbSections";
            this.gbSections.Size = new System.Drawing.Size(206, 115);
            this.gbSections.TabIndex = 2;
            this.gbSections.TabStop = false;
            this.gbSections.Text = "Sections à imprimer";
            // 
            // cbSommaireLivraisons
            // 
            this.cbSommaireLivraisons.AutoSize = true;
            this.cbSommaireLivraisons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSommaireLivraisons.Location = new System.Drawing.Point(13, 86);
            this.cbSommaireLivraisons.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.cbSommaireLivraisons.Name = "cbSommaireLivraisons";
            this.cbSommaireLivraisons.Size = new System.Drawing.Size(180, 21);
            this.cbSommaireLivraisons.TabIndex = 2;
            this.cbSommaireLivraisons.Text = "Sommaire des livraisons";
            this.cbSommaireLivraisons.UseVisualStyleBackColor = true;
            // 
            // cbSommaireRoute
            // 
            this.cbSommaireRoute.AutoSize = true;
            this.cbSommaireRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSommaireRoute.Location = new System.Drawing.Point(13, 55);
            this.cbSommaireRoute.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.cbSommaireRoute.Name = "cbSommaireRoute";
            this.cbSommaireRoute.Size = new System.Drawing.Size(162, 21);
            this.cbSommaireRoute.TabIndex = 1;
            this.cbSommaireRoute.Text = "Sommaire de la route";
            this.cbSommaireRoute.UseVisualStyleBackColor = true;
            // 
            // cbDetailRoute
            // 
            this.cbDetailRoute.AutoSize = true;
            this.cbDetailRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDetailRoute.Location = new System.Drawing.Point(13, 24);
            this.cbDetailRoute.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.cbDetailRoute.Name = "cbDetailRoute";
            this.cbDetailRoute.Size = new System.Drawing.Size(135, 21);
            this.cbDetailRoute.TabIndex = 0;
            this.cbDetailRoute.Text = "Détail de la route";
            this.cbDetailRoute.UseVisualStyleBackColor = true;
            // 
            // cbBeneficiairesNonClasses
            // 
            this.cbBeneficiairesNonClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBeneficiairesNonClasses.Location = new System.Drawing.Point(245, 206);
            this.cbBeneficiairesNonClasses.Margin = new System.Windows.Forms.Padding(10);
            this.cbBeneficiairesNonClasses.Name = "cbBeneficiairesNonClasses";
            this.cbBeneficiairesNonClasses.Size = new System.Drawing.Size(111, 38);
            this.cbBeneficiairesNonClasses.TabIndex = 3;
            this.cbBeneficiairesNonClasses.Text = "Bénéficiaires non classés";
            this.cbBeneficiairesNonClasses.UseVisualStyleBackColor = true;
            // 
            // frmFeuillesRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 628);
            this.Controls.Add(this.cbBeneficiairesNonClasses);
            this.Controls.Add(this.btnGenererFeuille);
            this.Controls.Add(this.clbRoutes);
            this.Controls.Add(this.mcDateLivraisons);
            this.Controls.Add(this.gbSections);
            this.Name = "frmFeuillesRoute";
            this.Text = "frmFeuillesRoute";
            this.gbSections.ResumeLayout(false);
            this.gbSections.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSections;
        private System.Windows.Forms.CheckBox cbSommaireLivraisons;
        private System.Windows.Forms.CheckBox cbSommaireRoute;
        private System.Windows.Forms.CheckBox cbDetailRoute;
        private CustomControls.MonthCalendar mcDateLivraisons;
        private System.Windows.Forms.CheckedListBox clbRoutes;
        private System.Windows.Forms.Button btnGenererFeuille;
        private System.Windows.Forms.CheckBox cbBeneficiairesNonClasses;
    }
}