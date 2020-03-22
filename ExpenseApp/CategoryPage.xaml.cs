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
        Transaction chosenitem;
        EntryPageViewModel obj;


        public CategoryPage(EntryPageViewModel viewModel, string selectedenvelope, string month)
        {
            InitializeComponent();
            BindingContext = viewModel;
            obj = viewModel;//since viewModel has scope only inside constructor bit we need viewModel obj outside constructor as well

            listview.ItemsSource = viewModel.envelope;
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
           // BindingContext = viewModel;

           // listview.ItemsSource = viewModel.envelope;


        }
        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                chosenitem = (Transaction)listview.SelectedItem;
            }

        }

        private void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
           
            obj.Deleteselectedtransaction(chosenitem, obj.transactions);
            //EntryPageViewModel.Deleteselectedtransaction(chosenitem, obj.envelope);


        }

    }
  }


