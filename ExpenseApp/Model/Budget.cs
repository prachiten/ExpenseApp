using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExpenseApp.Model
{
    public class Budget : INotifyPropertyChanged
    {
        float monthlyPlan;

        float monthlyActual;

        float monthlyLeft;

        public string Filename { get; set; }
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

        public Budget()
        {

        }
        public virtual void OnPropertyChanged(string money)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(money));
        }
    }
}
