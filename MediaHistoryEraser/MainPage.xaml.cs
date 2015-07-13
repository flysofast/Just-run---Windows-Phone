using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MediaHistoryEraser.Resources;
using Microsoft.Devices;
using System.Windows.Resources;

namespace MediaHistoryEraser
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            prg.IsIndeterminate = true;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                for (int i = 0; i < 25; i++)
                {
                    MediaHistoryItem historyItem = new MediaHistoryItem();

                    StreamResourceInfo sri = Application.GetResourceStream(new Uri("Assets/hlogo.png", UriKind.Relative));
                    historyItem.ImageStream = sri.Stream;
                    historyItem.Source = "";
                    historyItem.Title = i.ToString();
                    historyItem.PlayerContext["a"] = i.ToString();
                    MediaHistory mediaHistory = MediaHistory.Instance;
                    mediaHistory.WriteRecentPlay(historyItem);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            prg.IsIndeterminate = false;
            prg.Visibility = Visibility.Collapsed;
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}