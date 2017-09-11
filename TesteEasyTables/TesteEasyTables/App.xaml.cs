using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TesteEasyTables
{
    public partial class App : Application
    {
      //  public static MobileServiceClient MobileService = new MobileServiceClient("http://pedro1teste.azurewebsites.net");
        public App()
        {
            InitializeComponent();

            MainPage = new TesteEasyTables.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
