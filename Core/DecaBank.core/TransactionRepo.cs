﻿using DecaBankApp_Week_3_Task_.Core.DecaBank.Data;
using DecaBankApp_Week_3_Task_.Core.DecaBank.Model;
using DecaBankApp_Week_3_Task_.Core.Technicals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecaBankApp_Week_3_Task_.Core.DecaBank.core
{
    public class TransactionRepo
    {
        /// <summary>
        /// Add money to customer account using specified Id
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public string MakeDeposit(double amount, string accountNumber, string description)
        {
            var message = string.Empty;
            var previousTransactionCount = DataStore.TransactionHistoryTable.Count;
            var newTransaction = new TransactionHistory();

            foreach (var account in DataStore.AccountTable)
            {
                if (account.AccountNumber == accountNumber && amount > 0)
                {
                    //newTransaction.Id = transactionCount;
                    newTransaction.AccountId = account.Id;
                    newTransaction.Amount = amount;
                    newTransaction.Description = description;
                    newTransaction.Sender = account.AccountName;
                    newTransaction.TransactionType = Utility.TransactionType.Cr.ToString();
                    account.AccountBalance += amount;
                    newTransaction.Balance = account.AccountBalance;
                    account.TransactionHistory.Add(newTransaction);
                    //transactionCount++;
                }
            }
            DataStore.TransactionHistoryTable.Add(newTransaction);

            int updatedTransactionCount = DataStore.TransactionHistoryTable.Count;

            if (updatedTransactionCount > previousTransactionCount)
                message += "Transaction Succesful";

            else
            {
                message += "Transaction Failed";
            }

            return message;
        }

        /// <summary>
        /// Sends specified amount to another customer account
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="accountId"></param>
        /// <param name="receiverAccountNumber"></param>
        /// <param name="receiverAccountName"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public string SendMoney(double amount, int accountId, string receiverAccountNumber, string description)
        {
            var message = string.Empty;
            var previousTransactionCount = DataStore.TransactionHistoryTable.Count;
            var newTransaction = new TransactionHistory();
            var receiverTransaction = new TransactionHistory();

            foreach (var account in DataStore.AccountTable)
            {
                if (account.Id == accountId)
                {
                    if (account.AccountType == Utility.AccountType.Current.ToString() && account.AccountBalance >= amount) //Current account holder can empty their account
                    {
                        //newTransaction.Id = transactionCount;
                        newTransaction.AccountId = accountId;
                        newTransaction.Amount = amount;
                        newTransaction.Sender = account.AccountName;
                        newTransaction.ReceiverAccountNumber = receiverAccountNumber;
                        newTransaction.Description = description;
                        newTransaction.TransactionType = Utility.TransactionType.Dr.ToString();
                        account.AccountBalance -= amount;
                        newTransaction.Balance = account.AccountBalance;
                        account.TransactionHistory.Add(newTransaction);
                        //transactionCount++;
                    }
                    //Savings account holders must maintain a minimum balance of N1000
                    else if (account.AccountType == Utility.AccountType.Savings.ToString() && account.AccountBalance > amount + 1000)
                    {
                        //newTransaction.Id = transactionCount;
                        newTransaction.AccountId = accountId;
                        newTransaction.Amount = amount;
                        newTransaction.Sender = account.AccountName;
                        newTransaction.ReceiverAccountNumber = receiverAccountNumber;
                        newTransaction.Description = description;
                        newTransaction.TransactionType = Utility.TransactionType.Dr.ToString();
                        account.AccountBalance -= amount;
                        newTransaction.Balance = account.AccountBalance;
                        account.TransactionHistory.Add(newTransaction);
                        //transactionCount++;
                    }
                    else
                        return "Insufficient Funds.";

                }
            }

            //Credit recieving account
            foreach (var account in DataStore.AccountTable)
            {
                if (account.AccountNumber == receiverAccountNumber)
                {
                    //receiverTransaction.Id = transactionCount;
                    receiverTransaction.Amount = amount;
                    receiverTransaction.Description = description;
                    receiverTransaction.Sender = newTransaction.Sender;
                    receiverTransaction.TransactionType = Utility.TransactionType.Cr.ToString();
                    account.AccountBalance += amount;
                    receiverTransaction.Balance = account.AccountBalance;
                    account.TransactionHistory.Add(receiverTransaction);
                    //transactionCount++;
                }
            }

            DataStore.TransactionHistoryTable.Add(newTransaction);
            int updatedTransactionCount = DataStore.TransactionHistoryTable.Count;

            if (updatedTransactionCount > previousTransactionCount)
                message += "Transaction Succesful";

            else
            {
                message += "Transaction Failed";
            }
            return message;
        }

        /// <summary>
        /// Transfer money between customer accounts
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="accountId"></param>
        /// <param name="otherAccountId"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public string TransferToOtherAccount(double amount, int accountId, int otherAccountId, string accountDescription, string otherDescription)
        {
            var message = string.Empty;
            var previousTransactionCount = DataStore.TransactionHistoryTable.Count;
            var newTransaction = new TransactionHistory();
            var receiverTransaction = new TransactionHistory();

            //Debit sending account
            foreach (var account in DataStore.AccountTable)
            {
                if (account.Id == accountId)
                {
                    if (account.AccountType == Utility.AccountType.Current.ToString() && account.AccountBalance >= amount) //Current account holder can empty their account
                    {
                        //newTransaction.Id = transactionCount;
                        newTransaction.AccountId = accountId;
                        newTransaction.Amount = amount;
                        newTransaction.Sender = account.AccountNumber;
                        newTransaction.Description = accountDescription;
                        newTransaction.TransactionType = Utility.TransactionType.Dr.ToString();
                        account.AccountBalance -= amount;
                        newTransaction.Balance = account.AccountBalance;
                        account.TransactionHistory.Add(newTransaction);
                        //transactionCount++;
                    }
                    //Savings account holders must maintain a minimum balance of N1000
                    else if (account.AccountType == Utility.AccountType.Savings.ToString() && account.AccountBalance > amount + 1000)
                    {
                        //newTransaction.Id = transactionCount;
                        newTransaction.AccountId = accountId;
                        newTransaction.Amount = amount;
                        newTransaction.Sender = account.AccountName;
                        newTransaction.Description = accountDescription;
                        newTransaction.TransactionType = Utility.TransactionType.Dr.ToString();
                        account.AccountBalance -= amount;
                        newTransaction.Balance = account.AccountBalance;
                        account.TransactionHistory.Add(newTransaction);
                        //transactionCount++;
                    }
                    else
                        return "Insufficient Funds.";

                }
            }

            //Credit recieving account
            foreach (var account in DataStore.AccountTable)
            {
                if (account.Id == otherAccountId)
                {
                    //receiverTransaction.Id = transactionCount;
                    receiverTransaction.AccountId = otherAccountId;
                    receiverTransaction.Amount = amount;
                    receiverTransaction.Description = otherDescription;
                    receiverTransaction.Sender = account.AccountName;
                    receiverTransaction.TransactionType = Utility.TransactionType.Cr.ToString();
                    account.AccountBalance += amount;
                    receiverTransaction.Balance = account.AccountBalance;
                    account.TransactionHistory.Add(receiverTransaction);
                    //transactionCount++;
                }
            }

            //Add record to transferring account
            DataStore.TransactionHistoryTable.Add(newTransaction);
            //Add record to receiving account
            DataStore.TransactionHistoryTable.Add(receiverTransaction);

            int updatedTransactionCount = DataStore.TransactionHistoryTable.Count;

            if (updatedTransactionCount > previousTransactionCount)
                message += "Transaction Succesful";

            else
            {
                message += "Transaction Failed";
            }
            return message;

        }
        /// <summary>
        /// Withdraws the amount out of the specified customer account.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="accountId"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public string MakeWithdrawal(double amount, int accountId, string description)
        {
            var message = string.Empty;

            var previousTransactionCount = DataStore.TransactionHistoryTable.Count;
            var newTransaction = new TransactionHistory();

            foreach (var account in DataStore.AccountTable)
            {
                if (account.Id == accountId)
                {
                    if (account.AccountType == Utility.AccountType.Current.ToString() && account.AccountBalance >= amount)
                    {
                        //newTransaction.Id = transactionCount;
                        newTransaction.AccountId = accountId;
                        newTransaction.Amount = amount;
                        newTransaction.Description = description;
                        newTransaction.TransactionType = Utility.TransactionType.Dr.ToString();
                        account.AccountBalance -= amount;
                        newTransaction.Balance = account.AccountBalance;
                        account.TransactionHistory.Add(newTransaction);
                        //transactionCount++;
                    }
                    else if (account.AccountType == Utility.AccountType.Savings.ToString() && account.AccountBalance > (amount + 1000))
                    {
                        //newTransaction.Id = transactionCount;
                        newTransaction.AccountId = accountId;
                        newTransaction.Amount = amount;
                        newTransaction.Description = description;
                        newTransaction.TransactionType = Utility.TransactionType.Dr.ToString();
                        // implement pin for security
                        account.AccountBalance -= amount;
                        newTransaction.Balance = account.AccountBalance;
                        account.TransactionHistory.Add(newTransaction);
                        //transactionCount++;
                    }
                    else
                        return "Insufficient Funds.";


                }
            }
            DataStore.TransactionHistoryTable.Add(newTransaction);
            int updatedTransactionCount = DataStore.TransactionHistoryTable.Count;

            if (updatedTransactionCount > previousTransactionCount)
                message += "Transaction Succesful";

            else
            {
                message += "Transaction Failed";
            }
            return message;

        }

        /// <summary>
        /// Get Customer account balance for specified account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns> 
        public string GetAccountBalance(int accountId)
        {
            var message = string.Empty;
            foreach (var account in DataStore.AccountTable)
            {
                if (!(account.Id == accountId))
                    message = "Account does not exist";
                else
                    message = $"Your Account Balance is N{account.AccountBalance}";
            }

            return message;
        }



        /// <summary>
        /// Prints out customer account details and statements in a nicely formated table
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public string GetAccountDetails(string accountNumber)
        {
            var message = string.Empty;

            if (DataStore.AccountTable.Count != 0)
            {
                Console.Clear();
                PrintTable.PrintLine();
                PrintTable.PrintRow("FULL NAME", "ACCOUNT NUMBER", "ACCOUNT TYPE", "ACCOUNT BALANCE");
                PrintTable.PrintLine();

                foreach (var account in DataStore.AccountTable)
                {
                    if (account.AccountNumber == accountNumber)
                    {
                        PrintTable.PrintRow($"{account.AccountName}", $"{account.AccountNumber}", $"{account.AccountType}", $"N{account.AccountBalance}");
                        PrintTable.PrintLine();
                    }

                }
            }
            else
            {
                message += $"No Account Created yet";
            }

            return message;
        }

        /// <summary>
        /// Prints out customer account details and statements in a nicely formated table
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public string GetStatementOfAccount(int accountId)
        {
            var message = string.Empty;
            if (DataStore.TransactionHistoryTable.Count != 0)
            {
                Console.Clear();
                Console.WriteLine($"ACCOUNT STATEMENT ON ACCOUNT NO {DataStore.AccountTable[accountId - 1].AccountNumber}");
                PrintTable.PrintLine();
                PrintTable.PrintRow();
                PrintTable.PrintRow("DATE", "DESCRIPTION", "AMOUNT", "BALANCE");
                PrintTable.PrintLine();

                var transactions = DataStore.AccountTable.FirstOrDefault(account => account.Id == accountId).TransactionHistory;

                foreach (var transaction in transactions)
                {
                    PrintTable.PrintRow($"{transaction.TransactionDate}", $"{transaction.Description}", $"{transaction.Amount}{transaction.TransactionType}", $"N{transaction.Balance}");
                    PrintTable.PrintLine();
                    //if (transaction.AccountId == accountId)
                    //{


                    //}
                }
            }
            else
            {
                message += $"No transaction made yet";
            }

            return message;
        }

    }
}


