using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public static class Bank
    {
        private static List<Account> _accounts = new List<Account>();

        private static Account GetByAccountName(string name)
        {
            return _accounts.FirstOrDefault(x => x.AccountName == name);
        }

        public static decimal? SeeAmountByAccountName(string name)
        {
            decimal? outputAmount = null;

            Account account = GetByAccountName(name);

            if (account != null)
            {
               outputAmount =  account.GetAmount();
            }

            return outputAmount;
        }

        public static void OpenAccount(string name)
        {
            _accounts.Add(new Account(name));
        }

        public static bool CloseAccount(string name)
        {
            Account account = GetByAccountName(name);

            if (account != null)
            {
                _accounts.Remove(account);
                return true;
            }

           return false;
        }

        public static void AccountDeposit(decimal depositAmount, string name)
        {
            if (GetByAccountName(name) != null)
            {
                Account account = GetByAccountName(name);
                account.Deposit(depositAmount);
            }
            else
            {
                Console.WriteLine("Invalid Account");
            }
        }

        public static void AccountWithdraw(decimal withdrawAmount, string name) 
        {
            if (GetByAccountName(name) != null)
            {
                Account account = GetByAccountName(name);
                account.Withdraw(withdrawAmount);
            }
            else
            {
                Console.WriteLine("Invalid Account");
            }
        }
    }
}

