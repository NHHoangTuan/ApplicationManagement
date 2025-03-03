﻿#pragma checksum "..\..\..\..\GUI\Login.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3A716BA205AA3F83B33596F07885EC0C743CD34E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ApplicationManagement.Converter;
using ApplicationManagement.GUI;
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


namespace ApplicationManagement.GUI {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 63 "..\..\..\..\GUI\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock userTextBlock;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\GUI\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userTextBox;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\GUI\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock passwordTextBlock;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\GUI\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordTextBox;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\GUI\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox rememberCheckBox;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\GUI\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SignInButton;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\GUI\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SignUpButton;
        
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
            System.Uri resourceLocater = new System.Uri("/ApplicationManagement;component/gui/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\GUI\Login.xaml"
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
            
            #line 23 "..\..\..\..\GUI\Login.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseUp);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 52 "..\..\..\..\GUI\Login.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.userTextBlock = ((System.Windows.Controls.TextBlock)(target));
            
            #line 63 "..\..\..\..\GUI\Login.xaml"
            this.userTextBlock.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.userTextBlock_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.userTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 64 "..\..\..\..\GUI\Login.xaml"
            this.userTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.userTextBox_TextChanged);
            
            #line default
            #line hidden
            
            #line 65 "..\..\..\..\GUI\Login.xaml"
            this.userTextBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.userTextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.passwordTextBlock = ((System.Windows.Controls.TextBlock)(target));
            
            #line 77 "..\..\..\..\GUI\Login.xaml"
            this.passwordTextBlock.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.passwordTextBlock_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.passwordTextBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 78 "..\..\..\..\GUI\Login.xaml"
            this.passwordTextBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.passwordTextBox_PasswordChanged);
            
            #line default
            #line hidden
            
            #line 79 "..\..\..\..\GUI\Login.xaml"
            this.passwordTextBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.passwordTextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.rememberCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 83 "..\..\..\..\GUI\Login.xaml"
            this.rememberCheckBox.Click += new System.Windows.RoutedEventHandler(this.rememberCheckBox_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SignInButton = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\..\GUI\Login.xaml"
            this.SignInButton.Click += new System.Windows.RoutedEventHandler(this.SignInButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SignUpButton = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\..\GUI\Login.xaml"
            this.SignUpButton.Click += new System.Windows.RoutedEventHandler(this.SignUpButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

