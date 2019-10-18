using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexRec.Support
{
    public interface IDialogLoadSaveService
    {
        /// <summary>
        /// Метод для загрузки списка файлов диалоговым окном
        /// </summary>
        /// <param name="typeParametr">Тип объекта с которым работаем каталог (Directory) или (File).</param>
        /// <returns></returns>
        List<string> LoadFiles(string typeParametr);
        /// <summary>
        /// Метод для сохранения списка выбранных в диалоговом окна файлов 
        /// </summary>
        /// <param name="files"></param>  
        /// <param name="typeParametr">Тип объекта с которым работаем каталог (Directory) или (File).</param>        
        void SaveFiles(List<string> files, string typeParametr);

    }
}
