using CodeFirst;
using DataAccessLayer.Repositories;
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
    /// Interaction logic for AddPhotoForm.xaml
    /// </summary>
    public partial class AddPhotoForm : Window
    {
        public AddPhotoForm()
        {
            InitializeComponent();
            AddPhotoButton.Content = "Add";
        }
        Photo photoToEdit = null;
        public AddPhotoForm(Photo photo)
        {
            InitializeComponent();
            AddPhotoButton.Content = "Edit";
            photoToEdit = photo;
            PhotoPathTB.Text = photoToEdit.PhotoAddress;
        }

        private void AddPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(PhotoPathTB.Text))
            using (PhotoRepository photoRepository = new PhotoRepository())
            {
                if(photoToEdit == null)
                {
                    photoToEdit = new Photo();
                }
                photoToEdit.PhotoAddress = PhotoPathTB.Text;
                photoRepository.CreateOrUpdate(photoToEdit);
                photoRepository.Save();

                int amountOfPhotos = 0;
                foreach(var path in PhotoPathTB.Text.Split(' '))
                {
                    amountOfPhotos++;
                }
                MessageBox.Show($"There are {amountOfPhotos} photos", "Info",MessageBoxButton.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter photo path");
            }
        }
    }
}
