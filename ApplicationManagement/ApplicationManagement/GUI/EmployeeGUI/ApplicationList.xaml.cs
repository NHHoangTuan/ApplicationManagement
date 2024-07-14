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

namespace ApplicationManagement.GUI.EmployeeGUI
{
    /// <summary>
    /// Interaction logic for ApplicationList.xaml
    /// </summary>
    public partial class ApplicationList : Page
    {

        /*public class DataTest
        {
            public string CandidateName { get; set; }
            public string CCCD { get; set; }
            public string Gender { get; set; }
            public DateTime BirthDate { get; set; }
            public string PhoneNumber { get; set; }
            public string Position { get; set; }
            public string Avatar { get; set; }
        }*/

        //BindingList<DataTest> listApplication = null;

        BindingList<ApplicationDTO>? originalList = null; // Store the original list
        BindingList<ApplicationDTO>? listShow = null;
        ApplicationBUS _applicationBUS;


        public ApplicationList()
        {
            InitializeComponent();
            //listApplication = new BindingList<DataTest>();
            _applicationBUS = new ApplicationBUS();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


            originalList = _applicationBUS.getAllApplication();
            if (originalList != null)
            {
                listShow = new BindingList<ApplicationDTO>(originalList.Where(a => a.Validity == "NOT OK").ToList());
            }
            

            if (listShow != null) 
            applicationListView.ItemsSource = listShow;

            if (listShow == null || listShow.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy bất kì đơn ứng tuyển cần duyệt nào";
            }
            else
            {
                MessageText.Text = "";
            }


        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var application = applicationListView.SelectedItem as ApplicationDTO;
            if (application == null) return;
            ApplicationDetail recruitDetail = new ApplicationDetail(application);
            recruitDetail.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (recruitDetail.ShowDialog() == true)
            {
                originalList.Clear();
                originalList = _applicationBUS.getAllApplication();



                var currentListShow = originalList.Where(a => a.Validity == "NOT OK").ToList();

                applicationListView.ItemsSource = currentListShow;
                
                if (currentListShow == null || currentListShow.Count == 0)
                {
                    MessageText.Text = "Opps! Không tìm thấy bất kì đơn ứng tuyển cần duyệt nào";
                }
                else
                {
                    MessageText.Text = "";
                }

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
