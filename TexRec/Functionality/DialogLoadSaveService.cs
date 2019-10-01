using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ookii.Dialogs.Wpf;
using System.Windows;

namespace TexRec.Support
{
    public class DialogLoadSaveService : IDialogLoadSaveService
    {
        public List<string> LoadFiles()
        {
            VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
            dialog.Description = "Please select a folder.";
            dialog.UseDescriptionForTitle = true; // This applies to the Vista style dialog only, not the old dialog.
            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
                MessageBox.Show( "Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");
            if ((bool)dialog.ShowDialog())
                MessageBox.Show( "The selected folder was: " + dialog.SelectedPath, "Sample folder browser dialog");

            List<string> resFileList = new List<string>();
            resFileList.Add(dialog.SelectedPath);
            return resFileList;
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
