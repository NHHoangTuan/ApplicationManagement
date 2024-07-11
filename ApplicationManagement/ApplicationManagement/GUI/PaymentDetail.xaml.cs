using ApplicationManagement.BUS;
using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for PaymentDetail.xaml
    /// </summary>
    public partial class PaymentDetail : Window
    {

        RecruitmentDTO copyRecruitmentDTO { get; set; }
        RecruitmentDTO selectedRecruit;
        RecruitmentBUS recruitmentBUS;


        public PaymentDetail(RecruitmentDTO r)
        {
            InitializeComponent();

            this.DataContext = r;
            copyRecruitmentDTO = (RecruitmentDTO)r.Clone();
            selectedRecruit = r;
            recruitmentBUS = new RecruitmentBUS();

        }

        private void rejectButton_Click(object sender, RoutedEventArgs e)
        {

            
        }

        private void PaymentButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecruit != null)
            {
                var result = MessageBox.Show($"Bạn muốn thanh toán hóa đơn cho bài đăng tuyển? {selectedRecruit.Vacancies} - {selectedRecruit.Enterprise.EnterpriseName}?",
                   "Confirm accept", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    BillBUS billBUS = new BillBUS();
                    BillDTO newBill = new BillDTO
                    {
                        MaThue = selectedRecruit.Enterprise.TaxID,
                        MaPhieu = selectedRecruit.formID,
                        SoTien = CalculateAmount(selectedRecruit), 
                        DaNhan = -1
                    };


                    int billId = billBUS.CreateBill(newBill);
                    newBill.MaHoaDon = billId;

                   
                    Bill bill = new Bill(newBill);
                    if (bill.ShowDialog() == true)
                    {
                        this.Close();
                    }
                    
                    
                    //bill.Show();

                    /*recruitmentBUS.setValidity(selectedRecruit, true);
                    recruitmentBUS.updateRecruitStatus(selectedRecruit);
                    DialogResult = true;*/

                    //updateDataSource(_currentPage, _currentCurrency, _currentStartPrice, _currentEndPrice, _currentList);
                }
            }
        }

        private int CalculateAmount(RecruitmentDTO recruit)
        {
            return  150000*recruit.RecruitPeriod; // Số tiền ví dụ
        }

        
    }
}
