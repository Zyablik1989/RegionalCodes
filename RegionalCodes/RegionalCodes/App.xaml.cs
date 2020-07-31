using RegionalCodes.Managers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegionalCodes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RegionalCodesManager.FillRegionalCodes();
            RegionalCodesManager.FillCodesForDictionary();
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
