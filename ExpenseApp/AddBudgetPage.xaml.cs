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
            TestButton.IsEnabled = File.Exists(App.budget_filename);
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var budget = (Budget)BindingContext;
            

            File.WriteAllText(App.budget_filename, budget.MonthlyPlan.ToString());

            await Navigation.PopAsync();
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void TestButton_Clicked(object sender, EventArgs e)
        {

            File.Delete(App.budget_filename);
            entry.Text = "";
            entry.Placeholder = "Please set the budget first";
            TestButton.IsEnabled = false;
        }
    }
}
