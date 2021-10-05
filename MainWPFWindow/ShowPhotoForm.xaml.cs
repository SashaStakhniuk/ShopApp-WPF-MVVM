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

namespace MainWPFWindow
{
    /// <summary>
    /// Interaction logic for ShowPhotoForm.xaml
    /// </summary>
    public partial class ShowPhotoForm : Window
    {
        public ShowPhotoForm(string path)
        {
            InitializeComponent();
            string[] photos = path.Split(' ');
            foreach(var photoPath in photos)
            {
                //MessageBox.Show(photoPath);
                var bitmap = new BitmapImage(new Uri(photoPath));
                StackPanelViewer.Children.Add(new Image
                {
                    Source = bitmap,
                    Height = 400,
                    Width = 450
                });
            }
        }
    }
}
