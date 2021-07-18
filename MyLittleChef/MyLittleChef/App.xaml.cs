using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyLittleChef.Services;
using MyLittleChef.Views;
using System.IO;

namespace MyLittleChef
{
    public partial class App : Application
    {
        static DBManager database;

        public static DBManager Database
        {
            get
            {
                if (database == null)
                {
                    database = new DBManager(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyLittleChefy.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
