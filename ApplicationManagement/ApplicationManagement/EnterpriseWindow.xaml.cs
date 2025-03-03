﻿using ApplicationManagement.GUI;
using ApplicationManagement.GUI.EnterpriseGUI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ApplicationManagement {
    /// <summary>
    /// Interaction logic for EnterpriseWindow.xaml
    /// </summary>
    public partial class EnterpriseWindow : Window {

        ToggleButton[] buttons;
        JobPosting jobPosting;
        ApproveApplicationList approveApplicationList;
        EnterpriseDashboard enterpriseDashboard;
        CreatedRecruitList createdRecruitList;

        Payment payment;

        public EnterpriseWindow() {
            InitializeComponent();
            jobPosting = new JobPosting();
            payment = new Payment();
            approveApplicationList = new ApproveApplicationList();
            enterpriseDashboard = new EnterpriseDashboard();
            createdRecruitList = new CreatedRecruitList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            ToggleButton[] new_buttons = new ToggleButton[] { JobPostingButton, PaymentButton,
                ApproveApplicationButton, logOutButton, DashboardButton, CreatedRecruitButton};
            buttons = new_buttons;

            DashboardButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
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


        private void JobPostingButton_Click(object sender, RoutedEventArgs e) {
            changeButtonColor(JobPostingButton);
            if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(jobPosting);
        }

        private void PaymentButton_Click(object sender, RoutedEventArgs e) {
            changeButtonColor(PaymentButton);
            if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(payment);
        }

        private void ApproveApplicationButton_Click(object sender, RoutedEventArgs e) {
            changeButtonColor(ApproveApplicationButton);
            if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(approveApplicationList);
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

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(DashboardButton);
            if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(enterpriseDashboard);
        }

        private void CreatedRecruitButton_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(CreatedRecruitButton);
            if (pageNavigation.NavigationService.Content != null)
            {
                pageNavigation.NavigationService.RemoveBackEntry();
            }

            pageNavigation.NavigationService.Navigate(createdRecruitList);
        }
    }
}
