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
    /// Interaction logic for AdministratorForm.xaml
    /// </summary>
    public partial class AdministratorForm : Window
    {
        //FromDB fromDB = null;
        readonly PersonRepository personRepository = null;
        readonly GoodRepository goodRepository = null;
        readonly ManufacturerRepository manufacturerRepository = null;
        readonly CategoryRepository categoryRepository = null;
        readonly PhotoRepository photoRepository = null;
        readonly ReceiptRepository receiptRepository = null;
        public AdministratorForm()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;

            personRepository = new PersonRepository();
            goodRepository = new GoodRepository();
            manufacturerRepository = new ManufacturerRepository();
            categoryRepository = new CategoryRepository();
            photoRepository = new PhotoRepository();
            receiptRepository = new ReceiptRepository();

            dataGridPersons.DataContext = personRepository.GetAll();
            dataGridGoods.DataContext = goodRepository.GetAll();
            dataGridManufacturers.DataContext = manufacturerRepository.GetAll();
            dataGridCategories.DataContext = categoryRepository.GetAll();
            dataGridPhotos.DataContext = photoRepository.GetAll();
            dataGridReceipts.DataContext = receiptRepository.GetAll();
        }
        private void AddNewPersonButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm(true);
            registrationForm.ShowDialog();
            dataGridPersons.DataContext = personRepository.GetAll();
        }
        private void EditPersonButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridPersons.SelectedItems.Count == 1)
                {
                    Person selectedPerson = (Person)dataGridPersons.SelectedCells[0].Item;
                    RegistrationForm rf = new RegistrationForm(selectedPerson);
                    rf.ShowDialog();
                    dataGridPersons.DataContext = personRepository.GetAll();
                }
                else
                {
                    MessageBox.Show("No one person was selectes or selected more than 1 person", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception /*ex*/)
            {
                //MessageBox.Show(ex.ToString(),"Error!!!",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        private void DeletePersonButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPersons.SelectedItems.Count == 1)
            {
                MessageBoxResult result = MessageBox.Show("Are you shure?","Deleting selected person", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    Person selectedPerson = (Person)dataGridPersons.SelectedCells[0].Item;
                    personRepository.Delete(selectedPerson);
                    personRepository.Save();
                    MessageBox.Show("Person was deleted from DB");
                    dataGridPersons.DataContext = personRepository.GetAll();
                }
            }
            else
            {
                MessageBox.Show("No one person was selectes","Error", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void AddGoodButton_Click(object sender, RoutedEventArgs e)
        {
            AddGoodForm agf = new AddGoodForm();
            agf.ShowDialog();
            dataGridGoods.DataContext = goodRepository.GetAll();
            dataGridPhotos.DataContext = photoRepository.GetAll();
        }

        private void EditGoodButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Good selectedGood = (Good)dataGridGoods.SelectedCells[0].Item;
                if (dataGridGoods.SelectedItems.Count == 1)
                {
                    AddGoodForm agf = new AddGoodForm(selectedGood);
                    agf.ShowDialog();
                    dataGridGoods.DataContext = goodRepository.GetAll();
                    dataGridPhotos.DataContext = photoRepository.GetAll();
                }
                else
                {
                    MessageBox.Show("No one good was selectes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception)
            {

            }
        }
        private void RemoveGoodButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridGoods.SelectedItems.Count == 1)
                {
                    MessageBoxResult result = MessageBox.Show("Are you shure?", "Deleting selected good", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        Good selectedGood = (Good)dataGridGoods.SelectedCells[0].Item;

                        int photoId = (int)selectedGood.PhotoId;

                        goodRepository.Delete(selectedGood);
                        goodRepository.Save();
                        dataGridGoods.DataContext = goodRepository.GetAll();

                        photoRepository.Delete(photoRepository.Get(photoId));
                        photoRepository.Save();
                        dataGridPhotos.DataContext = photoRepository.GetAll();

                        MessageBox.Show("Good and related datas (Photos) was deleted");
                    }
                }
                else
                {
                    MessageBox.Show("No one good was selectes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryForm acf = new AddCategoryForm();
            acf.ShowDialog();
            dataGridCategories.DataContext = categoryRepository.GetAll();
        }

        private void EditCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Category selectedCategory = (Category)dataGridCategories.SelectedCells[0].Item;
                if (dataGridCategories.SelectedItems.Count == 1)
                {
                    AddCategoryForm acf = new AddCategoryForm(selectedCategory);
                    acf.ShowDialog();
                    dataGridCategories.DataContext = categoryRepository.GetAll();
                }
                else
                {
                    MessageBox.Show("No one category was selectes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {

            }
        }

        private void RemoveCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Category selectedCategory = (Category)dataGridCategories.SelectedCells[0].Item;
                if (dataGridCategories.SelectedItems.Count == 1)
                {
                    MessageBoxResult result = MessageBox.Show("Are you shure?", "Deleting selected category", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (goodRepository.GetAll().Where(x => x.CategoryId == selectedCategory.CategoryId).Count() > 0)
                        {
                            MessageBox.Show("There are bindings elements in goods table, remove goods firstly", "You can't delete this category", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            categoryRepository.Delete(selectedCategory);
                            categoryRepository.Save();
                            dataGridCategories.DataContext = categoryRepository.GetAll();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No one category was selectes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {

            }
        }
        private void AddManufacturyButton_Click(object sender, RoutedEventArgs e)
        {
            AddManufacturyForm amf = new AddManufacturyForm();
            amf.ShowDialog();
            dataGridManufacturers.DataContext = manufacturerRepository.GetAll();

        }
        private void EditManufacturyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridManufacturers.SelectedItems.Count == 1)
                {
                    Manufacturer selectedManufacturer = (Manufacturer)dataGridManufacturers.SelectedCells[0].Item;
                    AddManufacturyForm amf = new AddManufacturyForm(selectedManufacturer);
                    amf.ShowDialog();
                    dataGridManufacturers.DataContext = manufacturerRepository.GetAll();
                }
                else
                {
                    MessageBox.Show("No one manufacturer was selectes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {

            }
        }

        private void RemoveManufacturyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Manufacturer selectedManufacturer = (Manufacturer)dataGridManufacturers.SelectedCells[0].Item;
                if (dataGridManufacturers.SelectedItems.Count == 1)
                {

                    MessageBoxResult result = MessageBox.Show("Are you shure?", "Deleting selected manufacturer", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (goodRepository.GetAll().Where(x=> x.ManufacturerId == selectedManufacturer.ManufacturerId).Count()>0)
                        {
                            MessageBox.Show("There are bindings elements in goods table, remove goods firstly", "You can't delete this manufactury", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            manufacturerRepository.Delete(selectedManufacturer);
                            manufacturerRepository.Save();
                            dataGridManufacturers.DataContext = manufacturerRepository.GetAll();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No one manufacturer was selectes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {

            }
        }

        private void dataGridPhotos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StackViewPanelRefresh();
        }
        private void StackViewPanelRefresh()
        {
            try
            {
                PhotoViewStackPanel.Children.Clear();
                Photo selectedPhoto = (Photo)dataGridPhotos.SelectedCells[0].Item;
                foreach (var photoPath in selectedPhoto.PhotoAddress.Split(' '))
                {
                    var bitmap = new BitmapImage(new Uri(photoPath));
                    PhotoViewStackPanel.Children.Add(new Image
                    {
                        Source = bitmap,
                        Height = 400,
                        Width = 450
                    });
                }
            }
            catch (Exception)
            {

            }
        }
        private void AddPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            AddPhotoForm apf = new AddPhotoForm();
            apf.ShowDialog();
            dataGridPhotos.DataContext = photoRepository.GetAll();
        }

        private void EditPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridPhotos.SelectedItems.Count == 1)
                {
                    Photo selectedPhoto = (Photo)dataGridPhotos.SelectedCells[0].Item;
                    AddPhotoForm apf = new AddPhotoForm(selectedPhoto);
                    apf.ShowDialog();
                    dataGridPhotos.DataContext = photoRepository.GetAll();
                    StackViewPanelRefresh();
                }
            }
            catch (Exception)
            {

            }
        }

        private void RemovePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridPhotos.SelectedItems.Count == 1)
                {
                    Photo selectedPhoto = (Photo)dataGridPhotos.SelectedCells[0].Item;
                    photoRepository.Delete(selectedPhoto);
                    photoRepository.Save();
                    dataGridPhotos.DataContext = photoRepository.GetAll();
                }
            }
            catch(Exception)
            {

            }
        }

        private void DeleteReceiptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridReceipts.SelectedItems.Count == 1)
                {
                    Receipt receiptToDelete = (Receipt)dataGridReceipts.SelectedItem;
                    //MessageBox.Show(receiptToDelete.Price.ToString());
                    using (ReceiptRepository rr = new ReceiptRepository())
                    {
                        rr.Delete(receiptToDelete);
                        rr.Save();
                        dataGridReceipts.DataContext = rr.GetAll();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
