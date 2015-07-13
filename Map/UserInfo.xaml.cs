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
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Map
{
    public partial class UserInfo : PhoneApplicationPage
    {
        UserData user = new UserData();
        JustRunDataContext db = new JustRunDataContext(JustRunDataContext.ConnectionString);
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        public UserInfo()
        {
            InitializeComponent();
            if ((bool)settings["FirstRunAndNotRegistered"])
            {
                MessageBox.Show(AppResources.FirstRegMsg);
                settings["FirstRunAndNotRegistered"] = false;
                settings.Save();
            }


            user = db.UserDatas.First();


            tbAge.Text = user.Age.ToString();

            tbGrade.Text = (user.Grade * 100).ToString();

            tbWeight.Text = user.Weight.ToString();
            tbHeight.Text = user.Height.ToString();

            if (user.Gender == null)
                lpGender.SelectedIndex = 2;
            else
                lpGender.SelectedIndex = user.Gender == true ? 0 : 1;



            if (db.RunDatas.Count() == 0)
            {
                tbLastRun.Text = AppResources.YourLastRun + "--";
                tbAvgSpeed.Text = AppResources.AvgSpeed + "--";
                tbTotalCalories.Text = AppResources.TotalCalories + "--";
                tbTotalDistance.Text = AppResources.TotalDistance + "--";
                tbTotalDuration.Text = AppResources.TotalDuration + "--";
                tbAvgPace.Text = AppResources.AvgPace + "--";
                return;
            }

            var data = db.RunDatas;

            Update(data);
        }

        private void BuildApplicationBar(byte type)
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            try
            {
                ApplicationBar = new ApplicationBar();
                ApplicationBar.Opacity = 0.6;

                ApplicationBar.BackgroundColor = Color.FromArgb(255, 10, 50, 91);
                // Create a new button and set the text value to the localized string from AppResources.
                if (type == 0)
                {
                    ApplicationBarIconButton btSave = new ApplicationBarIconButton(new Uri("/Assets/AppBar/check.png", UriKind.Relative));
                    btSave.Text = AppResources.Save;
                    btSave.Click += btSave_Click;
                    ApplicationBar.Buttons.Add(btSave);

                    ApplicationBarIconButton btCancel = new ApplicationBarIconButton(new Uri("/Assets/AppBar/cancel.png", UriKind.Relative));
                    btCancel.Text = AppResources.Cancel;
                    btCancel.Click += btCancel_Click;
                    ApplicationBar.Buttons.Add(btCancel);

                    ApplicationBarIconButton btRefresh = new ApplicationBarIconButton(new Uri("/Assets/AppBar/refresh.png", UriKind.Relative));
                    btRefresh.Text = AppResources.Refresh;
                    btRefresh.Click += btRefresh_Click;
                    ApplicationBar.Buttons.Add(btRefresh);


                }
                if (type == 1)
                {
                    ApplicationBarIconButton btTotal = new ApplicationBarIconButton(new Uri("/Assets/AppBar/all.png", UriKind.Relative));
                    btTotal.Text = AppResources.Total;
                    btTotal.Click += btTotal_Click;
                    ApplicationBar.Buttons.Add(btTotal);

                    ApplicationBarIconButton btWeek = new ApplicationBarIconButton(new Uri("/Assets/AppBar/week.png", UriKind.Relative));
                    btWeek.Text = AppResources.Week;
                    btWeek.Click += btWeek_Click;
                    ApplicationBar.Buttons.Add(btWeek);

                    ApplicationBarIconButton btMonth = new ApplicationBarIconButton(new Uri("/Assets/AppBar/month.png", UriKind.Relative));
                    btMonth.Text = AppResources.Month;
                    btMonth.Click += btMonth_Click;
                    ApplicationBar.Buttons.Add(btMonth);

                    ApplicationBarIconButton btYear = new ApplicationBarIconButton(new Uri("/Assets/AppBar/year.png", UriKind.Relative));
                    btYear.Text = AppResources.Year;
                    btYear.Click += btYear_Click;
                    ApplicationBar.Buttons.Add(btYear);
                }

                if (type == 2)
                {

                    ApplicationBarIconButton btWeek = new ApplicationBarIconButton(new Uri("/Assets/AppBar/week.png", UriKind.Relative));
                    btWeek.Text = AppResources.Week;
                    btWeek.Click += btWeekChart_Click;
                    ApplicationBar.Buttons.Add(btWeek);

                    ApplicationBarIconButton btMonth = new ApplicationBarIconButton(new Uri("/Assets/AppBar/month.png", UriKind.Relative));
                    btMonth.Text = AppResources.Month;
                    btMonth.Click += btMonthChart_Click;
                    ApplicationBar.Buttons.Add(btMonth);


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            BMICalculate(ref tbStatus);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else NavigationService.Navigate(new Uri("/PivotMainPage.xaml", UriKind.Relative));
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                prgBar.IsIndeterminate = true;
                prgBar.Visibility = Visibility.Visible;
                Rec.Visibility = Visibility.Visible;

                bool? gender;
                if (lpGender.SelectedIndex == 2)
                    gender = null;
                else
                    gender = lpGender.SelectedIndex == 0 ? true : false;

                // User user = new User(int.Parse(tbAge.Text), double.Parse(tbWeight.Text), double.Parse(tbGrade.Text) / 100, gender);

                var user = db.UserDatas.First();
                user.Age = int.Parse(tbAge.Text);
                user.Weight = double.Parse(tbWeight.Text);
                user.Grade = double.Parse(tbGrade.Text) / 100;
                user.Gender = gender;
                if (tbHeight.Text != "")
                    user.Height = double.Parse(tbHeight.Text);
                db.SubmitChanges();

                if (NavigationService.CanGoBack)
                    NavigationService.GoBack();
                else
                    NavigationService.Navigate(new Uri("/PivotMainPage.xaml", UriKind.Relative));

            }
            catch
            {
                MessageBox.Show(AppResources.InvalidUserInfo, "Warning", MessageBoxButton.OK);
                return;
            }
        }





        void btYear_Click(object sender, EventArgs e)
        {
            if (db.RunDatas.Count() == 0) return;
            try
            {
                Calendar cal = DateTimeFormatInfo.CurrentInfo.Calendar;
                int yearNo = cal.GetYear(DateTime.Now);
                List<RunData> data = new List<RunData>();
                foreach (var p in db.RunDatas)
                {
                    if (cal.GetYear(p.Datetime) == yearNo)
                        data.Add(p);
                }
                Update(data);

            }
            catch
            {

                MessageBox.Show(AppResources.NoDataMsg);
            }

        }

        void btMonth_Click(object sender, EventArgs e)
        {
            if (db.RunDatas.Count() == 0) return;
            try
            {

                Calendar cal = DateTimeFormatInfo.CurrentInfo.Calendar;
                int monthNo = cal.GetMonth(DateTime.Now);
                List<RunData> data = new List<RunData>();
                foreach (var p in db.RunDatas)
                {
                    if (cal.GetMonth(p.Datetime) == monthNo)
                        data.Add(p);
                }
                Update(data);
            }
            catch 
            {

                MessageBox.Show(AppResources.NoDataMsg);
            }

        }

        void btWeek_Click(object sender, EventArgs e)
        {
            if (db.RunDatas.Count() == 0) return;
            try
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                Calendar cal = dfi.Calendar;
                int weekNo = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                List<RunData> data = new List<RunData>();
                foreach (var p in db.RunDatas)
                {
                    if (cal.GetWeekOfYear(p.Datetime, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) == weekNo)
                        data.Add(p);
                }
                Update(data);
            }
            catch
            {

                MessageBox.Show(AppResources.NoDataMsg);
            }

        }

        void btTotal_Click(object sender, EventArgs e)
        {
            if (db.RunDatas.Count() == 0) return;
            var data = db.RunDatas;
            Update(data);
        }

        private void Update(IEnumerable<RunData> data)
        {
            tbTotalCalories.Text = string.Format("{0}{1:0.##} cal", AppResources.TotalCalories, data.Sum(p => p.BurnedCalories));
            tbAvgSpeed.Text = string.Format("{0}{1:0.##} km/h", AppResources.AvgSpeed, data.Average(p => p.AvgSpeed));
            tbTotalDistance.Text = string.Format("{0}{1:0.##} km", AppResources.TotalDistance, data.Sum(p => p.Distance));
            tbTotalDuration.Text = AppResources.TotalDuration + getDurationString(data);
            tbAvgPace.Text = string.Format("{0}{1:0.##} min/km", AppResources.AvgPace, data.Average(p => p.AvgPace));

        }
        private string getDurationString(IEnumerable<RunData> data)
        {
            int result = 0;
            foreach (var run in data)
            {
                string duration = run.Duration;
                duration = Regex.Replace(duration, @"[^\d]", " ");
                duration = Regex.Replace(duration, @"\s+", " ");
                string[] time = duration.Trim().Split(' ');
                for (int i = 0; i < 3; i++)
                {
                    int baseNum = i == 0 ? 3600 : i == 1 ? 60 : 1;
                    result += int.Parse(time[i]) * baseNum;
                }
            }
            return string.Format("{0}h {1}m {2}s", result / 3600, (result / 60) % 60, result % 60);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try
            {
                if (db.RunDatas.Count() != 0)
                {

                    var lastRun = db.RunDatas.Max(p => p.Datetime);
                    tbLastRun.Text = AppResources.YourLastRun + lastRun.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch ((sender as Pivot).SelectedIndex)
                {
                    case 0:
                        // this.ApplicationBar = AppBar1;
                        {
                            BuildApplicationBar(0);
                            BMICalculate(ref tbStatus);
                        }
                        break;
                    case 1:
                        {
                            BuildApplicationBar(1);
                        }
                        break;
                    case 2:
                        {
                            BuildApplicationBar(2);
                            DoGraphPivotItem();
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        void DoGraphPivotItem()
        {

            try
            {
                Chart.Series[0].DataSource = ChartData.GetChartData(DateTime.Now, "Calories", 7);
                tbDistance.Foreground = new SolidColorBrush(Colors.White);
                tbCalories.Foreground = new SolidColorBrush((App.Current.Resources["PhoneAccentBrush"] as SolidColorBrush).Color);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        byte type = 1;
        private void tbDistance_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            type = 2;
            Chart.Series[0].DataSource = ChartData.GetChartData(DateTime.Now, "Distance", 7);
            tbDistance.Foreground = new SolidColorBrush((App.Current.Resources["PhoneAccentBrush"] as SolidColorBrush).Color);
            tbCalories.Foreground = new SolidColorBrush(Colors.White);
        }

        private void tbCalories_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            type = 1;
            Chart.Series[0].DataSource = ChartData.GetChartData(DateTime.Now, "Calories", 7);
            tbDistance.Foreground = new SolidColorBrush(Colors.White);
            tbCalories.Foreground = new SolidColorBrush((App.Current.Resources["PhoneAccentBrush"] as SolidColorBrush).Color);
        }

        private void btMonthChart_Click(object sender, EventArgs e)
        {
            if (type == 1)
                Chart.Series[0].DataSource = ChartData.GetChartData(DateTime.Now, "Calories", 30);
            if (type == 2)
                Chart.Series[0].DataSource = ChartData.GetChartData(DateTime.Now, "Distance", 30);
        }

        private void btWeekChart_Click(object sender, EventArgs e)
        {
            if (type == 1)
                Chart.Series[0].DataSource = ChartData.GetChartData(DateTime.Now, "Calories", 7);
            if (type == 2)
                Chart.Series[0].DataSource = ChartData.GetChartData(DateTime.Now, "Distance", 7);
        }


        void BMICalculate(ref TextBlock tb)
        {

            try
            {
                int age = int.Parse(tbAge.Text);
                double weight = double.Parse(tbWeight.Text);
                double height = double.Parse(tbHeight.Text);
                bool? gender;
                if (lpGender.SelectedIndex == 2)
                    gender = null;
                else
                    gender = lpGender.SelectedIndex == 0 ? true : false;
                double BMI = weight / ((height / 100) * (height / 100));

                if (BMI < 18.5)
                {
                    tb.Text = AppResources.UnderWeight;
                    tb.Foreground = new SolidColorBrush(Colors.Cyan);
                }
                if (BMI >= 18.5 && BMI < 25)
                {
                    tb.Text = AppResources.Normal;
                    tb.Foreground = new SolidColorBrush(Colors.Green);
                }
                if (BMI >= 25 && BMI < 30)
                {
                    tb.Text = AppResources.OverWeight;
                    tb.Foreground = new SolidColorBrush(Colors.Orange);
                }
                if (BMI >= 30)
                {
                    tb.Text = AppResources.Obesity;
                    tb.Foreground = new SolidColorBrush(Colors.Red);
                }

            }
            catch
            {

                tb.Text = AppResources.Unknown;
                tb.Foreground = new SolidColorBrush(Colors.DarkGray);
            }



        }
    }
}