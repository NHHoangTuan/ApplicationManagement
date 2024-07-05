﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Business> Businesses { get; set; }

        public Enterprise()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Businesses = new ObservableCollection<Business>
            {
                new Business
                {
                    Name = "Shopee",
                    Description = "Shopee là nền tảng thương mại điện tử ở Đông Nam Á và Đài Loan. Ra mắt năm 2015, nền tảng thương mại Shopee được xây dựng nhằm cung cấp cho người sử dụng những trải nghiệm dễ dàng, an toàn và nhanh chóng khi mua sắm trực tuyến thông qua hệ thống hỗ trợ thanh toán và vận hành vững mạnh.",
                    Logo = "Assets/Images/Design/1.jpg"
                },
                new Business
                {
                    Name = "Lazada",
                    Description = "Lazada là một trong những nền tảng thương mại điện tử hàng đầu tại Đông Nam Á. Được thành lập vào năm 2012, Lazada mang đến trải nghiệm mua sắm trực tuyến dễ dàng và an toàn với nhiều sản phẩm phong phú.",
                    Logo = "Assets/Images/Design/2.jpg"
                },
                new Business
                {
                    Name = "Tiki",
                    Description = "Tiki là nền tảng thương mại điện tử hàng đầu Việt Nam. Với dịch vụ giao hàng nhanh chóng và đa dạng các sản phẩm, Tiki cam kết mang lại sự hài lòng cho khách hàng trong mỗi giao dịch mua sắm.",
                    Logo = "Assets/Images/Design/3.jpg"
                },
                new Business
                {
                    Name = "Sendo",
                    Description = "Sendo là một trong những sàn thương mại điện tử lớn nhất Việt Nam, mang đến trải nghiệm mua sắm trực tuyến đa dạng với nhiều sản phẩm từ thời trang, điện tử, đến gia dụng.",
                    Logo = "Assets/Images/Design/4.png"
                },
                new Business
                {
                    Name = "Amazon",
                    Description = "Amazon là công ty thương mại điện tử hàng đầu thế giới, cung cấp hàng triệu sản phẩm và dịch vụ khác nhau. Amazon mang đến cho khách hàng trên toàn cầu trải nghiệm mua sắm tiện lợi và đáng tin cậy.",
                    Logo = "Assets/Images/Design/5.png"
                }
            };
            enterpriseListView.ItemsSource = Businesses;
        }

        public class Business
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Logo { get; set; }
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
    }
}