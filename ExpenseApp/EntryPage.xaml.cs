using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        Budget budget = new Budget();
        public EntryPage()
        {
            InitializeComponent();
            BindingContext = budget;
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();


            var filename = Path.Combine(App.FolderPath,
                    $"budget.txt");
            var hasBudget = File.Exists(filename);

            // if budget file has not been created yet, we shoud input budget first
            if (!hasBudget)
            {
                //await Navigation.PushAsync(new AddBudgetPage
                //{
                //    BindingContext = new Budget()
                //});
                // TBD this dosen't work
            }
            // else we can just read the budget from the budget file
            else
            {
                budget.Filename = filename;
                budget.MonthlyPlan = float.Parse(File.ReadAllText(filename));
            }

        }

        async void OnBudgetAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBudgetPage
            {
                BindingContext = new Budget()
            });
        }
    }
}