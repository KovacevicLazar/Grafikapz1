﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "281DE0C7D9379F4B6317D2379AA09ED12F16A046E3831EA3D21C397E78F1A7CB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PredmetniZadatak1;
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


namespace PredmetniZadatak1 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EllipseButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RectangleButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PolygonButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ImageButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UndoButton;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RedoButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ClearButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas PaintCanvas;
        
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
            System.Uri resourceLocater = new System.Uri("/PredmetniZadatak1;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.EllipseButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\MainWindow.xaml"
            this.EllipseButton.Click += new System.Windows.RoutedEventHandler(this.EllipseButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RectangleButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\MainWindow.xaml"
            this.RectangleButton.Click += new System.Windows.RoutedEventHandler(this.RectangleButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PolygonButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\MainWindow.xaml"
            this.PolygonButton.Click += new System.Windows.RoutedEventHandler(this.PolygonButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ImageButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\MainWindow.xaml"
            this.ImageButton.Click += new System.Windows.RoutedEventHandler(this.ImageButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.UndoButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\MainWindow.xaml"
            this.UndoButton.Click += new System.Windows.RoutedEventHandler(this.UndoButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RedoButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\MainWindow.xaml"
            this.RedoButton.Click += new System.Windows.RoutedEventHandler(this.RedoButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ClearButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\MainWindow.xaml"
            this.ClearButton.Click += new System.Windows.RoutedEventHandler(this.ClearButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PaintCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this.PaintCanvas.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.PaintCanvas_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 21 "..\..\MainWindow.xaml"
            this.PaintCanvas.MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.PaintCanvas_MouseRightButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

