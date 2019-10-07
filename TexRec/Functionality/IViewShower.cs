using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexRec.Functionality
{
    /// <summary>
    /// Интерфейс для показа Views
    /// </summary>
    interface IViewShower
    {
        /// <summary>
        /// Функция для показа view
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="viewParametr"></param>
        void ShowView(string viewName, string viewParametr);

    }
}
