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
        private ObservableCollection<Expense> _expenses;
        float monthlyPlan;
        float monthlyActual;
        float monthlyLeft;

        public ObservableCollection<Expense> Expenses
        {
            get => _expenses;
            set
            {
                if(_expenses != value)
                {
                    _expenses = value;
                    OnPropertyChanged(nameof(Expenses));
                }
            }
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

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
