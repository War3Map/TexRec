using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor;
using System.ComponentModel;

namespace TexRec.MainModel
{
    class ImageListModel
    {
        private List<Image> imageList;

        public List<Image> ImageList
        {
            get { return imageList; }
            set {
                imageList =value;
                //RaisePropertyChanged("imageList");
            }

        }

        public ImageListModel()
        {
            imageList = new List<Image>();

        }


        public void ProcessList()
        {

        }


        public void Save()
        {


        }


    }
}
