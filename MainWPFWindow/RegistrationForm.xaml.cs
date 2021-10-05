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
    /// Interaction logic for RegistrationForm.xaml
    /// </summary>
    public partial class RegistrationForm : Window
    {
        Person personInSystem = null;
       public Person Person
        {
            get { return personInSystem; }
            set { personInSystem = value; }
        }
        public RegistrationForm()//user create
        {
            InitializeComponent();
            //AcceptButton.Content = "Create an account";
            AcceptButton.Visibility = Visibility.Visible;
            AcceptButton.IsEnabled = true;

            EditButton.Visibility = Visibility.Hidden;
            EditButton.IsEnabled = false;
        }
        public RegistrationForm(bool addRole) // administraiton create
        {
            InitializeComponent();
            // AcceptButton.Content = "Create an account";

            AcceptButton.Visibility = Visibility.Visible;
            AcceptButton.IsEnabled = true;

            EditButton.Visibility = Visibility.Hidden;
            EditButton.IsEnabled = false;

            if (addRole)
            {
                RoleLB.Visibility = Visibility.Visible;
                RoleTB.Visibility = Visibility.Visible;
                RoleTB.Text = "Customer";
            }
        }
         Person personToUpdate = null;
        public RegistrationForm(Person person) // administraiton edit
        {
            InitializeComponent();

           // AcceptButton.Content = "Edit an account";
       
            RoleLB.Visibility = Visibility.Visible;
            RoleTB.Visibility = Visibility.Visible;

            AcceptButton.Visibility = Visibility.Hidden;
            AcceptButton.IsEnabled = false;

            EditButton.Visibility = Visibility.Visible;
            EditButton.IsEnabled = true;

            personToUpdate = new Person();
            personToUpdate = person;
            FirstNameTB.Text = personToUpdate.FirstName;
            LastNameTB.Text = personToUpdate.LastName;
            EmailTB.Text = personToUpdate.Email;
            RoleTB.Text = personToUpdate.Role;
            LoginTB.Text = personToUpdate.Login;
           
            PasswordPB.Password = personToUpdate.Password;
            PasswordTB.Text = personToUpdate.Password;
        }
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if(CheckDatas(true))
            {
                if(personToUpdate==null)
                {
                    personToUpdate = new Person();
                }
                using (PersonRepository personRepository = new PersonRepository())
                {
                    personToUpdate.FirstName = FirstNameTB.Text;
                    personToUpdate.LastName = LastNameTB.Text;
                    personToUpdate.Email = EmailTB.Text;
                    personToUpdate.Role = RoleTB.Text;
                    personToUpdate.Login = LoginTB.Text;
                    personToUpdate.Password = PasswordPB.Password;
                    personRepository.CreateOrUpdate(personToUpdate);
                    personRepository.Save();
                    personInSystem = personRepository.GetAll().Where(x => x.Login.ToString() == LoginTB.Text.ToString() && x.Password.ToString() == PasswordPB.Password.ToString()).FirstOrDefault();
                }
                MessageBox.Show("Done");
                this.Close();
            }   
        }
        private void PasswordLB_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PasswordTB.Visibility = Visibility.Hidden;
            PasswordTB.Clear();
        }
        private void PasswordLB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PasswordTB.Text = PasswordPB.Password;
            PasswordTB.Visibility = Visibility.Visible;
        }

        private void PasswordLB_MouseLeave(object sender, MouseEventArgs e)
        {
            PasswordTB.Visibility = Visibility.Hidden;
            PasswordTB.Clear();
        }
        private bool CheckDatas(bool checkInDB)
        {
            bool continueWork = true;
            if (String.IsNullOrEmpty(FirstNameTB.Text))
            {
                MessageBox.Show("Enter your first name", "FirstNameTB is empty", MessageBoxButton.OK, MessageBoxImage.Warning);
                continueWork = false;
            }
            else if (String.IsNullOrEmpty(LastNameTB.Text))
            {
                MessageBox.Show("Enter your last name", "LastNameTB is empty", MessageBoxButton.OK, MessageBoxImage.Warning);
                continueWork = false;
            }
            else if (String.IsNullOrEmpty(EmailTB.Text))
            {
                MessageBox.Show("Enter your e-mail", "EmailTB is empty", MessageBoxButton.OK, MessageBoxImage.Warning);
                continueWork = false;
            }
            else if (!EmailTB.Text.Contains('@') || !EmailTB.Text.Contains('.'))
            {
                MessageBox.Show("Create new e-mail", "Create e-mail with '.' and '@' ", MessageBoxButton.OK, MessageBoxImage.Error);
                continueWork = false;
            }
            else if (String.IsNullOrEmpty(LoginTB.Text))
            {
                MessageBox.Show("Enter your login", "LoginTB is empty", MessageBoxButton.OK, MessageBoxImage.Warning);
                continueWork = false;
            }
            else if (String.IsNullOrEmpty(PasswordPB.Password))
            {
                MessageBox.Show("Enter your password", "PasswordPB is empty", MessageBoxButton.OK, MessageBoxImage.Warning);
                continueWork = false;
            }
            else
            {
                if(checkInDB)
                {
                    using (PersonRepository personRepository = new PersonRepository())
                    {
                        var loginExist = personRepository.GetAll().Where(x => x.Login == LoginTB.Text).Select(x => x.Login).FirstOrDefault();
                        var emailExist = personRepository.GetAll().Where(x => x.Email == EmailTB.Text).Select(x => x.Email).FirstOrDefault();
                        if (!String.IsNullOrEmpty(emailExist))
                        {
                            MessageBox.Show("Email already exist", "Create new e-mail", MessageBoxButton.OK, MessageBoxImage.Error);
                            continueWork = false;
                        }
                        else if(!String.IsNullOrEmpty(loginExist))
                        {
                            MessageBox.Show("Create new login", "This login is alredy exist", MessageBoxButton.OK, MessageBoxImage.Error);
                            continueWork = false;
                        }
                      
                    }
                }
               
                if (String.IsNullOrEmpty(RoleTB.Text))
                {
                    RoleTB.Text = "Customer";
                }
                
            }
            if (continueWork)
                return true;
            else
                return false;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
           
             if (CheckDatas(false))
             {
                 if (personToUpdate == null)
                 {
                     personToUpdate = new Person();
                 }
                 using (PersonRepository personRepository = new PersonRepository())
                 {
                     personToUpdate.FirstName = FirstNameTB.Text;
                     personToUpdate.LastName = LastNameTB.Text;
                     personToUpdate.Email = EmailTB.Text;
                     personToUpdate.Role = RoleTB.Text;
                     personToUpdate.Login = LoginTB.Text;
                     personToUpdate.Password = PasswordPB.Password;
                     personRepository.CreateOrUpdate(personToUpdate);
                     personRepository.Save();
                 }
                 MessageBox.Show("Done");
                 this.Close();
             }
        
        }
    }
}
