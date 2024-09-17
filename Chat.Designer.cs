using System;
using System.Windows.Forms;

namespace Matrise
{
    partial class Chat
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtChatLog;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnSaveLogs;
        private System.Windows.Forms.Button btnClearLogs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtChatLog = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnSaveLogs = new System.Windows.Forms.Button();
            this.btnClearLogs = new System.Windows.Forms.Button();

            // 
            // txtChatLog
            // 
            this.txtChatLog.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtChatLog.ForeColor = System.Drawing.Color.White;
            this.txtChatLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChatLog.Location = new System.Drawing.Point(12, 12);
            this.txtChatLog.Multiline = true;
            this.txtChatLog.Name = "txtChatLog";
            this.txtChatLog.ReadOnly = true;
            this.txtChatLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChatLog.Size = new System.Drawing.Size(776, 365);
            this.txtChatLog.TabIndex = 0;
            this.txtChatLog.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtChatLog.Padding = new Padding(5);
            this.txtChatLog.BorderStyle = BorderStyle.FixedSingle;
            this.txtChatLog.BorderStyle = BorderStyle.None;

            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Location = new System.Drawing.Point(12, 383);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(695, 23);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMessage.Padding = new Padding(5);
            this.txtMessage.BorderStyle = BorderStyle.None;

            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackColor = System.Drawing.Color.FromArgb(50, 150, 250);
            this.btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMessage.ForeColor = System.Drawing.Color.White;
            this.btnSendMessage.Location = new System.Drawing.Point(713, 381);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 25);
            this.btnSendMessage.TabIndex = 2;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = false;
            this.btnSendMessage.FlatAppearance.BorderSize = 0;
            this.btnSendMessage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 160, 255);
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);

            // 
            // btnSaveLogs
            // 
            this.btnSaveLogs.BackColor = System.Drawing.Color.FromArgb(40, 200, 100);
            this.btnSaveLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveLogs.ForeColor = System.Drawing.Color.White;
            this.btnSaveLogs.Location = new System.Drawing.Point(632, 410);
            this.btnSaveLogs.Name = "btnSaveLogs";
            this.btnSaveLogs.Size = new System.Drawing.Size(75, 25);
            this.btnSaveLogs.TabIndex = 3;
            this.btnSaveLogs.Text = "Save Logs";
            this.btnSaveLogs.UseVisualStyleBackColor = false;
            this.btnSaveLogs.FlatAppearance.BorderSize = 0;
            this.btnSaveLogs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 210, 110);
            this.btnSaveLogs.Click += new System.EventHandler(this.btnSaveLogs_Click);

            // 
            // btnClearLogs
            // 
            this.btnClearLogs.BackColor = System.Drawing.Color.FromArgb(250, 100, 100);
            this.btnClearLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLogs.ForeColor = System.Drawing.Color.White;
            this.btnClearLogs.Location = new System.Drawing.Point(713, 410);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(75, 25);
            this.btnClearLogs.TabIndex = 4;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = false;
            this.btnClearLogs.FlatAppearance.BorderSize = 0;
            this.btnClearLogs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 120, 120);
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);

            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClearLogs);
            this.Controls.Add(this.btnSaveLogs);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtChatLog);
            this.Name = "Chat";
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
