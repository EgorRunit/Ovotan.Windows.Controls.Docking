using System.Windows.Navigation;

namespace Ovotan.Windows.Controls.Docking.Interfaces

{
    public interface IDockPanel : IDockGridChild
    {
        string Header => string.Empty;
    }
}
