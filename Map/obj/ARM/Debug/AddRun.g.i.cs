﻿#pragma checksum "D:\Rin\Visual Studio projects\Windows Phone 8\Students\201306\Windows Phone 8\Nam\Map Beta\Map\AddRun.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "354551047CE1937BBA60317706DF817B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Map {
    
    
    public partial class AddRun : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.DatePicker dpDate;
        
        internal Microsoft.Phone.Controls.TimePicker tpTime;
        
        internal System.Windows.Controls.TextBox tbDistance;
        
        internal System.Windows.Controls.TextBox tbDuration;
        
        internal System.Windows.Controls.Button btSave;
        
        internal System.Windows.Controls.TextBox tbCalo;
        
        internal System.Windows.Controls.Button btCancel;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Map;component/AddRun.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.dpDate = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("dpDate")));
            this.tpTime = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("tpTime")));
            this.tbDistance = ((System.Windows.Controls.TextBox)(this.FindName("tbDistance")));
            this.tbDuration = ((System.Windows.Controls.TextBox)(this.FindName("tbDuration")));
            this.btSave = ((System.Windows.Controls.Button)(this.FindName("btSave")));
            this.tbCalo = ((System.Windows.Controls.TextBox)(this.FindName("tbCalo")));
            this.btCancel = ((System.Windows.Controls.Button)(this.FindName("btCancel")));
        }
    }
}

