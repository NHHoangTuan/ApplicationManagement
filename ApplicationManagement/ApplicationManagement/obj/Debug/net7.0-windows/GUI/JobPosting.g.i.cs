﻿#pragma checksum "..\..\..\..\GUI\JobPosting.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F757746007AF8F8F00D706CB645C133BE2CA1D2D"
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
    /// JobPosting
    /// </summary>
    public partial class JobPosting : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\..\..\GUI\JobPosting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox vacanciesTextBox;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\GUI\JobPosting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox numberRecruitTextBox;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\GUI\JobPosting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateStartPicker;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\..\GUI\JobPosting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateEndPicker;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\..\..\GUI\JobPosting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox requireInfoTextBox;
        
        #line default
        #line hidden
        
        
        #line 221 "..\..\..\..\GUI\JobPosting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker specificDate;
        
        #line default
        #line hidden
        
        
        #line 256 "..\..\..\..\GUI\JobPosting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RecruitForm;
        
        #line default
        #line hidden
        
        
        #line 284 "..\..\..\..\GUI\JobPosting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button post;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ApplicationManagement;component/gui/jobposting.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\GUI\JobPosting.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.vacanciesTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.numberRecruitTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.dateStartPicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.dateEndPicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.requireInfoTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.specificDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.RecruitForm = ((System.Windows.Controls.ComboBox)(target));
            
            #line 255 "..\..\..\..\GUI\JobPosting.xaml"
            this.RecruitForm.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RecruitForm_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.post = ((System.Windows.Controls.Button)(target));
            
            #line 294 "..\..\..\..\GUI\JobPosting.xaml"
            this.post.Click += new System.Windows.RoutedEventHandler(this.post_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

