﻿#pragma checksum "D:\Rin\Visual Studio projects\Windows Phone 8\Students\201306\Windows Phone 8\Nam\Map\Map\PivotPage1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6A5778A20166542CF38E4AE838A52626"
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
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Shell;
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
    
    
    public partial class PivotPage1 : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem abmnUserInfo;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem abmnSettings;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem abmnAbout;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton btShowLocation;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton btDone_AB;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton btReset_AB;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal Microsoft.Phone.Maps.Controls.Map MyFirstMap;
        
        internal System.Windows.Controls.Button btZoomIn;
        
        internal System.Windows.Controls.Button btZoomOut;
        
        internal System.Windows.Controls.Viewbox InfoViewbox;
        
        internal System.Windows.Controls.TextBlock tbDistance;
        
        internal System.Windows.Controls.TextBlock tbTemSpeed;
        
        internal System.Windows.Controls.Button btStart;
        
        internal System.Windows.Controls.TextBlock tbCalories;
        
        internal System.Windows.Controls.Viewbox TimeViewbox;
        
        internal System.Windows.Controls.TextBlock tbTimeCount;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Map;component/PivotPage1.xaml", System.UriKind.Relative));
            this.abmnUserInfo = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("abmnUserInfo")));
            this.abmnSettings = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("abmnSettings")));
            this.abmnAbout = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("abmnAbout")));
            this.btShowLocation = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("btShowLocation")));
            this.btDone_AB = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("btDone_AB")));
            this.btReset_AB = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("btReset_AB")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.MyFirstMap = ((Microsoft.Phone.Maps.Controls.Map)(this.FindName("MyFirstMap")));
            this.btZoomIn = ((System.Windows.Controls.Button)(this.FindName("btZoomIn")));
            this.btZoomOut = ((System.Windows.Controls.Button)(this.FindName("btZoomOut")));
            this.InfoViewbox = ((System.Windows.Controls.Viewbox)(this.FindName("InfoViewbox")));
            this.tbDistance = ((System.Windows.Controls.TextBlock)(this.FindName("tbDistance")));
            this.tbTemSpeed = ((System.Windows.Controls.TextBlock)(this.FindName("tbTemSpeed")));
            this.btStart = ((System.Windows.Controls.Button)(this.FindName("btStart")));
            this.tbCalories = ((System.Windows.Controls.TextBlock)(this.FindName("tbCalories")));
            this.TimeViewbox = ((System.Windows.Controls.Viewbox)(this.FindName("TimeViewbox")));
            this.tbTimeCount = ((System.Windows.Controls.TextBlock)(this.FindName("tbTimeCount")));
        }
    }
}

