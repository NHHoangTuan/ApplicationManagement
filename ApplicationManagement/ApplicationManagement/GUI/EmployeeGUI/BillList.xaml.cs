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

namespace ApplicationManagement.GUI.EmployeeGUI
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
            else
            {
                MessageText.Text = "";
            }


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

                

                if (currentListShow == null || currentListShow.Count == 0)
                {
                    MessageText.Text = "Opps! Không tìm thấy bất kì hóa đơn nào cần duyệt";
                }
                else
                {
                    MessageText.Text = "";
                }


            }
            //HideOverlay();
            MainWindow.Instance.HideOverlay();
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
