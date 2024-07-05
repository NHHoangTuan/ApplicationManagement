using ApplicationManagement.GUI;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ToggleButton[] buttons;
        Enterprise enterprise;
        

        public MainWindow()
        {
            InitializeComponent();
            enterprise = new Enterprise();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ToggleButton[] new_buttons = new ToggleButton[] { dashboardButton, enterpriseButton, tag2Button,
                tag3Button, tag4Button, configurationButton, tag5Button};
            buttons = new_buttons;

            dashboardButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        bool isMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (isMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1280;
                    this.Height = 780;

                    isMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    isMaximized = true;
                }
            }
        }

        private void dashboardButton_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(dashboardButton);
            /*if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(dashboard);*/
        }

        private void enterpriseButton_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(enterpriseButton);
            if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(enterprise);
        }

        private void tag2Button_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(tag2Button);
            /*if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(tag2);*/
        }

        private void tag3Button_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(tag3Button);
            /*if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(tag3);*/
        }

        private void tag4Button_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(tag4Button);
            /*if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(tag4);*/
        }

        private void tag5Button_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(tag5Button);
            /*if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(tag5);*/
        }

        private void configurationButton_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(configurationButton);
            /*if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(configuration);*/
        }

        private void changeButtonColor(ToggleButton b)
        {

            foreach (var button in buttons)
            {

                button.IsChecked = false;

            }

            b.IsChecked = true;
        }

        
    }
}
