namespace CABS.Formulaires
{
    partial class frmGestionLivraisons
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
            this.gbBeneficiaire = new System.Windows.Forms.GroupBox();
            this.lblNomValeur = new System.Windows.Forms.Label();
            this.lblPrenomValeur = new System.Windows.Forms.Label();
            this.btnChoisirBeneficiaire = new System.Windows.Forms.Button();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.mcCalendrier = new CustomControls.MonthCalendar();
            this.gbInfosLivraison = new System.Windows.Forms.GroupBox();
            this.lblPRepas = new System.Windows.Forms.Label();
            this.lblPrixRepasValeur = new System.Windows.Forms.Label();
            this.lblNbRepasValeur = new System.Windows.Forms.Label();
            this.lblDateValeur = new System.Windows.Forms.Label();
            this.lblNbRepas = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.gbGestionLivraisons = new System.Windows.Forms.GroupBox();
            this.nudPrixRepas = new System.Windows.Forms.NumericUpDown();
            this.lblPrixRepas = new System.Windows.Forms.Label();
            this.btnSupprimerLivraisons = new System.Windows.Forms.Button();
            this.cbFinDeSemaine = new System.Windows.Forms.CheckBox();
            this.nudNombreRepas = new System.Windows.Forms.NumericUpDown();
            this.lblNombreRepas = new System.Windows.Forms.Label();
            this.cbVendredi = new System.Windows.Forms.CheckBox();
            this.btnAjouterLivraisons = new System.Windows.Forms.Button();
            this.dtpA = new System.Windows.Forms.DateTimePicker();
            this.lblA = new System.Windows.Forms.Label();
            this.lblDe = new System.Windows.Forms.Label();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.lblFrequence = new System.Windows.Forms.Label();
            this.cmbFrequence = new System.Windows.Forms.ComboBox();
            this.cbDimanche = new System.Windows.Forms.CheckBox();
            this.cbSamedi = new System.Windows.Forms.CheckBox();
            this.cbJeudi = new System.Windows.Forms.CheckBox();
            this.cbMercredi = new System.Windows.Forms.CheckBox();
            this.cbMardi = new System.Windows.Forms.CheckBox();
            this.cbLundi = new System.Windows.Forms.CheckBox();
            this.btnInscription = new System.Windows.Forms.Button();
            this.gbBeneficiaire.SuspendLayout();
            this.gbInfosLivraison.SuspendLayout();
            this.gbGestionLivraisons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrixRepas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNombreRepas)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBeneficiaire
            // 
            this.gbBeneficiaire.Controls.Add(this.lblNomValeur);
            this.gbBeneficiaire.Controls.Add(this.lblPrenomValeur);
            this.gbBeneficiaire.Controls.Add(this.btnChoisirBeneficiaire);
            this.gbBeneficiaire.Controls.Add(this.lblNom);
            this.gbBeneficiaire.Controls.Add(this.lblPrenom);
            this.gbBeneficiaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBeneficiaire.Location = new System.Drawing.Point(19, 19);
            this.gbBeneficiaire.Margin = new System.Windows.Forms.Padding(10);
            this.gbBeneficiaire.Name = "gbBeneficiaire";
            this.gbBeneficiaire.Size = new System.Drawing.Size(620, 51);
            this.gbBeneficiaire.TabIndex = 0;
            this.gbBeneficiaire.TabStop = false;
            this.gbBeneficiaire.Text = "Bénéficiaire";
            // 
            // lblNomValeur
            // 
            this.lblNomValeur.BackColor = System.Drawing.Color.White;
            this.lblNomValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNomValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomValeur.Location = new System.Drawing.Point(356, 22);
            this.lblNomValeur.Margin = new System.Windows.Forms.Padding(3);
            this.lblNomValeur.Name = "lblNomValeur";
            this.lblNomValeur.Size = new System.Drawing.Size(222, 23);
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
            this.lblPrenomValeur.Size = new System.Drawing.Size(222, 23);
            this.lblPrenomValeur.TabIndex = 1;
            this.lblPrenomValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChoisirBeneficiaire
            // 
            this.btnChoisirBeneficiaire.Image = global::CABS.Properties.Resources._16px_Magnifying_glass_icon;
            this.btnChoisirBeneficiaire.Location = new System.Drawing.Point(584, 18);
            this.btnChoisirBeneficiaire.Name = "btnChoisirBeneficiaire";
            this.btnChoisirBeneficiaire.Size = new System.Drawing.Size(30, 30);
            this.btnChoisirBeneficiaire.TabIndex = 4;
            this.btnChoisirBeneficiaire.UseVisualStyleBackColor = true;
            this.btnChoisirBeneficiaire.Click += new System.EventHandler(this.btnChoisirBeneficiaire_Click);
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(305, 25);
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
            // mcCalendrier
            // 
            this.mcCalendrier.CalendarDimensions = new System.Drawing.Size(3, 1);
            this.mcCalendrier.ColorTable.Border = System.Drawing.Color.DodgerBlue;
            this.mcCalendrier.ColorTable.DayActiveGradientBegin = System.Drawing.Color.DodgerBlue;
            this.mcCalendrier.ColorTable.DayActiveTodayCircleBorder = System.Drawing.Color.Transparent;
            this.mcCalendrier.ColorTable.DaySelectedGradientBegin = System.Drawing.Color.DodgerBlue;
            this.mcCalendrier.ColorTable.DaySelectedText = System.Drawing.Color.White;
            this.mcCalendrier.ColorTable.DaySelectedTodayCircleBorder = System.Drawing.Color.Transparent;
            this.mcCalendrier.ColorTable.DayTodayCircleBorder = System.Drawing.Color.Transparent;
            this.mcCalendrier.ColorTable.FooterTodayCircleBorder = System.Drawing.Color.Transparent;
            this.mcCalendrier.ColorTable.HeaderActiveGradientBegin = System.Drawing.Color.DodgerBlue;
            this.mcCalendrier.ColorTable.HeaderArrow = System.Drawing.Color.White;
            this.mcCalendrier.ColorTable.HeaderGradientBegin = System.Drawing.Color.DodgerBlue;
            this.mcCalendrier.ColorTable.HeaderText = System.Drawing.Color.White;
            this.mcCalendrier.ColorTable.MonthSeparator = System.Drawing.Color.DodgerBlue;
            this.mcCalendrier.Enabled = false;
            this.mcCalendrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mcCalendrier.Location = new System.Drawing.Point(19, 90);
            this.mcCalendrier.Margin = new System.Windows.Forms.Padding(10);
            this.mcCalendrier.Name = "mcCalendrier";
            this.mcCalendrier.SelectionMode = CustomControls.MonthCalendarSelectionMode.Day;
            this.mcCalendrier.SelectionRange = new System.Windows.Forms.SelectionRange(new System.DateTime(2015, 7, 23, 0, 0, 0, 0), new System.DateTime(2015, 7, 23, 0, 0, 0, 0));
            this.mcCalendrier.ShowFooter = false;
            this.mcCalendrier.ShowWeekHeader = false;
            this.mcCalendrier.TabIndex = 2;
            this.mcCalendrier.DateSelected += new System.EventHandler<System.Windows.Forms.DateRangeEventArgs>(this.mcCalendrier_DateSelected);
            // 
            // gbInfosLivraison
            // 
            this.gbInfosLivraison.Controls.Add(this.lblPRepas);
            this.gbInfosLivraison.Controls.Add(this.lblPrixRepasValeur);
            this.gbInfosLivraison.Controls.Add(this.lblNbRepasValeur);
            this.gbInfosLivraison.Controls.Add(this.lblDateValeur);
            this.gbInfosLivraison.Controls.Add(this.lblNbRepas);
            this.gbInfosLivraison.Controls.Add(this.lblDate);
            this.gbInfosLivraison.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInfosLivraison.Location = new System.Drawing.Point(19, 262);
            this.gbInfosLivraison.Margin = new System.Windows.Forms.Padding(10);
            this.gbInfosLivraison.Name = "gbInfosLivraison";
            this.gbInfosLivraison.Size = new System.Drawing.Size(193, 117);
            this.gbInfosLivraison.TabIndex = 3;
            this.gbInfosLivraison.TabStop = false;
            this.gbInfosLivraison.Text = "Infos livraison";
            // 
            // lblPRepas
            // 
            this.lblPRepas.AutoSize = true;
            this.lblPRepas.Location = new System.Drawing.Point(6, 83);
            this.lblPRepas.Margin = new System.Windows.Forms.Padding(3);
            this.lblPRepas.Name = "lblPRepas";
            this.lblPRepas.Size = new System.Drawing.Size(84, 17);
            this.lblPRepas.TabIndex = 4;
            this.lblPRepas.Text = "Prix/Repas :";
            // 
            // lblPrixRepasValeur
            // 
            this.lblPrixRepasValeur.BackColor = System.Drawing.Color.White;
            this.lblPrixRepasValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPrixRepasValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrixRepasValeur.Location = new System.Drawing.Point(96, 80);
            this.lblPrixRepasValeur.Margin = new System.Windows.Forms.Padding(3);
            this.lblPrixRepasValeur.Name = "lblPrixRepasValeur";
            this.lblPrixRepasValeur.Size = new System.Drawing.Size(91, 23);
            this.lblPrixRepasValeur.TabIndex = 5;
            this.lblPrixRepasValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNbRepasValeur
            // 
            this.lblNbRepasValeur.BackColor = System.Drawing.Color.White;
            this.lblNbRepasValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNbRepasValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbRepasValeur.Location = new System.Drawing.Point(90, 51);
            this.lblNbRepasValeur.Margin = new System.Windows.Forms.Padding(3);
            this.lblNbRepasValeur.Name = "lblNbRepasValeur";
            this.lblNbRepasValeur.Size = new System.Drawing.Size(97, 23);
            this.lblNbRepasValeur.TabIndex = 3;
            this.lblNbRepasValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateValeur
            // 
            this.lblDateValeur.BackColor = System.Drawing.Color.White;
            this.lblDateValeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateValeur.Location = new System.Drawing.Point(58, 22);
            this.lblDateValeur.Margin = new System.Windows.Forms.Padding(3);
            this.lblDateValeur.Name = "lblDateValeur";
            this.lblDateValeur.Size = new System.Drawing.Size(129, 23);
            this.lblDateValeur.TabIndex = 1;
            this.lblDateValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNbRepas
            // 
            this.lblNbRepas.AutoSize = true;
            this.lblNbRepas.Location = new System.Drawing.Point(6, 54);
            this.lblNbRepas.Margin = new System.Windows.Forms.Padding(3);
            this.lblNbRepas.Name = "lblNbRepas";
            this.lblNbRepas.Size = new System.Drawing.Size(78, 17);
            this.lblNbRepas.TabIndex = 2;
            this.lblNbRepas.Text = "Nb. repas :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 25);
            this.lblDate.Margin = new System.Windows.Forms.Padding(3);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(46, 17);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date :";
            // 
            // gbGestionLivraisons
            // 
            this.gbGestionLivraisons.Controls.Add(this.nudPrixRepas);
            this.gbGestionLivraisons.Controls.Add(this.lblPrixRepas);
            this.gbGestionLivraisons.Controls.Add(this.btnSupprimerLivraisons);
            this.gbGestionLivraisons.Controls.Add(this.cbFinDeSemaine);
            this.gbGestionLivraisons.Controls.Add(this.nudNombreRepas);
            this.gbGestionLivraisons.Controls.Add(this.lblNombreRepas);
            this.gbGestionLivraisons.Controls.Add(this.cbVendredi);
            this.gbGestionLivraisons.Controls.Add(this.btnAjouterLivraisons);
            this.gbGestionLivraisons.Controls.Add(this.dtpA);
            this.gbGestionLivraisons.Controls.Add(this.lblA);
            this.gbGestionLivraisons.Controls.Add(this.lblDe);
            this.gbGestionLivraisons.Controls.Add(this.dtpDe);
            this.gbGestionLivraisons.Controls.Add(this.lblFrequence);
            this.gbGestionLivraisons.Controls.Add(this.cmbFrequence);
            this.gbGestionLivraisons.Controls.Add(this.cbDimanche);
            this.gbGestionLivraisons.Controls.Add(this.cbSamedi);
            this.gbGestionLivraisons.Controls.Add(this.cbJeudi);
            this.gbGestionLivraisons.Controls.Add(this.cbMercredi);
            this.gbGestionLivraisons.Controls.Add(this.cbMardi);
            this.gbGestionLivraisons.Controls.Add(this.cbLundi);
            this.gbGestionLivraisons.Enabled = false;
            this.gbGestionLivraisons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGestionLivraisons.Location = new System.Drawing.Point(232, 262);
            this.gbGestionLivraisons.Margin = new System.Windows.Forms.Padding(10);
            this.gbGestionLivraisons.Name = "gbGestionLivraisons";
            this.gbGestionLivraisons.Size = new System.Drawing.Size(407, 231);
            this.gbGestionLivraisons.TabIndex = 4;
            this.gbGestionLivraisons.TabStop = false;
            this.gbGestionLivraisons.Text = "Enregistrer/Supprimer livraisons";
            // 
            // nudPrixRepas
            // 
            this.nudPrixRepas.DecimalPlaces = 2;
            this.nudPrixRepas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPrixRepas.Location = new System.Drawing.Point(143, 184);
            this.nudPrixRepas.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.nudPrixRepas.Name = "nudPrixRepas";
            this.nudPrixRepas.Size = new System.Drawing.Size(69, 23);
            this.nudPrixRepas.TabIndex = 17;
            this.nudPrixRepas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPrixRepas.ThousandsSeparator = true;
            // 
            // lblPrixRepas
            // 
            this.lblPrixRepas.AutoSize = true;
            this.lblPrixRepas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrixRepas.Location = new System.Drawing.Point(8, 186);
            this.lblPrixRepas.Name = "lblPrixRepas";
            this.lblPrixRepas.Size = new System.Drawing.Size(84, 17);
            this.lblPrixRepas.TabIndex = 16;
            this.lblPrixRepas.Text = "Prix/Repas :";
            // 
            // btnSupprimerLivraisons
            // 
            this.btnSupprimerLivraisons.Location = new System.Drawing.Point(222, 193);
            this.btnSupprimerLivraisons.Margin = new System.Windows.Forms.Padding(5);
            this.btnSupprimerLivraisons.Name = "btnSupprimerLivraisons";
            this.btnSupprimerLivraisons.Size = new System.Drawing.Size(161, 30);
            this.btnSupprimerLivraisons.TabIndex = 19;
            this.btnSupprimerLivraisons.Text = "Supprimer";
            this.btnSupprimerLivraisons.UseVisualStyleBackColor = true;
            this.btnSupprimerLivraisons.Click += new System.EventHandler(this.btnSupprimerLivraisons_Click);
            // 
            // cbFinDeSemaine
            // 
            this.cbFinDeSemaine.AutoSize = true;
            this.cbFinDeSemaine.Location = new System.Drawing.Point(278, 26);
            this.cbFinDeSemaine.Name = "cbFinDeSemaine";
            this.cbFinDeSemaine.Size = new System.Drawing.Size(123, 21);
            this.cbFinDeSemaine.TabIndex = 2;
            this.cbFinDeSemaine.Text = "Fin de semaine";
            this.cbFinDeSemaine.UseVisualStyleBackColor = true;
            // 
            // nudNombreRepas
            // 
            this.nudNombreRepas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNombreRepas.Location = new System.Drawing.Point(144, 153);
            this.nudNombreRepas.Margin = new System.Windows.Forms.Padding(5);
            this.nudNombreRepas.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudNombreRepas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNombreRepas.Name = "nudNombreRepas";
            this.nudNombreRepas.Size = new System.Drawing.Size(68, 23);
            this.nudNombreRepas.TabIndex = 15;
            this.nudNombreRepas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNombreRepas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNombreRepas
            // 
            this.lblNombreRepas.AutoSize = true;
            this.lblNombreRepas.Location = new System.Drawing.Point(8, 155);
            this.lblNombreRepas.Margin = new System.Windows.Forms.Padding(5);
            this.lblNombreRepas.Name = "lblNombreRepas";
            this.lblNombreRepas.Size = new System.Drawing.Size(126, 17);
            this.lblNombreRepas.TabIndex = 14;
            this.lblNombreRepas.Text = "Nombre de repas :";
            // 
            // cbVendredi
            // 
            this.cbVendredi.AutoSize = true;
            this.cbVendredi.Location = new System.Drawing.Point(315, 58);
            this.cbVendredi.Margin = new System.Windows.Forms.Padding(5);
            this.cbVendredi.Name = "cbVendredi";
            this.cbVendredi.Size = new System.Drawing.Size(84, 21);
            this.cbVendredi.TabIndex = 7;
            this.cbVendredi.Text = "Vendredi";
            this.cbVendredi.UseVisualStyleBackColor = true;
            // 
            // btnAjouterLivraisons
            // 
            this.btnAjouterLivraisons.Location = new System.Drawing.Point(222, 153);
            this.btnAjouterLivraisons.Margin = new System.Windows.Forms.Padding(5);
            this.btnAjouterLivraisons.Name = "btnAjouterLivraisons";
            this.btnAjouterLivraisons.Size = new System.Drawing.Size(161, 30);
            this.btnAjouterLivraisons.TabIndex = 18;
            this.btnAjouterLivraisons.Text = "Enregistrer";
            this.btnAjouterLivraisons.UseVisualStyleBackColor = true;
            this.btnAjouterLivraisons.Click += new System.EventHandler(this.btnAjouterLivraisons_Click);
            // 
            // dtpA
            // 
            this.dtpA.Location = new System.Drawing.Point(249, 120);
            this.dtpA.Margin = new System.Windows.Forms.Padding(5);
            this.dtpA.Name = "dtpA";
            this.dtpA.Size = new System.Drawing.Size(150, 23);
            this.dtpA.TabIndex = 13;
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(214, 125);
            this.lblA.Margin = new System.Windows.Forms.Padding(5);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(25, 17);
            this.lblA.TabIndex = 12;
            this.lblA.Text = "À :";
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(8, 125);
            this.lblDe.Margin = new System.Windows.Forms.Padding(5);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(34, 17);
            this.lblDe.TabIndex = 10;
            this.lblDe.Text = "De :";
            // 
            // dtpDe
            // 
            this.dtpDe.Location = new System.Drawing.Point(52, 120);
            this.dtpDe.Margin = new System.Windows.Forms.Padding(5);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(152, 23);
            this.dtpDe.TabIndex = 11;
            // 
            // lblFrequence
            // 
            this.lblFrequence.AutoSize = true;
            this.lblFrequence.Location = new System.Drawing.Point(8, 27);
            this.lblFrequence.Margin = new System.Windows.Forms.Padding(5);
            this.lblFrequence.Name = "lblFrequence";
            this.lblFrequence.Size = new System.Drawing.Size(84, 17);
            this.lblFrequence.TabIndex = 0;
            this.lblFrequence.Text = "Fréquence :";
            // 
            // cmbFrequence
            // 
            this.cmbFrequence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrequence.FormattingEnabled = true;
            this.cmbFrequence.Items.AddRange(new object[] {
            "Date sélectionnée",
            "Jour",
            "Semaine"});
            this.cmbFrequence.Location = new System.Drawing.Point(102, 24);
            this.cmbFrequence.Margin = new System.Windows.Forms.Padding(5);
            this.cmbFrequence.Name = "cmbFrequence";
            this.cmbFrequence.Size = new System.Drawing.Size(168, 24);
            this.cmbFrequence.TabIndex = 1;
            this.cmbFrequence.SelectedIndexChanged += new System.EventHandler(this.cmbFrequence_SelectedIndexChanged);
            // 
            // cbDimanche
            // 
            this.cbDimanche.AutoSize = true;
            this.cbDimanche.Location = new System.Drawing.Point(92, 89);
            this.cbDimanche.Margin = new System.Windows.Forms.Padding(5);
            this.cbDimanche.Name = "cbDimanche";
            this.cbDimanche.Size = new System.Drawing.Size(90, 21);
            this.cbDimanche.TabIndex = 9;
            this.cbDimanche.Text = "Dimanche";
            this.cbDimanche.UseVisualStyleBackColor = true;
            // 
            // cbSamedi
            // 
            this.cbSamedi.AutoSize = true;
            this.cbSamedi.Location = new System.Drawing.Point(8, 89);
            this.cbSamedi.Margin = new System.Windows.Forms.Padding(5);
            this.cbSamedi.Name = "cbSamedi";
            this.cbSamedi.Size = new System.Drawing.Size(74, 21);
            this.cbSamedi.TabIndex = 8;
            this.cbSamedi.Text = "Samedi";
            this.cbSamedi.UseVisualStyleBackColor = true;
            // 
            // cbJeudi
            // 
            this.cbJeudi.AutoSize = true;
            this.cbJeudi.Location = new System.Drawing.Point(244, 58);
            this.cbJeudi.Margin = new System.Windows.Forms.Padding(5);
            this.cbJeudi.Name = "cbJeudi";
            this.cbJeudi.Size = new System.Drawing.Size(61, 21);
            this.cbJeudi.TabIndex = 6;
            this.cbJeudi.Text = "Jeudi";
            this.cbJeudi.UseVisualStyleBackColor = true;
            // 
            // cbMercredi
            // 
            this.cbMercredi.AutoSize = true;
            this.cbMercredi.Location = new System.Drawing.Point(152, 58);
            this.cbMercredi.Margin = new System.Windows.Forms.Padding(5);
            this.cbMercredi.Name = "cbMercredi";
            this.cbMercredi.Size = new System.Drawing.Size(82, 21);
            this.cbMercredi.TabIndex = 5;
            this.cbMercredi.Text = "Mercredi";
            this.cbMercredi.UseVisualStyleBackColor = true;
            // 
            // cbMardi
            // 
            this.cbMardi.AutoSize = true;
            this.cbMardi.Location = new System.Drawing.Point(80, 58);
            this.cbMardi.Margin = new System.Windows.Forms.Padding(5);
            this.cbMardi.Name = "cbMardi";
            this.cbMardi.Size = new System.Drawing.Size(62, 21);
            this.cbMardi.TabIndex = 4;
            this.cbMardi.Text = "Mardi";
            this.cbMardi.UseVisualStyleBackColor = true;
            // 
            // cbLundi
            // 
            this.cbLundi.AutoSize = true;
            this.cbLundi.Location = new System.Drawing.Point(8, 58);
            this.cbLundi.Margin = new System.Windows.Forms.Padding(5);
            this.cbLundi.Name = "cbLundi";
            this.cbLundi.Size = new System.Drawing.Size(62, 21);
            this.cbLundi.TabIndex = 3;
            this.cbLundi.Text = "Lundi";
            this.cbLundi.UseVisualStyleBackColor = true;
            // 
            // btnInscription
            // 
            this.btnInscription.Enabled = false;
            this.btnInscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInscription.Location = new System.Drawing.Point(652, 37);
            this.btnInscription.Name = "btnInscription";
            this.btnInscription.Size = new System.Drawing.Size(151, 30);
            this.btnInscription.TabIndex = 1;
            this.btnInscription.Text = "Fiche d\'inscription...";
            this.btnInscription.UseVisualStyleBackColor = true;
            this.btnInscription.Click += new System.EventHandler(this.btnInscription_Click);
            // 
            // frmGestionLivraisons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 647);
            this.Controls.Add(this.btnInscription);
            this.Controls.Add(this.gbGestionLivraisons);
            this.Controls.Add(this.gbInfosLivraison);
            this.Controls.Add(this.mcCalendrier);
            this.Controls.Add(this.gbBeneficiaire);
            this.Name = "frmGestionLivraisons";
            this.Text = "frmGestionLivraisons";
            this.Load += new System.EventHandler(this.frmGestionLivraisons_Load);
            this.gbBeneficiaire.ResumeLayout(false);
            this.gbBeneficiaire.PerformLayout();
            this.gbInfosLivraison.ResumeLayout(false);
            this.gbInfosLivraison.PerformLayout();
            this.gbGestionLivraisons.ResumeLayout(false);
            this.gbGestionLivraisons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrixRepas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNombreRepas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBeneficiaire;
        private System.Windows.Forms.Label lblNomValeur;
        private System.Windows.Forms.Label lblPrenomValeur;
        private System.Windows.Forms.Button btnChoisirBeneficiaire;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private CustomControls.MonthCalendar mcCalendrier;
        private System.Windows.Forms.GroupBox gbInfosLivraison;
        private System.Windows.Forms.GroupBox gbGestionLivraisons;
        private System.Windows.Forms.Label lblNbRepas;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbFrequence;
        private System.Windows.Forms.CheckBox cbDimanche;
        private System.Windows.Forms.CheckBox cbSamedi;
        private System.Windows.Forms.CheckBox cbVendredi;
        private System.Windows.Forms.CheckBox cbJeudi;
        private System.Windows.Forms.CheckBox cbMercredi;
        private System.Windows.Forms.CheckBox cbMardi;
        private System.Windows.Forms.CheckBox cbLundi;
        private System.Windows.Forms.Label lblNbRepasValeur;
        private System.Windows.Forms.Label lblDateValeur;
        private System.Windows.Forms.Label lblFrequence;
        private System.Windows.Forms.DateTimePicker dtpA;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.Button btnAjouterLivraisons;
        private System.Windows.Forms.Label lblNombreRepas;
        private System.Windows.Forms.NumericUpDown nudNombreRepas;
        private System.Windows.Forms.CheckBox cbFinDeSemaine;
        private System.Windows.Forms.Button btnSupprimerLivraisons;
        private System.Windows.Forms.Button btnInscription;
        private System.Windows.Forms.NumericUpDown nudPrixRepas;
        private System.Windows.Forms.Label lblPrixRepas;
        private System.Windows.Forms.Label lblPRepas;
        private System.Windows.Forms.Label lblPrixRepasValeur;
    }
}