using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovotan.Windows.Controls.Docking.Interfaces
{
    public interface IDropDockPanel
    {
        DropPositions GetDropPositions();
    }

    public class DropPositions
    {
        public bool AttachToLeft { get; set; }
        public bool AttachToRight { get; set; }
        public bool AttachToTop { get; set; }
        public bool AttachToBottom { get; set; }

        public bool SplitToLeft { get; set; }
        public bool SplitToRight { get; set; }
        public bool SplitToTop { get; set; }
        public bool SplitToBottom { get; set; }

    }
}
