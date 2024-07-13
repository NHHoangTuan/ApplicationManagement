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

            // Display the first page items
            DisplayCurrentPageItems();
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

        private void SearchTermTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = SearchTermTextBox.Text?.ToLower();
            if (string.IsNullOrEmpty(searchTerm))
            {
                listShow = new BindingList<RecruitmentDTO>(originalList.ToList());
            }
            else
            {
                var filteredList = originalList
                    .Where(r => r.Vacancies?.ToLower().Contains(searchTerm) == true
                    || r.Enterprise.EnterpriseName?.ToLower().Contains(searchTerm) == true
                    || r.Enterprise.Address?.ToLower().Contains(searchTerm) == true)
                    .ToList();
                listShow = new BindingList<RecruitmentDTO>(filteredList);
            }

            // Reset to the first page when searching
            currentPage = 1;
            DisplayCurrentPageItems();
        }

        private void SortCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortCombobox.SelectedItem == null || !(SortCombobox.SelectedItem is ComboBoxItem selectedItem))
                return;

            string selectedSortOption = selectedItem.Content?.ToString();

            if (selectedSortOption == null)
                return;

            switch (selectedSortOption)
            {
                case "No Sort":
                    listShow = new BindingList<RecruitmentDTO>(originalList.ToList());
                    break;
                case "Sort by name (A-Z)":
                    listShow = new BindingList<RecruitmentDTO>(originalList.OrderBy(r => r.Vacancies).ToList());
                    break;
                case "Sort by name (Z-A)":
                    listShow = new BindingList<RecruitmentDTO>(originalList.OrderByDescending(r => r.Vacancies).ToList());
                    break;
                default:
                    break;
            }

            // Reset to the first page when sorting
            currentPage = 1;
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

            nomineeListView.ItemsSource = currentPageItems;

            UpdatePageInfo();
        }

        private void FirstButton_Click(object sender, RoutedEventArgs e)
        {
            currentPage = 1;
            DisplayCurrentPageItems();
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPageItems();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)listShow.Count / itemsPerPage);
            if (currentPage < totalPages)
            {
                currentPage++;
                DisplayCurrentPageItems();
            }
        }

        private void LastButton_Click(object sender, RoutedEventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)listShow.Count / itemsPerPage);
            currentPage = totalPages;
            DisplayCurrentPageItems();
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
