using ApplicationManagement.BUS;
using ApplicationManagement.DAO;
using ApplicationManagement.DTO;
using System;
using System.ComponentModel;
using System.Windows;

namespace ApplicationManagement.GUI {
    /// <summary>
    /// Interaction logic for EnterpriseSignUp.xaml
    /// </summary>
    public partial class EnterpriseSignUp : Window {
        EnterpriseDTO enterprise = new EnterpriseDTO();
        EnterpriseDAO enterpriseDAO = new EnterpriseDAO();
        AccountBUS accountBUS;

        public EnterpriseSignUp() {
            InitializeComponent();
            accountBUS = new AccountBUS();
        }

        private void enterpriseSignUp_Click(object sender, RoutedEventArgs e) {

            string Username = accountTextBox.Text;
            string Password = passwordTextBox.Password;
            string retypePassword = retypePasswordTextBox.Password;

            enterprise.EnterpriseName = enterpriseNameTextBox.Text;
            enterprise.Description = "Description";
            enterprise.Logo = "Assets/Images/Design/enterprise.jpg";
            enterprise.Background = "Assets/Images/Design/1_1.jpg";
            enterprise.Address = enterpriseAddressTextBox.Text;
            enterprise.TaxID = taxCodeTextBox.Text;
            enterprise.Leader = representativeNameTextBox.Text;
            enterprise.Email = emailTextBox.Text;


            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(retypePassword))
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản và mật khẩu");
            else if (Password.Equals(retypePassword) == false) MessageBox.Show("Hai mật khẩu không trùng khớp");
            else if (accountBUS.IsUsernameExist(Username))
            {
                MessageBox.Show("Tên tài khoản đã tồn tại");
            }

            else
            {

                if (IsValid(enterprise))
                {
                    try
                    {
                        enterpriseDAO.AddEnterpriseAccount(enterprise, Username, Password);
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

        private bool IsValid(EnterpriseDTO enterprise) {
            var properties = TypeDescriptor.GetProperties(enterprise);
            foreach (PropertyDescriptor property in properties) {
                var error = enterprise[property.Name];
                if (!string.IsNullOrEmpty(error)) {
                    Console.WriteLine(error);
                    return false;
                }
            }
            return true;
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

        private void retypePasswordTextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            retypePasswordTextBox.Focus();
        }

        private void passwordTextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            passwordTextBox.Focus();
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
    }
}
