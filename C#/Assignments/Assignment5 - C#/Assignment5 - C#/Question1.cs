using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    using System;

    // User Defined Exception 
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    class Accounts
    {
        // Data members
        private int accountNo;
        private string customerName;
        private string accountType;
        private char transactionType;
        private double amount;
        private double balance;

        // Constructor
        public Accounts(int accNo, string custName, string accType, double initialBalance)
        {
            accountNo = accNo;
            customerName = custName;
            accountType = accType;
            balance = initialBalance;
        }

        // Transaction Method
        public void Transaction(char transType, double amt)
        {
            transactionType = Char.ToUpper(transType);
            amount = amt;

            if (transactionType == 'D')
            {
                Deposit(amount);
            }
            else if (transactionType == 'W')
            {
                Withdraw(amount); 
            }
            else
            {
                Console.WriteLine("Invalid Transaction Type!");
            }
        }

        // Deposit 
        public void Deposit(double amt)
        {
            if (amt <= 0)
                throw new ArgumentException("Deposit amount must be greater than zero.");

            balance += amt;
            Console.WriteLine("Amount Deposited: " + amt);
        }

        // Withdraw 
        public void Withdraw(double amt)
        {
            if (amt <= 0)
                throw new ArgumentException("Withdrawal amount must be greater than zero.");

            if (amt > balance)
                throw new InsufficientBalanceException("Insufficient balance for withdrawal!");

            balance -= amt;
            Console.WriteLine("Amount Withdrawn: " + amt);
        }

        // Display 
        public void ShowData()
        {
            Console.WriteLine("\n--- Account Details ---");
            Console.WriteLine("Account No: " + accountNo);
            Console.WriteLine("Customer Name: " + customerName);
            Console.WriteLine("Account Type: " + accountType);
            Console.WriteLine("Last Transaction Type: " + transactionType);
            Console.WriteLine("Transaction Amount: " + amount);
            Console.WriteLine("Current Balance: " + balance);
        }
    }

    class Question1
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Account Number: ");
                int accNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Customer Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Account Type: ");
                string accType = Console.ReadLine();

                Console.WriteLine("Enter Initial Balance: ");
                double balance = Convert.ToDouble(Console.ReadLine());

                Accounts acc = new Accounts(accNo, name, accType, balance);

                Console.WriteLine("Enter Transaction Type (D for Deposit, W for Withdrawal): ");
                char transType = Convert.ToChar(Console.ReadLine());

                Console.WriteLine("Enter Amount: ");
                double amt = Convert.ToDouble(Console.ReadLine());

                acc.Transaction(transType, amt);

                acc.ShowData();
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Input format is incorrect. Please enter valid data.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nTransaction Process Completed.");
            }
        }
    }
}