﻿#pragma checksum "..\..\..\..\GUI\Enterprise.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09A6CBC2C367ED7BAA479C310367A1E71AEB6558"
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
    /// Enterprise
    /// </summary>
    public partial class Enterprise : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 46 "..\..\..\..\GUI\Enterprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MessageText;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\GUI\Enterprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView enterpriseListView;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\..\..\GUI\Enterprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTermTextBox;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\..\..\GUI\Enterprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SortCombobox;
        
        #line default
        #line hidden
        
        
        #line 277 "..\..\..\..\GUI\Enterprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FirstButton;
        
        #line default
        #line hidden
        
        
        #line 285 "..\..\..\..\GUI\Enterprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrevButton;
        
        #line default
        #line hidden
        
        
        #line 294 "..\..\..\..\GUI\Enterprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock pageInfoTextBlock;
        
        #line default
        #line hidden
        
        
        #line 305 "..\..\..\..\GUI\Enterprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NextButton;
        
        #line default
        #line hidden
        
        
        #line 314 "..\..\..\..\GUI\Enterprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LastButton;
        
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
            System.Uri resourceLocater = new System.Uri("/ApplicationManagement;component/gui/enterprise.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\GUI\Enterprise.xaml"
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
            
            #line 12 "..\..\..\..\GUI\Enterprise.xaml"
            ((ApplicationManagement.GUI.Enterprise)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MessageText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.enterpriseListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.SearchTermTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 196 "..\..\..\..\GUI\Enterprise.xaml"
            this.SearchTermTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTermTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SortCombobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 238 "..\..\..\..\GUI\Enterprise.xaml"
            this.SortCombobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SortCombobox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.FirstButton = ((System.Windows.Controls.Button)(target));
            
            #line 279 "..\..\..\..\GUI\Enterprise.xaml"
            this.FirstButton.Click += new System.Windows.RoutedEventHandler(this.FirstButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PrevButton = ((System.Windows.Controls.Button)(target));
            
            #line 287 "..\..\..\..\GUI\Enterprise.xaml"
            this.PrevButton.Click += new System.Windows.RoutedEventHandler(this.PrevButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.pageInfoTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.NextButton = ((System.Windows.Controls.Button)(target));
            
            #line 308 "..\..\..\..\GUI\Enterprise.xaml"
            this.NextButton.Click += new System.Windows.RoutedEventHandler(this.NextButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.LastButton = ((System.Windows.Controls.Button)(target));
            
            #line 316 "..\..\..\..\GUI\Enterprise.xaml"
            this.LastButton.Click += new System.Windows.RoutedEventHandler(this.LastButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 4:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 166 "..\..\..\..\GUI\Enterprise.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ListViewItem_MouseDoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

