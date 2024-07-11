using ApplicationManagement.BUS;
using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Bill.xaml
    /// </summary>
    public partial class Bill : Window
    {

        private BillDTO bill;
        BillDTO copyBillDTO { get; set; }
        BillDTO selectedBill;
        BillBUS billBUS;

        public Bill(BillDTO bill)
        {
            InitializeComponent();
            this.bill = bill;
            this.DataContext = bill;

            copyBillDTO = (BillDTO)bill.Clone();
            selectedBill = bill;
            billBUS = new BillBUS();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            // Logic xử lý khi nhấn nút Xác nhận
            var result = MessageBox.Show($"Bạn đã thanh toán hóa đơn? Gửi đi!",
                   "Confirm accept", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                billBUS.setDaNhan(selectedBill, 0);
                billBUS.updateDaNhan(selectedBill);


                DialogResult = true;
                this.Close();
            }
            
        }

        private void Add_Bill_Click(object sender, RoutedEventArgs e)
        {
            // Logic để chọn ảnh
            MessageBox.Show("Chọn ảnh chuyển khoản.");
        }
    }
}
