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
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            panel3 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 408);
            panel1.TabIndex = 0;
            // 
            // button4
            // 
            button4.Location = new Point(30, 200);
            button4.Name = "button4";
            button4.Size = new Size(139, 32);
            button4.TabIndex = 3;
            button4.Text = "Reports";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(30, 133);
            button3.Name = "button3";
            button3.Size = new Size(139, 32);
            button3.TabIndex = 2;
            button3.Text = "Locations";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(30, 62);
            button1.Name = "button1";
            button1.Size = new Size(139, 32);
            button1.TabIndex = 0;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.BackgroundImageLayout = ImageLayout.None;
            panel3.Controls.Add(dataGridView1);
            panel3.Location = new Point(206, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(382, 408);
            panel3.TabIndex = 6;
            panel3.Paint += panel3_Paint;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(24, 25);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(333, 360);
            dataGridView1.TabIndex = 0;
            // 
            // adminPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 409);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "adminPanel";
            Text = "adminPanel";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button4;
        private Button button3;
        private Button button1;
        private Panel panel3;
        private DataGridView dataGridView1;
    }
}