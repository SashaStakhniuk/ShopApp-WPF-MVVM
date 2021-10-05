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
    /// Interaction logic for MakeOrderForm.xaml
    /// </summary>
    public partial class MakeOrderForm : Window
    {
        readonly Person customer = null;
        readonly Good goodToBuy = null;
        int discount = 0;
        public MakeOrderForm(Person person, Good good)
        {
            InitializeComponent();
            customer = person;
            goodToBuy = good;

            FirstNameTB.Text = person.FirstName;
            LastNameTB.Text = person.LastName;
            GoodNameTB.IsEnabled = false;
            GoodNameTB.Text = good.GoodName;
            PriceTB.IsEnabled = false;
            PriceTB.Text = good.Price.ToString();
            AmountTB.Text = "1";
            DiscountTB.IsEnabled = false;
            DiscountTB.Text = "0";
            GeneralPriceTB.IsEnabled = false;
        }

        private void AmountTB_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(AmountTB.Text))
                {
                    decimal amountOrderedGoods = Decimal.Parse(AmountTB.Text);
                    decimal price = Decimal.Parse(PriceTB.Text);

                    if (amountOrderedGoods == 1)
                    {
                        discount = 0;
                    }
                    else if (amountOrderedGoods > 1 && amountOrderedGoods <= 4)
                    {
                        discount = 2;
                    }
                    else if (amountOrderedGoods >= 5 && amountOrderedGoods <= 10)
                    {
                        discount = 5;
                    }
                    else if (amountOrderedGoods >= 11 && amountOrderedGoods <= 20)
                    {
                        discount = 10;
                    }
                    else if (amountOrderedGoods >= 21 && amountOrderedGoods <= 50)
                    {
                        discount = 15;
                    }
                    else if (amountOrderedGoods >= 51)
                    {
                        discount = 20;
                    }
                    DiscountTB.Text = discount.ToString();
                    GeneralPriceTB.Text = ((amountOrderedGoods * price)-(((amountOrderedGoods * price)*discount)/100)).ToString();
                }
                else
                {
                    DiscountTB.Text = "0";
                    GeneralPriceTB.Text = "0";
                }
            }
            catch(Exception)
            {

            }
           
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {         
                using (GoodRepository goodRepository = new GoodRepository())
                {
                    if (goodToBuy.GoodCount - Decimal.Parse(AmountTB.Text) >= 0 && Decimal.Parse(AmountTB.Text)>0)
                    {
                        using (ReceiptRepository receiptRepository = new ReceiptRepository())
                        {
                            receiptRepository.CreateOrUpdate(new Receipt
                            {
                                PersonId = customer.PersonId,
                                GoodId = goodToBuy.GoodId,
                                Price = goodToBuy.Price,
                                Amount = Decimal.Parse(AmountTB.Text),
                                Discount = discount,
                                GeneralPrice = Decimal.Parse(GeneralPriceTB.Text),
                                BuyTime = DateTime.Now
                            });
                            receiptRepository.Save();
                        }
                        goodToBuy.GoodCount -= Decimal.Parse(AmountTB.Text);
                        goodRepository.CreateOrUpdate(goodToBuy);
                        goodRepository.Save();
                        MessageBox.Show($"{customer.FirstName} {customer.LastName}, thanks\nAwait for your order","Access",MessageBoxButton.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Currently available {goodToBuy.GoodCount} units of selected goods" , "There are no such amount of selected product",MessageBoxButton.OK,MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
