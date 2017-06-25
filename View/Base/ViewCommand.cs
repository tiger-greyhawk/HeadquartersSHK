using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace View.Base
{
    public class ViewCommand
    {
        private static readonly RoutedCommand _accept = new RoutedCommand("Accept", typeof(ViewCommand));

        public static RoutedCommand Accept
        {
            get { return ViewCommand._accept; }
        }
    }
}
