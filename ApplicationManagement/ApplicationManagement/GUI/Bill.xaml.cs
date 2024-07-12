using ApplicationManagement.BUS;
using ApplicationManagement.DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
            


            if (selectedBill != null)
            {

                // Logic xử lý khi nhấn nút Xác nhận
                var result = MessageBox.Show($"Bạn đã thanh toán hóa đơn? Gửi đi!",
                       "Confirm accept", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {


                    try
                    {
                        billBUS.setDaNhan(selectedBill, 0);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi",
                       MessageBoxButton.OK);
                    }

                    try
                    {
                        billBUS.updateDaNhan(selectedBill);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi",
                       MessageBoxButton.OK);
                    }

                    MessageBox.Show("Thanh toán thành công, chờ nhân viên duyệt", "Thông báo",
                   MessageBoxButton.OK);
                    DialogResult = true;
                    Close();

                    /*billBUS.setDaNhan(selectedBill, 0);
                    billBUS.updateDaNhan(selectedBill);


                    DialogResult = true;
                    this.Close();*/
                }  

            }

        }

        private void Add_Bill_Click(object sender, RoutedEventArgs e)
        {
            // Logic để chọn ảnh
            MessageBox.Show("Chọn ảnh chuyển khoản.");


            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Documents (*.png;*.jpg)|*.png;*.jpg",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

                if (fileInfo.Length > 10 * 1024 * 1024)
                {

                    MessageBox.Show($"File vượt quá giới hạn 10MB", "Thông báo",
                   MessageBoxButton.OK);
                    return;
                }

                try
                {

                    // Define the destination path
                    string destinationDirectory = @"D:\App\Payment_Uploaded";

                    // Ensure the directory exists
                    if (!Directory.Exists(destinationDirectory))
                    {
                        Directory.CreateDirectory(destinationDirectory);
                    }

                    // Process the file (e.g., save it to a server or directory)
                    string destinationPath = System.IO.Path.Combine(destinationDirectory, fileInfo.Name);
                    //File.Copy(fileInfo.FullName, destinationPath, true);

                    MessageBox.Show($"Upload file thành công", "Thông báo",
                   MessageBoxButton.OK);

                    nameFileUpload.Text = fileInfo.Name;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi",
                   MessageBoxButton.OK);
                }
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
