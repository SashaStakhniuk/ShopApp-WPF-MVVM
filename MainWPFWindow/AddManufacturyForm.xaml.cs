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
    /// Interaction logic for AddManufacturyForm.xaml
    /// </summary>
    public partial class AddManufacturyForm : Window
    {
        Manufacturer manufacturerToEdit = new Manufacturer();
        public AddManufacturyForm()
        {
            InitializeComponent();
            AddManufacturerButton.Content = "Add manufacturer";
        }
        public AddManufacturyForm(Manufacturer manufacturer)
        {
            InitializeComponent();
            manufacturerToEdit = manufacturer;
            ManufacturerTB.Text = manufacturerToEdit.ManufacturerName;
            AddManufacturerButton.Content = "Edit manufacturer";
        }

        private void AddManufacturerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(ManufacturerTB.Text))
            {
                using (ManufacturerRepository mr = new ManufacturerRepository())
                {
                    var manufacturyExist = mr.GetAll().Where(x => x.ManufacturerName.ToLower() == ManufacturerTB.Text.ToLower()).ToList();
                    if (manufacturyExist.Count > 0)
                    {
                        MessageBox.Show("Manufacturer is already exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (manufacturerToEdit == null)
                        {
                            manufacturerToEdit = new Manufacturer();
                        }
                        manufacturerToEdit.ManufacturerName = ManufacturerTB.Text;
                        mr.CreateOrUpdate(manufacturerToEdit);
                        mr.Save();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Manufactury textBox can't be empty");
            }   
        }
    }
}
