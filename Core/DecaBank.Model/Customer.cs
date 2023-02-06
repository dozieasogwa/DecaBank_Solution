using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Created properties to model costumer account details
//collect costumer description.
//Each account should be costumer specific

namespace DecaBankApp_Week_3_Task_.Core.DecaBank.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return LastName + " " + FirstName; }
        }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }

        //create a file to store collected costumer details
        //Keep count of costumer Account
        public List<Account> Account { get; set; }

        private static int count = 1;

        //Use a constructor to generate current date
        //And update account list.
        // increment costumer Id
        public Customer() 
        {
            Id += count++;
            DateCreated = DateTime.Now;
            Account = new List<Account>();
        }

    }
}
