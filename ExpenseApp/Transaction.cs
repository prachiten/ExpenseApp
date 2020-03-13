using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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


        public int getMonth()
        {
            int month = Date.Month;

            return month;
        }

        //public void WriteToFile()
        //{
        //    //write to file
        //    string contents = DescriptionName + "," + Payee + "," + Amount + "," + Date + "," + Envelope + "," + Notes;
        //    File.AppendAllText(App.filename, contents + Environment.NewLine);
        //}

        public void WriteToFile(string filename)
        {
            //write to file
            string contents = DescriptionName + "," + Payee + "," + Amount + "," + Date + "," + Envelope + "," + Notes;
            File.AppendAllText(filename, contents + Environment.NewLine);
            
        }

        public void ExtractFromFileRow(string row)
        {
            //take file row as input and populate class variables
            string[] contents = row.Split(',');
            DescriptionName = contents[0];
            Payee = contents[1];
            Amount = Decimal.Parse(contents[2]);
            Date = DateTime.Parse(contents[3]);
            Envelope = contents[4];
            Notes = contents[5];
        }



    }


}
