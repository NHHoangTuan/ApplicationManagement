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
    /// Interaction logic for RecruitList.xaml
    /// </summary>
    public partial class RecruitList : Page
    {

        BindingList<RecruitmentDTO>? list = null;
        BindingList<RecruitmentDTO>? originalList = null; // Store the original list

        BindingList<RecruitmentDTO>? listShow = null;
        RecruitmentBUS _recruitmentBUS;
        RecruitmentDTO selectRecruit = null;

        // Page pagination
        int currentPage = 1;
        int itemsPerPage = 4;

        public RecruitList()
        {
            InitializeComponent();
            _recruitmentBUS = new RecruitmentBUS();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize or reset currentPage
            currentPage = 1;        

            originalList = _recruitmentBUS.getAllRecruitment();

            if (originalList != null)
            {
                listShow = new BindingList<RecruitmentDTO>(originalList.Where(a => a.Validity == "NOT OK").ToList());
            }

            recruitListView.ItemsSource = listShow;

            // Display the first page items
            //DisplayCurrentPageItems();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var recruit = recruitListView.SelectedItem as RecruitmentDTO;
            if (recruit == null) return;
            RecruitDetail recruitDetail = new RecruitDetail(recruit);
            recruitDetail.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (recruitDetail.ShowDialog() == true)
            {
                originalList.Clear();
                originalList = _recruitmentBUS.getAllRecruitment();


                var currentListShow = originalList.Where(a => a.Validity == "NOT OK").ToList();

                recruitListView.ItemsSource = currentListShow;
             

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


        private void UpdatePageInfo()
        {
            int totalPages = (int)Math.Ceiling((double)list.Count / itemsPerPage);
            pageInfoTextBlock.Text = $"{currentPage}/{totalPages}";

        }


        private void DisplayCurrentPageItems()
        {
            int startIndex = (currentPage - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage - 1, list.Count - 1);

            var currentPageItems = list.Skip(startIndex).Take(itemsPerPage).ToList();

            recruitListView.ItemsSource = currentPageItems;

            UpdatePageInfo();
        }

      
    }
}
