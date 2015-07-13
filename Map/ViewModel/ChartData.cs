using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Map
{
    class ChartData
    {
        public static ObservableCollection<ChartDataContext> GetChartData(DateTime datetime, string type, int dayNumber)
        {
            JustRunDataContext db = new JustRunDataContext(JustRunDataContext.ConnectionString);
            ObservableCollection<ChartDataContext> values = new ObservableCollection<ChartDataContext>();
            var RunDatas = new List<RunData>();

            foreach (var item in db.RunDatas)
            {
                var a = item;
                // MessageBox.Show(a.Datetime.ToString());
                a.Datetime = item.Datetime.Date;
                //MessageBox.Show(a.Datetime.ToString());
                RunDatas.Add(a);

            }
            //MessageBox.Show(datetime.AddDays(-dayNumber).ToString());
            var data = from p in RunDatas
                       where p.Datetime >= datetime.AddDays(-dayNumber) && p.Datetime <= datetime
                       group p by p.Datetime into g
                       select new
                       {
                           _dateTime = g.Key,
                           _burnedCalories = g.Sum(p => p.BurnedCalories),
                           _distance = g.Sum(p => p.Distance)
                       };
            if (type == "Calories")
                foreach (var item in data)
                {
                    // MessageBox.Show(item.ToString());
                    values.Add(new ChartDataContext(item._dateTime.ToShortDateString(), item._burnedCalories));
                }
            if (type == "Distance")
                foreach (var item in data)
                {
                    values.Add(new ChartDataContext(item._dateTime.ToShortDateString(), (double)item._distance));
                }
            return values;
        }

    }
}
