﻿#pragma checksum "..\..\EmploeeInfo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8333DEABDC0D344167AD787D10DA0C167A8D16B922B17371304342D48901813C"
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
    /// EmploeeInfo
    /// </summary>
    public partial class EmploeeInfo : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\EmploeeInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock fio;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\EmploeeInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock position;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\EmploeeInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock birthday;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\EmploeeInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock phone;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\EmploeeInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock gender;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\EmploeeInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock email;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\EmploeeInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock login;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\EmploeeInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock password;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\EmploeeInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteEmpButton;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\EmploeeInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeEmpButton;
        
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
            System.Uri resourceLocater = new System.Uri("/alimak;component/emploeeinfo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EmploeeInfo.xaml"
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
            this.fio = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.position = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.birthday = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.phone = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.gender = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.email = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.login = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.password = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.DeleteEmpButton = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\EmploeeInfo.xaml"
            this.DeleteEmpButton.Click += new System.Windows.RoutedEventHandler(this.DeleteEmpButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ChangeEmpButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\EmploeeInfo.xaml"
            this.ChangeEmpButton.Click += new System.Windows.RoutedEventHandler(this.ChangeEmpButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

