using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using ExpenseApp.Model;

namespace ExpenseApp
{
    public class EntryPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Expense> expenses { get; set; }
        float monthlyPlan;
        float monthlyActual;
        float monthlyLeft;

        public EntryPageViewModel()
        {
            expenses = new ObservableCollection<Expense>();
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
        }
        public string BudgetFilename { get; set; }
        public float MonthlyPlan
        {
            get => monthlyPlan;
            set
            {
                monthlyPlan = value;
                OnPropertyChanged(nameof(MonthlyPlan));
                monthlyLeft = monthlyPlan - monthlyActual;
                OnPropertyChanged(nameof(MonthlyLeft));
            }
        }
        public float MonthlyActual
        {
            get => monthlyActual;
            set
            {
                monthlyActual = value;
                OnPropertyChanged(nameof(MonthlyActual));
                monthlyLeft = monthlyPlan - monthlyActual;
                OnPropertyChanged(nameof(MonthlyLeft));
            }
        }

        public float MonthlyLeft
        {
            get => monthlyLeft;
            set
            {
                monthlyLeft = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string money)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(money));
        }

    }
}
