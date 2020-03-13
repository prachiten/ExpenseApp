using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseApp.Model
{
    public class Expense
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double TotalSpending { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
