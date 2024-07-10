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

        BindingList<RecruitmentDTO> list = null;
        BindingList<RecruitmentDTO> originalList = null; // Store the original list

        // Page pagination
        int currentPage = 1;
        int itemsPerPage = 4;

        public Nominee()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            // Initialize or reset currentPage
            currentPage = 1;

            /*originalList = new BindingList<RecruitmentDTO> { new RecruitmentDTO
            {
                Vacancies = "Kế Toán Trưởng",
                Description = "Công ty TNHH MTV Kosei Quốc tế đang tuyển dụng Kế Toán Trưởng với mức lương 20-25 triệu/tháng.",
                MinSalary = 20000000,
                MaxSalary = 25000000,
                ExperienceRequirement = "3 năm kinh nghiệm",
                Enterprise = new EnterpriseDTO
                {
                    EnterpriseName = "Kosei",
                    Description = "Công ty TNHH MTV Kosei Quốc tế",
                    Logo = "Assets/Images/Design/1.jpg",
                    Background = "Assets/Images/Design/1_1.jpg",
                    Address = "TP. Hồ Chí Minh"
                }
            },
            new RecruitmentDTO
            {
                Vacancies = "Lập Trình Viên .NET",
                Description = "Tuyển dụng Lập Trình Viên .NET làm việc tại Hà Nội.",
                MinSalary = 15000000,
                MaxSalary = 20000000,
                ExperienceRequirement = "2 năm kinh nghiệm",
                Enterprise = new EnterpriseDTO
                {
                    EnterpriseName = "Tech Corp",
                    Description = "Tech Corp là công ty công nghệ hàng đầu",
                    Logo = "Assets/Images/Design/1.jpg",
                    Background = "Assets/Images/Design/1_1.jpg",
                    Address = "Hà Nội"
                }
            },
            new RecruitmentDTO
            {
                Vacancies = "Nhân Viên Kinh Doanh",
                Description = "Tuyển dụng Nhân Viên Kinh Doanh làm việc tại TP. Hồ Chí Minh.",
                MinSalary = 12000000,
                MaxSalary = 18000000,
                ExperienceRequirement = "1 năm kinh nghiệm",
                Enterprise = new EnterpriseDTO
                {
                    EnterpriseName = "Sales Inc",
                    Description = "Sales Inc chuyên về các giải pháp kinh doanh",
                    Logo = "Assets/Images/Design/1.jpg",
                    Background = "Assets/Images/Design/1_1.jpg",
                    Address = "TP. Hồ Chí Minh"
                }
            },
            new RecruitmentDTO
            {
                Vacancies = "Chuyên Viên Marketing",
                Description = "Công ty TNHH Marketing Pro tuyển dụng Chuyên Viên Marketing.",
                MinSalary = 18000000,
                MaxSalary = 25000000,
                ExperienceRequirement = "2 năm kinh nghiệm",
                Enterprise = new EnterpriseDTO
                {
                    EnterpriseName = "Marketing Pro",
                    Description = "Marketing Pro là công ty chuyên về dịch vụ tiếp thị",
                    Logo = "Assets/Images/Design/1.jpg",
                    Background = "Assets/Images/Design/1_1.jpg",
                    Address = "TP. Hồ Chí Minh"
                }
            },
            new RecruitmentDTO
            {
                Vacancies = "Quản Lý Dự Án",
                Description = "Tuyển dụng Quản Lý Dự Án làm việc tại Đà Nẵng.",
                MinSalary = 25000000,
                MaxSalary = 30000000,
                ExperienceRequirement = "5 năm kinh nghiệm",
                Enterprise = new EnterpriseDTO
                {
                    EnterpriseName = "Project Management Ltd",
                    Description = "Project Management Ltd chuyên về quản lý dự án",
                    Logo = "Assets/Images/Design/1.jpg",
                    Background = "Assets/Images/Design/1_1.jpg",
                    Address = "Đà Nẵng"
                }
            }
            };*/

            list = new BindingList<RecruitmentDTO>(originalList);
            nomineeListView.ItemsSource = list;

            // Display the first page items
            DisplayCurrentPageItems();
        }

        private void RecruitmentButton_Click(object sender, RoutedEventArgs e)
        {
            var nominee = nomineeListView.SelectedItem as RecruitmentDTO;
            if (nominee == null) return;
            NomineeDetail nomineeDetail = new NomineeDetail(nominee);
            nomineeDetail.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (nomineeDetail.ShowDialog() == true)
            {


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


            }
        }

        private void SearchTermTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = SearchTermTextBox.Text?.ToLower();
            if (string.IsNullOrEmpty(searchTerm))
            {
                list = new BindingList<RecruitmentDTO>(originalList.ToList());
            }
            else
            {
                var filteredList = originalList
                    .Where(r => r.Vacancies?.ToLower().Contains(searchTerm) == true
                    || r.Enterprise.EnterpriseName?.ToLower().Contains(searchTerm) == true
                    || r.Enterprise.Address?.ToLower().Contains(searchTerm) == true)
                    .ToList();
                list = new BindingList<RecruitmentDTO>(filteredList);
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
                    list = new BindingList<RecruitmentDTO>(originalList.ToList());
                    break;
                case "Sort by name (A-Z)":
                    list = new BindingList<RecruitmentDTO>(originalList.OrderBy(r => r.Vacancies).ToList());
                    break;
                case "Sort by name (Z-A)":
                    list = new BindingList<RecruitmentDTO>(originalList.OrderByDescending(r => r.Vacancies).ToList());
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
            int totalPages = (int)Math.Ceiling((double)list.Count / itemsPerPage);
            pageInfoTextBlock.Text = $"{currentPage}/{totalPages}";

        }

        private void DisplayCurrentPageItems()
        {
            int startIndex = (currentPage - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage - 1, list.Count - 1);

            var currentPageItems = list.Skip(startIndex).Take(itemsPerPage).ToList();

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
            int totalPages = (int)Math.Ceiling((double)list.Count / itemsPerPage);
            if (currentPage < totalPages)
            {
                currentPage++;
                DisplayCurrentPageItems();
            }
        }

        private void LastButton_Click(object sender, RoutedEventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)list.Count / itemsPerPage);
            currentPage = totalPages;
            DisplayCurrentPageItems();
        }
    }
}
