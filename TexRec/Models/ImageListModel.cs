using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor;
using System.ComponentModel;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace TexRec.MainModel
{
    class ImageListModel:BindableBase
    {
        private ObservableCollection<Image> sourceList;

        public ObservableCollection<Image> SourceList
        {
            get { return sourceList; }
            private set {
                sourceList = value;
                RaisePropertyChanged("sourceList");
            }

        }

        private ObservableCollection<Image> resultList;

        public ObservableCollection<Image> ResultList
        {
            get { return resultList; }
            private set
            {
                resultList = value;
                RaisePropertyChanged("resultList");
            }

        }

        public ImageListModel()
        {
            sourceList = new ObservableCollection<Image>();
            resultList = new ObservableCollection<Image>();
        }

        public void SetList(List<string> files)
        {
            foreach (string file in files)
            {
                sourceList.Add(new Image(file));
            }

        }

        public void ProcessList()
        {

        }


        public void Save()
        {


        }


    }
}
