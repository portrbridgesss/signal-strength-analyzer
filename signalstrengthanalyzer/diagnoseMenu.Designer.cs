namespace signalstrengthanalyzer
{
    partial class diagnoseMenu
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
            comboBox1 = new ComboBox();
            groupBoxDesignInfo = new GroupBox();
            lblStatus = new Label();
            lblSignalStrength = new Label();
            label1 = new Label();
            buttonAnalyze = new Button();
            groupBoxDesignInfo.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(25, 51);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(153, 23);
            comboBox1.TabIndex = 0;
            // 
            // groupBoxDesignInfo
            // 
            groupBoxDesignInfo.Controls.Add(lblStatus);
            groupBoxDesignInfo.Controls.Add(lblSignalStrength);
            groupBoxDesignInfo.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxDesignInfo.Location = new Point(201, 23);
            groupBoxDesignInfo.Name = "groupBoxDesignInfo";
            groupBoxDesignInfo.Size = new Size(200, 246);
            groupBoxDesignInfo.TabIndex = 1;
            groupBoxDesignInfo.TabStop = false;
            groupBoxDesignInfo.Text = "Device Information";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(17, 103);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(64, 25);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "label2";
            // 
            // lblSignalStrength
            // 
            lblSignalStrength.AutoSize = true;
            lblSignalStrength.Location = new Point(17, 36);
            lblSignalStrength.Name = "lblSignalStrength";
            lblSignalStrength.Size = new Size(64, 25);
            lblSignalStrength.TabIndex = 4;
            lblSignalStrength.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 23);
            label1.Name = "label1";
            label1.Size = new Size(140, 25);
            label1.TabIndex = 2;
            label1.Text = "Pick a Location";
            // 
            // buttonAnalyze
            // 
            buttonAnalyze.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAnalyze.Location = new Point(25, 137);
            buttonAnalyze.Name = "buttonAnalyze";
            buttonAnalyze.Size = new Size(153, 83);
            buttonAnalyze.TabIndex = 3;
            buttonAnalyze.Text = "Analyze";
            buttonAnalyze.UseVisualStyleBackColor = true;
            buttonAnalyze.Click += buttonAnalyze_Click;
            // 
            // diagnoseMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 281);
            Controls.Add(buttonAnalyze);
            Controls.Add(label1);
            Controls.Add(groupBoxDesignInfo);
            Controls.Add(comboBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "diagnoseMenu";
            Text = "diagnoseMenu";
            Load += diagnoseMenu_Load;
            groupBoxDesignInfo.ResumeLayout(false);
            groupBoxDesignInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private GroupBox groupBoxDesignInfo;
        private Label label1;
        private Button buttonAnalyze;
        private Label lblSignalStrength;
        private Label lblStatus;
    }
}