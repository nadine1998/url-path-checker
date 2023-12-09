namespace CheckPath
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            urlTextBox = new TextBox();
            loadCsvButton = new Button();
            analyzeButton = new Button();
            rapportButton = new Button();
            label1 = new Label();
            progessLabel = new Label();
            chargementLabel = new Label();
            label3 = new Label();
            routeLabel = new Label();
            listeVulBox = new ListBox();
            label2 = new Label();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            chargerToolStripMenuItem = new ToolStripMenuItem();
            analyserToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            quitterToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // urlTextBox
            // 
            urlTextBox.Location = new Point(114, 41);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.PlaceholderText = "Entrez URL";
            urlTextBox.Size = new Size(398, 27);
            urlTextBox.TabIndex = 0;
            // 
            // loadCsvButton
            // 
            loadCsvButton.Location = new Point(563, 39);
            loadCsvButton.Name = "loadCsvButton";
            loadCsvButton.Size = new Size(94, 29);
            loadCsvButton.TabIndex = 1;
            loadCsvButton.Text = "Charger CSV";
            loadCsvButton.UseVisualStyleBackColor = true;
            loadCsvButton.Click += loadCsvButton_Click;
            // 
            // analyzeButton
            // 
            analyzeButton.Location = new Point(679, 39);
            analyzeButton.Name = "analyzeButton";
            analyzeButton.Size = new Size(94, 29);
            analyzeButton.TabIndex = 2;
            analyzeButton.Text = "Analyser";
            analyzeButton.UseVisualStyleBackColor = true;
            analyzeButton.Click += analyzeButton_Click;
            // 
            // rapportButton
            // 
            rapportButton.Location = new Point(347, 397);
            rapportButton.Name = "rapportButton";
            rapportButton.Size = new Size(174, 29);
            rapportButton.TabIndex = 3;
            rapportButton.Text = "Générer rapport";
            rapportButton.UseVisualStyleBackColor = true;
            rapportButton.Click += rapportButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(114, 89);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 4;
            label1.Text = "Chargement :";
            // 
            // progessLabel
            // 
            progessLabel.AutoSize = true;
            progessLabel.Location = new Point(237, 89);
            progessLabel.Name = "progessLabel";
            progessLabel.Size = new Size(0, 20);
            progessLabel.TabIndex = 5;
            // 
            // chargementLabel
            // 
            chargementLabel.AutoSize = true;
            chargementLabel.Location = new Point(217, 89);
            chargementLabel.Name = "chargementLabel";
            chargementLabel.Size = new Size(0, 23);
            chargementLabel.TabIndex = 7;
            chargementLabel.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(114, 150);
            label3.Name = "label3";
            label3.Size = new Size(126, 20);
            label3.TabIndex = 8;
            label3.Text = "Route parcourue :";
            // 
            // routeLabel
            // 
            routeLabel.AutoSize = true;
            routeLabel.Location = new Point(268, 150);
            routeLabel.Name = "routeLabel";
            routeLabel.Size = new Size(0, 20);
            routeLabel.TabIndex = 9;
            // 
            // listeVulBox
            // 
            listeVulBox.FormattingEnabled = true;
            listeVulBox.HorizontalScrollbar = true;
            listeVulBox.Location = new Point(114, 240);
            listeVulBox.Name = "listeVulBox";
            listeVulBox.ScrollAlwaysVisible = true;
            listeVulBox.Size = new Size(543, 124);
            listeVulBox.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(114, 217);
            label2.Name = "label2";
            label2.Size = new Size(179, 20);
            label2.TabIndex = 11;
            label2.Text = "Vulnérabilité(s) trouvée(s)";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chargerToolStripMenuItem, toolStripSeparator2, analyserToolStripMenuItem, toolStripSeparator1, quitterToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(60, 24);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // chargerToolStripMenuItem
            // 
            chargerToolStripMenuItem.Name = "chargerToolStripMenuItem";
            chargerToolStripMenuItem.Size = new Size(224, 26);
            chargerToolStripMenuItem.Text = "Charger";
            chargerToolStripMenuItem.Click += chargerToolStripMenuItem_Click;
            // 
            // analyserToolStripMenuItem
            // 
            analyserToolStripMenuItem.Name = "analyserToolStripMenuItem";
            analyserToolStripMenuItem.Size = new Size(224, 26);
            analyserToolStripMenuItem.Text = "Analyser";
            analyserToolStripMenuItem.Click += analyserToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            // 
            // quitterToolStripMenuItem
            // 
            quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            quitterToolStripMenuItem.Size = new Size(224, 26);
            quitterToolStripMenuItem.Text = "Quitter";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(221, 6);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(listeVulBox);
            Controls.Add(routeLabel);
            Controls.Add(label3);
            Controls.Add(chargementLabel);
            Controls.Add(progessLabel);
            Controls.Add(label1);
            Controls.Add(rapportButton);
            Controls.Add(analyzeButton);
            Controls.Add(loadCsvButton);
            Controls.Add(urlTextBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "URL Vulnerability Checker";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button loadCsvButton;
        private Button analyzeButton;
        private Button rapportButton;
        public TextBox urlTextBox;
        private Label label1;
        private Label label2;
        public Label progessLabel;
        public Label chargementLabel;
        private Label label3;
        public Label routeLabel;
        public ListBox listeVulBox;
        private ListBox listBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem chargerToolStripMenuItem;
        private ToolStripMenuItem analyserToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem quitterToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
    }
}
