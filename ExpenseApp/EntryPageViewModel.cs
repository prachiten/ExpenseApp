using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using ExpenseApp.Model;

namespace ExpenseApp
{
    public class EntryPageViewModel :INotifyPropertyChanged
    {
        public ObservableCollection<Expense> expenses { get; set; }
        public ObservableCollection<Transaction> transactions { get; set; }
        public Budget budget { get; set; }
        public int currentMonth { get; set; }

        public EntryPageViewModel()
        {
            var expenses = initExpenses();
        }
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
        public virtual void OnPropertyChanged(string money)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(money));
        }
        private List<Expense> initExpenses()
        {
            var expenses = new List<Expense>();
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
                Image = "others.png",
            });
            return expenses;
        }

        public void UpdateExpenses(ObservableCollection<Expense> expenses, int month, ObservableCollection<Transaction> transaction_list)
        {
            int i = 0;
            var defualtExpenses = initExpenses();
            double monthlySpending=0;
            foreach (var E in App.ExpenseCategoryString)
            {
                var totalExpense = totalExpenseByMonthandEnvelop(E, month, transaction_list);
                defualtExpenses[i].TotalSpending = totalExpense;
                monthlySpending += totalExpense;
                i++;
            }
            if(monthlySpending != MonthlyActual)
            {
                MonthlyActual = monthlySpending;
            }
            expenses.Clear();
            defualtExpenses.ForEach(e => expenses.Add(e));
        }

        public double totalExpenseByMonthandEnvelop(string Envelope, int thisMonth, ObservableCollection<Transaction> transaction_list)
        {
            //BindingContext= this;
            double total = 0.0;
            //ReadAllTransactions(transactions,transaction_filemane);
            foreach (var T in transaction_list)
            {
                if (T.getMonth()==thisMonth && string.Equals(Envelope, T.Envelope))
                {
                    total += (double)T.Amount;
                }
            }
            return total;
        }

        public static void ReadAllTransactions(ObservableCollection<Transaction> transaction_list, string filename)
        {

            string[] readText = File.ReadAllLines(filename);
            transaction_list.Clear();
            foreach (string row in readText)
            {
                Transaction T = new Transaction();
                T.ExtractFromFileRow(row);
                transaction_list.Add(T);
            }

        }
        public void transactionsByMonth(ObservableCollection<Transaction> transactions, int thisMonth)
        {
            foreach (var T in transactions)
            {
                if (T.getMonth() == thisMonth)
                {

                }
            }
            //return transaction_list;
        }

    }
}
