using System;
using System.Xml.Linq;


namespace Assignment2
{
    public class Arrays
    {
        // Arrays.Question1
        // Write a  Program to assign integer values to an array  and then print the following
        // a.Average value of Array elements
        // b.Minimum and Maximum value in an array


        public static void AQ1()
        {
            Console.WriteLine("Arrays.Question 1");
            Console.WriteLine();
            Console.WriteLine("Enter the size of the array : ");
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];
            int sum = 0;
            int min = int.MaxValue, max = int.MinValue;
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter the element {0} : ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
                sum += arr[i];
                if (min > arr[i]) min = arr[i];//b.calculating minimum value in an array
                if (max < arr[i]) max = arr[i];//b.calculating maximum value in an array
            }
            Console.WriteLine("Average value of Array elements : {0}", sum / size); //a.Average value of Array elements
            Console.WriteLine("Minimum value in an array : {0} \nMaximun value in the array : {1}", min, max); //b.Minimum and Maximum value in an array

            Console.WriteLine("\n-----------------------------------------------");
            Console.WriteLine();
        }

        //Arrays.Question2
        // Write a program in C# to accept ten marks and display the following
        //   a.Total
        //   b.Average
        //   c.Minimum marks
        //   d.Maximum marks
        //   e.Display marks in ascending order
        //   f.Display marks in descending order

        public static void AQ2()
        {
            Console.WriteLine("Arrays.Question 2");
            Console.WriteLine();

            int[] arr = new int[10];
            int Total = 0;
            int min = int.MaxValue, max = int.MinValue;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter the mark {0} : ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
                Total += arr[i]; //a.calculating total
                if (min > arr[i]) min = arr[i]; //c.calculating Minimum marks
                if (max < arr[i]) max = arr[i]; //d.calculating Maximum marks
            }

            Console.WriteLine("Total : {0}", Total); //a.Total
            Console.WriteLine("Average : {0}", Total / 10); //b.Average
            Console.WriteLine("Minimum marks : {0}", min); //c.Minimum marks
            Console.WriteLine("Maximum marks : {0}", max); //d.Minimum marks

            for (int i = 0; i < 10; i++) //e.ascending order
            {
                for (int j = 0; j < 10 - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Marks in ascending order : ");
            foreach (int mark in arr) //e.Display marks in ascending order
            {
                Console.Write(mark + " ");
            }

            for (int i = 0; i < 10; i++) //f.descending order
            {
                for (int j = 0; j < 10 - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\nMarks in descending order : ");
            foreach (int mark in arr)//f.Display marks in descending order
            {
                Console.Write(mark + " ");
            }

            Console.WriteLine("\n-----------------------------------------------");
            Console.WriteLine();
        }

        //Arrays.Question3
        // Write a C# Sharp program to copy the elements of one array into another array.

        public static void AQ3()
        {
            Console.WriteLine("Arrays.Question 3");
            Console.WriteLine();
            Console.WriteLine("Enter the size of the array : ");
            int size = int.Parse(Console.ReadLine());
            int[] arr1 = new int[size];
            int[] arr2 = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter the element {0} : ", i + 1);
                arr1[i] = int.Parse(Console.ReadLine());
                arr2[i] = arr1[i]; //copying the elements of one array to another array
            }
            Console.WriteLine("Elements of the first array : ");
            foreach (int element in arr1)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine("\nElements of the second array : ");
            foreach (int element in arr2)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine("\n-----------------------------------------------");
            Console.WriteLine();

        }
    }
}
