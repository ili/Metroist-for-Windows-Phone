using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroistLib.Component.MessageBox
{
    public class MessageBoxEventArgs : EventArgs
    {
        public Visual.Controls.MessageBox.CustomMessageBoxResult Result { get; set; }
    }
}
