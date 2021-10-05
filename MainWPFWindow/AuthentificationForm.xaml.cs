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
    /// Interaction logic for RegistrationAuthentificationForm.xaml
    /// </summary>
    public partial class AuthentificationForm : Window
    {
        private Person person;
        public AuthentificationForm()
        {
            InitializeComponent();
        }
        public Person Person
        {
            get { return person; }
            set {  person = value; }
        }
        private  void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => {
                Dispatcher.BeginInvoke(new Action(() => { 

                    if (!String.IsNullOrEmpty(LoginTB.Text) && !String.IsNullOrEmpty(PasswordPB.Password))
                    {
                        using (PersonRepository db = new PersonRepository())
                        {
                            var userExist = db.GetAll().Where(x => x.Login.ToString() == LoginTB.Text.ToString() && x.Password.ToString() == PasswordPB.Password.ToString()).ToList();//.FirstOrDefault();

                            if (userExist.Count == 0)
                            {
                                MessageBox.Show("Check your Log-In and Password", "No such user", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                            else
                            {
                                person = userExist.FirstOrDefault();
                                MessageBox.Show("Welcome in 'InternetShop'");
                                this.Close();
                                if (userExist.FirstOrDefault().Role == "Administrator" || userExist.FirstOrDefault().Role == "CreatorDataBase")
                                {
                                    AdministratorForm administratorForm = new AdministratorForm();
                                    administratorForm.ShowDialog();
                                }
                            }
                        }            
                    }
                    else
                    {
                        MessageBox.Show("Fill your Log-In and Password", "Empty text boxes", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }));
            });
        }
        private void PasswordLB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PasswordTB.Visibility = Visibility.Visible;
            PasswordTB.Text = PasswordPB.Password;
        }

        private void PasswordLB_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PasswordTB.Visibility = Visibility.Hidden;
            PasswordTB.Clear();
        }

        private void PasswordLB_MouseLeave(object sender, MouseEventArgs e)
        {
            PasswordTB.Visibility = Visibility.Hidden;
            PasswordTB.Clear();
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationForm rf = new RegistrationForm();
            rf.ShowDialog();
            if(rf.Person!=null)
            person = rf.Person;
            this.Close();
        }
    }
}
