using System;
using System.Drawing;
using System.Windows.Forms;


namespace Sp00ksy.Services
{
    public class MatrixRain : Panel
    {
        private const int ColumnCount = 80;
        private const int RowCount = 40;
        private int[] yPos;
        private Random random = new Random();
        private System.Windows.Forms.Timer timer; // Explicitly use System.Windows.Forms.Timer

        public MatrixRain()
        {
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.Black;

            yPos = new int[ColumnCount];
            for (int i = 0; i < ColumnCount; i++)
            {
                yPos[i] = random.Next(-500, 0);
            }

            timer = new System.Windows.Forms.Timer
            {
                Interval = 50
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate(); // Trigger the Paint event
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Font font = new Font("Consolas", 12, FontStyle.Regular);
            Brush brush = new SolidBrush(Color.Lime);

            for (int i = 0; i < ColumnCount; i++)
            {
                int x = i * 15;
                yPos[i] += 15;
                if (yPos[i] > this.ClientSize.Height)
                {
                    yPos[i] = 0;
                }

                string text = ((char)random.Next(0x30A0, 0x30FF)).ToString();
                g.DrawString(text, font, brush, x, yPos[i]);
            }
        }
    }
}
