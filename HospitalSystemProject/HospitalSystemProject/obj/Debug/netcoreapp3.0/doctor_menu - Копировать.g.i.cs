﻿#pragma checksum "..\..\..\doctor_menu - Копировать.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A82FF019047BF7BCAD067561E82E367FD7755CF1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalSystemProject;
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


namespace HospitalSystemProject {
    
    
    /// <summary>
    /// doctor_menu
    /// </summary>
    public partial class doctor_menu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\doctor_menu - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Patients_info;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\doctor_menu - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid My_schedule;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\doctor_menu - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ph;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\doctor_menu - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Staff_addition;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\doctor_menu - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\doctor_menu - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox surname;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\doctor_menu - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phone;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\doctor_menu - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\doctor_menu - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datepicker1;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\doctor_menu - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combobox1;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\doctor_menu - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox salary;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HospitalSystemProject;component/doctor_menu%20-%20%d0%9a%d0%be%d0%bf%d0%b8%d1%80" +
                    "%d0%be%d0%b2%d0%b0%d1%82%d1%8c.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\doctor_menu - Копировать.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\doctor_menu - Копировать.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PatientsInfo_Click2);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 13 "..\..\..\doctor_menu - Копировать.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PatientsInfo_Click3);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 15 "..\..\..\doctor_menu - Копировать.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PatientsInfo_Click1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Patients_info = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.My_schedule = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.ph = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Staff_addition = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.surname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.phone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 12:
            this.datepicker1 = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 13:
            this.combobox1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 14:
            this.salary = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            
            #line 50 "..\..\..\doctor_menu - Копировать.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.insert_ward);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

