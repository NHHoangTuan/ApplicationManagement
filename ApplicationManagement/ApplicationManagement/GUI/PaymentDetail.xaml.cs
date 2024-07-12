﻿using ApplicationManagement.BUS;
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

                    _billBUS.deleteBill(id);

                    recruitmentBUS.setValidity(selectedRecruit, true);
                    recruitmentBUS.deleteRecruit(selectedRecruit);
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
            return  150000*recruit.RecruitPeriod; // Số tiền ví dụ
        }

        
    }
}
