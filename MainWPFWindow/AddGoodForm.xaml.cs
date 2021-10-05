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
    public partial class AddGoodForm : Window
    {
        readonly GoodRepository goodRepository = null;
        readonly CategoryRepository categoryRepository = null;
        readonly ManufacturerRepository manufacturerRepository = null;
        readonly PhotoRepository photoRepository = null;

        public AddGoodForm()
        {
            InitializeComponent();
            goodRepository = new GoodRepository();
            categoryRepository = new CategoryRepository();
            manufacturerRepository = new ManufacturerRepository();
            photoRepository = new PhotoRepository();

            AddGoodButton.Content = "Add new good";

            PriceTB.Text = "0,0";
            CountTB.Text = "0,0";

            GoodCategoryCB.DataContext = categoryRepository.GetAll().Select(x => x.CategoryName);
            GoodManufacturerCB.DataContext = manufacturerRepository.GetAll().Select(x=> x.ManufacturerName);
        }
        
        Good goodToEdit = null;
        
        public AddGoodForm(Good good)
        {
            InitializeComponent();
            goodToEdit = good;
            goodRepository = new GoodRepository();
            categoryRepository = new CategoryRepository();
            manufacturerRepository = new ManufacturerRepository();
            photoRepository = new PhotoRepository();

            AddGoodButton.Content = "Edit good";              

            GoodCategoryCB.DataContext = categoryRepository.GetAll().Select(x => x.CategoryName);
            GoodManufacturerCB.DataContext = manufacturerRepository.GetAll().Select(x => x.ManufacturerName);

            PriceTB.Text = goodToEdit.Price.ToString();
            CountTB.Text = goodToEdit.GoodCount.ToString();
            GoodNameTB.Text = goodToEdit.GoodName;
            GoodManufacturerCB.SelectedItem = manufacturerRepository.GetAll().Where(x=> x.ManufacturerId== goodToEdit.ManufacturerId).Select(x=> x.ManufacturerName).FirstOrDefault();
            GoodCategoryCB.SelectedItem = categoryRepository.GetAll().Where(x => x.CategoryId == goodToEdit.CategoryId).Select(x => x.CategoryName).FirstOrDefault();
            PhotoTB.Text = photoRepository.GetAll().Where(x=> x.PhotoId==goodToEdit.PhotoId).Select(x=> x.PhotoAddress).FirstOrDefault();
        }
        private void AddGoodButton_Click(object sender, RoutedEventArgs e)
        {
            if(CheckDatas())
            {
                Photo photo = new Photo();
                if(goodToEdit!=null)
                {
                    photo = photoRepository.Get((int)goodToEdit.PhotoId);
                }
                photo.PhotoAddress = PhotoTB.Text;
                //MessageBox.Show(photo.PhotoAddress);
                photoRepository.CreateOrUpdate(photo);
                photoRepository.Save();

                if(goodToEdit==null)
                {
                    goodToEdit = new Good();
                }
                goodToEdit.GoodName = GoodNameTB.Text;
                goodToEdit.ManufacturerId = manufacturerRepository.GetAll().Where(x => x.ManufacturerName == GoodManufacturerCB.Text).Select(x => x.ManufacturerId).FirstOrDefault();
                goodToEdit.CategoryId = categoryRepository.GetAll().Where(x => x.CategoryName == GoodCategoryCB.Text).Select(x => x.CategoryId).FirstOrDefault();
                goodToEdit.PhotoId = photoRepository?.GetAll().Where(x => x.PhotoAddress == PhotoTB.Text).Select(x => x.PhotoId).FirstOrDefault();
                goodToEdit.Price = Decimal.Parse(PriceTB.Text);
                goodToEdit.GoodCount = Decimal.Parse(CountTB.Text);

                goodRepository.CreateOrUpdate(goodToEdit);
                goodRepository.Save();
                this.Close();
            }
        }
        private void ShowGoodPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(PhotoTB.Text))
            {
                ShowPhotoForm spf = new ShowPhotoForm(PhotoTB.Text);
                spf.ShowDialog();
            }
            else
            {
                MessageBox.Show("There are no any photos");
            }
        }
        private bool CheckDatas()
        {
            bool contWork = true;
            if (String.IsNullOrEmpty(GoodNameTB.Text))
            {
                MessageBox.Show("Enter good's name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                contWork = false;
            }
            else if (String.IsNullOrEmpty(GoodManufacturerCB.Text))
            {
                MessageBox.Show("Select manufacturer", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                contWork = false;
            }
            else if (String.IsNullOrEmpty(GoodCategoryCB.Text))
            {
                MessageBox.Show("Select category", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                contWork = false;
            }
            else if (String.IsNullOrEmpty(PhotoTB.Text))
            {
                MessageBox.Show("You must add the photo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                contWork = false;
            }
            else if (PriceTB.Text.Any(c => char.IsLetter(c)) || PriceTB.Text.Contains('.'))
            {
                MessageBox.Show("Price can't include symbols and '.' . Enter number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                contWork = false;
            }
            else if (CountTB.Text.Any(c => char.IsLetter(c)) || CountTB.Text.Contains('.'))
            {
                MessageBox.Show("Count can't include symbols and '.' . Enter number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                contWork = false;
            }
            if (contWork)
                return true;
            else
                return false;
        }
    }
}
