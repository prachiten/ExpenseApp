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
        
        public CategoryPage(EntryPageViewModel viewModel, string selectedenvelope,string month)
        {
            InitializeComponent();
            ToolbarItem item1 = new ToolbarItem
            {
                Text = selectedenvelope,
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
        




    }
}