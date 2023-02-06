using DecaBankApp_Week_3_Task_.Core.DecaBank.Data;
using DecaBankApp_Week_3_Task_.Core.DecaBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Costumer Registration
namespace DecaBankApp_Week_3_Task_.Core.DecaBank.core
{
    public class CustomerRepo
    {
        public string password;

        //initialize transaction Count = 1;
        int accountCount = 1;

        public string Email { get; set; }

        public static string RegisterCustomer(string firstName, string lastName, string email, string phoneNumber, string password)
        {
            string message = string.Empty;
            var previousUserCount = DataStore.CustomerTable.Count;

            var foundCustomer = DataStore.CustomerTable.Find(i => i.Email == email);

            if (foundCustomer == null)
            {
                var customer = new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Password = password
                };

                DataStore.CustomerTable.Add(customer);

                //Confirm that a customer record have been updated in customer table.
                var updatedUserCount = DataStore.CustomerTable.Count;
                if (updatedUserCount > previousUserCount) 
                    message = "Registration successful";
                else
                    message = "Registration failed";

            }
            else
            {
                message = "An account with this email already exist. Please login instead";
            }
            return message;

        }
      
        /// Create new customer account
      
        public string CreateAccount(Account model, Customer customer)
        {
            var message = string.Empty;
            var previousAccountCount = DataStore.AccountTable.Count;
            if (model != null)
            {
                model.Id = accountCount;
                model.CustomerId = customer.Id;
                model.AccountName = customer.FullName;
                customer.Account.Add(model);
                accountCount++;
            }
            DataStore.AccountTable.Add(model);

            int updatedAccountCount = DataStore.AccountTable.Count;

            if (updatedAccountCount > previousAccountCount)
                message += "Account created successfuly";

            else
            {
                message += "please all fields are required";
            }

            return message;
        }

    }
}