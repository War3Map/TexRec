using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace TexRec.ImageModel
{
    class ImageModel:BindableBase
    {
        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value;
                RaisePropertyChanged("imagePath");
            }
        }
        public ImageModel (string imagePath)
        {

            ImagePath = imagePath;
            RaisePropertyChanged("imagePath");
        }


    }
}
