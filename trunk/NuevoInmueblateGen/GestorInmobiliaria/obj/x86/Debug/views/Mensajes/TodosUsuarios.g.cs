#pragma checksum "..\..\..\..\..\views\Mensajes\TodosUsuarios.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5BB6F8853E1AA1EC4B2FBD319B24365D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18444
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using System.Windows.Interactivity;
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
using Xceed.Wpf.DataGrid;
using Xceed.Wpf.DataGrid.Automation;
using Xceed.Wpf.DataGrid.Converters;
using Xceed.Wpf.DataGrid.FilterCriteria;
using Xceed.Wpf.DataGrid.Markup;
using Xceed.Wpf.DataGrid.ValidationRules;
using Xceed.Wpf.DataGrid.Views;


namespace GestorInmobiliaria.views.Mensaje {
    
    
    /// <summary>
    /// TodosUsuarios
    /// </summary>
    public partial class TodosUsuarios : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\..\views\Mensajes\TodosUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.DataGrid.DataGridControl dGListaUsuarios;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\views\Mensajes\TodosUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCerrarInf;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\views\Mensajes\TodosUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\..\views\Mensajes\TodosUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\views\Mensajes\TodosUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkTodosUsuarios;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\views\Mensajes\TodosUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkTodasInmobiliarias;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\views\Mensajes\TodosUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCerrar;
        
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
            System.Uri resourceLocater = new System.Uri("/GestorInmobiliaria;component/views/mensajes/todosusuarios.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\views\Mensajes\TodosUsuarios.xaml"
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
            this.dGListaUsuarios = ((Xceed.Wpf.DataGrid.DataGridControl)(target));
            return;
            case 2:
            this.btnCerrarInf = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\..\..\views\Mensajes\TodosUsuarios.xaml"
            this.btnCerrarInf.Click += new System.Windows.RoutedEventHandler(this.btnCerrar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.chkTodosUsuarios = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.chkTodasInmobiliarias = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.btnCerrar = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\..\..\views\Mensajes\TodosUsuarios.xaml"
            this.btnCerrar.Click += new System.Windows.RoutedEventHandler(this.btnCerrar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

