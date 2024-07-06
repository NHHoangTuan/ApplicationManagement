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

        CandidateDTO candidate = new CandidateDTO();
        DatabaseHelper dbHelper;

        public CandidateSignUp() {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            candidate = new CandidateDTO();
        }

        private void candidateSignUp_Click(object sender, RoutedEventArgs e) {

            candidate.CandidateName = candidateNameTextBox.Text;
            candidate.CCCD = candidateIDTextBox.Text;
            candidate.PhoneNumber = candidatePhoneNumberTextBox.Text;
            candidate.Gender = (bool)candidateRadioButtonMale.IsChecked ? "Nam" : "Nữ";
            candidate.DateOfBirth = candidateDOB.SelectedDate.ToString();

            if (IsValid(candidate)) {
                try {
                    dbHelper.SaveCandidate(candidate);
                    dbHelper.AddCandidateAccount(candidate);
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
    }
}
