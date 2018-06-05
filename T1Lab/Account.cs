using System;
using System.Collections.Generic;
using System.Text;

namespace T1Lab
{
    public class Account
    {
        public double Balance { get; private set; }
        public double Interest { get; set; }

        public Account(double initialBalance, double interest)
        {
            //if (initialBalance < 1)
            //    throw new Exception("Value is to low, must be 1 dollar or higher"); ;
            //if (double.IsNaN(initialBalance))
            //    throw new Exception("Must enter a number");
            //if (double.IsInfinity(initialBalance))
            //    throw new Exception("You have enter a to low or to high number");

            //if (interest < double.Epsilon)
            //    throw new Exception("Value is to low, must be higher"); ;
            //if (double.IsNaN(interest))
            //    throw new Exception("Must enter a number");
            //if (double.IsInfinity(interest))
            //    throw new Exception("You have enter a to low or to high number");

            Balance = initialBalance;
            Interest = interest;
        }

        public void Deposit(double amount)
        {
            if (amount < 10)
                throw new Exception("Value is to low, must be 10 dollar or higher");
            if (double.IsNaN(amount))
                throw new Exception("Must enter a number");
            if (double.IsInfinity(amount))
                throw new Exception("You have enter a to low or to high number");

            Balance += amount;
            Console.WriteLine($"Successfully deposited {amount} dollar.\nYou have {Balance} dollar in your account.");

        }

        public void Withdraw(double amount)
        {
            if (amount < 10)
                throw new Exception("Value is to low, lowest amount to withdraw is 10 dollar");
            if (Balance < 10)
                throw new Exception("Not enough funds in your account for a withdrawal");
            if (double.IsNaN(amount))
                throw new Exception("Must enter a number");
            if (double.IsInfinity(amount))
                throw new Exception("You have enter a to low or to high number");


            Balance -= amount;
            Console.WriteLine($"Successfully withdrawed {amount} dollar.\nYou have {Balance} dollar in your account.");
        }

        public bool Transfer(Account targetedAccount, double amount)
        {
            if (targetedAccount == null)
                throw new Exception("Target account is null, cannot access it.\n Null is not allowed");
            if (amount < 5)
                throw new Exception($"You cannot transfer less than 5 dollar, your current amount is {Balance}");
            if (Balance < 5)
                throw new Exception($"Not enough funds in your account for a transfer, your current amount is {Balance}");
            if (this == targetedAccount)
                throw new Exception($"You cannot transfer to the same account");
            if (double.IsNaN(amount))
                throw new Exception("Must enter a number");
            if (double.IsInfinity(amount))
                throw new Exception("You have enter a to low or to high number");

            targetedAccount.Balance += amount;
            Balance -= amount;

            Console.WriteLine($"You transfered {amount} dollar from your account, you have {Balance} dollar in your account");

            return true;
        }

        public double CalculateInterest()
        {
            if(double.IsNaN(Interest))
                throw new Exception("Must enter a number");
            if (double.IsNaN(Balance))
                throw new Exception("Must enter a number");
            if (double.IsInfinity(Interest))                                                                                                                    
                throw new Exception("You have enter a to low or to high number");
            if (double.IsInfinity(Balance))
                throw new Exception("Balance is either to low or to high number");

            double rate = Interest * Balance;
            double newBalance = rate + Balance;
            Balance = newBalance;

            Console.WriteLine($"Your current interest is {newBalance}");

            return rate;
        }

    }
}
