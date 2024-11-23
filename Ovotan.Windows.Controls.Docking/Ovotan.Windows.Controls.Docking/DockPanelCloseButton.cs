using Ovotan.Windows.Controls.Controls;
using Ovotan.Windows.Controls.Docking.Exceptions;
using Ovotan.Windows.Controls.Docking.Interfaces;
using System.Windows;

namespace Ovotan.Windows.Controls.Docking
{
    public class DockPanelCloseButton : ViewboxIcon
    {
        public override void OnApplyTemplate()
        {
            Command = new ButtonCommand<object>(_ => OnClose());
            base.OnApplyTemplate();
        }

        internal void OnClose() 
        {
            if (Parent is FrameworkElement frameworkElement)
            {
                if (frameworkElement.TemplatedParent is IDockGridChild child)
                {

                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new NotFrameworkElement();
            }
        }
    }
}   
