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


        //read each row in the file, create transaction object for each row content, return the list of all transaction objects

        //public static List<Transaction> ReadAllTransactions()
        //{
        //    List<Transaction> all_transactions = new List<Transaction>();
        //    string[] readText = File.ReadAllLines(filename);
        //    foreach (string row in readText)
        //    {
        //        Transaction T = new Transaction();
        //        T.ExtractFromFileRow(row);
        //        all_transactions.Add(T);

        //    }
        //    return all_transactions;
        //}


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
