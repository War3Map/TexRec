using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ookii.Dialogs.Wpf;
using System.Windows;
using static FileAndDirWorker.FileAndDirWorker;

namespace TexRec.Support
{
    public class DialogLoadSaveService : IDialogLoadSaveService
    {
        //TODO: диалоговое окно для загрузки списка файлов из нескольких каталогов
        public List<string> LoadFiles(string type)
        {
            List<string> resFileList;
            if (type == "Directory") GetFromDirectory(out resFileList);
            else GetFromFileList(out resFileList);
            return resFileList;
        }

        /// <summary>
        /// Получает список выбранных файлов  его в результирующий список
        /// </summary>
        /// <param name="resFileList">результирующий список</param>
        private void GetFromFileList(out List<string> resFileList)
        {
            resFileList = new List<string>();
            VistaOpenFileDialog dialog = new VistaOpenFileDialog();
            dialog.Title = "Выберете файлы изображений";
            dialog.Filter = "Файлы изображений (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png";
            dialog.Multiselect = true;
            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
                MessageBox.Show("Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");
            if ((bool)dialog.ShowDialog())
                //добавление
                resFileList.AddRange(dialog.FileNames);            
        }

        /// <summary>
        /// Получает список файлов из каталога и записывает его в результирующий список
        /// </summary>
        /// <param name="resFileList">результирующий список</param>
        private void GetFromDirectory(out List<string> resFileList)
        {
            resFileList = new List<string>();
            VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
            dialog.Description = "Выберете папку с изображениями";
            dialog.UseDescriptionForTitle = true; // This applies to the Vista style dialog only, not the old dialog.
            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
                MessageBox.Show("Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");
            if ((bool)dialog.ShowDialog())
                //добавление
                resFileList.Add(dialog.SelectedPath);            
        }

        public void SaveFiles(List<string> files)
        {
            throw new NotImplementedException();
        }

        public void ShowDialog()
        {
          throw new NotImplementedException();
        }
    }
}
