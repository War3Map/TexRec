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
using System.Windows.Shapes;

namespace TexRec.ImageView
{
    /// <summary>
    /// Логика взаимодействия для ImageForm.xaml
    /// </summary>
    public partial class ImageForm : Window
    {
        ImageViewModel.ImageViewModel imageViewModel;
        //public ImageForm()
        //{
        //    InitializeComponent();
        //    imageView = new ImageViewModel.ImageViewModel();
        //}

        public ImageForm(string file)
        {
            InitializeComponent();
            imageViewModel = new ImageViewModel.ImageViewModel(file);
            DataContext = imageViewModel;

        }
    }
}
