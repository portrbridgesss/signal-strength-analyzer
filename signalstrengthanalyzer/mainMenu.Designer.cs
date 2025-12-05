namespace signalstrengthanalyzer
{
    partial class mainMenu
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
            labelStatusText = new Label();
            listBox_Locations = new ListBox();
            buttonAnalyze = new Button();
            buttonSettings = new Button();
            panelColor = new Panel();
            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // labelStatusText
            // 
            labelStatusText.AutoSize = true;
            labelStatusText.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStatusText.Location = new Point(8, 23);
            labelStatusText.Name = "labelStatusText";
            labelStatusText.Size = new Size(53, 21);
            labelStatusText.TabIndex = 1;
            labelStatusText.Text = "status";
            labelStatusText.Click += label1_Click;
            // 
            // listBox_Locations
            // 
            listBox_Locations.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox_Locations.FormattingEnabled = true;
            listBox_Locations.ItemHeight = 25;
            listBox_Locations.Location = new Point(12, 100);
            listBox_Locations.Name = "listBox_Locations";
            listBox_Locations.Size = new Size(246, 279);
            listBox_Locations.TabIndex = 3;
            listBox_Locations.SelectedIndexChanged += listBox_Locations_SelectedIndexChanged;
            // 
            // buttonAnalyze
            // 
            buttonAnalyze.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAnalyze.Location = new Point(264, 233);
            buttonAnalyze.Name = "buttonAnalyze";
            buttonAnalyze.Size = new Size(185, 94);
            buttonAnalyze.TabIndex = 4;
            buttonAnalyze.Text = "Analyze Current Connection";
            buttonAnalyze.UseVisualStyleBackColor = true;
            buttonAnalyze.Click += buttonAnalyze_Click;
            // 
            // buttonSettings
            // 
            buttonSettings.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSettings.Location = new Point(370, 348);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(79, 31);
            buttonSettings.TabIndex = 6;
            buttonSettings.Text = "Settings";
            buttonSettings.UseVisualStyleBackColor = true;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // panelColor
            // 
            panelColor.BackColor = SystemColors.ActiveCaption;
            panelColor.Dock = DockStyle.Top;
            panelColor.Location = new Point(0, 0);
            panelColor.Name = "panelColor";
            panelColor.Size = new Size(461, 60);
            panelColor.TabIndex = 7;
            panelColor.Paint += panelColor_Paint;
            panelColor.MouseClick += panelColor_MouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 75);
            label1.Name = "label1";
            label1.Size = new Size(156, 21);
            label1.TabIndex = 8;
            label1.Text = "Overall Area Status: ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelStatusText);
            groupBox1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(264, 100);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(185, 116);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Overall Area Status: ";
            // 
            // mainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 394);
            Controls.Add(label1);
            Controls.Add(buttonSettings);
            Controls.Add(buttonAnalyze);
            Controls.Add(listBox_Locations);
            Controls.Add(panelColor);
            Controls.Add(groupBox1);
            Name = "mainMenu";
            Text = "Form1";
            FormClosing += mainMenu_FormClosing;
            Load += mainMenu_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelStatusText;
        private ListBox listBox_Locations;
        private Button buttonAnalyze;
        private Button buttonSettings;
        private Panel panelColor;
        private Label label1;
        private GroupBox groupBox1;
    }
}
