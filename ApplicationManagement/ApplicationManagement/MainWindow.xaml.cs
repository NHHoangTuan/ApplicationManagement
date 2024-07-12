using ApplicationManagement.GUI;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace ApplicationManagement {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public static MainWindow Instance { get; private set; }


        ToggleButton[] buttons;
        Enterprise enterprise;
        Candidate candidate;
        RecruitList recruitList;
        ApplicationList applicationList;
        BillList billList;

        public MainWindow() {
            InitializeComponent();
            Instance = this;

            enterprise = new Enterprise();
            candidate = new Candidate();
            recruitList = new RecruitList();
            applicationList = new ApplicationList();
            billList = new BillList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            ToggleButton[] new_buttons = new ToggleButton[] { enterpriseButton, recruitListButton, paymentListButton,
                candidateButton, applicationListButton, tag3Button, logOutButton};
            buttons = new_buttons;

            enterpriseButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
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

        private void paymentListButton_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(paymentListButton);
            if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(billList);
        }



        public void ShowOverlay()
        {
            // Hiển thị và làm mờ overlay
            Overlay.Visibility = Visibility.Visible;
            DoubleAnimation fadeIn = new DoubleAnimation(0, 0.5, TimeSpan.FromSeconds(0.3));
            Overlay.BeginAnimation(OpacityProperty, fadeIn);
        }

        public void HideOverlay()
        {
            // Sau khi dialog đóng, ẩn overlay
            DoubleAnimation fadeOut = new DoubleAnimation(0.5, 0, TimeSpan.FromSeconds(0.3));
            fadeOut.Completed += (s, e) => Overlay.Visibility = Visibility.Collapsed;
            Overlay.BeginAnimation(OpacityProperty, fadeOut);
        }
    }
}
