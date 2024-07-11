using ApplicationManagement.BUS;
using ApplicationManagement.DAO;
using ApplicationManagement.DTO;
using System;
using System.ComponentModel;
using System.Windows;

namespace ApplicationManagement.GUI {
    /// <summary>
    /// Interaction logic for CandidateSignUp.xaml
    /// </summary>
    public partial class CandidateSignUp : Window {

        CandidateDTO candidate;
        CandidateBUS candidateBUS;
        AccountBUS accountBUS;

        public CandidateSignUp() {
            InitializeComponent();
            candidate = new CandidateDTO();
            candidateBUS = new CandidateBUS();
            accountBUS = new AccountBUS();
        }

        private void candidateSignUp_Click(object sender, RoutedEventArgs e) {

            candidate.CandidateName = candidateNameTextBox.Text;
            candidate.CCCD = candidateIDTextBox.Text;
            candidate.PhoneNumber = candidatePhoneNumberTextBox.Text;
            candidate.Gender = (bool)candidateRadioButtonMale.IsChecked ? "Nam" : "Nữ";
            candidate.DateOfBirth = candidateDOB.SelectedDate.ToString();

            string inputUsername = usernameTextBox.Text;
            string inputPassword = passwordTextBox.Password;
            string inputRePassword = retypePasswordTextBox.Password;


            if (string.IsNullOrEmpty(inputUsername) || string.IsNullOrEmpty(inputPassword) || string.IsNullOrEmpty(inputRePassword))
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản và mật khẩu");
            else if (inputPassword.Equals(inputRePassword) == false) MessageBox.Show("Hai mật khẩu không trùng khớp");

            else
            {

                if (IsValid(candidate))
                {
                    try
                    {
                        candidateBUS.saveCandidate(candidate);
                        accountBUS.addAccount(inputUsername, inputPassword, candidate);
                        MessageBox.Show("Đăng ký thành công", "Thành Công!", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi đăng ký: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin đăng ký không hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool IsValid(CandidateDTO candidate) {
            var properties = TypeDescriptor.GetProperties(candidate);
            foreach (PropertyDescriptor property in properties) {
                var error = candidate[property.Name];
                if (!string.IsNullOrEmpty(error)) {
                    Console.WriteLine(error);
                    return false;
                }
            }
            return true;
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

        private void retypePasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(retypePasswordTextBox.Password) && retypePasswordTextBox.Password.Length > 0)
            {
                retypePasswordTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                retypePasswordTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void passwordTextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            passwordTextBox.Focus();
        }

        private void retypePasswordTextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            retypePasswordTextBox.Focus();
        }
    }
}
