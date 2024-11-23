using Ovotan.Windows.Controls.Docking.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ovotan.Windows.Controls.Docking.UnitTest.Mocks
{
    internal class DockPanel : IDockPanel
    {
        public string Header { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event RoutedEventHandler Close;

        public void OnClose()
        {
            throw new NotImplementedException();
        }
    }
}
