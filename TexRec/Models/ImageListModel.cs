using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor;
using System.ComponentModel;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.IO;

using FileAndDirWorker;
using System.Windows;

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

        /// <summary>
        /// Возвращает список имён файлов результата вычислений основной модели
        /// </summary>
        /// <returns> List<string> result</returns>
        public ObservableCollection<string> GetResultsList()
        {
            var files = new ObservableCollection<string>();
            foreach (var imageFile in resultList)
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
        /// <summary>
        /// Обработка списка картинок в модели
        /// </summary>
        public async void ProcessList()
        {
            //TODO: Определение имени попроще
            resultList.Clear();          
            if (!Directory.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp")))
                Directory.CreateDirectory(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp"));
             await ProcessImages();
            RaisePropertyChanged("resultList");
            MessageBox.Show("Действия завершены!");


            //immageProcessingTask.Start();
            //foreach (Image x in sourceList)
            //{


            //    string newFilename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp",
            //        new FileInfo(x.Filename).Name);
            //    x.ConvertToGray(newFilename);
            //    resultList.Add(new Image(newFilename));
            //}


        }


        private async Task ProcessImages()
        {

            Task immageProcessingTask =  Task.Factory.StartNew(
            () =>
            {
                Parallel.ForEach(sourceList,
                (x) =>
                {
                    //TODO: Определение имени попроще
                    string newFilename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp",
            new FileInfo(x.Filename).Name);
                    x.ConvertToGray(newFilename);
                    resultList.Add(new Image(newFilename));
                }
                );
            });

            await immageProcessingTask;
        }


        ///TODO: А надо ли это здесь вообще?
        /// <summary>
        /// Сохраняет результаты списка в указанную директорию
        /// </summary>
        /// <param name="typeParametr">Тип сохранения результатов: сохранение одного файла или сохранение всех в каталог</param>
        public void SaveResults(Support.IDialogLoadSaveService loadSaveService,string typeParametr)
        {
            var resList = new List<string>();
            foreach (var res in resultList)
            {
                resList.Add(res.Filename);
            }
            loadSaveService.SaveFiles(resList, typeParametr);
        }


    }
}
