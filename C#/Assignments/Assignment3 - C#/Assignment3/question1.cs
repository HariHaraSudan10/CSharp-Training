using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


//1.Create a class called Accounts which has data members/fields like Account no, Customer name, Account type, Transaction type (d/w), amount, balance
//D->Deposit
//W->Withdrawal

//-write a function that updates the balance depending upon the transaction type

//	-If transaction type is deposit call the function credit by passing the amount to be deposited and update the balance

//  function  Credit(int amount)  (int or float or double - anything yo can use)

//	-If transaction type is withdraw call the function debit by passing the amount to be withdrawn and update the balance

//  Debit(int amt) function 

//-Pass the other information like Account no, customer name, acc type through constructor

//-write and call the show data method to display the values.
namespace Assignment3
{
    

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

        //  transaction
        public void Transaction(char transType, double amt)
        {
            transactionType = Char.ToUpper(transType);
            amount = amt;

            if (transactionType == 'D')
            {
                Credit(amount);
            }
            else if (transactionType == 'W')
            {
                Debit(amount);
            }
            else
            {
                Console.WriteLine("Invalid Transaction Type!");
            }
        }

        // Deposit
        public void Credit(double amt)
        {
            balance += amt;
            Console.WriteLine("Amount Deposited: " + amt);
        }

        // Withdraw
        public void Debit(double amt)
        {
            if (amt <= balance)
            {
                balance -= amt;
                Console.WriteLine("Amount Withdrawn: " + amt);
            }
            else
            {
                Console.WriteLine("Insufficient Balance!");
            }
        }

        // Display details
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

    class question1
    {
        static void Main()
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
    }
}
