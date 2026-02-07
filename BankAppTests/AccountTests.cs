using BankApp;
using NUnit.Framework;

namespace BankAppTests
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void TestAccountCreation()
        {
            const string testName = "TEST_ACCOUNT";
            Account testAccount = new Account("TEST_ACCOUNT");

            string name = testAccount.AccountName;

            Assert.AreEqual(testName, name);
        }

        
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(123456, 123456)]
        [TestCase(-1, 0)]
        [TestCase(-1000, 0)]
        [TestCase(-9999, 0)]
        
        public void TestAccountDeposit(decimal depositAmount, decimal expectedFinalAmount)
        {
            const string testName = "TEST_ACCOUNT";
            Account testAccount = new Account("TEST_ACCOUNT");

            testAccount.Deposit(depositAmount);

            decimal resultingAmount = testAccount.GetAmount();
            Assert.AreEqual(expectedFinalAmount, resultingAmount);
        }
    }
}