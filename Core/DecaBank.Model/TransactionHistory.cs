using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Created properties to model transaction record history details
//As a description of every transaction
//Each transaction should have a history

namespace DecaBankApp_Week_3_Task_.Core.DecaBank.Model
{
 public class TransactionHistory
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public double Amount { get; set; }
        public string TransactionType { get; set; }
        public string Sender { get; set; }
        public string ReceiverAccountName { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public string Description { get; set; }
        public double Balance { get; set; }
        public string TransactionDate { get; set; }

        private int count = 1;


        //Use a constructor to generate current date 
        //And set it to short date format and to string
        // implement increment transaction Id
        public TransactionHistory()
        {
            Id = count++;
            TransactionDate = DateTime.Now.ToShortDateString();
        }
    }
}
