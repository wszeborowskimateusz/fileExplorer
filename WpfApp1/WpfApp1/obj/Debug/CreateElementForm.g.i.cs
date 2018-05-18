﻿#pragma checksum "..\..\CreateElementForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74C5186F29E5F703F08A637C4D7D3138DB382F95"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// CreateElementForm
    /// </summary>
    public partial class CreateElementForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\CreateElementForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\CreateElementForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton FileRadio;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\CreateElementForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton DirectoryRadio;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\CreateElementForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ReadOnlyCB;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\CreateElementForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ArchiveCB;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\CreateElementForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox HiddenCB;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\CreateElementForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox SystemCB;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/createelementform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CreateElementForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\CreateElementForm.xaml"
            this.nameTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.gotFocus);
            
            #line default
            #line hidden
            
            #line 13 "..\..\CreateElementForm.xaml"
            this.nameTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.lostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FileRadio = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.DirectoryRadio = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.ReadOnlyCB = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.ArchiveCB = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.HiddenCB = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.SystemCB = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            
            #line 33 "..\..\CreateElementForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateNewDiskElement);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 34 "..\..\CreateElementForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.cancel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
