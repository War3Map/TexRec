using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Prism.Mvvm;


namespace TexRec.ImageViewModel
{
    class ImageViewModel:BindableBase

    {
        ImageModel.ImageModel imageModel;

        public System.Windows.Media.ImageSource SourceImage
        {
            get
            {
                return new BitmapImage(new Uri(ImagePath, UriKind.Absolute)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
            }
        }
    

        public string ImagePath => imageModel.ImagePath;
        public ImageViewModel(string file)
        {

            imageModel = new ImageModel.ImageModel(file);

        }
    }
}


