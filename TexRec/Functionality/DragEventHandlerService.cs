using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TexRec.Functionality
{
    class DragEventHandlerService : IArgsHandlerService
    {
        public IEnumerable GetHandledEnumResult(RoutedEventArgs eventArgs)
        {
            var dragArgs = eventArgs as DragEventArgs;
            var files = (string[])dragArgs.Data.GetData(DataFormats.FileDrop);          
            return files.ToList<string>();
        }

        public object GetHandledResult(RoutedEventArgs eventArgs)
        {
            throw new NotImplementedException();
        }
    }
}
