using DecaBankApp_Week_3_Task_.Core.DecaBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//method to authenticate login and Logout.
namespace DecaBankApp_Week_3_Task_.Core.DecaBank.core
{
    internal class AuthenticationRepo
    {
        public static bool Login(string email, string password)
        {
            bool isValid = false;
            foreach (var customer in DataStore.CustomerTable)
            {
                if (customer.Email == email && customer.Password == password)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        public static bool Logout(string email, string password)
        {
            return Login(email, password) == false;
        }

    }
}