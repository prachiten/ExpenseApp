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
        public List<Expense> expenses { get; private set; }
        public EntryPage()
        {
            InitializeComponent();
            BindingContext = budget;
            expenses = new List<Expense>();
            expenses.Add(new Expense
            {
                Name = "Housing",
                Image = "home.png"
            });
            expenses.Add(new Expense
            {
                Name = "Food",
                Image = "food.png"
            });
            expenses.Add(new Expense
            {
                Name = "Transportation",
                Image = "car.png"
            });
            expenses.Add(new Expense
            {
                Name = "Utilities",
                Image = "utilities.png"
            });
            expenses.Add(new Expense
            {
                Name = "Medical",
                Image = "medical.png"
            });
            expenses.Add(new Expense
            {
                Name = "Others",
                Image = "others.png"
            });
            BindingContext = this;
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

    private void OnAddButton_Clicked(object sender, EventArgs e)
    {

    }
  }
   

    
     public class Expense
     {
        public string Name { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return Name;
        }


     }
}