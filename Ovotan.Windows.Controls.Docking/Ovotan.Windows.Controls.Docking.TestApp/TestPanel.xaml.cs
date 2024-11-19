using Ovotan.Windows.Controls.Docking.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ovotan.Windows.Controls.Docking.TestApp
{
    /// <summary>
    /// Interaction logic for TestPanel.xaml
    /// </summary>
    public partial class TestPanel : UserControl, IDockPanel
    {
        static int _index = 0;
        public TestPanel()
        {
            InitializeComponent();
            MainButton.Content = $"button - {_index}";
            _index++;
        }

        public string Header => throw new NotImplementedException();

        public override string ToString()
        {
            return $"TestPanel - {_index}";
        }
    }
}
