using DecaBankApp_Week_3_Task_.Core.Technicals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Created properties to model user account requirements
//collect account description.

namespace DecaBankApp_Week_3_Task_.Core.DecaBank.Model 
{
    public class Account
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public double AccountBalance { get; set; }

        //create a file to store  transaction history
        //set account deposit value to 0
        public List<TransactionHistory> TransactionHistory { get; set; }

        private double accountBalance = 0;

    }
}

