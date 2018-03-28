using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace OurTasks
{
    public partial class App : Application
    {
        static MockDataStore dataStore;
        public static MockDataStore DataStore
        {
            get
            {
                if (dataStore == null)
                {
                    dataStore = new MockDataStore();
                }
                return dataStore;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ItemsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            App.DataStore.GenerateData();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
