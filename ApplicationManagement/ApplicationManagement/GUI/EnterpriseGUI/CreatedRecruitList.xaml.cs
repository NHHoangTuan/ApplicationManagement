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

namespace ApplicationManagement.GUI.EnterpriseGUI
{
    /// <summary>
    /// Interaction logic for CreatedRecruitList.xaml
    /// </summary>
    public partial class CreatedRecruitList : Page
    {

        BindingList<RecruitmentDTO>? list = null;
        BindingList<RecruitmentDTO>? originalList = null; // Store the original list

        BindingList<RecruitmentDTO>? listShow = null;
        RecruitmentBUS _recruitmentBUS;
        BillBUS _billBUS;

        public CreatedRecruitList()
        {
            InitializeComponent();
            _recruitmentBUS = new RecruitmentBUS();
            _billBUS = new BillBUS();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            originalList = _recruitmentBUS.getAllRecruitmentForEnterprise(Login.CurrentAccountID);

            if (originalList != null)
            {
                listShow = new BindingList<RecruitmentDTO>(originalList.ToList());
            }

            if (listShow != null)
                recruitListView.ItemsSource = listShow;

            if (listShow == null || listShow.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy bất kì bài tuyển dụng nào";
            }
            else
            {
                MessageText.Text = "";
            }
        }


        public void RefeshList(BindingList<RecruitmentDTO> list)
        {
            if (list != null)
            {
                listShow = new BindingList<RecruitmentDTO>(list.ToList());
            }

            if (listShow != null)
                recruitListView.ItemsSource = listShow;

            if (listShow == null || listShow.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy bất kì bài tuyển dụng nào";
            }
            else
            {
                MessageText.Text = "";
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void SortCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void statusButton_Loaded(object sender, RoutedEventArgs e)
        {
            Button statusButton = sender as Button;
            if (statusButton == null)
                return;

            // Find the data context (which is your PaymentItem)
            RecruitmentDTO item = statusButton.DataContext as RecruitmentDTO;
            if (item == null)
                return;

            // Apply the logic based on the value of item.IsPaid
            var bill = _billBUS.getBillByFormID(item.formID);
            if (item.Validity == "OK" && bill.DaNhan == 1)
            {
                statusButton.Content = "Đã được duyệt và thanh toán";
                statusButton.IsEnabled = false;
                statusButton.Background = new SolidColorBrush(Colors.Green);
                //rejectButton.Visibility = Visibility.Hidden;
            }
            else if (item.Validity == "OK" && bill.DaNhan == 0)
            {
                statusButton.Content = "⏱ Đã thanh toán và chờ duyệt";
                statusButton.IsEnabled = false;
                statusButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4cc7cf"));
                //rejectButton.Visibility = Visibility.Hidden;
            }
            else if (item.Validity == "OK" && bill.DaNhan == -1)
            {
                statusButton.Content = "Đã được duyệt, chờ thanh toán";
                statusButton.IsEnabled = false;
                statusButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e06666"));
                //rejectButton.Visibility = Visibility.Visible;
            }
            else if (item.Validity == "OK" && bill.DaNhan == -2)
            {
                statusButton.Content = "Bị từ chối thanh toán";
                statusButton.IsEnabled = false;
                statusButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a9a19b"));
            }
            else if (item.Validity == "REJECT")
            {
                statusButton.Content = "Bị từ chối và hủy bài tuyển dụng";
                statusButton.IsEnabled = false;
                statusButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f0bae0"));
            }
            else
            {
                statusButton.Content = "Chờ duyệt";
                statusButton.IsEnabled = false;
                statusButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3d5875"));
            }
        }
    }
}
