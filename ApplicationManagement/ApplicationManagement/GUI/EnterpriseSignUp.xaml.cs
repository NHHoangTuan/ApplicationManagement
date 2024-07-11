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

        public EnterpriseSignUp() {
            InitializeComponent();
        }

        private void enterpriseSignUp_Click(object sender, RoutedEventArgs e) {

            string Username = accountTextBox.Text;
            string Password = passwordTextBox.Text;

            enterprise.EnterpriseName = enterpriseNameTextBox.Text;
            enterprise.Description = "Description";
            enterprise.Logo = "Assets/Images/Design/enterprise.jpg";
            enterprise.Background = "Assets/Images/Design/1_1.jpg";
            enterprise.Address = enterpriseAddressTextBox.Text;
            enterprise.TaxID = taxCodeTextBox.Text;
            enterprise.Leader = representativeNameTextBox.Text;
            enterprise.Email = emailTextBox.Text;

            if (IsValid(enterprise)) {
                try {
                    enterpriseDAO.AddEnterpriseAccount(enterprise, Username, Password);
                    MessageBox.Show("Đăng ký thành công", "Thành Công!", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show($"Lỗi khi đăng ký: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else {
                MessageBox.Show("Thông tin đăng ký không hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
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
    }
}
