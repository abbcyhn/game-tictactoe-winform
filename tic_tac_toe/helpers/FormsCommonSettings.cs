using System.Drawing;
using System.Windows.Forms;

namespace tic_tac_toe.helpers
{
    public static class FormsCommonSettings
    {
        public static void SetIcon(this Form form)
        {
            form.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        public static void SetParentCenterLocation(this Form form)
        {
            form.StartPosition = FormStartPosition.CenterParent;
        }

        public static void SetSizeSettings(this Form form)
        {
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}