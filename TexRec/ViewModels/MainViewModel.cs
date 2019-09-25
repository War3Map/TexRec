using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Prism.Mvvm;
using MainModel = TexRec.MainModel;
using Prism.Commands;
using System.Collections.ObjectModel;

namespace TexRec.MainViewModel
{

    class MainViewModel : BindableBase
    {
        MainModel.ImageListModel mainModel = new MainModel.ImageListModel();


        private ObservableCollection<string> sourceList;

        public ObservableCollection<string> SourceList
        {
            get { return sourceList; }
            private set
            {
                sourceList = value;
                RaisePropertyChanged("sourceList");
            }

        }

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

        public DelegateCommand<List<string>> LoadListCommand { get; }

        public MainViewModel()
        {
            //пробрасываем изменившиеся свойства модели во View
            mainModel.PropertyChanged += (s, e) => {               
                RaisePropertyChanged(e.PropertyName);
            };

            ChangeListCommand = new DelegateCommand<string> ((item) => {
                //пробный вариант
                var nlist = new List<string>();
                nlist.Add(item);
                mainModel.SetList(nlist);
            });

            ProcessCommand = new DelegateCommand (() => {

                mainModel.ProcessList();
            });


        }


    }
}
