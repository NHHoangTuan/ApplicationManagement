﻿#pragma checksum "..\..\..\CandidateWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9DB930814B319610D882F4AD2B9C079B4D6C7CF6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ApplicationManagement;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ApplicationManagement {
    
    
    /// <summary>
    /// CandidateWindow
    /// </summary>
    public partial class CandidateWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 63 "..\..\..\CandidateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton dashboardButton;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\CandidateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton NomineeButton;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\CandidateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton logOutButton;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\CandidateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame pageNavigation;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ApplicationManagement;component/candidatewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CandidateWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\CandidateWindow.xaml"
            ((ApplicationManagement.CandidateWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 14 "..\..\..\CandidateWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\CandidateWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dashboardButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 63 "..\..\..\CandidateWindow.xaml"
            this.dashboardButton.Click += new System.Windows.RoutedEventHandler(this.dashboardButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NomineeButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 70 "..\..\..\CandidateWindow.xaml"
            this.NomineeButton.Click += new System.Windows.RoutedEventHandler(this.NomineeButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.logOutButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 78 "..\..\..\CandidateWindow.xaml"
            this.logOutButton.Click += new System.Windows.RoutedEventHandler(this.logOutButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.pageNavigation = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

