﻿#pragma checksum "..\..\..\..\GUI\ChooseTypeSignUp.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A20E735F2321AED448F034291585718BB6EBF360"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// ChooseTypeSignUp
    /// </summary>
    public partial class ChooseTypeSignUp : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\GUI\ChooseTypeSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainContainer;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\GUI\ChooseTypeSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button enterpriseButton;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\GUI\ChooseTypeSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.IconPacks.PackIconMaterial Logout;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\GUI\ChooseTypeSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button candidateButton;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\GUI\ChooseTypeSignUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.IconPacks.PackIconMaterial Login;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ApplicationManagement;V1.0.0.0;component/gui/choosetypesignup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\GUI\ChooseTypeSignUp.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainContainer = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.enterpriseButton = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\GUI\ChooseTypeSignUp.xaml"
            this.enterpriseButton.Click += new System.Windows.RoutedEventHandler(this.enterpriseButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Logout = ((MahApps.Metro.IconPacks.PackIconMaterial)(target));
            return;
            case 4:
            this.candidateButton = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\..\GUI\ChooseTypeSignUp.xaml"
            this.candidateButton.Click += new System.Windows.RoutedEventHandler(this.candidateButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Login = ((MahApps.Metro.IconPacks.PackIconMaterial)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

