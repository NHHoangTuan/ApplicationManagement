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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApplicationManagement.GUI
{
    /// <summary>
    /// Interaction logic for ApproveApplicationDetail.xaml
    /// </summary>
    public partial class ApproveApplicationDetail : Window
    {

        ApplicationDTO selectedApplication;
        ApplicationBUS applicationBUS;
        ApproveBUS approveBUS;
        private string cvFilePath = "";

        public ApproveApplicationDetail(ApplicationDTO a)
        {
            InitializeComponent();

            this.DataContext = a;
            selectedApplication = a;

            applicationBUS = new ApplicationBUS();
            approveBUS = new ApproveBUS();
        }

        

        private void viewButton_Click(object sender, RoutedEventArgs e)
        {



            if (selectedApplication.CVPath == null) {

                MessageBox.Show("Không tìm thấy CV");
                return; }

            // Hiển thị và làm mờ overlay
            Overlay.Visibility = Visibility.Visible;
            DoubleAnimation fadeIn = new DoubleAnimation(0, 0.5, TimeSpan.FromSeconds(0.3));
            Overlay.BeginAnimation(OpacityProperty, fadeIn);

            cvFilePath = selectedApplication.CVPath;

            CVWindow cvWindow = new CVWindow();
            cvWindow.LoadPdf(cvFilePath);
            cvWindow.ShowDialog();

            // Sau khi dialog đóng, ẩn overlay
            DoubleAnimation fadeOut = new DoubleAnimation(0.5, 0, TimeSpan.FromSeconds(0.3));
            fadeOut.Completed += (s, e) => Overlay.Visibility = Visibility.Collapsed;
            Overlay.BeginAnimation(OpacityProperty, fadeOut);
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedApplication != null)
            {
                var result = MessageBox.Show($"Đồng ý phê duyệt hồ sơ ứng tuyển {selectedApplication.Candidate.CandidateName}?",
                   "Xác nhận phê duyệt", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    try
                    {
                        approveBUS.updateApproveStatus(selectedApplication.FormID, 1);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                    

                    DialogResult = true;

                    //updateDataSource(_currentPage, _currentCurrency, _currentStartPrice, _currentEndPrice, _currentList);
                }
            }
        }

        private void rejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedApplication != null)
            {
                var result = MessageBox.Show($"Từ chối phê duyệt cho hồ sơ ứng tuyển {selectedApplication.Candidate.CandidateName}?",
                   "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        approveBUS.updateApproveStatus(selectedApplication.FormID, -1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    DialogResult = true;

                    //updateDataSource(_currentPage, _currentCurrency, _currentStartPrice, _currentEndPrice, _currentList);
                }
            }
        }
    }
}
