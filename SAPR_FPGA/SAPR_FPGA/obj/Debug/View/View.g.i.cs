﻿#pragma checksum "..\..\..\View\View.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FC8026F9C76A177C4468C14D3CF2CF75"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18063
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
using _3DTools;


namespace SAPR_FPGA.View {
    
    
    /// <summary>
    /// View
    /// </summary>
    public partial class View : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\View\View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid WorkG;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\View\View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewport3D port3d;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\View\View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Media3D.PerspectiveCamera Perspective;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\View\View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Media3D.MeshGeometry3D meshTrig;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\View\View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Media3D.MeshGeometry3D Trig2;
        
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
            System.Uri resourceLocater = new System.Uri("/SAPR_FPGA;component/view/view.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\View.xaml"
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
            this.WorkG = ((System.Windows.Controls.Grid)(target));
            
            #line 9 "..\..\..\View\View.xaml"
            this.WorkG.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.WorkGrid_MouseWheel);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\View\View.xaml"
            this.WorkG.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.с);
            
            #line default
            #line hidden
            return;
            case 2:
            this.port3d = ((System.Windows.Controls.Viewport3D)(target));
            
            #line 10 "..\..\..\View\View.xaml"
            this.port3d.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.WorkGrid_MouseWheel);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\View\View.xaml"
            this.port3d.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.port3d_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Perspective = ((System.Windows.Media.Media3D.PerspectiveCamera)(target));
            return;
            case 4:
            this.meshTrig = ((System.Windows.Media.Media3D.MeshGeometry3D)(target));
            return;
            case 5:
            this.Trig2 = ((System.Windows.Media.Media3D.MeshGeometry3D)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

