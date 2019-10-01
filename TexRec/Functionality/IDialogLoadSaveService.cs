using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TexRec.Support
{
    public interface IDialogLoadSaveService
    {
      
        List<string> LoadFiles();
        void SaveFiles(List<string> files);


    }
}
