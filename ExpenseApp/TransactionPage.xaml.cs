using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExpenseApp.Model;

namespace ExpenseApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionPage : ContentPage
    {

        public TransactionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public async void OnAddanotherExpense_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransactionPage
            {
                BindingContext = new Transaction()
            });
        }

        public async void OnSaveButton_Clicked_1(object sender, EventArgs e)
        {
            var T = (Transaction)BindingContext;
            if (Picker_E.SelectedItem==null)
            {
                await DisplayAlert("Alert", "Envelope not selected. Please select an envelope.", "OK");
                return;
            }
            T.Envelope = Picker_E.SelectedItem.ToString();
            if(T.Date == DateTime.MinValue )
            {
                T.Date = TransactionDatePicker.Date;
            }
            
            T.WriteToFile(App.transaction_filemane);
            //NavigationPage.CurrentPageProperty;
            await Navigation.PopAsync();
        }

       public async void OnCancelButton_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void TransactionDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var contents = BindingContext as Transaction;
            contents.Date = e.NewDate;
           // DateLabel.Text = e.NewDate.ToString();
        }
    }

}