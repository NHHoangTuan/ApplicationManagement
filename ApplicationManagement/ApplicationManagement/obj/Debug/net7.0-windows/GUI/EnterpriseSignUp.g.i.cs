﻿#pragma checksum "..\..\..\..\GUI\EnterpriseSignUp.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F5A7D2CFAF58BF251D0E76E168E459D5BAE094F2"
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
    /// EnterpriseSignUp
    /// </summary>
    public partial class EnterpriseSignUp : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\..\GUI\EnterpriseSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox accountTextBox;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\GUI\EnterpriseSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordTextBox;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\GUI\EnterpriseSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox enterpriseNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\..\..\GUI\EnterpriseSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox taxCodeTextBox;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\..\GUI\EnterpriseSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox representativeNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 285 "..\..\..\..\GUI\EnterpriseSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox enterpriseAddressTextBox;
        
        #line default
        #line hidden
        
        
        #line 332 "..\..\..\..\GUI\EnterpriseSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailTextBox;
        
        #line default
        #line hidden
        
        
        #line 359 "..\..\..\..\GUI\EnterpriseSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button enterpriseSignUp;
        
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
            System.Uri resourceLocater = new System.Uri("/ApplicationManagement;component/gui/enterprisesignup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\GUI\EnterpriseSignUp.xaml"
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
            this.accountTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.passwordTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.enterpriseNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.taxCodeTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.representativeNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.enterpriseAddressTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.emailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.enterpriseSignUp = ((System.Windows.Controls.Button)(target));
            
            #line 368 "..\..\..\..\GUI\EnterpriseSignUp.xaml"
            this.enterpriseSignUp.Click += new System.Windows.RoutedEventHandler(this.enterpriseSignUp_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

