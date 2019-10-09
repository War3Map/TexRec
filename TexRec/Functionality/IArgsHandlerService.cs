using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TexRec.Functionality
{
    interface IArgsHandlerService
    {
        /// <summary>
        /// Получает результат обработки аргументов в виде списка.
        /// </summary>
        /// <param name="eventArgs">Аргументы события.</param>
        /// <returns></returns>
        IEnumerable GetHandledEnumResult(RoutedEventArgs eventArgs);

        /// <summary>
        /// Получает результат обработки аргументов в виде объекта.
        /// </summary>
        /// <param name="eventArgs">Аргументы события.</param>
        /// <returns></returns>
        object GetHandledResult(RoutedEventArgs eventArgs);
    }
}
