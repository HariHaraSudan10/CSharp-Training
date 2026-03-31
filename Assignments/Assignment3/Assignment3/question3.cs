using Assignment3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//3.Create a class called Saledetails which has data members like Salesno, Productno, Price, dateofsale, Qty, TotalAmount
//-Create a method called Sales() that takes qty, Price details of the object and updates the TotalAmount as  Qty *Price
//- Pass the other information like SalesNo, Productno, Price, Qty and Dateof sale through constructor
//- call the show data method to display the values without an object.

namespace Assignment3
{
    class SaleDetails
    {
        // Data members
        private int salesNo;
        private int productNo;
        private double price;
        private int qty;
        private string dateOfSale;
        private double totalAmount;

        // Constructor
        public SaleDetails(int sNo, int pNo, double pr, int q, string date)
        {
            salesNo = sNo;
            productNo = pNo;
            price = pr;
            qty = q;
            dateOfSale = date;
        }

        // total amount
        public void Sales()
        {
            totalAmount = qty * price;
        }

        // Display Data
        public static void ShowData(SaleDetails s)
        {
            Console.WriteLine("\n--- Sales Details ---");
            Console.WriteLine("Sales No: " + s.salesNo);
            Console.WriteLine("Product No: " + s.productNo);
            Console.WriteLine("Price: " + s.price);
            Console.WriteLine("Quantity: " + s.qty);
            Console.WriteLine("Date of Sale: " + s.dateOfSale);
            Console.WriteLine("Total Amount: " + s.totalAmount);
        }
    }

    class question3
    {
        static void Main()
        {
            
            Console.Write("Enter Sales No: ");
            int sNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product No: ");
            int pNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Date of Sale: ");
            string date = Console.ReadLine();

            SaleDetails sale = new SaleDetails(sNo, pNo, price, qty, date);
            sale.Sales();
            SaleDetails.ShowData(sale);
        }
    }
}
