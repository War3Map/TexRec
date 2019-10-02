using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor;
using System.ComponentModel;
using Prism.Mvvm;
using System.Collections.ObjectModel;

using FileAndDirWorker;

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


        //задаёт список
        public void SetList(List<string> paths)
        {
            sourceList.Clear();
            var files = new List<string>();
            FileAndDirWorker.FileAndDirWorker.GetAllImageFiles(paths.ToArray(), files);            
            foreach (string file in files)
            {
                sourceList.Add(new Image(file));
            }
            RaisePropertyChanged("sourceList");

        }
        //чистит список
        public void ClearList()
        {
            sourceList.Clear();
            RaisePropertyChanged("sourceList");
        }

        /// <summary>
        /// Возвращает список имён файлов основной модели
        /// </summary>
        /// <returns> List<string> result</returns>
        public ObservableCollection<string> GetFileNameList()
        {            
            var files = new ObservableCollection<string>();    
            foreach (var imageFile in sourceList)
            {
                files.Add(imageFile.Filename);
            }
            return files;
        }



        public void AddListItems(List<string> files)
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
