#pragma checksum "..\..\..\..\View\EditCompanyWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CC96B77B6D4C0DAC48A916F5F8E7404862539D9C"
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
using airlineApp.View;


namespace airlineApp.View {
    
    
    /// <summary>
    /// EditCompanyWindow
    /// </summary>
    public partial class EditCompanyWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\View\EditCompanyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal airlineApp.View.EditCompanyWindow EditCompanyWnd;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\View\EditCompanyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CompanyNameTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/airlineApp;component/view/editcompanywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\EditCompanyWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.EditCompanyWnd = ((airlineApp.View.EditCompanyWindow)(target));
            return;
            case 2:
            this.CompanyNameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 40 "..\..\..\..\View\EditCompanyWindow.xaml"
            this.CompanyNameTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewTextInputOnlyLetters);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 64 "..\..\..\..\View\EditCompanyWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewTextInputOnlyLetters);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

