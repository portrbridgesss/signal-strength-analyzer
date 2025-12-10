
namespace signalstrengthanalyzer
{
    partial class adminPanel
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
            panel1 = new Panel();
            btnReports = new Button();
            btnLocations = new Button();
            btnDashboards = new Button();
            panel3 = new Panel();
            btnRefresh = new Button();
            dataGridView1 = new DataGridView();
            lbladminPanel = new Label();
            btnExitadminPanel = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(btnExitadminPanel);
            panel1.Controls.Add(lbladminPanel);
            panel1.Controls.Add(btnReports);
            panel1.Controls.Add(btnLocations);
            panel1.Controls.Add(btnDashboards);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 408);
            panel1.TabIndex = 0;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(30, 200);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(139, 32);
            btnReports.TabIndex = 3;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnLocations
            // 
            btnLocations.Location = new Point(30, 133);
            btnLocations.Name = "btnLocations";
            btnLocations.Size = new Size(139, 32);
            btnLocations.TabIndex = 2;
            btnLocations.Text = "Locations";
            btnLocations.UseVisualStyleBackColor = true;
            btnLocations.Click += btnLocations_Click;
            // 
            // btnDashboards
            // 
            btnDashboards.Location = new Point(30, 66);
            btnDashboards.Name = "btnDashboards";
            btnDashboards.Size = new Size(139, 32);
            btnDashboards.TabIndex = 0;
            btnDashboards.Text = "Dashboard";
            btnDashboards.UseVisualStyleBackColor = true;
            btnDashboards.Click += btnDashboard_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.BackgroundImageLayout = ImageLayout.None;
            panel3.Controls.Add(btnRefresh);
            panel3.Controls.Add(dataGridView1);
            panel3.Location = new Point(199, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(389, 408);
            panel3.TabIndex = 6;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.Control;
            btnRefresh.Font = new Font("Segoe UI", 14F);
            btnRefresh.Location = new Point(110, 351);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(164, 37);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += button1_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 21);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(344, 324);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // lbladminPanel
            // 
            lbladminPanel.AutoSize = true;
            lbladminPanel.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbladminPanel.ForeColor = SystemColors.ButtonHighlight;
            lbladminPanel.Location = new Point(46, 21);
            lbladminPanel.Name = "lbladminPanel";
            lbladminPanel.Size = new Size(105, 23);
            lbladminPanel.TabIndex = 5;
            lbladminPanel.Text = "Admin Panel";
            // 
            // btnExitadminPanel
            // 
            btnExitadminPanel.Location = new Point(30, 313);
            btnExitadminPanel.Name = "btnExitadminPanel";
            btnExitadminPanel.Size = new Size(139, 32);
            btnExitadminPanel.TabIndex = 6;
            btnExitadminPanel.Text = "Exit";
            btnExitadminPanel.UseVisualStyleBackColor = true;
            btnExitadminPanel.Click += btnExitadminPanel_Click;
            // 
            // adminPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 394);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "adminPanel";
            Text = "adminPanel";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel panel1;
        private Button btnReports;
        private Button btnLocations;
        private Button btnDashboards;
        private Panel panel3;
        private DataGridView dataGridView1;
        private Button btnRefresh;
        private Label lbladminPanel;
        private Button btnExitadminPanel;
    }
}