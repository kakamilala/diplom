﻿#pragma checksum "..\..\AddDepartment.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0B2249669D31C02A199012B14247B2591E718700186BDD304CCA3068CBF60786"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using alimak;


namespace alimak {
    
    
    /// <summary>
    /// AddDepartment
    /// </summary>
    public partial class AddDepartment : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\AddDepartment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock title;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\AddDepartment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox user;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\AddDepartment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox iddep;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\AddDepartment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddDepButton;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\AddDepartment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeDepButton;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\AddDepartment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveDepButton;
        
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
            System.Uri resourceLocater = new System.Uri("/alimak;component/adddepartment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddDepartment.xaml"
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
            
            #line 11 "..\..\AddDepartment.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.user = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.iddep = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AddDepButton = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\AddDepartment.xaml"
            this.AddDepButton.Click += new System.Windows.RoutedEventHandler(this.AddDepButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ChangeDepButton = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\AddDepartment.xaml"
            this.ChangeDepButton.Click += new System.Windows.RoutedEventHandler(this.ChangeDepButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RemoveDepButton = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\AddDepartment.xaml"
            this.RemoveDepButton.Click += new System.Windows.RoutedEventHandler(this.RemoveDepButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

