using System.Windows.Forms;

namespace Sp00ksy.Services.PingCheck
{
    public class ToolTipService
    {
        private readonly ToolTip toolTip;

        public ToolTipService()
        {
            toolTip = new ToolTip();
        }

        public void SetToolTip(Control control, string text)
        {
            toolTip.SetToolTip(control, text);
        }
    }
}
