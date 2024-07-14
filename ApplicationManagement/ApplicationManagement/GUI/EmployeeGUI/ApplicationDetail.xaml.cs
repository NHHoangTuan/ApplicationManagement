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

namespace ApplicationManagement.GUI.EmployeeGUI
{
    /// <summary>
    /// Interaction logic for ApplicationDetail.xaml
    /// </summary>
    public partial class ApplicationDetail : Window
    {

        ApplicationDTO selectedApplication;
        ApplicationBUS applicationBUS;
        ApproveBUS approveBUS;

        public ApplicationDetail(ApplicationDTO a)
        {
            InitializeComponent();
            this.DataContext = a;
            selectedApplication = a;
            
            applicationBUS = new ApplicationBUS();
            approveBUS = new ApproveBUS();

        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedApplication != null)
            {
                var result = MessageBox.Show($"Bạn có chắc muốn duyệt hồ sơ ứng tuyển {selectedApplication.Candidate.CandidateName}?",
                   "Xác nhận duyệt", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    try
                    {
                        applicationBUS.setValidity(selectedApplication, "OK");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    try
                    {
                        applicationBUS.updateApplicationStatus(selectedApplication);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }


                    try
                    {
                        approveBUS.insertApprove(selectedApplication.FormID, selectedApplication.Enterprise.TaxID);
                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message); }

                    DialogResult = true;

                    //updateDataSource(_currentPage, _currentCurrency, _currentStartPrice, _currentEndPrice, _currentList);
                }
            }
        }

        private void rejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedApplication != null)
            {
                var result = MessageBox.Show($"Bạn có chắc muốn từ chối hồ sơ ứng tuyển {selectedApplication.Candidate.CandidateName}?",
                   "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        applicationBUS.setValidity(selectedApplication, "REJECT");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    /*try
                    {
                        applicationBUS.deleteApplication(selectedApplication);
                    }
                    catch ( Exception ex) { MessageBox.Show(ex.Message ); }*/

                    try
                    {
                        applicationBUS.updateApplicationStatus(selectedApplication);
                    }
                    catch ( Exception ex) { MessageBox.Show(ex.Message ); }

                    DialogResult = true;

                    //updateDataSource(_currentPage, _currentCurrency, _currentStartPrice, _currentEndPrice, _currentList);
                }
            }
        }
    }
}
