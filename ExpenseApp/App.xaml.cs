using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseApp
{
    public partial class App : Application
    {
        public static string FolderPath { get; set; }
        public App()
        {
            InitializeComponent();
            FolderPath = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);
            MainPage = new NavigationPage(new EntryPage());
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
