using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Defining the constant  variable
namespace DecaBankApp_Week_3_Task_.Core.Technicals
{
  public class Utility
    {
        public enum AccountType
        {
            Savings,
            Current
        }

        public enum TransactionType
        {
            Cr,
            Dr
        }

        public enum TransactionDescription
        {
            POS,
            ATM,
            USSD,
        }

        public static string GenerateAccountNumber()
        {
            var accountNumber = string.Empty;

            String startWith = "098";
            Random generator = new Random();
            String r = generator.Next(0, 999999).ToString("AG");
            accountNumber = startWith + r;

            return accountNumber;
        }
    }
}

