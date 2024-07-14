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
        EnterpriseBUS enterpriseBUS;


        public CandidateDashboard() {
            InitializeComponent();
            recruitmentBUS = new RecruitmentBUS();
            enterpriseBUS = new EnterpriseBUS();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {

            

            listEnterprise = enterpriseBUS.getAllEnterprise();
            listNominee = recruitmentBUS.getAllRecruitmentForApplication();
            
            var TotalNomineeNumber = 0;
            if (listNominee != null)
            {
                TotalNomineeNumber = listNominee.Count;
            }
            var TotalEnterpriseNumber = 0;
            if (listEnterprise != null)
            {
                TotalEnterpriseNumber = listEnterprise.Count;
            }
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
