using Microsoft.Phone.Maps.Controls;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Map
{
    // [Serializable]
    [DataContract]

    public class ARunData
    {

        public ARunData()
        {
        }
        JustRunDataContext db = new JustRunDataContext(JustRunDataContext.ConnectionString);
        [DataMember]
        public GeoCoordinateCollection geoCollection = new GeoCoordinateCollection();
        [DataMember]
        public DateTime datetime { set; get; }
        [DataMember]
        public double BurnedCalories { set; get; }
        [DataMember]
        public string Duration { set; get; }
        [DataMember]
        public double AvgSpeed { set; get; }
        [DataMember]
        public double AvgPace { set; get; }
        [DataMember]
        public double Distance { set; get; }
        [DataMember]
        public int No { set; get; }
        [DataMember]
        public bool IsSynced { set; get; }

        public void Save()
        {
            try
            {
                int TimeCount = 0;
                string _duration;
                _duration = Regex.Replace(Duration, @"[^\d]", " ");
                _duration = Regex.Replace(_duration, @"\s+", " ");
                string[] time = _duration.Trim().Split(' ');
                for (int i = 0; i < 3; i++)
                {
                    int baseNum = i == 0 ? 3600 : i == 1 ? 60 : 1;
                    TimeCount += int.Parse(time[i]) * baseNum;
                }

                IsolatedStorageSettings data = IsolatedStorageSettings.ApplicationSettings;
                if (AvgSpeed == 0 || double.IsNaN(this.AvgSpeed))
                    if (TimeCount != 0)
                        AvgSpeed = (Distance / TimeCount) * 3.6;
                    else AvgSpeed = 0;

                if (AvgPace == 0 || double.IsNaN(this.AvgPace))
                    if (Distance != 0)
                        AvgPace = ((float)TimeCount / 60) / (Distance);
                    else
                        AvgPace = 0;
                if (double.IsNaN(this.BurnedCalories)) this.BurnedCalories = 0;
                if (double.IsNaN(this.Distance)) this.Distance = 0;

                RunData runData = new RunData();
                runData.AvgPace = AvgPace;
                runData.AvgSpeed = AvgSpeed;
                runData.BurnedCalories = BurnedCalories;
                runData.Datetime = datetime;
                runData.Distance = Distance;
                runData.Duration = Duration;
                db.RunDatas.InsertOnSubmit(runData);
                db.SubmitChanges();
                var max = db.RunDatas.Max(p => p.No);

                ARunData.ToGeoCordTable(geoCollection, max);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ToGeoCordTable(GeoCoordinateCollection geoCordCollection, int No)
        {
            using (JustRunDataContext db = new JustRunDataContext(JustRunDataContext.ConnectionString))
            {
                db.CreateIfNotExists();
                db.LogDebug = true;
                foreach (var _geoCord in geoCordCollection)
                {
                    GeoCord geoCord = new GeoCord();
                    geoCord.No = No;
                    geoCord.Latitude = _geoCord.Latitude;
                    geoCord.Longitude = _geoCord.Longitude;
                    db.GeoCords.InsertOnSubmit(geoCord);
                }
                db.SubmitChanges();
                
            }

        }
        public static void ToIsoDatabase()
        {
            try
            {
                JustRunDataContext db = new JustRunDataContext(JustRunDataContext.ConnectionString);
                db.CreateIfNotExists();
                db.LogDebug = true;

                var data = (List<ARunData>)IsolatedStorageSettings.ApplicationSettings["RunData"];

                foreach (var item in data)
                {
                    RunData runData = new RunData();
                    runData.Duration = item.Duration;
                    runData.Distance = item.Distance;
                    runData.AvgPace = item.AvgPace;
                    runData.AvgSpeed = item.AvgSpeed;
                    runData.BurnedCalories = item.BurnedCalories;
                    runData.Datetime = item.datetime;
                    db.RunDatas.InsertOnSubmit(runData);
                    db.SubmitChanges();
                    var max = db.RunDatas.Max(p => p.No);

                    ARunData.ToGeoCordTable(item.geoCollection, max);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

    }
}
