using ApplicationManagement.BUS;
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

namespace ApplicationManagement.GUI.CandidateGUI
{
    /// <summary>
    /// Interaction logic for SubmittedApplication.xaml
    /// </summary>
    public partial class SubmittedApplication : Page
    {

        BindingList<ApplicationDTO> listShow = null;
        BindingList<ApplicationDTO> originalList = null; // Store the original list
        RecruitmentBUS _recruitmentBUS;
        BrowseProfileBUS browseProfileBUS;
        ApplicationBUS _applicationBUS;


        public SubmittedApplication()
        {
            InitializeComponent();
            _recruitmentBUS = new RecruitmentBUS();
            browseProfileBUS = new BrowseProfileBUS();
            _applicationBUS = new ApplicationBUS();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            originalList = _applicationBUS.getAllApplicationForCandidate(Login.CurrentAccountID);

            if (originalList != null)
            {
                listShow = new BindingList<ApplicationDTO>(originalList.ToList());
            }

            if (listShow != null)
                submittedApplicationListView.ItemsSource = listShow;

            if (listShow == null || listShow.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy gì";
            }

        }

        public void RefeshList(BindingList<ApplicationDTO> list)
        {
            if (list != null)
            {
                listShow = new BindingList<ApplicationDTO>(list.ToList());
            }

            if (listShow != null)
                submittedApplicationListView.ItemsSource = listShow;

            if (listShow == null || listShow.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy gì";
            }
            else
            {
                MessageText.Text = "";
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void statusButton_Loaded(object sender, RoutedEventArgs e)
        {
            Button statusButton = sender as Button;
            if (statusButton == null)
                return;

            // Find the data context (which is your PaymentItem)
            ApplicationDTO item = statusButton.DataContext as ApplicationDTO;
            if (item == null)
                return;

            // Apply the logic based on the value of item.IsPaid
            var browseProfile = browseProfileBUS.getBrowseProfileByFormID(item.FormID);

            if (item.Validity == "OK" && browseProfile.trangthai == 1)
            {
                statusButton.Content = "Đã được doanh nghiệp duyệt";
                statusButton.IsEnabled = false;
                statusButton.Background = new SolidColorBrush(Colors.Green);
                //rejectButton.Visibility = Visibility.Hidden;
            }
            else if (item.Validity == "OK" && browseProfile.trangthai == 0)
            {
                statusButton.Content = "⏱ Chờ doanh nghiệp duyệt";
                statusButton.IsEnabled = false;
                statusButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4cc7cf"));
                //rejectButton.Visibility = Visibility.Hidden;
            }
            
            
            else if (item.Validity == "REJECT")
            {
                statusButton.Content = "Bị từ chối và hủy bài ứng tuyển";
                statusButton.IsEnabled = false;
                statusButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f2889e"));
            }
            else
            {
                statusButton.Content = "Chờ duyệt";
                statusButton.IsEnabled = false;
                statusButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3d5875"));
            }
        }

        private void SortCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
