using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

namespace ExpenseApp
{
    public partial class App : Application
    {
        public static string FolderPath { get; set; }
        enum ExpenseCategory { Housing = 0, Food = 1, Transportation = 2, Utilities = 3, Medical = 4, Others = 5 };
        public static string[] ExpenseCategoryString = { "Housing", "Food", "Transportation", "Utilities", "Medical", "Others" };
        public static string transaction_filemane;
        public static string budget_filename;
        public App()
        {
            InitializeComponent();
            FolderPath = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);
            transaction_filemane = Path.Combine(App.FolderPath, "transactions.txt");
            budget_filename = Path.Combine(App.FolderPath,
                    $"budget.txt");
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
