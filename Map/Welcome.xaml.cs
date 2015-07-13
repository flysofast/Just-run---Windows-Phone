using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using Map.Resources;
using Microsoft.Phone.Tasks;
using System.Windows.Threading;

namespace Map
{
    public partial class Welcome : PhoneApplicationPage
    {
        public Welcome()
        {
            InitializeComponent();
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            prgBar.IsIndeterminate = true;

            try
            {
                int launchCount = (int)IsolatedStorageSettings.ApplicationSettings["LaunchCount"];
                bool newRelease = (bool)IsolatedStorageSettings.ApplicationSettings["NewRelease"];
                if (newRelease)
                {
                    MessageBox.Show(AppResources.NewReleaseMsg, "Change logs", MessageBoxButton.OK);
                    IsolatedStorageSettings.ApplicationSettings["NewRelease"] = false;
                    IsolatedStorageSettings.ApplicationSettings["ReleaseCount"] = AppResources._ReleaseCount;
                    IsolatedStorageSettings.ApplicationSettings.Save();
                }
                
                if (launchCount % 3 == 0 && launchCount > 0 && !(bool)settings["Voted"] &&
                    MessageBox.Show(AppResources.RateMsg, "Rate & Review", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {

                    MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
                    marketplaceReviewTask.Show();
                    settings["Voted"] = true;
                }

                var _appSettings = (AppSettings)IsolatedStorageSettings.ApplicationSettings["AppSettings"];
                if (!_appSettings._EnableLocationAccess)
                    if (MessageBox.Show(AppResources.AllowLocationMsg, AppResources.Attention, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                        _appSettings._EnableLocationAccess = true;
                
                IsolatedStorageSettings.ApplicationSettings["LaunchCount"] = launchCount + 1;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            WebClient ReleaseCountRequest = new WebClient(); 
            ReleaseCountRequest.DownloadStringAsync(new Uri("http://justrun.comlu.com/ReleaseCount.php"));
            ReleaseCountRequest.DownloadStringCompleted += ReleaseCountRequest_DownloadStringCompleted;
        }
        void ReleaseCountRequest_DownloadStringCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                try
                {
                    string result = e.Result.ToString();
                    string startString = "<JustRunServerResponse>";
                    int start = result.IndexOf(startString) + startString.Length;
                    int length = result.IndexOf(("</JustRunServerResponse>")) - start;
                   
                    if (int.Parse(result.Substring(start, length)) > int.Parse(AppResources._ReleaseCount) && MessageBox.Show(AppResources.NewUpdateAvailableMsg, AppResources.NewUpdateAvailable, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();
                        marketplaceDetailTask.ContentIdentifier = "32718529-30bd-482c-b6e3-e876aba10a15";
                        marketplaceDetailTask.ContentType = MarketplaceContentType.Applications;
                        marketplaceDetailTask.Show();
                    }

                        //using (JustRunDataContext db = new JustRunDataContext(JustRunDataContext.ConnectionString))
                        //{
                        //    var q = db.UserDatas.First();
                        //    MessageBox.Show(q.Age.ToString());
                        //}
                        
                }
                catch
                {
                   
                }

               
            }

            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;


            if (!(bool)settings["FirstRunAndNotRegistered"])
            {
                if (settings.Contains("UserInfo"))
                {
                    var info = (User)settings["UserInfo"];
                    info.ToIsoDatabase();
                    settings.Remove("UserInfo");
                    settings.Save();
                }
                if (settings.Contains("RunData"))
                {
                    ARunData.ToIsoDatabase();
                    settings.Remove("RunData");
                    settings.Save();
                }
                // NavigationService.Navigate(new Uri("/UserInfo.xaml", UriKind.Relative));
                //Map.App.RootFrame.Navigate(new Uri("/ServerComTest.xaml", UriKind.Relative));
                // Map.App.RootFrame.Navigate(new Uri("/Musicpage.xaml", UriKind.Relative));
                NavigationService.Navigate(new Uri("/PivotMainPage.xaml", UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("/UserInfo.xaml", UriKind.Relative));
            }

        }
        

    }
}