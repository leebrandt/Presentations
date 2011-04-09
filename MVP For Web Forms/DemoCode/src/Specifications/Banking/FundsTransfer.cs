using NUnit.Framework;

namespace BddDemo.Specifications.Banking
{
    [TestFixture]
    public class When_transferring_money_from_savings_to_checking
    {
        Account _savings;
        Account _checking;

        [SetUp]
        public void Context()
        {
            // Given a valid checking account
            _checking = new Account() { AccountType = AccountTypes.Checking, IsValid = true, Balance = 50M };

            // And a valid savings account with enough to cover the transfer amount
            _savings = new Account {AccountType = AccountTypes.Savings, IsValid = true, Balance = 100M};
            
            Action();
        }

        public void Action()
        {
            // When transferring money from savings to checking
            _savings.Transfer(50M, _checking);
        }

        [Test]
        public void It_should_debit_savings_account_for_the_amount_of_the_transfer()
        {
            Assert.AreEqual(50M, _savings.Balance);
        }

        [Test]
        public void It_should_credit_checking_account_for_the_amount_of_the_transfer()
        {
            Assert.AreEqual(100M, _checking.Balance);
        }
    }


    
    public class Account
    {
        public AccountTypes AccountType { get; set; }
        public bool IsValid { get; set; }
        public decimal Balance { get; set; }

        public void Transfer(decimal amount, Account account)
        {
            this.Balance -= amount;
            account.Balance += amount;
        }

    }

    public enum AccountTypes
    {
        Savings, 
        Checking
    }
}