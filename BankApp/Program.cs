using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a command to continue");
            Console.WriteLine("");
            Console.WriteLine("--Options--");
            Console.WriteLine("OPEN_ACCOUNT AccountName - Opens an account for the specified person");
            Console.WriteLine("CLOSE_ACCOUNT AccountName - Closes an account for the specified person");
            Console.WriteLine("DEPOSIT AccountName Amount - Deposits Amount into Person's account");
            Console.WriteLine("WITHDRAW AccountName Amount - Withdraws Amount from Person's account");
            Console.WriteLine("SEE_BALANCE AccountName - See amount in Person's account");

            while (true)
            {
                Console.WriteLine("");

                string consoleInput = Console.ReadLine();

                List<string> arguments = consoleInput.Split(' ').ToList();

                string command = arguments[0];

                switch (command)
                {
                    case "DEPOSIT":
                        if (arguments.Count == 3 && !string.IsNullOrEmpty(arguments[1]) && (decimal.TryParse(arguments[2], out decimal Money)))
                        {
                           Bank.AccountDeposit(Money, arguments[1]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Deposit Command");
                        }
                         break;
                    case "WITHDRAW":
                        if (arguments.Count == 3 && !string.IsNullOrEmpty(arguments[1]) && (decimal.TryParse(arguments[2], out Money)))
                        {
                            Bank.AccountWithdraw(Money, arguments[1]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Withdraw Command");
                        }
                        break;
                    case "OPEN_ACCOUNT":
                        if (arguments.Count == 2 && !string.IsNullOrEmpty(arguments[1]))
                        {
                            Bank.OpenAccount(arguments[1]);
                            Console.WriteLine("Opened a new account for " + arguments[1]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid command for OPEN_ACCOUNT");
                        }
                        break;
                    case "CLOSE_ACCOUNT":
                        if (arguments.Count == 2 && !string.IsNullOrEmpty(arguments[1]))
                        {
                            bool closed = Bank.CloseAccount(arguments[1]);
                            if (closed)
                            {
                                Console.WriteLine("Closed Account " + arguments[1]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Account");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Command for CLOSE_ACCOUNT");
                        }
                            break;
                    case "SEE_BALANCE":
                        if (arguments.Count == 2 && !string.IsNullOrEmpty(arguments[1]))
                        {
                            decimal? amount = Bank.SeeAmountByAccountName(arguments[1]);

                            if(amount != null)
                            {
                                Console.WriteLine(arguments[1] + " has a balance of $" + amount);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Account");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Command for SEE_BALANCE");
                        }
                            break;
                    default:
                        Console.WriteLine("Command " + command + " was not found...");
                        break;
                }
            }
        }
    }
}
