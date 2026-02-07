using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Account
    {
        public string AccountName { get; private set; }

        public Account(string name)
        {
            AccountName = name;
        }

        private decimal _amount { get; set; }

        public decimal GetAmount ()
        {
            return _amount;
        }
       
        public void Deposit(decimal depositAmount)
        {
            if(depositAmount > 0)
            {
              _amount += depositAmount;
              Console.WriteLine("Deposited $" + depositAmount + " successfully");
            }
            else
            {
                Console.WriteLine("Invalid Deposit Amount");
            }
        }

        public void Withdraw(decimal withdrawAmount)
        {
            if (withdrawAmount > 0 && withdrawAmount < _amount)
            {
                _amount -= withdrawAmount;
                Console.WriteLine("Withdrew $" + withdrawAmount + " successfully");
            }
            else
            {
                Console.WriteLine("Invalid Withdraw Amount");
            }
        }

    }
}
