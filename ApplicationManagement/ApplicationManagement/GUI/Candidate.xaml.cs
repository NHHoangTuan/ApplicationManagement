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
    /// Interaction logic for Candidate.xaml
    /// </summary>
    public partial class Candidate : Page
    {

        BindingList<CandidateDTO> list = new BindingList<CandidateDTO>();

        public Candidate()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            list = new BindingList<CandidateDTO>()
            {
                new CandidateDTO()
    {
        CandidateName = "Nguyễn Văn A",
        CCCD = "012345678901",
        Gender = "Nam",
        PhoneNumber = "0901234567",
        Address = "123 Đường A, Quận 1, TP. HCM",
        Avatar = "Assets/Images/Data/user_icon.png",
        AboutMe = "Giới thiệu bản thân, giới thiệu cái quần què, tự đi mà code backend"
    },
    new CandidateDTO()
    {
        CandidateName = "Trần Thị B",
        CCCD = "098765432109",
        Gender = "Nữ",
        PhoneNumber = "0912345678",
        Address = "456 Đường B, Quận 2, TP. HCM",
        Avatar = "Assets/Images/Data/user_icon.png",
        AboutMe = "Giới thiệu bản thân, giới thiệu cái quần què, tự đi mà code backend"
    },
    new CandidateDTO()
    {
        CandidateName = "Lê Văn C",
        CCCD = "123456789012",
        Gender = "Nam",
        PhoneNumber = "0923456789",
        Address = "789 Đường C, Quận 3, TP. HCM",
        Avatar = "Assets/Images/Data/user_icon.png",
        AboutMe = "Giới thiệu bản thân, giới thiệu cái quần què, tự đi mà code backend"
    },
    new CandidateDTO()
    {
        CandidateName = "Phạm Thị D",
        CCCD = "234567890123",
        Gender = "Nữ",
        PhoneNumber = "0934567890",
        Address = "101 Đường D, Quận 4, TP. HCM",
        Avatar = "Assets/Images/Data/user_icon.png",
        AboutMe = "Giới thiệu bản thân, giới thiệu cái quần què, tự đi mà code backend"
    },
    new CandidateDTO()
    {
        CandidateName = "Hoàng Văn E",
        CCCD = "345678901234",
        Gender = "Nam",
        PhoneNumber = "0945678901",
        Address = "112 Đường E, Quận 5, TP. HCM",
        Avatar = "Assets/Images/Data/user_icon.png",
        AboutMe = "Giới thiệu bản thân, giới thiệu cái quần què, tự đi mà code backend"
    }
            };
            candidateListView.ItemsSource = list;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var candidate = candidateListView.SelectedItem as CandidateDTO;
            if (candidate == null) return;
            CandidateDetail candidateDetail = new CandidateDetail(candidate);
            candidateDetail.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (candidateDetail.ShowDialog() == true)
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
