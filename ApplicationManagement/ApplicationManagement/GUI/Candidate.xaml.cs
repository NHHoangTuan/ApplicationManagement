using ApplicationManagement.DAO;
using ApplicationManagement.DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApplicationManagement.GUI {
    /// <summary>
    /// Interaction logic for Candidate.xaml
    /// </summary>
    public partial class Candidate : Page {
        BindingList<CandidateDTO> list = null;
        CandidateDAO _candidateDAO;

        public Candidate() {
            InitializeComponent();
            _candidateDAO = new CandidateDAO();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            LoadCandidatesFromDatabase();
        }

        private void LoadCandidatesFromDatabase() {
            List<CandidateDTO> candidates = _candidateDAO.getCandidates();
            list = new BindingList<CandidateDTO>(candidates);

            if (list != null) 
            candidateListView.ItemsSource = list;

            if (list == null || list.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy bất kì ứng viên nào";
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            var candidate = candidateListView.SelectedItem as CandidateDTO;
            if (candidate == null) return;
            CandidateDetail candidateDetail = new CandidateDetail(candidate);
            candidateDetail.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (candidateDetail.ShowDialog() == true) {
                // Handle dialog result if needed
            }
        }

        private void SearchTermTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            // Implement search functionality if needed
        }

        private void SortCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // Implement sort functionality if needed
        }

        private void FirstButton_Click(object sender, RoutedEventArgs e) {
            // Implement pagination if needed
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e) {
            // Implement pagination if needed
        }

        private void NextButton_Click(object sender, RoutedEventArgs e) {
            // Implement pagination if needed
        }

        private void LastButton_Click(object sender, RoutedEventArgs e) {
            // Implement pagination if needed
        }
    }
}
