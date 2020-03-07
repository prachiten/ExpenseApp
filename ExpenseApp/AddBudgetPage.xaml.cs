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
    public partial class AddBudgetPage : ContentPage
    {
        public AddBudgetPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var budget = (Budget)BindingContext;
            if (string.IsNullOrWhiteSpace(budget.Filename))
            {
                var filename = Path.Combine(App.FolderPath,
                    $"budget.txt");
                File.WriteAllText(filename, budget.MonthlyPlan.ToString());
            }
            else
            {
                File.WriteAllText(budget.Filename, budget.MonthlyPlan.ToString());
            }
            await Navigation.PopAsync();
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
