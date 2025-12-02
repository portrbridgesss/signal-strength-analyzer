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
            labelStaticStatusText = new Label();
            labelStatus = new Label();
            listBox_Locations = new ListBox();
            buttonAnalyze = new Button();
            labelLocationInfo = new Label();
            buttonSettings = new Button();
            SuspendLayout();
            // 
            // labelStaticStatusText
            // 
            labelStaticStatusText.AutoSize = true;
            labelStaticStatusText.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStaticStatusText.Location = new Point(358, 50);
            labelStaticStatusText.Name = "labelStaticStatusText";
            labelStaticStatusText.Size = new Size(156, 21);
            labelStaticStatusText.TabIndex = 1;
            labelStaticStatusText.Text = "Overall Area Status: ";
            labelStaticStatusText.Click += label1_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStatus.Location = new Point(358, 71);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(97, 21);
            labelStatus.TabIndex = 2;
            labelStatus.Text = "placeholder";
            labelStatus.Click += label2_Click;
            // 
            // listBox_Locations
            // 
            listBox_Locations.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox_Locations.FormattingEnabled = true;
            listBox_Locations.ItemHeight = 25;
            listBox_Locations.Location = new Point(12, 50);
            listBox_Locations.Name = "listBox_Locations";
            listBox_Locations.Size = new Size(340, 329);
            listBox_Locations.TabIndex = 3;
            // 
            // buttonAnalyze
            // 
            buttonAnalyze.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAnalyze.Location = new Point(358, 238);
            buttonAnalyze.Name = "buttonAnalyze";
            buttonAnalyze.Size = new Size(152, 99);
            buttonAnalyze.TabIndex = 4;
            buttonAnalyze.Text = "Analyze Current Connection";
            buttonAnalyze.UseVisualStyleBackColor = true;
            // 
            // labelLocationInfo
            // 
            labelLocationInfo.AutoSize = true;
            labelLocationInfo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLocationInfo.Location = new Point(358, 118);
            labelLocationInfo.Name = "labelLocationInfo";
            labelLocationInfo.Size = new Size(97, 21);
            labelLocationInfo.TabIndex = 5;
            labelLocationInfo.Text = "placeholder";
            labelLocationInfo.Click += label1_Click_1;
            // 
            // buttonSettings
            // 
            buttonSettings.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSettings.Location = new Point(12, 12);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(79, 31);
            buttonSettings.TabIndex = 6;
            buttonSettings.Text = "Settings";
            buttonSettings.UseVisualStyleBackColor = true;
            // 
            // mainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 400);
            Controls.Add(buttonSettings);
            Controls.Add(labelLocationInfo);
            Controls.Add(buttonAnalyze);
            Controls.Add(listBox_Locations);
            Controls.Add(labelStatus);
            Controls.Add(labelStaticStatusText);
            Name = "mainMenu";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelStaticStatusText;
        private Label labelStatus;
        private ListBox listBox_Locations;
        private Button buttonAnalyze;
        private Label labelLocationInfo;
        private Button buttonSettings;
    }
}
