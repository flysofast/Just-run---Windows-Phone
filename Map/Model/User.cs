
using System.Linq;

using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using Map.Resources;
using System.Windows;
using System;

namespace Map
{
    [DataContract]
    public class User
    {
        [DataMember]
        public  int age;

        [DataMember]
        public  double weight;

        [DataMember]
        public  double grade;

        [DataMember]
        public bool? gender;
        
        public User()
        {
            grade = 0.02;
            weight = 60;
        }
        public User(int a, double w, double g, bool? s)
        {
            if (g > 100 || g < 0)
            {
                MessageBox.Show(AppResources.InvalidUserInfo,"Warning",MessageBoxButton.OK);
                return;
            }
            age = a;
            weight = w;
            grade = g;
            gender = s;
        }
        public void ToIsoDatabase()
        {
            try
            {
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                using (JustRunDataContext db = new JustRunDataContext(JustRunDataContext.ConnectionString))
                {
                    db.CreateIfNotExists();
                    db.LogDebug = true;
                    var info = (User)settings["UserInfo"];
                    UserData a = new UserData();
                    a.Age = info.age;
                    a.Gender = info.gender;
                    a.Grade = info.grade;
                    a.Weight = info.weight;
                    db.UserDatas.InsertOnSubmit(a);
                    
                    db.SubmitChanges();
                    
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
       
    }
}
