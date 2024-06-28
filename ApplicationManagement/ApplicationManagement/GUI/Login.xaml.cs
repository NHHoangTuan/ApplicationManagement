using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ApplicationManagement.GUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        bool isChecked;
        public Login()
        {
            InitializeComponent();
            if (rememberCheckBox.IsChecked == true)
            {
                isChecked = true;
            }
            else
            {
                isChecked = false;
            }
        }

        private void userTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            userTextBox.Focus();
        }

        private void userTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(userTextBox.Text) && userTextBox.Text.Length > 0)
            {
                userTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                userTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void passwordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordTextBox.Password) && passwordTextBox.Password.Length > 0)
            {
                passwordTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                passwordTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void passwordTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordTextBox.Focus();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }



        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            /*if (!string.IsNullOrEmpty(userTextBox.Text) && !string.IsNullOrEmpty(passwordTextBox.Password))
            {

                string inputUsername = userTextBox.Text;
                string inputPassword = passwordTextBox.Password;

                UserBUS productBUS = new UserBUS();
                User handleApiUser = productBUS.getOne(inputUsername, inputPassword);

                if (handleApiUser != null)
                {

                    Trace.WriteLine("Success");


                    MainWindow mainPage = new MainWindow();
                    AppConfig.SetValue("username", inputUsername);
                    AppConfig.SetValue("password", inputPassword);
                    this.Close();
                    mainPage.Show();


                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                    Trace.WriteLine("invalid Username or password");
                }
            }*/
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            /*var signUp = new SignUp();
            signUp.ShowDialog();*/
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*string? checkRemember = AppConfig.GetValue("checkRememberMe");


            if (checkRemember != null && checkRemember.Equals("true"))
            {
                isChecked = true;
            }
            if (checkRemember != null && checkRemember.Equals("false"))
            {
                isChecked = false;
            }

            if (isChecked == true)
            {
                rememberCheckBox.IsChecked = true;
                userTextBox.Text = AppConfig.GetValue("username");
                passwordTextBox.Password = AppConfig.GetValue("password");
            }
            else { rememberCheckBox.IsChecked = false; }*/
        }

        private void rememberCheckBox_Click(object sender, RoutedEventArgs e)
        {
            /*if (rememberCheckBox.IsChecked == true)
            {
                isChecked = true;
                AppConfig.SetValue("checkRememberMe", "true");
            }
            else
            {
                isChecked = false;
                AppConfig.SetValue("checkRememberMe", "false");
            }*/
        }
    }
}
