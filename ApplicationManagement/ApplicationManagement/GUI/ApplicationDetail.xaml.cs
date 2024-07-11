using ApplicationManagement.BUS;
using ApplicationManagement.DTO;
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

namespace ApplicationManagement.GUI
{
    /// <summary>
    /// Interaction logic for ApplicationDetail.xaml
    /// </summary>
    public partial class ApplicationDetail : Window
    {

        ApplicationDTO selectedApplication;
        ApplicationBUS applicationBUS;

        public ApplicationDetail(ApplicationDTO a)
        {
            InitializeComponent();
            this.DataContext = a;
            selectedApplication = a;
            
            applicationBUS = new ApplicationBUS();

        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedApplication != null)
            {
                var result = MessageBox.Show($"Bạn có chắc muốn duyệt hồ sơ ứng tuyển {selectedApplication.Candidate.CandidateName}?",
                   "Xác nhận duyệt", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    applicationBUS.setValidity(selectedApplication, true);
                    applicationBUS.updateApplicationStatus(selectedApplication);
                    DialogResult = true;

                    //updateDataSource(_currentPage, _currentCurrency, _currentStartPrice, _currentEndPrice, _currentList);
                }
            }
        }

        private void rejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedApplication != null)
            {
                var result = MessageBox.Show($"Bạn có chắc muốn xóa hồ sơ ứng tuyển {selectedApplication.Candidate.CandidateName}?",
                   "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    applicationBUS.setValidity(selectedApplication, true);
                    applicationBUS.deleteApplication(selectedApplication);
                    DialogResult = true;

                    //updateDataSource(_currentPage, _currentCurrency, _currentStartPrice, _currentEndPrice, _currentList);
                }
            }
        }
    }
}
