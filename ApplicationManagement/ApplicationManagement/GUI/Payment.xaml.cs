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

            originalList = _recruitmentBUS.getAllRecruitment();

            var billStatus = _billBUS.GetBillStatuses();

            if (originalList != null)
            {
                listShow = new BindingList<RecruitmentDTO>(
                    originalList.Where(a =>
                        (!billStatus.ContainsKey(a.formID) && a.Validity == "OK") ||
                        (billStatus.ContainsKey(a.formID) && billStatus[a.formID] == -1)
                    ).ToList()
                );
            }


            PaymentListView.ItemsSource = listShow;

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
                originalList = _recruitmentBUS.getAllRecruitment();

                var currentListShow = originalList.Where(a => a.Validity == "OK").ToList();

                PaymentListView.ItemsSource = currentListShow;

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
    }
}
