﻿#pragma checksum "C:\Users\IT\SkyDrive\Projects\Map Beta\Map\PivotMainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1A1A8C3A1A279BA4627A17B8F65D6E6A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
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
    
    
    public partial class PivotMainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Controls.PhoneApplicationPage MainPage;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem abmnMusicPlayer;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem mniAdd_AB;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem abmnUserInfo;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem abmnSettings;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem abmnAbout;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem abmnShareSMS;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem abmnShareEmail;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton btShowLocation;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton btPause_AB;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton btReset_AB;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Media.SolidColorBrush myAnimatedBrush;
        
        internal System.Windows.Media.Animation.Storyboard myStoryboard;
        
        internal Microsoft.Phone.Maps.Controls.Map MyFirstMap;
        
        internal System.Windows.Controls.Button btZoomIn;
        
        internal System.Windows.Controls.Button btZoomOut;
        
        internal System.Windows.Controls.TextBlock tbDistance;
        
        internal System.Windows.Controls.TextBlock tbTemSpeed;
        
        internal System.Windows.Controls.Button btStart;
        
        internal System.Windows.Controls.Button btFinished;
        
        internal System.Windows.Controls.TextBlock tbCalories;
        
        internal System.Windows.Controls.Viewbox TimeViewbox;
        
        internal System.Windows.Controls.TextBlock tbTimeCount;
        
        internal System.Windows.Controls.TextBlock tbPace;
        
        internal System.Windows.Controls.ProgressBar prgBar;
        
        internal System.Windows.Controls.TextBlock tbFindingLocation;
        
        internal Microsoft.Phone.Controls.LongListMultiSelector longListMultiSelector;
        
        internal System.Windows.Controls.TextBlock tbSongTitle;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Map;component/PivotMainPage.xaml", System.UriKind.Relative));
            this.MainPage = ((Microsoft.Phone.Controls.PhoneApplicationPage)(this.FindName("MainPage")));
            this.abmnMusicPlayer = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("abmnMusicPlayer")));
            this.mniAdd_AB = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("mniAdd_AB")));
            this.abmnUserInfo = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("abmnUserInfo")));
            this.abmnSettings = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("abmnSettings")));
            this.abmnAbout = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("abmnAbout")));
            this.abmnShareSMS = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("abmnShareSMS")));
            this.abmnShareEmail = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("abmnShareEmail")));
            this.btShowLocation = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("btShowLocation")));
            this.btPause_AB = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("btPause_AB")));
            this.btReset_AB = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("btReset_AB")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.myAnimatedBrush = ((System.Windows.Media.SolidColorBrush)(this.FindName("myAnimatedBrush")));
            this.myStoryboard = ((System.Windows.Media.Animation.Storyboard)(this.FindName("myStoryboard")));
            this.MyFirstMap = ((Microsoft.Phone.Maps.Controls.Map)(this.FindName("MyFirstMap")));
            this.btZoomIn = ((System.Windows.Controls.Button)(this.FindName("btZoomIn")));
            this.btZoomOut = ((System.Windows.Controls.Button)(this.FindName("btZoomOut")));
            this.tbDistance = ((System.Windows.Controls.TextBlock)(this.FindName("tbDistance")));
            this.tbTemSpeed = ((System.Windows.Controls.TextBlock)(this.FindName("tbTemSpeed")));
            this.btStart = ((System.Windows.Controls.Button)(this.FindName("btStart")));
            this.btFinished = ((System.Windows.Controls.Button)(this.FindName("btFinished")));
            this.tbCalories = ((System.Windows.Controls.TextBlock)(this.FindName("tbCalories")));
            this.TimeViewbox = ((System.Windows.Controls.Viewbox)(this.FindName("TimeViewbox")));
            this.tbTimeCount = ((System.Windows.Controls.TextBlock)(this.FindName("tbTimeCount")));
            this.tbPace = ((System.Windows.Controls.TextBlock)(this.FindName("tbPace")));
            this.prgBar = ((System.Windows.Controls.ProgressBar)(this.FindName("prgBar")));
            this.tbFindingLocation = ((System.Windows.Controls.TextBlock)(this.FindName("tbFindingLocation")));
            this.longListMultiSelector = ((Microsoft.Phone.Controls.LongListMultiSelector)(this.FindName("longListMultiSelector")));
            this.tbSongTitle = ((System.Windows.Controls.TextBlock)(this.FindName("tbSongTitle")));
        }
    }
}

