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
using System.Windows.Media.Animation;
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

        BillBUS _billBUS;


        public PaymentDetail(RecruitmentDTO r)
        {
            InitializeComponent();

            this.DataContext = r;
            copyRecruitmentDTO = (RecruitmentDTO)r.Clone();
            selectedRecruit = r;
            recruitmentBUS = new RecruitmentBUS();
            _billBUS = new BillBUS();


        }

        private void rejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecruit != null)
            {
                var result = MessageBox.Show($"Bạn có chắc muốn hủy hóa đơn này? Đồng nghĩa xóa bài đăng tuyển! {selectedRecruit.Vacancies} - {selectedRecruit.Enterprise.EnterpriseName}?",
                   "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // Hiển thị và làm mờ overlay
                    Overlay.Visibility = Visibility.Visible;
                    DoubleAnimation fadeIn = new DoubleAnimation(0, 0.5, TimeSpan.FromSeconds(0.3));
                    Overlay.BeginAnimation(OpacityProperty, fadeIn);

                    int id = selectedRecruit.formID;

                    try
                    {
                        _billBUS.deleteBill(id);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                    try
                    {
                        recruitmentBUS.setValidity(selectedRecruit, "OK");
                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message); }

                    try
                    {
                        recruitmentBUS.deleteRecruit(selectedRecruit);
                    }
                    catch( Exception ex) { MessageBox.Show(ex.Message ); }

                    DialogResult = true;

                    //updateDataSource(_currentPage, _currentCurrency, _currentStartPrice, _currentEndPrice, _currentList);
                }
            }

        }

        private void PaymentButton_Click(object sender, RoutedEventArgs e)
        {

            if (selectedRecruit != null)
            {
                var result = MessageBox.Show($"Gửi thanh toán hóa đơn cho bài đăng tuyển? Khi đã gửi không thể hoàn tác. {selectedRecruit.Vacancies} - {selectedRecruit.Enterprise.EnterpriseName}?",
                   "Confirm accept", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    // Hiển thị và làm mờ overlay
                    Overlay.Visibility = Visibility.Visible;
                    DoubleAnimation fadeIn = new DoubleAnimation(0, 0.5, TimeSpan.FromSeconds(0.3));
                    Overlay.BeginAnimation(OpacityProperty, fadeIn);


                    BillDTO bill = null;
                    if (_billBUS.IsMaPhieuExists(selectedRecruit.formID))
                    {
                        bill = _billBUS.getBillByFormID(selectedRecruit.formID);
                    }
                    else
                    {
                        BillDTO newBill = new BillDTO
                        {
                            MaThue = selectedRecruit.Enterprise.TaxID,
                            MaPhieu = selectedRecruit.formID,
                            SoTien = CalculateAmount(selectedRecruit),
                            DaNhan = -1
                        };


                        int billId = _billBUS.CreateBill(newBill);
                        newBill.MaHoaDon = billId;

                        bill = newBill;
                    }
                    

                   
                    Bill billScreen = new Bill(bill);
                    if (billScreen.ShowDialog() == true)
                    {
                        DialogResult = true;
                        this.Close();
                    }


                    // Sau khi dialog đóng, ẩn overlay
                    DoubleAnimation fadeOut = new DoubleAnimation(0.5, 0, TimeSpan.FromSeconds(0.3));
                    fadeOut.Completed += (s, e) => Overlay.Visibility = Visibility.Collapsed;
                    Overlay.BeginAnimation(OpacityProperty, fadeOut);


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
            return  30000*recruit.RecruitPeriod; // Số tiền ví dụ
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (_billBUS.getBillByFormID(selectedRecruit.formID) == null) return;
            if (_billBUS.getBillByFormID(selectedRecruit.formID).DaNhan == 1)
            {
                PaymentButton.Content = "😘 Đã Thanh Toán";
                PaymentButton.IsEnabled = false;
                rejectButton.Visibility = Visibility.Hidden;
                PaymentButton.Background = new SolidColorBrush(Colors.Green);
            }
            else if (_billBUS.getBillByFormID(selectedRecruit.formID).DaNhan == 0)
            {
                PaymentButton.Content = "⏱ Đã thanh toán và chờ duyệt";
                PaymentButton.IsEnabled = false;
                rejectButton.Visibility = Visibility.Hidden;
                PaymentButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4cc7cf"));
            }
            else if (_billBUS.getBillByFormID(selectedRecruit.formID).DaNhan == -1)
            {
                PaymentButton.Content = "✔ Thanh toán";
                PaymentButton.IsEnabled = true;
                rejectButton.Visibility = Visibility.Visible;
            }

            else
            {
                PaymentButton.Content = "✔ Thanh toán lại";
                PaymentButton.IsEnabled = true;
                rejectButton.Visibility = Visibility.Visible;
            }

        }
    }
}
