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

        public CategoryPage(EntryPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

            listview.ItemsSource = viewModel.envelope;


        }
        ListView HeaderList = new ListView()
        {
            Header = "Header",
        };
    }
}