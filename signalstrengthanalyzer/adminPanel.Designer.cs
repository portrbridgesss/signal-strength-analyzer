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
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            button6 = new Button();
            panel2 = new Panel();
            lbladminProfile = new Label();
            panel3 = new Panel();
            button7 = new Button();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 544);
            panel1.TabIndex = 0;
            // 
            // button5
            // 
            button5.Location = new Point(30, 367);
            button5.Name = "button5";
            button5.Size = new Size(139, 32);
            button5.TabIndex = 4;
            button5.Text = "Remove";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(30, 304);
            button4.Name = "button4";
            button4.Size = new Size(139, 32);
            button4.TabIndex = 3;
            button4.Text = "Reports";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(30, 236);
            button3.Name = "button3";
            button3.Size = new Size(139, 32);
            button3.TabIndex = 2;
            button3.Text = "Locations";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(30, 133);
            button2.Name = "button2";
            button2.Size = new Size(139, 32);
            button2.TabIndex = 1;
            button2.Text = "Admin Profile";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(30, 62);
            button1.Name = "button1";
            button1.Size = new Size(139, 32);
            button1.TabIndex = 0;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(224, 22);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 27);
            textBox1.TabIndex = 1;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.MenuHighlight;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Location = new Point(420, 22);
            button6.Name = "button6";
            button6.Size = new Size(28, 27);
            button6.TabIndex = 2;
            button6.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(button7);
            panel2.Controls.Add(lbladminProfile);
            panel2.Location = new Point(224, 83);
            panel2.Name = "panel2";
            panel2.Size = new Size(749, 52);
            panel2.TabIndex = 5;
            // 
            // lbladminProfile
            // 
            lbladminProfile.AutoSize = true;
            lbladminProfile.ForeColor = SystemColors.MenuHighlight;
            lbladminProfile.Location = new Point(15, 18);
            lbladminProfile.Name = "lbladminProfile";
            lbladminProfile.Size = new Size(80, 15);
            lbladminProfile.TabIndex = 0;
            lbladminProfile.Text = "Admin Profile";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.BackgroundImageLayout = ImageLayout.None;
            panel3.Controls.Add(dataGridView1);
            panel3.Location = new Point(224, 133);
            panel3.Name = "panel3";
            panel3.Size = new Size(749, 347);
            panel3.TabIndex = 6;
            // 
            // button7
            // 
            button7.BackColor = SystemColors.MenuHighlight;
            button7.ForeColor = SystemColors.ButtonHighlight;
            button7.Location = new Point(101, 13);
            button7.Name = "button7";
            button7.Size = new Size(123, 24);
            button7.TabIndex = 7;
            button7.Text = "See Admin Profile";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(24, 20);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(702, 304);
            dataGridView1.TabIndex = 0;
            // 
            // adminPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 544);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(button6);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            Name = "adminPanel";
            Text = "adminPanel";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private Button button6;
        private Panel panel2;
        private Panel panel3;
        private Label lbladminProfile;
        private Button button7;
        private DataGridView dataGridView1;
    }
}