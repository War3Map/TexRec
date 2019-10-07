using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexRec.Functionality
{
    interface IOpenerService
    {
        /// <summary>
        /// Открывает объект
        /// </summary>
        /// <param name="objectName"></param>
        void Open(string objectName);
    }
}
