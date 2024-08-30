namespace Sp00ksy
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

        private void NetCheck_Click(object sender, EventArgs e)
        {
            NetCheckForm frm = new();
            frm.ShowDialog();
        }

        private void PingCheck_Click(object sender, EventArgs e)
        {
            PingCheckForm pingFrm = new();
            pingFrm.ShowDialog();
        }

        private void btnOpenChat_Click(object sender, EventArgs e)
        {
            // Open the PlasmaChat form
            PlasmaChat chatForm = new PlasmaChat();
            chatForm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Existing event handler code if any
        }
    }
}
