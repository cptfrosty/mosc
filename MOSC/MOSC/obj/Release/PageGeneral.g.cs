﻿#pragma checksum "..\..\PageGeneral.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F24FD133ECDB19022A43D185CDF061C2E08ED159"
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
    /// PageGeneral
    /// </summary>
    public partial class PageGeneral : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\PageGeneral.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MOSC.PageGeneral pageGeneral;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\PageGeneral.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock infoService;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\PageGeneral.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRunService;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\PageGeneral.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOffService;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\PageGeneral.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock timeNow;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\PageGeneral.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock typeSchedule;
        
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
            System.Uri resourceLocater = new System.Uri("/MOSC;component/pagegeneral.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PageGeneral.xaml"
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
            this.pageGeneral = ((MOSC.PageGeneral)(target));
            return;
            case 2:
            this.infoService = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.btnRunService = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\PageGeneral.xaml"
            this.btnRunService.Click += new System.Windows.RoutedEventHandler(this.btnRunService_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnOffService = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\PageGeneral.xaml"
            this.btnOffService.Click += new System.Windows.RoutedEventHandler(this.btnOffService_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.timeNow = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.typeSchedule = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

