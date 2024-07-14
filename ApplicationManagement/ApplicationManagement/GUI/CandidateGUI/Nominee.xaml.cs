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

namespace ApplicationManagement.GUI
{
    /// <summary>
    /// Interaction logic for Nominee.xaml
    /// </summary>
    public partial class Nominee : Page
    {

        BindingList<RecruitmentDTO> listShow = null;
        BindingList<RecruitmentDTO> originalList = null; // Store the original list
        RecruitmentBUS _recruitmentBUS;
        BrowseProfileBUS browseProfileBUS;

        // Page pagination
        int currentPage = 1;
        int itemsPerPage = 4;

        public Nominee()
        {
            InitializeComponent();
            _recruitmentBUS = new RecruitmentBUS();
            browseProfileBUS = new BrowseProfileBUS();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            // Initialize or reset currentPage
            currentPage = 1;

            originalList = _recruitmentBUS.getAllRecruitmentForApplication();

            if(originalList!= null)
            {
                listShow = new BindingList<RecruitmentDTO>(originalList.ToList());
            }

            if (listShow!= null)
            nomineeListView.ItemsSource = listShow;

            if (listShow == null || listShow.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy bất kì vị trí ứng tuyển nào";
            }
            else
            {
                MessageText.Text = "";
            }

        }


        private void RefeshList(BindingList<RecruitmentDTO> list)
        {
            if (list == null)
            {
                return;
            }

            var currentListShow = list.ToList();
            if (currentListShow != null)
                nomineeListView.ItemsSource = currentListShow;

            if (currentListShow == null || currentListShow.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy bất kì vị trí ứng tuyển nào";
            }
            else
            {
                MessageText.Text = "";
            }


        }


        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var nominee = nomineeListView.SelectedItem as RecruitmentDTO;
            if (nominee == null) return;
            NomineeDetail nomineeDetail = new NomineeDetail(nominee);
            nomineeDetail.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (nomineeDetail.ShowDialog() == true)
            {

                originalList.Clear();
                originalList = _recruitmentBUS.getAllRecruitmentForApplication();
                RefeshList(originalList);
                StatusButton_Loaded(sender, e);


            }
        }


        private void StatusButton_Loaded(object sender, RoutedEventArgs e)
        {
            Button statusButton = sender as Button;
            if (statusButton == null)
                return;

            // Find the data context (which is your PaymentItem)
            RecruitmentDTO item = statusButton.DataContext as RecruitmentDTO;
            if (item == null)
                return;

            int applied = browseProfileBUS.getApplicationFormIDWithCurrentUser(item.formID, Login.CurrentAccountID);

            if (applied != -1)
            {
                
                statusButton.Content = "Đã ứng tuyển";
                statusButton.IsEnabled = false;
                //statusButton.Background = new SolidColorBrush(Colors.Green);
                statusButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6aa84f"));
            }
            else
            {
                statusButton.Visibility = Visibility.Hidden;
            }
        }
    }
}
