﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Prism.Mvvm;
using MainModel = TexRec.MainModel;
using Prism.Commands;
using System.Collections.ObjectModel;
using TexRec.Functionality;
using TexRec.Support;
using System.Windows;

namespace TexRec.MainViewModel
{

    class MainViewModel : BindableBase
    {
        //основная модель
        MainModel.ImageListModel mainModel = new MainModel.ImageListModel();
        //Сервис для работы с диалогами
        IDialogLoadSaveService dialogService;
        //Сервис для показа представлений
        IViewShower viewShower;
        //Сервис для открытия 
        IOpenerService openerService;

        //могут пригодится
        ////Сервис для определения типа загрузки(файл/каталог)
        //IResolveIOService ioservice;


        public ReadOnlyObservableCollection<string> sourceList => new ReadOnlyObservableCollection<string>( mainModel.GetFileNameList());

        //private ObservableCollection<string> sourceList;

        //public ObservableCollection<string> SourceList
        //{
        //    get { return sourceList; }
        //    private set
        //    {
        //        sourceList = value;
        //        RaisePropertyChanged("sourceList");
        //    }

        //}

        private ObservableCollection<string> resultList;

        public ObservableCollection<string> ResultList
        {
            get { return resultList; }
            private set
            {
                resultList = value;
                RaisePropertyChanged("resultList");
            }

        }



        public DelegateCommand ProcessCommand { get; }

        //Предполагаемый вариант
        //public DelegateCommand<List<string>> ChangeListCommand { get; }

        //пробный вариант
        public DelegateCommand<string> ChangeListCommand { get; }

        //команда загрузки списка
        public DelegateCommand<string> LoadListCommand { get; }
        //команда очистки списка
        public DelegateCommand ClearListCommand { get; }
        //команда перетягивания элементов на список
        public DelegateCommand<RoutedEventArgs> DragFileListCommand { get; }
        //команда открытия файла
        public DelegateCommand<string> OpenFileCommand { get; }
        //команда открытия файла в просмотрщике
        public DelegateCommand<string> OpenFileBrowserCommand { get; }

        //конструктор
        public MainViewModel(IDialogLoadSaveService dialogService,IViewShower vievShower, IOpenerService openerService)
        {
            //Инициализируем сервис диалоговых окон
            this.dialogService = dialogService;
            //Инициализируем сервис показа представлений
            this.viewShower = vievShower;
            //Инициализируем сервис открытия документов
            this.openerService = openerService;

            //пробрасываем изменившиеся свойства модели во View
            mainModel.PropertyChanged += (s, e) => {               
                RaisePropertyChanged(e.PropertyName);
            };

            //ChangeListCommand = new DelegateCommand<string>((item) =>
            //{
            //    //пробный вариант
            //    var nlist = new List<string>();
            //    nlist.Add(item);
            //    mainModel.SetList(nlist);
            //});

            OpenFileBrowserCommand = new DelegateCommand<string>(
                (vievParametr) => {
                    if (vievParametr != null)
                        viewShower.ShowView("ImageForm", vievParametr);
                }
            );

            OpenFileCommand = new DelegateCommand<string>(
                (file) => {
                    if (file != null)
                        openerService.Open(file);
                }
            );

            LoadListCommand = new DelegateCommand<string>(
                (typeParametr)=> { mainModel.SetList(dialogService.LoadFiles(typeParametr)); }
            );

            ClearListCommand = new DelegateCommand(
                () => { mainModel.ClearList(); }
            );


            ProcessCommand = new DelegateCommand (() => {
                mainModel.ProcessList();
            });

            DragFileListCommand = new DelegateCommand<RoutedEventArgs>(
                (e) => {

                        //можно изменить
                        var eventArgs = e as DragEventArgs;
                        var files= (string [])eventArgs.Data.GetData(DataFormats.FileDrop);
                        mainModel.SetList(files.ToList<string>());                    
                    }
                );

        }


    }
}
