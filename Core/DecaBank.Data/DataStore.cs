using DecaBankApp_Week_3_Task_.Core.DecaBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecaBankApp_Week_3_Task_.Core.DecaBank.Data
{
    public class DataStore
    {
        public static List<Customer> CustomerTable { get; set; } = new List<Customer>();
        public static List<Account> AccountTable { get; set; } = new List<Account>();
        public static List<TransactionHistory> TransactionHistoryTable { get; set; } = new List<TransactionHistory>();
    }
}
