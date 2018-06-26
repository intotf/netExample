using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.DependencyLocate
{
    internal sealed class MacButton : IButton
    {
        public String Description { get; private set; }

        public MacButton()
        {
            this.Description = " Mac风格按钮";
        }

        public String ShowInfo()
        {
            return this.Description;
        }
    }
}
