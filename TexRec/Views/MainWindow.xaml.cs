using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TexRec
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        TexRec.MainViewModel.MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new TexRec.MainViewModel.MainViewModel(
                new Support.DialogLoadSaveService(),
                new Functionality.ImageViewShower(),
                new Functionality.FileOpenerService(),
                new Functionality.DragEventHandlerService()
                );
            DataContext = viewModel;
        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
        }
    }
}
