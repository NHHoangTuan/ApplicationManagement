using ApplicationManagement.BUS;
using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Enterprise.xaml
    /// </summary>
    public partial class Enterprise : Page
    {

        BindingList<EnterpriseDTO>? originlist = new BindingList<EnterpriseDTO>();
        BindingList<EnterpriseDTO>? list = null;
        EnterpriseBUS enterpriseBUS;

        public Enterprise()
        {
            InitializeComponent();
            enterpriseBUS = new EnterpriseBUS();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            originlist = enterpriseBUS.getAllEnterprise();

            if (originlist != null )
            {
                list = new BindingList<EnterpriseDTO>(originlist.ToList());
            }


            

            if (list != null) 
            enterpriseListView.ItemsSource = list;

            if (list == null || list.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy bất kì doanh nghiệp nào";
            }
            else
            {
                MessageText.Text = "";
            }
        }

      


        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var enterprise = enterpriseListView.SelectedItem as EnterpriseDTO;
            if (enterprise == null) return;
            EnterpriseDetail enterpriseDetail = new EnterpriseDetail(enterprise);
            enterpriseDetail.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (enterpriseDetail.ShowDialog() == true)
            {
               

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
