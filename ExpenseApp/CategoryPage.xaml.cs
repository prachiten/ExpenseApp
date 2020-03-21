using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ExpenseApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        public ObservableCollection<Transaction> envelope_list;
        public ObservableCollection<Transaction> thisCategoryList;

        Transaction chosenItem;


            public CategoryPage(EntryPageViewModel viewModel, string selectedenvelope, string month)
            {
                InitializeComponent();
                BindingContext = viewModel;

                thisCategoryList = viewModel.envelope;
            listview.ItemsSource = thisCategoryList;
                 envelope_list = viewModel.transactions;
                ToolbarItem item1 = new ToolbarItem
                {
                    Text = selectedenvelope + "  Details",

                    Priority = 0,
                    Order = ToolbarItemOrder.Primary


                };
                ToolbarItem item2 = new ToolbarItem
                {

                    Text = month,
                    Priority = 0,
                    Order = ToolbarItemOrder.Primary


                };

                // "this" refers to a Page object
                ToolbarItems.Add(item1);
                ToolbarItems.Add(item2);
                BindingContext = viewModel;

                listview.ItemsSource = viewModel.envelope;


            }
        private void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
           // EntryPageViewModel.Deleteselectedtransaction(chosenItem, envelope_list);
           // EntryPageViewModel.Deleteselectedtransaction(chosenItem, thisCategoryList);

        }

        private void OnlistviewItemTapped(object sender, ItemTappedEventArgs e)
        {
            var val = sender as ListView;
            chosenItem = new Transaction();

            chosenItem = (Transaction) val.SelectedItem;
            

        }
    }

}
       
