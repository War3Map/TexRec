using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Prism.Mvvm;
using MainModel = TexRec.MainModel;

namespace TexRec.MainViewModel
{

    class MainViewModel : BindableBase
    {
        MainModel.ImageListModel mainModel = new MainModel.ImageListModel();



       
        public MainViewModel()
        {
            


        }


    }
}
