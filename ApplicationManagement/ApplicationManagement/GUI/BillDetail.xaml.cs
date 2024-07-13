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
using System.Windows.Shapes;

namespace ApplicationManagement.GUI
{
    /// <summary>
    /// Interaction logic for BillDetail.xaml
    /// </summary>
    public partial class BillDetail : Window
    {

        //BillDTO copyBillDTO { get; set; }
        BillDTO selectedBill;
        BillBUS billBUS;

        public BillDetail(BillDTO r)
        {
            InitializeComponent();
            this.DataContext = r;
            //copyBillDTO = (BillDTO)r.Clone();
            selectedBill = r;
            billBUS = new BillBUS();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (selectedBill != null)
            {
                var result = MessageBox.Show($"Hóa đơn này đã thanh toán đầy đủ ?",
                   "Confirm accept", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    try
                    {
                        billBUS.setDaNhan(selectedBill, 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        billBUS.updateDaNhan(selectedBill);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                    DialogResult = true;

                }
            }
        }

        private void ShowDetailBanking_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("/ Bill chuyển khoản /!");
            this.Close();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close();
            MainWindow.Instance.HideOverlay();
            
        }

        private void Refused_Click(object sender, RoutedEventArgs e)
        {
            if (selectedBill != null)
            {
                var result = MessageBox.Show($"Hóa đơn này chưa thanh toán đủ? Từ chối duyệt",
                   "Confirm accept", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        billBUS.setDaNhan(selectedBill, -2);
                    }
                    catch ( Exception ex) { MessageBox.Show(ex.Message ); }

                    try
                    {
                        billBUS.updateDaNhan(selectedBill);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    DialogResult = true;

                }
            }

        }
    }
}
