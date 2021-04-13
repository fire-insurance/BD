﻿#pragma checksum "..\..\..\View\LandInfo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0C62D8FA4F9F184919D6372FEDBD70C79B0FC2AECA10E743834BDD14CE9F99A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Kursach.View;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Kursach.View {
    
    
    /// <summary>
    /// LandInfo
    /// </summary>
    public partial class LandInfo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 61 "..\..\..\View\LandInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenFolder;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\View\LandInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox LightBox;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\View\LandInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox WaterBox;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\View\LandInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox HeatBox;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\View\LandInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid LandInfoTable;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\View\LandInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HousesInfo;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\View\LandInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\View\LandInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseButton1;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\View\LandInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HideButton1;
        
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
            System.Uri resourceLocater = new System.Uri("/Kursach;component/view/landinfo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\LandInfo.xaml"
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
            this.OpenFolder = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\View\LandInfo.xaml"
            this.OpenFolder.Click += new System.Windows.RoutedEventHandler(this.OpenFolder_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LightBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            this.WaterBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.HeatBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.LandInfoTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.HousesInfo = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\View\LandInfo.xaml"
            this.HousesInfo.Click += new System.Windows.RoutedEventHandler(this.HousesInfo_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\View\LandInfo.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CloseButton1 = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\..\View\LandInfo.xaml"
            this.CloseButton1.Click += new System.Windows.RoutedEventHandler(this.CloseButton1_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.HideButton1 = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\..\View\LandInfo.xaml"
            this.HideButton1.Click += new System.Windows.RoutedEventHandler(this.HideButton1_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

