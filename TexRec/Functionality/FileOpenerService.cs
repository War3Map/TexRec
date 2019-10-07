using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TexRec.Functionality
{
    class FileOpenerService : IOpenerService
    {
        /// <summary>
        /// Открывает файл
        /// </summary>
        /// <param name="objectName">Путь файла</param>
        public void Open(string objectName)
        {
            Process.Start(objectName);
        }
    }
}
