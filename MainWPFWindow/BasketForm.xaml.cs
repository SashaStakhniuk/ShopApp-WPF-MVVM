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
    /// Interaction logic for BasketForm.xaml
    /// </summary>
    public partial class BasketForm : Window
    {
        public BasketForm(Person person)
        {
            ReceiptRepository receiptRepository = new ReceiptRepository();
            InitializeComponent();
            DataGridReceipts.DataContext = receiptRepository.GetAll().Where(x=> x.PersonId == person.PersonId);
        }
    }
}
