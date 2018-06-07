using System;
using Xunit;
using T1Lab;

namespace XUnitTestT1Lab
{
    public class UnitTest1
    {

        public Account CreateAccount(double balance, double interest )
        {
            return new Account(balance, interest);
        }
        
        #region Account

        [Theory]
        [InlineData(-1)]
        [InlineData(double.NaN)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        public void Account_IfBalanceInputIsInvalid_ThrowException(double balance)
        {
            Assert.Throws<Exception>(() =>
            {
                Account account = CreateAccount(balance, 0.02);
            });
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(double.NaN)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        public void Account_IfInterestInputIsInvalid_ThrowException(double interest)
        {
            Assert.Throws<Exception>(() =>
            {
                Account account = CreateAccount(1000, interest);
            });
        }

        #endregion

        #region Deposit Tests

        [Theory]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.Epsilon)]
        [InlineData(3)]
        [InlineData(double.NaN)]
        public void Deposit_IfAmountIsToLow_ExceptionThrown(double amount)
        {
            Account account = CreateAccount(10000, 0.02);

            Assert.Throws<Exception>(() =>
            {
                account.Deposit(amount);
            });
        }


        [Fact]
        public void Deposit_IncreaseBalance_Successful()
        {
            Account account = CreateAccount(10000, 0.02);

            double deposit = 1000;
            account.Deposit(deposit);

            double expectedBalance = 11000;
            double actualBalance = account.Balance;

            Assert.Equal(expectedBalance, actualBalance);

        }

        #endregion

        #region Withdrawal Tests


        [Theory]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.Epsilon)]
        [InlineData(5)]
        [InlineData(double.NaN)]
        public void WithDraw_IfAmountIsToLow_ExceptionThrown(double amount)
        {
            Account account = CreateAccount(10000, 0.02);

            Assert.Throws<Exception>(() =>
            {
                account.Withdraw(amount);
            });
          
        }

        [Theory]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.Epsilon)]
        [InlineData(5)]
        public void WithDraw_IfBalanceIsToLow_ExceptionThrown(double amount)
        {
            Account account = CreateAccount(3, 0.02);

            Assert.Throws<Exception>(() =>
            {
                account.Withdraw(amount);
            });
        }
     
        [Fact]
        public void WithDraw_FromBalance_Successful()
        {
            Account account = CreateAccount(10000, 0.02);
            double withdrawal = 1000;
            account.Withdraw(withdrawal);
            double expectedBalance = 9000;
            double actualBalance = account.Balance;

            Assert.Equal(expectedBalance, actualBalance);
        }
        #endregion

        #region Transfer Tests

        [Theory]
        [InlineData(double.Epsilon)]
        [InlineData(double.NaN)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        public void Transfer_IfAmountIsToLow_ExceptionThrown(double amount)
        {
            Account account = new Account(1000, 0.02);
            Account newAccount = new Account(400, 0.02);

            Assert.Throws<Exception>(() =>
            {
                account.Transfer(newAccount, amount);
            });
        }

        [Fact]
        public void Transfer_InvalidAccount_ExceptionThrown()
        {
            Account account = new Account(1000, 0.02);

            double amount = 100;
            Assert.Throws<Exception>(() =>
            {
                account.Transfer(account, amount);
            });
        }

        [Fact]
        public void Transfer_IfBalanceIsToLow_ExceptionThrown()
        {
            Account account = new Account(3, 0.02);
            Account newAccount = new Account(400, 0.02);

            double amount = 100;

            Assert.Throws<Exception>(() =>
            {
                account.Transfer(newAccount, amount);
            });
        }

        [Fact]
        public void Transfer_ToAnotherAccount_Successful()
        {
            Account account = new Account(10000, 0.02);
            Account newAccount = new Account(400, 0.02);

            double amountToTransfer = 4000;
            account.Transfer(newAccount, amountToTransfer);

            double expectedNewAccountBalance = 4400;
            double actualNewAccountBalance = newAccount.Balance;

            Assert.Equal(expectedNewAccountBalance, actualNewAccountBalance);

        }
        #endregion

        #region Interest Tests

        [Fact]
        public void CalculateInterest_Successful()
        {
            Account account = CreateAccount(1000, 0.02);


            double actualrate = account.CalculateInterest();
            double expectedRate = 20;

            Assert.Equal(expectedRate, actualrate);
        } 

        [Fact]
        public void CalculateBalanceWithInterest_Successful()
        {
            Account account = CreateAccount(1000, 0.02);
            account.CalculateInterest();

            double actualBalance= account.Balance;
            double expectedBalance = 1020;

            Assert.Equal(expectedBalance, actualBalance);
        }
        #endregion

    }
}
