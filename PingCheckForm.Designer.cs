using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sp00ksy
{
    partial class PingCheckForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxIpAddress;
        private Button buttonPing;
        private Button buttonFetchIp;
        private Label labelResult;
        private TableLayoutPanel tableLayoutPanel;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PingCheckForm));
            textBoxIpAddress = new TextBox();
            buttonPing = new Button();
            buttonFetchIp = new Button();
            labelResult = new Label();
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();

            // 
            // textBoxIpAddress
            // 
            textBoxIpAddress.Anchor = AnchorStyles.None; // Center in the cell
            textBoxIpAddress.PlaceholderText = "Enter IP Address";
            textBoxIpAddress.Size = new Size(300, 23); // Set to a reasonable width
            textBoxIpAddress.TabIndex = 0;

            // 
            // buttonPing
            // 
            buttonPing.Anchor = AnchorStyles.None; // Center in the cell
            buttonPing.BackColor = Color.Transparent;
            buttonPing.BackgroundImageLayout = ImageLayout.Stretch;
            buttonPing.Font = new Font("Viner Hand ITC", 12F, FontStyle.Bold);
            buttonPing.Size = new Size(120, 46); // Adjust size if needed
            buttonPing.TabIndex = 1;
            buttonPing.Text = "Ping";
            buttonPing.UseVisualStyleBackColor = false;

            // 
            // buttonFetchIp
            // 
            buttonFetchIp.Anchor = AnchorStyles.None; // Center in the cell
            buttonFetchIp.BackColor = Color.Transparent;
            buttonFetchIp.BackgroundImageLayout = ImageLayout.Stretch;
            buttonFetchIp.Font = new Font("Viner Hand ITC", 12F, FontStyle.Bold);
            buttonFetchIp.Size = new Size(120, 42); // Adjust size if needed
            buttonFetchIp.TabIndex = 2;
            buttonFetchIp.Text = "Fetch IP";
            buttonFetchIp.UseVisualStyleBackColor = false;

            // 
            // labelResult
            // 
            labelResult.Anchor = AnchorStyles.None; // Center in the cell
            labelResult.BackColor = Color.Transparent;
            labelResult.Font = new Font("Viner Hand ITC", 12F, FontStyle.Bold);
            labelResult.Size = new Size(300, 26); // Set to a reasonable width
            labelResult.TabIndex = 3;
            labelResult.Text = "Ping result will be displayed here.";

            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.BackgroundImage = (Image)resources.GetObject("tableLayoutPanel.BackgroundImage");
            tableLayoutPanel.BackgroundImageLayout = ImageLayout.Stretch;
            tableLayoutPanel.ColumnCount = 3; // Three columns to have a small space between buttons
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F)); // First column for first button
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F)); // Space between buttons
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F)); // Second column for second button
            tableLayoutPanel.RowCount = 4; // 4 rows for controls
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F)); // Space for top padding
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F)); // Space for buttons row
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F)); // Space for TextBox
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F)); // Space for Label and bottom padding
            tableLayoutPanel.Dock = DockStyle.Fill; // Fill the form

            // Add controls to TableLayoutPanel
            tableLayoutPanel.Controls.Add(buttonFetchIp, 0, 1); // First button in the first column
            tableLayoutPanel.Controls.Add(buttonPing, 2, 1); // Second button in the third column
            tableLayoutPanel.SetColumnSpan(textBoxIpAddress, 3); // Span TextBox across all columns
            tableLayoutPanel.Controls.Add(textBoxIpAddress, 0, 2); // TextBox in the next row
            tableLayoutPanel.SetColumnSpan(labelResult, 3); // Span Label across all columns
            tableLayoutPanel.Controls.Add(labelResult, 0, 3); // Label in the next row

            // 
            // PingCheckForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1025, 487);
            Controls.Add(tableLayoutPanel);
            Name = "PingCheckForm";
            Text = "Check Ping";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
