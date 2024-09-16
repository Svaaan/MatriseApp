namespace Matrise
{
    public partial class MainForm : Form
    {
       

        public MainForm()
        {
            InitializeComponent();
          
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initialization code if needed
        }

        private void ImageConverter_Click(object sender, EventArgs e)
        {
            ImageConverterForm imageFrm = new();
            imageFrm.ShowDialog();
        }

        private void Watermark_Click(object sender, EventArgs e)
        {
            WatermarkForm frm = new();
            frm.ShowDialog();
        }

        private void PingCheck_Click(object sender, EventArgs e)
        {
            PingCheckForm pingFrm = new();
            pingFrm.ShowDialog();
        }

        private void OpenChat_Click(object sender, EventArgs e)
        {
            // Open the PlasmaChat form
            IpChatConnection chatForm = new IpChatConnection();
            chatForm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Existing event handler code if any
        }
    }
}
