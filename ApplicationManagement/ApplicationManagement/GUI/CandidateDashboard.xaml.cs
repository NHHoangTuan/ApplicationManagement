using ApplicationManagement.BUS;
using ApplicationManagement.DTO;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationManagement.GUI {
    /// <summary>
    /// Interaction logic for CandidateDashboard.xaml
    /// </summary>
    public partial class CandidateDashboard : Page {

        BindingList<RecruitmentDTO> listNominee = null;
        BindingList<EnterpriseDTO> listEnterprise = null;
        RecruitmentBUS recruitmentBUS;


        public CandidateDashboard() {
            InitializeComponent();

            recruitmentBUS = new RecruitmentBUS();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {

            listEnterprise = new BindingList<EnterpriseDTO>()
            {
                new EnterpriseDTO()
                {
                    EnterpriseName = "Shopee",
                    Description = "Shopee là nền tảng thương mại điện tử ở Đông Nam Á và Đài Loan. Ra mắt năm 2015, nền tảng thương mại Shopee được xây dựng nhằm cung cấp cho người sử dụng những trải nghiệm dễ dàng, an toàn và nhanh chóng khi mua sắm trực tuyến thông qua hệ thống hỗ trợ thanh toán và vận hành vững mạnh.",
                    Logo = "Assets/Images/Design/1.jpg",
                    Background = "Assets/Images/Design/1_1.jpg",
                    TaxID = "0123456789"
                },
                new EnterpriseDTO
                {
                    EnterpriseName = "Lazada",
                    Description = "Lazada là một trong những nền tảng thương mại điện tử hàng đầu tại Đông Nam Á. Được thành lập vào năm 2012, Lazada mang đến trải nghiệm mua sắm trực tuyến dễ dàng và an toàn với nhiều sản phẩm phong phú.",
                    Logo = "Assets/Images/Design/2.jpg",
                    Background = "Assets/Images/Design/1_1.jpg",
                    TaxID = "0123456789"
                },
                new EnterpriseDTO
                {
                    EnterpriseName = "Tiki",
                    Description = "Tiki là nền tảng thương mại điện tử hàng đầu Việt Nam. Với dịch vụ giao hàng nhanh chóng và đa dạng các sản phẩm, Tiki cam kết mang lại sự hài lòng cho khách hàng trong mỗi giao dịch mua sắm.",
                    Logo = "Assets/Images/Design/3.jpg",
                    Background = "Assets/Images/Design/1_1.jpg",
                    TaxID = "0123456789"
                },
                new EnterpriseDTO
                {
                    EnterpriseName = "Sendo",
                    Description = "Sendo là một trong những sàn thương mại điện tử lớn nhất Việt Nam, mang đến trải nghiệm mua sắm trực tuyến đa dạng với nhiều sản phẩm từ thời trang, điện tử, đến gia dụng.",
                    Logo = "Assets/Images/Design/4.png",
                    Background = "Assets/Images/Design/1_1.jpg",
                    TaxID = "0123456789"
                },
                new EnterpriseDTO
                {
                    EnterpriseName = "Amazon",
                    Description = "Amazon là công ty thương mại điện tử hàng đầu thế giới, cung cấp hàng triệu sản phẩm và dịch vụ khác nhau. Amazon mang đến cho khách hàng trên toàn cầu trải nghiệm mua sắm tiện lợi và đáng tin cậy.",
                    Logo = "Assets/Images/Design/5.png",
                    Background = "Assets/Images/Design/1_1.jpg",
                    TaxID = "0123456789"
                }
            };

            listNominee = recruitmentBUS.getAllRecruitment();

            /*listNominee = new BindingList<RecruitmentDTO> { new RecruitmentDTO
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
                    Address = "TP. Hồ Chí Minh",
                    TaxID = "0123456789"
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
                    Address = "Hà Nội",
                    TaxID = "0123456789"
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
                    Address = "TP. Hồ Chí Minh",
                    TaxID = "0123456789"
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
                    Address = "TP. Hồ Chí Minh",
                    TaxID = "0123456789"
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
                    Address = "Đà Nẵng",
                    TaxID = "0123456789"
                }
            }
            };*/


            var TotalNomineeNumber = listNominee.Count;
            var TotalEnterpriseNumber = listEnterprise.Count;
            Data data = new Data(TotalNomineeNumber, TotalEnterpriseNumber);
            this.DataContext = data;

            topEnterpriseListView.ItemsSource = listEnterprise;
            topNomineeListView.ItemsSource = listNominee;

        }

        private void RecruitmentButton_Click(object sender, RoutedEventArgs e) {

        }




        class Data {
            public int TotalNomineeNumber { get; set; }
            public int TotalEnterpriseNumber { get; set; }

            public Data(int TotalNomineeNumber, int TotalEnterpriseNumber) {
                this.TotalEnterpriseNumber = TotalEnterpriseNumber;
                this.TotalNomineeNumber = TotalNomineeNumber;
            }
        }

    }
}
