using ApplicationManagement.BUS;
using ApplicationManagement.DAO;
using ApplicationManagement.DTO;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ApplicationManagement.GUI {
    /// <summary>
    /// Interaction logic for EnterpriseSignUp.xaml
    /// </summary>
    public partial class EnterpriseSignUp : Window {

        private FileInfo? _selectedImage = null;
        private bool _isImageChanged = false;

        EnterpriseDTO enterprise = new EnterpriseDTO();
        EnterpriseBUS enterpriseBUS;
        AccountBUS accountBUS;

        public EnterpriseSignUp() {
            InitializeComponent();
            accountBUS = new AccountBUS();
            enterpriseBUS = new EnterpriseBUS();
        }

        private void enterpriseSignUp_Click(object sender, RoutedEventArgs e) {

            string Username = accountTextBox.Text;
            string Password = passwordTextBox.Password;
            string retypePassword = retypePasswordTextBox.Password;

            enterprise.EnterpriseName = enterpriseNameTextBox.Text;
            enterprise.Address = enterpriseAddressTextBox.Text;
            enterprise.TaxID = taxCodeTextBox.Text;
            enterprise.Leader = representativeNameTextBox.Text;
            enterprise.Email = emailTextBox.Text;
            enterprise.LogoPath = "...";

            if (enterprise.TaxID.Length != 10)
            {
                MessageBox.Show("Vui lòng nhập mã số thuế đúng 10 số");
                return;
            }

            if (_selectedImage == null)
            {
                MessageBox.Show("Vui lòng nhập hình ảnh");
                return;
            }
            string key = Guid.NewGuid().ToString();


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
                        enterpriseBUS.AddEnterpriseAccount(enterprise, Username, Password);
                        MessageBox.Show("Đăng ký thành công", "Thành Công!", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi đăng ký: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    try
                    {
                        enterprise.LogoPath = enterpriseBUS.uploadImage(_selectedImage, enterprise.TaxID, key);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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

        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            screen.Filter = "Files|*.png; *.jpg; *.jpeg;";
            if (screen.ShowDialog() == true)
            {
                _isImageChanged = true;
                _selectedImage = new FileInfo(screen.FileName);

                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(screen.FileName, UriKind.Absolute);
                bitmap.EndInit();

                AddedImage.Source = bitmap;

            }
        }
    }
}
