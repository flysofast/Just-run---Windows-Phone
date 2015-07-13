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
using System.Collections.ObjectModel;

namespace Map
{
    public partial class Chart1 : PhoneApplicationPage
    {
        ObservableCollection<ChartDataContext> values = new ObservableCollection<ChartDataContext>();
        public Chart1()
        {
            InitializeComponent();

            values.Add(new ChartDataContext() { Label = "Sony", YValue = 50 });
            values.Add(new ChartDataContext() { Label = "Dell", YValue = 35 });
            values.Add(new ChartDataContext() { Label = "HP", YValue = 27 });
            values.Add(new ChartDataContext() { Label = "HCL", YValue = 17 });
            values.Add(new ChartDataContext() { Label = "Toshiba", YValue = 16 });
            values.Add(new ChartDataContext() { Label = "Toshiba", YValue = 16 });
            try
            {
                Chart.Series[0].DataSource = values;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

       

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotMainPage.xaml", UriKind.Relative));
            
        }
    }
}