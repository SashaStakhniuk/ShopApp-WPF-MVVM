using CodeFirst;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MainWPFWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         GoodRepository goodRepository = null;
         CategoryRepository categoryRepository = null;
         PhotoRepository photoRepository = null;
        ManufacturerRepository manufacturerRepository = null;
        Person personInSystem = null;
        public MainWindow()
        {
           
            InitializeComponent();
            this.Title = "InternetShop";
            this.WindowState = WindowState.Maximized;

            SignInButton.Visibility = Visibility.Hidden;
            SignInButton.IsEnabled = false;

            BuyButton.Visibility = Visibility.Hidden;

            goodRepository = new GoodRepository();
            categoryRepository = new CategoryRepository();
            photoRepository = new PhotoRepository();
            manufacturerRepository = new ManufacturerRepository();


            Task.Run(() =>
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    AuthentificationForm af = new AuthentificationForm();
                    af.ShowDialog();
                    if (af.Person != null)
                    {
                        personInSystem = af.Person;
                        this.Title = $"InternetShop - Client: {personInSystem.FirstName} {personInSystem.LastName}";
                        CategoriesLB.DataContext = categoryRepository.GetAll().Select(x => x.CategoryName);
                    }
                }));
            });
        }
        private void CategoriesLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TBControl.SelectedIndex = 0;
                GoodsListBox.Items.Clear();
                var selectedGoods = goodRepository.GetAll().Where(x => x.CategoryId == categoryRepository.GetAll().Where(n => n.CategoryName == CategoriesLB.SelectedItem.ToString()).Select(n => n.CategoryId).FirstOrDefault());

                foreach (var good in selectedGoods)
                {
                    Task.Run(() =>
                    {
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            var photoPaths = photoRepository.GetAll().Where(x => x.PhotoId == good.PhotoId).Select(x => x.PhotoAddress);
                            GoodsListBox.Items.Add(new Label
                            {
                                FontSize = 16,
                                Content = good.GoodName,
                                Height = 30
                            });
                            foreach (var photoPath in photoPaths)
                            {
                                string[] paths = photoPath.Split(' ');
                                var bitmap = new BitmapImage(new Uri(paths[0]));

                                GoodsListBox.Items.Add(new Image
                                {
                                    Source = bitmap,
                                    Height = 300,
                                    Width = 350
                                });
                            }
                        }));
                    });                
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.ToString());
            }

        }
        private void ShowAddPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddPanelColumn.ActualWidth == 0)
            {
                AddPanelColumn.Width = new GridLength(250);
            }
            else
            {
                AddPanelColumn.Width = new GridLength(0);
            }
        }
        private void LogInButton_Click_1(object sender, RoutedEventArgs e)
        {
            try 
            {
                AuthentificationForm authentificationForm = new AuthentificationForm();
                authentificationForm.ShowDialog();
                if (authentificationForm.Person != null)
                {
                    personInSystem = authentificationForm.Person;
                    this.Title = $"InternetShop - Client: {personInSystem.FirstName} {personInSystem.LastName}";
                }
                CategoriesLB.DataContext = categoryRepository.GetAll().Select(x => x.CategoryName);
                AddPanelColumn.Width = new GridLength(250);

                goodRepository = new GoodRepository();
                categoryRepository = new CategoryRepository();
                photoRepository = new PhotoRepository();
                manufacturerRepository = new ManufacturerRepository();
            }
            catch(Exception)
            {

            }
        }

        private void SignIn_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
        }

        private void GoodsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PhotoViewStackPanel.Children.Clear();
                GoodInfoStackPanel.Children.Clear();
                GoodInfoStackPanel1.Children.Clear();
               // GoodInfoStackPanel2.Children.Clear();

                string selectedGood = ((Label)GoodsListBox.SelectedItem).Content.ToString();
                if(String.IsNullOrEmpty(selectedGood))
                {
                    BuyButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    BuyButton.Visibility = Visibility.Visible;
                }
                var photoPaths = photoRepository.GetAll().Where(x => x.PhotoId == goodRepository.GetAll().Where(c=> c.GoodName == selectedGood).Select(c=> c.PhotoId).FirstOrDefault()).Select(x => x.PhotoAddress);
                var goodInfo = goodRepository.GetAll().Where(x=> x.GoodName== selectedGood);             
                foreach (var photoPath in photoPaths)
                {
                    Task.Run(() => {
                        Dispatcher.BeginInvoke(new Action(() => 
                        {
                            string[] paths = photoPath.Split(' ');
                            foreach (var link in paths)
                            {
                                var bitmap = new BitmapImage(new Uri(link));

                                PhotoViewStackPanel.Children.Add(new Image
                                {
                                    Source = bitmap,
                                    Height = 300,
                                    Width = 350
                                });
                            }
                        }));
                    });
                    
                    TBControl.SelectedIndex = 1;
                }

                foreach(var good in goodInfo)
                {
                    Task.Run(() => {
                        Dispatcher.BeginInvoke(new Action(() => { 
                            GoodInfoStackPanel.Children.Add(new Label
                            {
                                FontSize = 14,
                                Content = $"Title:\n{good.GoodName}"
                            });
                        }));
                    });
                    Task.Run(() =>
                    {
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            GoodInfoStackPanel.Children.Add(new Label
                            {
                                FontSize = 14,
                                Content = $"Manufactury:\n {manufacturerRepository.GetAll().Where(x => x.ManufacturerId == good.ManufacturerId).Select(x => x.ManufacturerName).FirstOrDefault()}"
                            });
                        }));
                    });
                    Task.Run(() =>
                    {
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            GoodInfoStackPanel.Children.Add(new Label
                            {
                                FontSize = 14,
                                Content = $"Price:\n {good.Price}"
                            });
                        }));
                    });
                    Task.Run(() =>
                    {
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            GoodInfoStackPanel1.Children.Add(new Label
                            {
                                FontSize = 14,
                                Content = $"Category:\n {categoryRepository.GetAll().Where(x => x.CategoryId == good.CategoryId).Select(x => x.CategoryName).FirstOrDefault()}"
                            });
                        }));
                    });
                    
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.ToString());
            }

        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (personInSystem == null)
                    MessageBox.Show("Can't identify yourself. Tap on the Log-In button or Create an account", "Can't identify the person", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                else
                {
                    string selectedGood = ((Label)GoodsListBox.SelectedItem).Content.ToString();
                    if (!String.IsNullOrEmpty(selectedGood))
                    {
                        var goodInfo = goodRepository.GetAll().Where(x => x.GoodName == selectedGood).FirstOrDefault();
                        MakeOrderForm mof = new MakeOrderForm(personInSystem, goodInfo);
                        mof.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Select the good, and then try again");
                    }
                }
            }
            catch(Exception )
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void FindTB_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {   if(!String.IsNullOrEmpty(FindTB.Text))
                {
                    TBControl.SelectedIndex = 0;
                    GoodsListBox.Items.Clear();
                    var selectedGoods = goodRepository.GetAll().Where(x=> x.GoodName.ToLower().Contains(FindTB.Text.ToLower()));
                    GoodDatasView(selectedGoods);
                 }
                 else
                 {
                    GoodsListBox.Items.Clear();
                 }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(FindTB.Text))
                {
                    TBControl.SelectedIndex = 0;
                    GoodsListBox.Items.Clear();

                    var selectedGoods = goodRepository.GetAll().Where(x => x.ManufacturerId == manufacturerRepository.GetAll().Where(m=> m.ManufacturerName.ToLower() == FindTB.Text).Select(m=> m.ManufacturerId).FirstOrDefault());
                    GoodDatasView(selectedGoods);
                }
                else
                {
                    GoodsListBox.Items.Clear();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
        private void GoodDatasView(IEnumerable<Good> selectedGoods)
        {
            foreach (var good in selectedGoods)
            {
                Task.Run(() =>
                {
                    var photoPaths = photoRepository.GetAll().Where(x => x.PhotoId == good.PhotoId).Select(x => x.PhotoAddress).FirstOrDefault();

                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        GoodsListBox.Items.Add(new Label
                        {
                            FontSize = 16,
                            Content = good.GoodName,
                            Height = 30
                        });

                        string[] paths = photoPaths.Split(' ');
                        var bitmap = new BitmapImage(new Uri(paths[0]));

                        GoodsListBox.Items.Add(new Image
                        {
                            Source = bitmap,
                            Height = 300,
                            Width = 350
                        });                        
                    }));
                   
                });
            }
        }

        private void BasketButton_Click(object sender, RoutedEventArgs e)
        {
            BasketForm bf = new BasketForm(personInSystem);
            bf.ShowDialog();
        }
    }
}