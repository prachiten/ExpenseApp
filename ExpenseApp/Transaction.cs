using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;

namespace ExpenseApp
{
    public class Transaction
    {
        public string DescriptionName { get; set; }
        public string Payee { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Envelope { get; set; }
        public string Notes { get; set; }
        public string Filename { get; set;}
        public Guid guid { get; set; }
        EntryPageViewModel viewmodel1 = new EntryPageViewModel();

        public int getMonth()
        {
            int month = Date.Month;

            return month;
        }
        public DateTime getDate(DateTime date)
        {
            date = Date.Date;

            return date;
        }
        public string getguid( string dataguid)
        {
            dataguid = guid.ToString();
            return dataguid;
        }



        public void WriteToFile(string filename)
        {
            //write to file
            string contents = DescriptionName + "," + Payee + "," + Amount + "," + getDate(Date) + "," + Envelope + "," + Notes;
            //Transaction newTransaction = new Transaction();
            /*newTransaction.DescriptionName = DescriptionName;
            newTransaction.Payee = Payee;
            newTransaction.Amount = Amount;
            newTransaction.Date = getDate(Date);
            newTransaction.Envelope = Envelope;
            newTransaction.Notes = Notes;

            bool Found = false;
            foreach (var t in viewmodel1.transactions)
            {
                if (newTransaction.Match(t))
                {
                    Found = true;
                }
            }

            if (Found == false)*/
         File.AppendAllText(filename, contents + Environment.NewLine);
            
        }

        public void ExtractFromFileRow(string row)
        {
            //take file row as input and populate class variables
            string[] contents = row.Split(',');
            DescriptionName = contents[0];
            Payee = contents[1];
            Amount = Decimal.Parse(contents[2]);
            Date = DateTime.Parse((contents[3])).Date;  
            Envelope = contents[4];
            Notes = contents[5];
        }

       public bool Match(Transaction toCompare)
        {
            

            if (string.Equals(toCompare.DescriptionName, DescriptionName) == false)
            {
                return false;
            }
            if (string.Equals(toCompare.Payee, Payee) == false)
            {
                return false;
            }
            if (string.Equals(toCompare.Envelope, Envelope) == false)
            {
                return false;
            }
            if (string.Equals(toCompare.Notes, Notes) == false)
            {
                return false;
            }
            if (DateTime.Equals(toCompare.Date, Date) == false)
            {
                return false;
            }
            if (toCompare.Amount != Amount)
            {
                return false;
            }

            return true;
        }
    }
}
