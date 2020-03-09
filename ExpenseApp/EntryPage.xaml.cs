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

            //BindingContext = this;
            
            
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
   

    // move it to Model > Expense.cs
     //public class Expense
     //{
     //   public string Name { get; set; }
     //   public string Image { get; set; }

     //   public override string ToString()
     //   {
     //       return Name;
     //   }


     //}
}