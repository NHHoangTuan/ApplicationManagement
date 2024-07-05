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
    /// Interaction logic for ChooseTypeSignUp.xaml
    /// </summary>
    public partial class ChooseTypeSignUp : Window
    {
        public ChooseTypeSignUp()
        {
            InitializeComponent();
        }

        private void candidateButton_Click(object sender, RoutedEventArgs e)
        {
            var candidate = new CandidateSignUp();
            this.Close();
            candidate.ShowDialog();
            
        }

        private void enterpriseButton_Click(object sender, RoutedEventArgs e)
        {
            var enterprise = new EnterpriseSignUp();
            this.Close();
            enterprise.ShowDialog();
        }
    }
}
