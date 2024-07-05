using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ApplicationManagement {
    /// <summary>
    /// Interaction logic for CandidateWindow.xaml
    /// </summary>
    public partial class CandidateWindow : Window {

        ToggleButton[] buttons;

        public CandidateWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            ToggleButton[] new_buttons = new ToggleButton[] { dashboardButton, tag1Button, logOutButton };
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

        private void tag1Button_Click(object sender, RoutedEventArgs e) {
            changeButtonColor(tag1Button);
            /*if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(tag1);*/
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e) {
            changeButtonColor(logOutButton);
            /*if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(configuration);*/
        }

        private void changeButtonColor(ToggleButton b) {

            foreach (var button in buttons) {

                button.IsChecked = false;

            }

            b.IsChecked = true;
        }
    }
}
