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
    /// Interaction logic for ApproveApplicationList.xaml
    /// </summary>
    public partial class ApproveApplicationList : Page
    {

        BindingList<ApplicationDTO>? originalList = null; // Store the original list
        BindingList<ApplicationDTO>? listShow = null;
        ApplicationBUS _applicationBUS;

        public ApproveApplicationList()
        {
            InitializeComponent();
            _applicationBUS = new ApplicationBUS();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            originalList = _applicationBUS.getAllApplicationByEnterprise(Login.CurrentAccountID);
            if (originalList != null)
            {
                listShow = new BindingList<ApplicationDTO>(originalList.ToList());
            }

            if (listShow != null)
                applicationListView.ItemsSource = listShow;

            if (listShow == null || listShow.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy bất kì hồ sơ ứng tuyển cần phê duyệt nào";
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var application = applicationListView.SelectedItem as ApplicationDTO;
            if (application == null) return;
            ApproveApplicationDetail approveDetail = new ApproveApplicationDetail(application);
            approveDetail.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (approveDetail.ShowDialog() == true)
            {
                originalList.Clear();
                originalList = _applicationBUS.getAllApplicationByEnterprise(Login.CurrentAccountID);

                RefeshList(originalList);


            }
        }


        public void RefeshList(BindingList<ApplicationDTO> list)
        {
            list.Clear();
            list = _applicationBUS.getAllApplicationByEnterprise(Login.CurrentAccountID);
            if (list != null)
            {
                listShow = new BindingList<ApplicationDTO>(list.ToList());
            }

            if (listShow != null)
                applicationListView.ItemsSource = listShow;

            if (listShow == null || listShow.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy bất kì hồ sơ ứng tuyển cần phê duyệt nào";
            }
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
    }
}
