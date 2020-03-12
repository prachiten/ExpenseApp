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
        public ObservableCollection<Expense> expenses { get; private set; }
        TransactionPage transaction = new TransactionPage();
        public EntryPage()
        {
            InitializeComponent();
            
            BindingContext = viewModel;

            viewModel.Expenses = new ObservableCollection<Expense>();
            viewModel.Expenses.Add(new Expense
            {
                Name = "Housing",
                Image = "home.png"
            });
            viewModel.Expenses.Add(new Expense
            {
                Name = "Food",
                Image = "food.png"
            });
            viewModel.Expenses.Add(new Expense
            {
                Name = "Transportation",
                Image = "car.png"
            });
            viewModel.Expenses.Add(new Expense
            {
                Name = "Utilities",
                Image = "utilities.png"
            });
            viewModel.Expenses.Add(new Expense
            {
                Name = "Medical",
                Image = "medical.png"
            });
            viewModel.Expenses.Add(new Expense
            {
                Name = "Others",
                Image = "others.png"
            });

        }

        async protected override void OnAppearing()
        {
            
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
                viewModel.BudgetFilename = filename;
                viewModel.MonthlyPlan = float.Parse(File.ReadAllText(filename));
            }
            base.OnAppearing();

        }
        List<Transaction> transaction_list = new List<Transaction>();

        public double totalExpenseByMonthandEnvelop(string Envelope, string thisMonth)
        {
            //BindingContext= this;
            double total = 0.0;
            List<Transaction> transaction_list = App.ReadAllTransactions();
            foreach (var T in transaction_list)
            {
                if (string.Equals(T.getMonth(), thisMonth) && string.Equals(Envelope, T.Envelope))
                {
                    total += (double)T.Amount;
                }
            }
            return total;
        }

        public List<Transaction> transactionsByMonth(string thisMonth)
        {
            //BindingContext= this;
            List<Transaction> transaction_list = App.ReadAllTransactions();
            foreach (var T in transaction_list)
            {
                if (T.getMonth() == thisMonth)
                {

                }
            }
            return transaction_list;
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
            string month = P.SelectedItem.ToString();
            int i = 0;
            foreach (var E in App.ExpenseCategoryString)
            {
                var totalExpense = totalExpenseByMonthandEnvelop(E, month);
                viewModel.Expenses[i].TotalSpending = totalExpense.ToString();
                i++;
            }
        }
   

    // move it to Model > Expense.cs
     //public class Expense
     //{
     //   public string Name { get; set; }
     //   public string Image { get; set; }

     //   public override string ToString()
     //   {
     //       return Name;
     //   }


    }
}