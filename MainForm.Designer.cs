namespace Sp00ksy
{
    partial class MainForm
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
            button1 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            button2 = new Button();
            button3 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnOpenChat = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Dock = DockStyle.Fill;
            button1.ForeColor = Color.White; // Changed to White for visibility
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(250, 34);
            button1.TabIndex = 0;
            button1.Text = "Image Converter";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ImageConverter_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.Dock = DockStyle.Fill;
            button2.ForeColor = Color.White; // Changed to White for visibility
            button2.Location = new Point(259, 3);
            button2.Name = "button2";
            button2.Size = new Size(250, 34);
            button2.TabIndex = 1;
            button2.Text = "Net check";
            button2.UseVisualStyleBackColor = false;
            button2.Click += NetCheck_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.Dock = DockStyle.Fill;
            button3.ForeColor = Color.White; // Changed to White for visibility
            button3.Location = new Point(515, 3);
            button3.Name = "button3";
            button3.Size = new Size(250, 34);
            button3.TabIndex = 2;
            button3.Text = "Check ping";
            button3.UseVisualStyleBackColor = false;
            button3.Click += PingCheck_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Controls.Add(button2, 1, 0);
            tableLayoutPanel1.Controls.Add(button3, 2, 0);
            tableLayoutPanel1.Controls.Add(btnOpenChat, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1025, 40);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnOpenChat
            // 
            btnOpenChat.BackColor = Color.Black;
            btnOpenChat.Dock = DockStyle.Fill;
            btnOpenChat.ForeColor = Color.White; // Changed to White for visibility
            btnOpenChat.Location = new Point(771, 3);
            btnOpenChat.Name = "btnOpenChat";
            btnOpenChat.Size = new Size(251, 34);
            btnOpenChat.TabIndex = 3;
            btnOpenChat.Text = "Chat";
            btnOpenChat.UseVisualStyleBackColor = false;
            btnOpenChat.Click += btnOpenChat_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black; // Changed to Black for the form background
            ClientSize = new Size(1025, 487);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Matrise";
            Load += MainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnOpenChat; // Declare btnOpenChat here
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
