using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApplicationManagement.GUI {
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window {
        bool isChecked;
        public Login() {
            InitializeComponent();
            if (rememberCheckBox.IsChecked == true) {
                isChecked = true;
            }
            else {
                isChecked = false;
            }
        }

        private void userTextBlock_MouseDown(object sender, MouseButtonEventArgs e) {
            userTextBox.Focus();
        }

        private void userTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            if (!string.IsNullOrEmpty(userTextBox.Text) && userTextBox.Text.Length > 0) {
                userTextBlock.Visibility = Visibility.Collapsed;
            }
            else {
                userTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void passwordTextBox_PasswordChanged(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrEmpty(passwordTextBox.Password) && passwordTextBox.Password.Length > 0) {
                passwordTextBlock.Visibility = Visibility.Collapsed;
            }
            else {
                passwordTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void passwordTextBlock_MouseDown(object sender, MouseButtonEventArgs e) {
            passwordTextBox.Focus();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e) {
            Close();
        }



        private void SignInButton_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrEmpty(userTextBox.Text) && !string.IsNullOrEmpty(passwordTextBox.Password)) {

                string inputUsername = userTextBox.Text;
                string inputPassword = passwordTextBox.Password;

                if (inputUsername == "staff") {
                    MainWindow mainPage = new MainWindow();
                    this.Close();
                    mainPage.Show();
                }
                else if (inputUsername == "enterprise") {
                    EnterpriseWindow enterprisePage = new EnterpriseWindow();
                    this.Close();
                    enterprisePage.Show();
                }
                else if (inputUsername == "candidate") {
                    CandidateWindow candidatePage = new CandidateWindow();
                    this.Close();
                    candidatePage.Show();
                }
            }

        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e) {
            var chooseWindow = new ChooseTypeSignUp();
            chooseWindow.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
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

        private void rememberCheckBox_Click(object sender, RoutedEventArgs e) {
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
