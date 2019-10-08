using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexRec.ImageView;

namespace TexRec.Functionality
{
    class ImageViewShower : IViewShower
    {
        public void ShowView(string viewName, string viewParametr)
        {
            ImageForm imageView=new ImageForm(viewParametr);
            imageView.Show();            
        }
    }
}
