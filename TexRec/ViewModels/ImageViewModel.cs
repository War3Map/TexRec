using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexRec.ImageViewModel
{
    class ImageViewModel
    {
        ImageModel.ImageModel imageModel;
        public ImageViewModel(string file)
        {

            imageModel = new ImageModel.ImageModel(file);

        }
    }
}


