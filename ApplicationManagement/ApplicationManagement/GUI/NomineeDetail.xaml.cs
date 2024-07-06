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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApplicationManagement.GUI
{
    /// <summary>
    /// Interaction logic for NomineeDetail.xaml
    /// </summary>
    public partial class NomineeDetail : Window
    {

        RecruitmentDTO copyRecruitmentDTO {  get; set; }
        public NomineeDetail(RecruitmentDTO r)
        {
            InitializeComponent();
            this.DataContext = r;
            copyRecruitmentDTO = (RecruitmentDTO)r.Clone();
        }

        private void RecruitmentButton_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị và làm mờ overlay
            Overlay.Visibility = Visibility.Visible;
            DoubleAnimation fadeIn = new DoubleAnimation(0, 0.5, TimeSpan.FromSeconds(0.3));
            Overlay.BeginAnimation(OpacityProperty, fadeIn);

            var submit = new SubmitApplication(copyRecruitmentDTO);
            submit.ShowDialog();

            // Sau khi dialog đóng, ẩn overlay
            DoubleAnimation fadeOut = new DoubleAnimation(0.5, 0, TimeSpan.FromSeconds(0.3));
            fadeOut.Completed += (s, e) => Overlay.Visibility = Visibility.Collapsed;
            Overlay.BeginAnimation(OpacityProperty, fadeOut);
        }
    }
}
