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
    /// Interaction logic for AddCategoryForm.xaml
    /// </summary>
    public partial class AddCategoryForm : Window
    {
        Category categoryToEdit = null;
        public AddCategoryForm()
        {
            InitializeComponent();
            AddCategoryButton.Content = "Add category";
        }
        public AddCategoryForm(Category category)
        {
            InitializeComponent();
            categoryToEdit = category;
            CategoryTB.Text = categoryToEdit.CategoryName;
            AddCategoryButton.Content = "Edit category";
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(CategoryTB.Text))
            {
                using (CategoryRepository cr = new CategoryRepository())
                {
                    var categoryExist = cr.GetAll().Where(x => x.CategoryName.ToLower() == CategoryTB.Text.ToLower()).ToList();
                    if(categoryExist.Count>0)
                    {
                        MessageBox.Show("Category is already exist", "Error", MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                    else
                    {
                        if (categoryToEdit == null)
                        {
                            categoryToEdit = new Category();
                        }
                        categoryToEdit.CategoryName = CategoryTB.Text;
                        cr.CreateOrUpdate(categoryToEdit);
                        cr.Save();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Category textBox can't be empty");
            }
        }
    }
}
