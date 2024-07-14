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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationManagement.GUI
{
    /// <summary>
    /// Interaction logic for BillList.xaml
    /// </summary>
    public partial class BillList : Page
    {

   
        BindingList<BillDTO>? originalList = null; // Store the original list

        BindingList<BillDTO>? listShow = null;
        BillBUS _billBUS;
        BillBUS selectBill = null;


        // Page pagination
        int currentPage = 1;
        int itemsPerPage = 4;

        public BillList()
        {
            InitializeComponent();
            _billBUS = new BillBUS();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize or reset currentPage
            currentPage = 1;

            originalList = _billBUS.GetAllBills();

            if (originalList != null)
            {
                listShow = new BindingList<BillDTO>(originalList.Where(a => a.DaNhan == 0).ToList());
            }

            if (listShow != null)
            BillListView.ItemsSource = listShow;

            if (listShow == null || listShow.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy bất kì hóa đơn nào cần duyệt";
            }

            // Display the first page items
            DisplayCurrentPageItems();

        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var bill = BillListView.SelectedItem as BillDTO;
            if (bill == null) return;
            BillDetail billDetail = new BillDetail(bill);
            billDetail.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            

            MainWindow.Instance.ShowOverlay();
            //ShowOverlay();


            if (billDetail.ShowDialog() == true)
            {
                originalList.Clear();
                originalList = _billBUS.GetAllBills();

                var currentListShow = originalList.Where(a => a.DaNhan == 0).ToList();

                BillListView.ItemsSource = currentListShow;


            }
            //HideOverlay();
            MainWindow.Instance.HideOverlay();
        }

        private void SearchTermTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SortCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FirstButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LastButton_Click(object sender, RoutedEventArgs e)
        {

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

            BillListView.ItemsSource = currentPageItems;

            UpdatePageInfo();
        }


        /*public void ShowOverlay()
        {
            // Hiển thị và làm mờ overlay
            Overlay.Visibility = Visibility.Visible;
            DoubleAnimation fadeIn = new DoubleAnimation(0, 0.5, TimeSpan.FromSeconds(0.3));
            Overlay.BeginAnimation(OpacityProperty, fadeIn);
        }

        public void HideOverlay()
        {
            // Sau khi dialog đóng, ẩn overlay
            DoubleAnimation fadeOut = new DoubleAnimation(0.5, 0, TimeSpan.FromSeconds(0.3));
            fadeOut.Completed += (s, e) => Overlay.Visibility = Visibility.Collapsed;
            Overlay.BeginAnimation(OpacityProperty, fadeOut);
        }*/
    }
}
