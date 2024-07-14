using ApplicationManagement.DAO;
using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationManagement.GUI
{
    /// <summary>
    /// Interaction logic for JobPosting.xaml
    /// </summary>
    public partial class JobPosting : Page
    {
        public JobPosting()
        {
            InitializeComponent();
        }

        RecruitFormDTO recruitForm = new RecruitFormDTO();
        RecruitFormDAO recruitFormDAO = new RecruitFormDAO();

        private void post_Click(object sender, RoutedEventArgs e)
        {
            recruitForm.TaxID = GlobalEnterprise.TaxID;
            recruitForm.Vacancies = vacanciesTextBox.Text;  
            recruitForm.Amount = numberRecruitTextBox.Text;

            if (dateStartPicker.SelectedDate.HasValue && dateEndPicker.SelectedDate.HasValue)
            {
                DateTime startDate = dateStartPicker.SelectedDate.Value;
                DateTime endDate = dateEndPicker.SelectedDate.Value;

                // Tính số ngày giữa hai ngày
                recruitForm.Time = (endDate - startDate).Days;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn cả hai ngày.");
                return;
            }

            recruitForm.Description = requireInfoTextBox.Text;
            if (specificDate.SelectedDate.HasValue)
            {
                DateTime exactlyDate = specificDate.SelectedDate.Value;
                DateTime startDate = dateStartPicker.SelectedDate.Value;
                DateTime endDate = dateEndPicker.SelectedDate.Value;
                recruitForm.ExactlyDate = exactlyDate;

                // Check if ExactlyDate is between startDate and endDate
                if (exactlyDate < startDate || exactlyDate > endDate)
                {
                    MessageBox.Show("Ngày chính xác phải nằm giữa ngày bắt đầu và ngày kết thúc.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ngày chính xác.");
                return;
            }
            recruitForm.Form = RecruitForm.Text;
            switch (recruitForm.Form)
            {
                case "Đăng tuyển trên báo giấy":
                    {
                        recruitForm.Form = "BAOGIAY";
                        break;
                    }
                case "Đăng banner quảng cáo":
                    {
                        recruitForm.Form = "BANNER";
                        break;
                    }
                case "Đăng trên các trang mạng":
                    {
                        recruitForm.Form = "MEDIA";
                        break;
                    }
            }    

            if (IsValid(recruitForm))
            {
                try
                {
                    recruitFormDAO.AddRecruit(recruitForm);
                    MessageBox.Show("Đăng tuyển thành công", "Thành Công!", MessageBoxButton.OK, MessageBoxImage.Information);
                    refeshForm();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đăng tuyển: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Thông tin đăng tuyển không hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsValid(RecruitFormDTO recruitFormDTO)
        {
            var properties = TypeDescriptor.GetProperties(recruitFormDTO);
            foreach (PropertyDescriptor property in properties)
            {
                var error = recruitFormDTO[property.Name];
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine(error);
                    return false;
                }
            }
            return true;
        }

        private void RecruitForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void refeshForm()
        {
            vacanciesTextBox.Text = string.Empty;
            numberRecruitTextBox.Text = string.Empty;
            dateStartPicker.Text = string.Empty;
            dateEndPicker.Text = string.Empty;
            requireInfoTextBox.Text = string.Empty;
            specificDate.Text = string.Empty;
            RecruitForm.Text = string.Empty;
        }
    }
}
