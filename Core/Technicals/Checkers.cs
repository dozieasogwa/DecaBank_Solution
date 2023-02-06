using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Validating user account characters
//input must match the requirement
namespace DecaBankApp_Week_3_Task_.Core.Technicals
{
 public class Checkers
    {
        public static bool CheckName(string name)
        {
            if (!Regex.IsMatch(name, @"[A-Z,a-z]+$")) //Names must contain only alphabet strings
                return false;
            return true;
        }

        public static bool CheckEmail(string name)
        {
            if (!Regex.IsMatch(name, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")) //Names must contain only strings ant
                return false;
            return true;
        }

        public static bool CheckPassword(string password)
        {
            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,15}$"))
                return false;
            return true;
        }

        public static bool CheckPhoneNumber(string phoneNumber)
        {
            if (!Regex.IsMatch(phoneNumber, @"^[0]\d{10}$"))
                return false;
            return true;
        }

        public static bool CheckTransAccount(string accountNumber)
        {
            if (!Regex.IsMatch(accountNumber, @"\d{10}$"))
                return false;
            return true;
        }
    }
}
