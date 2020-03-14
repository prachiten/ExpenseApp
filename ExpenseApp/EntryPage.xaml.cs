using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace ExpenseApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {

        EntryPageViewModel viewModel = new EntryPageViewModel();
        
        public EntryPage()
        {
            InitializeComponent();
            BindingContext = viewModel;

            viewModel.currentMonth = DateTime.Now.Month;
            viewModel.expenses = new ObservableCollection<Expense>();
            viewModel.transactions = new ObservableCollection<Transaction>();
            listview.ItemsSource = viewModel.expenses;
        }

        async protected override void OnAppearing()
        {
            var hasBudget = File.Exists(App.budget_filename);
            var hasTransaction = File.Exists(App.transaction_filemane);

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
                viewModel.MonthlyPlan = float.Parse(File.ReadAllText(App.budget_filename));
                //below is to test popup page
                //File.Delete(App.budget_filename);
            }

            if (!hasTransaction)
            {
                File.Create(App.transaction_filemane);
            }else
            {
                //read transactions
                EntryPageViewModel.ReadAllTransactions(viewModel.transactions, App.transaction_filemane);
                viewModel.UpdateExpenses(viewModel.expenses, viewModel.currentMonth, viewModel.transactions);
            }

            MonthPicker.SelectedIndex = viewModel.currentMonth - 1;
            base.OnAppearing();
        }

        async void OnBudgetAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBudgetPage
            {
                BindingContext = new Budget()
            });
        }
        
    private void OnSetButton_Clicked(object sender, EventArgs e)
    {

    }


    void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //Expense selectedItem = e.SelectedItem as Expense;
    }

    void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
    {
        //Expense tappedItem = e.Item as Expense;
    }

    async void OnAddButton_Clicked(object sender, EventArgs e)
      {
          await Navigation.PushAsync(new TransactionPage
            {
                BindingContext = new Transaction()
            });
     }

        private void MonthPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var P = sender as Picker;
            int month = P.SelectedIndex+1;
            viewModel.UpdateExpenses(viewModel.expenses,month, viewModel.transactions);
        }

        private async void Button1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransportationPage());
        }
    }
}