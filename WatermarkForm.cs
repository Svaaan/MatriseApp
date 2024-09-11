using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Matrise.Services;

namespace Matrise
{
    public partial class WatermarkForm : Form
    {
        private readonly WatermarkService watermarkService;

        public WatermarkForm()
        {
            InitializeComponent();
            watermarkService = new WatermarkService();

        }

        private async void WatermarkButton_Click(object sender, EventArgs e)
        {


        }
    }
}
    

