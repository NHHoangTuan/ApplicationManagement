﻿#pragma checksum "..\..\..\..\GUI\CandidateSignUp.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "434449CF5C3DEBB2AF26AAAAEF7B03C4CB7EE5AE"
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


namespace ApplicationManagement.GUI {
    
    
    /// <summary>
    /// CandidateSignUp
    /// </summary>
    public partial class CandidateSignUp : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\..\GUI\CandidateSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox candidateNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\GUI\CandidateSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox candidatePhoneNumberTextBox;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\GUI\CandidateSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox candidateEmailTextBox;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\..\..\GUI\CandidateSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateStartPicker;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\..\..\GUI\CandidateSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox candidateAgeTextBox;
        
        #line default
        #line hidden
        
        
        #line 269 "..\..\..\..\GUI\CandidateSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox candidateAddressTextBox;
        
        #line default
        #line hidden
        
        
        #line 294 "..\..\..\..\GUI\CandidateSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button candidateSignUp;
        
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
            System.Uri resourceLocater = new System.Uri("/ApplicationManagement;component/gui/candidatesignup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\GUI\CandidateSignUp.xaml"
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
            this.candidateNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.candidatePhoneNumberTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.candidateEmailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.dateStartPicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.candidateAgeTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.candidateAddressTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.candidateSignUp = ((System.Windows.Controls.Button)(target));
            
            #line 303 "..\..\..\..\GUI\CandidateSignUp.xaml"
            this.candidateSignUp.Click += new System.Windows.RoutedEventHandler(this.candidateSignUp_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

