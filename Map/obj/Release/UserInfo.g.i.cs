﻿#pragma checksum "C:\Users\IT\SkyDrive\Projects\Map Beta\Map\UserInfo.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A2B00F4D4BEBCDB55605B97D1E29FE84"
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
using Visifire.Charts;


namespace Map {
    
    
    public partial class UserInfo : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox tbAge;
        
        internal System.Windows.Controls.TextBox tbWeight;
        
        internal System.Windows.Controls.TextBox tbGrade;
        
        internal System.Windows.Controls.TextBlock tbStatus;
        
        internal Microsoft.Phone.Controls.ListPicker lpGender;
        
        internal System.Windows.Controls.TextBox tbHeight;
        
        internal System.Windows.Controls.TextBlock tbStatusLabel;
        
        internal System.Windows.Shapes.Rectangle Rec;
        
        internal System.Windows.Controls.ProgressBar prgBar;
        
        internal System.Windows.Controls.TextBlock tbTotalCalories;
        
        internal System.Windows.Controls.TextBlock tbTotalDistance;
        
        internal System.Windows.Controls.TextBlock tbLastRun;
        
        internal System.Windows.Controls.TextBlock tbTotalDuration;
        
        internal System.Windows.Controls.TextBlock tbAvgSpeed;
        
        internal System.Windows.Controls.TextBlock tbAvgPace;
        
        internal Visifire.Charts.Chart Chart;
        
        internal Visifire.Charts.DataSeries DataSeries;
        
        internal System.Windows.Controls.TextBlock tbCalories;
        
        internal System.Windows.Controls.TextBlock tbDistance;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Map;component/UserInfo.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.tbAge = ((System.Windows.Controls.TextBox)(this.FindName("tbAge")));
            this.tbWeight = ((System.Windows.Controls.TextBox)(this.FindName("tbWeight")));
            this.tbGrade = ((System.Windows.Controls.TextBox)(this.FindName("tbGrade")));
            this.tbStatus = ((System.Windows.Controls.TextBlock)(this.FindName("tbStatus")));
            this.lpGender = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpGender")));
            this.tbHeight = ((System.Windows.Controls.TextBox)(this.FindName("tbHeight")));
            this.tbStatusLabel = ((System.Windows.Controls.TextBlock)(this.FindName("tbStatusLabel")));
            this.Rec = ((System.Windows.Shapes.Rectangle)(this.FindName("Rec")));
            this.prgBar = ((System.Windows.Controls.ProgressBar)(this.FindName("prgBar")));
            this.tbTotalCalories = ((System.Windows.Controls.TextBlock)(this.FindName("tbTotalCalories")));
            this.tbTotalDistance = ((System.Windows.Controls.TextBlock)(this.FindName("tbTotalDistance")));
            this.tbLastRun = ((System.Windows.Controls.TextBlock)(this.FindName("tbLastRun")));
            this.tbTotalDuration = ((System.Windows.Controls.TextBlock)(this.FindName("tbTotalDuration")));
            this.tbAvgSpeed = ((System.Windows.Controls.TextBlock)(this.FindName("tbAvgSpeed")));
            this.tbAvgPace = ((System.Windows.Controls.TextBlock)(this.FindName("tbAvgPace")));
            this.Chart = ((Visifire.Charts.Chart)(this.FindName("Chart")));
            this.DataSeries = ((Visifire.Charts.DataSeries)(this.FindName("DataSeries")));
            this.tbCalories = ((System.Windows.Controls.TextBlock)(this.FindName("tbCalories")));
            this.tbDistance = ((System.Windows.Controls.TextBlock)(this.FindName("tbDistance")));
        }
    }
}

