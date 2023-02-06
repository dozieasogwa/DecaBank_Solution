using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecaBankApp_Week_3_Task_.Core.Technicals;

namespace DecaBankApp_Week_3_Task_.Core.DecaBank.Model
{
    public class MenuOptions
    {
        public static string CreateAccountUI()
        {
            // variables required to create account
            var accountType = string.Empty;
            while (true)
            {
                Console.WriteLine("Select Account Type");
                var count = 1;
                foreach (var accType in Enum.GetNames(typeof(Utility.AccountType)))
                {
                    Console.WriteLine($"{count}: {accType}");
                    count++;
                }
                var response = Console.ReadLine();
                if (response == "1")
                {
                    accountType += Utility.AccountType.Savings;
                    break;
                }
                else if (response == "2")
                {
                    accountType += Utility.AccountType.Current;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
            }

            return accountType;

        }

        public static string TrasactionChannel()
        {
            var transactionChannelType = string.Empty;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Choose transaction channel: ");
                int count = 1;

                foreach (var transactionChannel in Enum.GetNames(typeof(Utility.TransactionDescription)))
                {
                    Console.WriteLine($"{count}: {transactionChannel}");
                    count++;
                }
                var response = Console.ReadLine();
                if (response == "1")
                {
                    transactionChannelType += Utility.TransactionDescription.POS;
                    break;
                }
                else if (response == "2")
                {
                    transactionChannelType += Utility.TransactionDescription.ATM;
                    break;
                }
                else if (response == "3")
                {
                    transactionChannelType += Utility.TransactionDescription.USSD;
                    break;
                }
               
                else
                {
                    Console.WriteLine("Invalid input. Please try again");
                    continue;
                }
            }
            return transactionChannelType;
        }

        //Algorithmn to generate customer account number.
        public static string GenerateAccountNumb()
        {
            var accountNumber = string.Empty;

            String startWith = "83";
            Random generator = new Random();
            String r = generator.Next(0, 999999).ToString("AG");
            accountNumber = startWith + r;

            return accountNumber;
        }
    }
}