using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Ovotan.Windows.Controls.Docking
{
    public class PanelHorizontalSplitter : ContentControl
    {
        public PanelHorizontalSplitter()
        {
            Background = new SolidColorBrush(Colors.Red);
            MouseEnter += PanelHorizontalSplitter_MouseEnter;
            MouseLeave += PanelHorizontalSplitter_MouseLeave;
            Cursor = Cursors.SizeWE;
        }

        private void PanelHorizontalSplitter_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
        }

        private void PanelHorizontalSplitter_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
