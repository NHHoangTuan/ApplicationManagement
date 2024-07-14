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
    /// Interaction logic for RecruitDetail.xaml
    /// </summary>
    public partial class RecruitDetail : Window
    {

        RecruitmentDTO copyRecruitmentDTO { get; set; }
        RecruitmentDTO selectedRecruit;
        RecruitmentBUS recruitmentBUS;

        public RecruitDetail(RecruitmentDTO r)
        {
            InitializeComponent();

            this.DataContext = r;
            copyRecruitmentDTO = (RecruitmentDTO)r.Clone();
            selectedRecruit = r;
            recruitmentBUS = new RecruitmentBUS();
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {


            if (selectedRecruit != null)
            {
                var result = MessageBox.Show($"Bạn có chắc muốn duyệt bài tuyển dụng {selectedRecruit.Vacancies} - {selectedRecruit.Enterprise.EnterpriseName}?",
                   "Xác nhận duyệt", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    recruitmentBUS.setValidity(selectedRecruit, "OK");
                    recruitmentBUS.updateRecruitStatus(selectedRecruit);
                    DialogResult = true;

                    //updateDataSource(_currentPage, _currentCurrency, _currentStartPrice, _currentEndPrice, _currentList);
                }
            }
        }

        private void rejectButton_Click(object sender, RoutedEventArgs e)
        {


            if (selectedRecruit != null)
            {
                var result = MessageBox.Show($"Bạn có chắc muốn từ chối hồ sơ {selectedRecruit.Vacancies} - {selectedRecruit.Enterprise.EnterpriseName}?",
                   "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        recruitmentBUS.setValidity(selectedRecruit, "REJECT");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                    try
                    {
                        recruitmentBUS.updateValidity(selectedRecruit.formID, "REJECT");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                    /*try
                    {
                        recruitmentBUS.deleteRecruit(selectedRecruit);
                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message); }*/

                    DialogResult = true;

                    //updateDataSource(_currentPage, _currentCurrency, _currentStartPrice, _currentEndPrice, _currentList);
                }
            }
        }
    }
}
