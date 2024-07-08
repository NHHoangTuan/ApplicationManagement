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
    /// Interaction logic for ApplicationList.xaml
    /// </summary>
    public partial class ApplicationList : Page
    {

        public class DataTest
        {
            public string CandidateName { get; set; }
            public string CCCD { get; set; }
            public string Gender { get; set; }
            public DateTime BirthDate { get; set; }
            public string PhoneNumber { get; set; }
            public string Position { get; set; }
            public string Avatar { get; set; }
        }

        BindingList<DataTest> listApplication = null;


        public ApplicationList()
        {
            InitializeComponent();
            listApplication = new BindingList<DataTest>();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listApplication= new BindingList<DataTest>{
                new DataTest { CandidateName = "Nguyễn Văn A", CCCD = "012345678901", Gender = "Nam", BirthDate = new DateTime(1990, 1, 1), PhoneNumber = "0901234567", Position = "Developer", Avatar = "Assets/Images/Data/user_icon.png" },
                new DataTest { CandidateName = "Trần Thị B", CCCD = "012345678902", Gender = "Nữ", BirthDate = new DateTime(1991, 2, 2), PhoneNumber = "0901234568", Position = "Designer", Avatar = "Assets/Images/Data/user_icon.png" },
                new DataTest { CandidateName = "Lê Văn C", CCCD = "012345678903", Gender = "Nam", BirthDate = new DateTime(1992, 3, 3), PhoneNumber = "0901234569", Position = "Tester", Avatar = "Assets/Images/Data/user_icon.png" },
                new DataTest { CandidateName = "Phạm Thị D", CCCD = "012345678904", Gender = "Nữ", BirthDate = new DateTime(1993, 4, 4), PhoneNumber = "0901234570", Position = "Manager", Avatar = "Assets/Images/Data/user_icon.png" },
                new DataTest { CandidateName = "Hoàng Văn E", CCCD = "012345678905", Gender = "Nam", BirthDate = new DateTime(1994, 5, 5), PhoneNumber = "0901234571", Position = "Developer", Avatar = "Assets/Images/Data/user_icon.png" },
                new DataTest { CandidateName = "Đặng Thị F", CCCD = "012345678906", Gender = "Nữ", BirthDate = new DateTime(1995, 6, 6), PhoneNumber = "0901234572", Position = "Designer", Avatar = "Assets/Images/Data/user_icon.png" },
                new DataTest { CandidateName = "Phan Văn G", CCCD = "012345678907", Gender = "Nam", BirthDate = new DateTime(1996, 7, 7), PhoneNumber = "0901234573", Position = "Tester", Avatar = "Assets/Images/Data/user_icon.png" },
                new DataTest { CandidateName = "Ngô Thị H", CCCD = "012345678908", Gender = "Nữ", BirthDate = new DateTime(1997, 8, 8), PhoneNumber = "0901234574", Position = "Manager", Avatar = "Assets/Images/Data/user_icon.png" },
                new DataTest { CandidateName = "Bùi Văn I", CCCD = "012345678909", Gender = "Nam", BirthDate = new DateTime(1998, 9, 9), PhoneNumber = "0901234575", Position = "Developer", Avatar = "Assets/Images/Data/user_icon.png" },
                new DataTest { CandidateName = "Vũ Thị J", CCCD = "012345678910", Gender = "Nữ", BirthDate = new DateTime(1999, 10, 10), PhoneNumber = "0901234576", Position = "Designer", Avatar = "Assets/Images/Data/user_icon.png" }
            };

            applicationListView.ItemsSource = listApplication;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

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

        private void rejectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
