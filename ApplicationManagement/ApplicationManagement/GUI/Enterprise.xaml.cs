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


            /*list = new BindingList<EnterpriseDTO>()
            {
                new EnterpriseDTO()
                {
                    EnterpriseName = "Shopee",
                    Description = "Shopee là nền tảng thương mại điện tử ở Đông Nam Á và Đài Loan. Ra mắt năm 2015, nền tảng thương mại Shopee được xây dựng nhằm cung cấp cho người sử dụng những trải nghiệm dễ dàng, an toàn và nhanh chóng khi mua sắm trực tuyến thông qua hệ thống hỗ trợ thanh toán và vận hành vững mạnh.",
                    LogoPath = "Assets/Images/Design/1.jpg",
                    Background = "Assets/Images/Design/1_1.jpg"

                },
                new EnterpriseDTO
                {
                    EnterpriseName = "Lazada",
                    Description = "Lazada là một trong những nền tảng thương mại điện tử hàng đầu tại Đông Nam Á. Được thành lập vào năm 2012, Lazada mang đến trải nghiệm mua sắm trực tuyến dễ dàng và an toàn với nhiều sản phẩm phong phú.",
                    LogoPath = "Assets/Images/Design/2.jpg",
                    Background = "Assets/Images/Design/1_1.jpg"
                },
                new EnterpriseDTO
                {
                    EnterpriseName = "Tiki",
                    Description = "Tiki là nền tảng thương mại điện tử hàng đầu Việt Nam. Với dịch vụ giao hàng nhanh chóng và đa dạng các sản phẩm, Tiki cam kết mang lại sự hài lòng cho khách hàng trong mỗi giao dịch mua sắm.",
                    LogoPath = "Assets/Images/Design/3.jpg",
                    Background = "Assets/Images/Design/1_1.jpg"
                },
                new EnterpriseDTO
                {
                    EnterpriseName = "Sendo",
                    Description = "Sendo là một trong những sàn thương mại điện tử lớn nhất Việt Nam, mang đến trải nghiệm mua sắm trực tuyến đa dạng với nhiều sản phẩm từ thời trang, điện tử, đến gia dụng.",
                    LogoPath = "Assets/Images/Design/4.png",
                    Background = "Assets/Images/Design/1_1.jpg"
                },
                new EnterpriseDTO
                {
                    EnterpriseName = "Amazon",
                    Description = "Amazon là công ty thương mại điện tử hàng đầu thế giới, cung cấp hàng triệu sản phẩm và dịch vụ khác nhau. Amazon mang đến cho khách hàng trên toàn cầu trải nghiệm mua sắm tiện lợi và đáng tin cậy.",
                    LogoPath = "Assets/Images/Design/5.png",
                    Background = "Assets/Images/Design/1_1.jpg"
                }
            };*/

            if (list != null) 
            enterpriseListView.ItemsSource = list;

            if (list == null || list.Count == 0)
            {
                MessageText.Text = "Opps! Không tìm thấy bất kì doanh nghiệp nào";
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
