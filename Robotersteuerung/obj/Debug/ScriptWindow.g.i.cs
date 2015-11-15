﻿#pragma checksum "..\..\ScriptWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A743935935A52B75E4212B9CA90DBDB9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Robotersteuerung;
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


namespace Robotersteuerung {
    
    
    /// <summary>
    /// ScriptWindow
    /// </summary>
    public partial class ScriptWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ScriptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu menu;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ScriptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuItem_header_data;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ScriptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuItem_close;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ScriptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox scriptBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ScriptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label se_state;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\ScriptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_startScript;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\ScriptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_stopScript;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\ScriptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_pauseScript;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\ScriptWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_resumeScript;
        
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
            System.Uri resourceLocater = new System.Uri("/Robotersteuerung;component/scriptwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ScriptWindow.xaml"
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
            this.menu = ((System.Windows.Controls.Menu)(target));
            return;
            case 2:
            this.menuItem_header_data = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 3:
            this.menuItem_close = ((System.Windows.Controls.MenuItem)(target));
            
            #line 12 "..\..\ScriptWindow.xaml"
            this.menuItem_close.Click += new System.Windows.RoutedEventHandler(this.menuItem_close_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.scriptBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.se_state = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.btn_startScript = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\ScriptWindow.xaml"
            this.btn_startScript.Click += new System.Windows.RoutedEventHandler(this.btn_startScript_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_stopScript = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\ScriptWindow.xaml"
            this.btn_stopScript.Click += new System.Windows.RoutedEventHandler(this.btn_stopScript_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_pauseScript = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\ScriptWindow.xaml"
            this.btn_pauseScript.Click += new System.Windows.RoutedEventHandler(this.btn_pauseScript_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_resumeScript = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\ScriptWindow.xaml"
            this.btn_resumeScript.Click += new System.Windows.RoutedEventHandler(this.btn_resumeScript_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

