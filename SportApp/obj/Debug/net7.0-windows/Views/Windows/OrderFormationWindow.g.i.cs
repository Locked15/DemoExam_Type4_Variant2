﻿#pragma checksum "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8EC3EAA8DB9298A28A501F7D3E7F0172B3F83085"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SportApp.Views.Windows;
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


namespace SportApp.Views.Windows {
    
    
    /// <summary>
    /// OrderFormationWindow
    /// </summary>
    public partial class OrderFormationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock finalDiscountBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock finalCostBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox pickupPointSelector;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView productsInOrderList;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label productCountLabel;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox productCountInputBox;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button removeProductFromOrderButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SportApp;V1.0.0.0;component/views/windows/orderformationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
            ((SportApp.Views.Windows.OrderFormationWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.OnWindowLoaded);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
            ((SportApp.Views.Windows.OrderFormationWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.OnWindowClosing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.finalDiscountBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.finalCostBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.pickupPointSelector = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.productsInOrderList = ((System.Windows.Controls.ListView)(target));
            
            #line 39 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
            this.productsInOrderList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnProductsInOrderListSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 43 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OnAddToOrderMenuItemClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.productCountLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.productCountInputBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 81 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
            this.productCountInputBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnProductCountInputBoxTextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 83 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnGetBulletinButtonClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.removeProductFromOrderButton = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
            this.removeProductFromOrderButton.Click += new System.Windows.RoutedEventHandler(this.OnRemoveProductFromOrderButtonClick);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 85 "..\..\..\..\..\Views\Windows\OrderFormationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnSaveOrderButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

