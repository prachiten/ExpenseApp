using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ExpenseApp.Model
{
    public class Budget : INotifyPropertyChanged
    {
        double monthlyPlan;

        double monthlyActual;

        double monthlyLeft;

        public double MonthlyPlan
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
        public double MonthlyActual
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

        public double MonthlyLeft
        {
            get => monthlyLeft;
            set
            {
                monthlyLeft = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Budget()
        {
            if (File.Exists(App.budget_filename))
            {
                monthlyPlan = float.Parse(File.ReadAllText(App.budget_filename));
            }
            
        }
        public virtual void OnPropertyChanged(string money)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(money));
        }
    }
}
