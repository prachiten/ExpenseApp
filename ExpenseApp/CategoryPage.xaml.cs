using System;
using System.Collections.Generic;
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
        public CategoryPage()
        {
            var viewmodel1 = new EntryPageViewModel();
            InitializeComponent();
            this.BindingContext = new EntryPageViewModel();
            listview.ItemsSource = viewmodel1.envelope;
        }
    }
}