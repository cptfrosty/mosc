﻿#pragma checksum "..\..\SettingService.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64CF85D2D4E6B19A6FD50F54AA15718FE335016F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MOSC;
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


namespace MOSC {
    
    
    /// <summary>
    /// SettingService
    /// </summary>
    public partial class SettingService : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\SettingService.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGeneral;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\SettingService.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSchedule;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\SettingService.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTask;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\SettingService.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame pageContent;
        
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
            System.Uri resourceLocater = new System.Uri("/MOSC;component/settingservice.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SettingService.xaml"
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
            this.btnGeneral = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\SettingService.xaml"
            this.btnGeneral.Click += new System.Windows.RoutedEventHandler(this.btnGeneral_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnSchedule = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\SettingService.xaml"
            this.btnSchedule.Click += new System.Windows.RoutedEventHandler(this.btnSchedule_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnTask = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\SettingService.xaml"
            this.btnTask.Click += new System.Windows.RoutedEventHandler(this.btnTask_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.pageContent = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

