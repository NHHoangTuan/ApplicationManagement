using ApplicationManagement.BUS;
using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Page
    {

        BindingList<RecruitmentDTO> listShow = null;
        BindingList<RecruitmentDTO> originalList = null; // Store the original list
        RecruitmentBUS _recruitmentBUS;
        BillBUS _billBUS;
        

        public Payment()
        {
            InitializeComponent();
            _recruitmentBUS = new RecruitmentBUS();
            _billBUS = new BillBUS();
        }

        

        // Page pagination
        int currentPage = 1;
        int itemsPerPage = 4;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
            // Initialize or reset currentPage
            currentPage = 1;


            originalList = _recruitmentBUS.getAllRecruitmentWaitingPayment(Login.CurrentAccountID);


            var billStatus = _billBUS.GetBillStatuses();

            /*if (originalList != null)
            {
                listShow = new BindingList<RecruitmentDTO>(
                    originalList.Where(a =>
                        (!billStatus.ContainsKey(a.formID) && a.Validity == "OK") ||
                        (billStatus.ContainsKey(a.formID) && billStatus[a.formID] == -1)
                    ).ToList()
                );
            }*/

            if (originalList != null)
            {
                listShow = new BindingList<RecruitmentDTO>(
                    originalList.ToList()
                );
            }

            if (listShow != null) 
            PaymentListView.ItemsSource = listShow;

            if (listShow == null || listShow.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy bất kì đơn cần thanh toán nào";
            }



            // Display the first page items
            DisplayCurrentPageItems();

        }

        private void UpdatePageInfo()
        {
            int totalPages = (int)Math.Ceiling((double)listShow.Count / itemsPerPage);
            pageInfoTextBlock.Text = $"{currentPage}/{totalPages}";

        }

        private void DisplayCurrentPageItems()
        {
            int startIndex = (currentPage - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage - 1, listShow.Count - 1);

            var currentPageItems = listShow.Skip(startIndex).Take(itemsPerPage).ToList();

            PaymentListView.ItemsSource = currentPageItems;

            UpdatePageInfo();
        }

        private void Payment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var payment = PaymentListView.SelectedItem as RecruitmentDTO;
            if (payment == null) return;
            PaymentDetail paymentDetail = new PaymentDetail(payment);
            paymentDetail.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (paymentDetail.ShowDialog() == true)
            {
                originalList.Clear();
                originalList = _recruitmentBUS.getAllRecruitmentWaitingPayment(Login.CurrentAccountID);

                RefeshList(originalList);
                PaymentButton_Loaded(sender, e);

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
                PaymentListView.ItemsSource = currentListShow;

            if (currentListShow == null || currentListShow.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy bất kì đơn cần thanh toán nào";
            }

          
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LastButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SortCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchTermTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FirstButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rejectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PaymentButton_Loaded(object sender, RoutedEventArgs e)
        {
            Button paymentButton = sender as Button;
            if (paymentButton == null)
                return;

            // Find the data context (which is your PaymentItem)
            RecruitmentDTO item = paymentButton.DataContext as RecruitmentDTO;
            if (item == null)
                return;

            // Apply the logic based on the value of item.IsPaid
            var bill = _billBUS.getBillByFormID(item.formID);
            if (bill != null && bill.DaNhan == 1)
            {
                paymentButton.Content = "😘 Đã Thanh Toán";
                paymentButton.IsEnabled = false;
                paymentButton.Background = new SolidColorBrush(Colors.Green);
                //rejectButton.Visibility = Visibility.Hidden;
            }
            else if (bill != null && bill.DaNhan == 0)
            {
                paymentButton.Content = "⏱ Đã thanh toán và chờ duyệt";
                paymentButton.IsEnabled = false;
                paymentButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4cc7cf"));
                //rejectButton.Visibility = Visibility.Hidden;
            }
            else if (bill != null && bill.DaNhan == -1)
            {
                paymentButton.Content = "Chưa Thanh Toán";
                paymentButton.IsEnabled = false;
                paymentButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e06666"));
                //rejectButton.Visibility = Visibility.Visible;
            }
            else
            {
                paymentButton.Content = "😥 Bị từ chối";
                paymentButton.IsEnabled = false;
                paymentButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a9a19b"));
            }
        }
    }
}
