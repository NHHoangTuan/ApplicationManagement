using ApplicationManagement.GUI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ApplicationManagement {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        ToggleButton[] buttons;
        Enterprise enterprise;
        Candidate candidate;
        RecruitList recruitList;
        ApplicationList applicationList;

        public MainWindow() {
            InitializeComponent();
            enterprise = new Enterprise();
            candidate = new Candidate();
            recruitList = new RecruitList();
            applicationList = new ApplicationList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            ToggleButton[] new_buttons = new ToggleButton[] { dashboardButton, enterpriseButton, recruitListButton, candidateButton,
                applicationListButton,
                tag3Button, logOutButton};
            buttons = new_buttons;

            dashboardButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) {
                this.DragMove();
            }
        }

        bool isMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            if (e.ClickCount == 2) {
                if (isMaximized) {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1280;
                    this.Height = 780;

                    isMaximized = false;
                }
                else {
                    this.WindowState = WindowState.Maximized;
                    isMaximized = true;
                }
            }
        }

        private void dashboardButton_Click(object sender, RoutedEventArgs e) {
            changeButtonColor(dashboardButton);
            /*if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(dashboard);*/
        }

        private void enterpriseButton_Click(object sender, RoutedEventArgs e) {
            changeButtonColor(enterpriseButton);
            if (pageNavigation.NavigationService.Content != null) {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(enterprise);
        }

        private void candidateButton_Click(object sender, RoutedEventArgs e) {
            changeButtonColor(candidateButton);
            if (pageNavigation.NavigationService.Content != null) {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(candidate);
        }

        private void tag3Button_Click(object sender, RoutedEventArgs e) {
            changeButtonColor(tag3Button);
            /*if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(tag3);*/
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e) {
            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void changeButtonColor(ToggleButton b) {

            foreach (var button in buttons) {

                button.IsChecked = false;

            }

            b.IsChecked = true;
        }

        private void recruitListButton_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(recruitListButton);
            if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(recruitList);
        }

        private void applicationListButton_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(applicationListButton);
            if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(applicationList);
        }
    }
}
