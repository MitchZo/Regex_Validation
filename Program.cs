using System;
using System.Text.RegularExpressions;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            bool isValid = false;
            while (run)
            {
                string userInput = GetUserInput($"What are you attempting to validate? Please enter a number." +
                $"\n1. Name\n2. Email Address\n3. Phone Number\n4. Date");
                switch (userInput)
                {
                    case "1":
                    case "1.":
                        isValid = ValidateName(GetUserInput("Please provide a name for validation.\nFormat of Xxxxx"));
                        Console.WriteLine(isValid.ToString());
                        break;
                    case "2":
                    case "2.":
                        isValid = ValidateEmail(GetUserInput("Please provide an email address for validation.\nFormat of xxx@xxxx.xxx"));
                        Console.WriteLine(isValid.ToString());
                        break;
                    case "3":
                    case "3.":
                        isValid = ValidatePhoneNumber(GetUserInput("Please provide a phone number for validation.\nFormat of xxx-xxx-xxxx"));
                        Console.WriteLine(isValid.ToString());
                        break;
                    case "4":
                    case "4.":
                        isValid = ValidateDate(GetUserInput("Please provide a date for validation.\nFormat of mm/dd/yyyy"));
                        Console.WriteLine(isValid.ToString());
                        break;
                }
                run = RunAgain();
                Console.Clear();
            }
        }
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public static bool ValidateName(string userInput)
        {
            return Regex.IsMatch(userInput, @"^([A-Z]{1}[a-z]{1,29})$");
        }
        public static bool ValidateEmail(string userInput)
        {
            return Regex.IsMatch(userInput, @"^[A-Za-z]{5,30}@[a-zA-Z]{5,10}\.[a-zA-Z]{2,3}$");
        }
        public static bool ValidatePhoneNumber(string userInput)
        {
            return Regex.IsMatch(userInput, @"^(\d{3})-{1}((\d{3})-(\d{4}))\S*$");
        }
        public static bool ValidateDate(string userInput)
        {
            return Regex.IsMatch(userInput, @"^(\d{2})[\/](\d{2})[\/]\d{4}$");
        }
        public static bool RunAgain()
        {
            Console.WriteLine("Would you like to run again?");
            string response = Console.ReadLine();
            if ((response.ToLower() == "yes") || (response.ToLower() == "y"))
            {
                return true;
            }
            else if ((response.ToLower() == "no") || (response.ToLower() == "n"))
            {
                return false;
            }
            else
                return RunAgain();
        }
    }
}