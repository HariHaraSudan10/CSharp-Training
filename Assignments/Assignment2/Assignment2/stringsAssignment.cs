using System;


namespace Assignment2
{
    internal class stringsAssignment
    {
        //Strings Assignment Question 1
        //Write a program in C# to accept a word from the user and display the length of it.

        public static void SQ1()
        {
            Console.WriteLine("Strings Assignment Question 1");
            Console.WriteLine();

            Console.WriteLine("Enter a word : ");
            string word = Console.ReadLine();
            Console.WriteLine("Length of the word is : {0}", word.Length);//Length of the word

            Console.WriteLine("\n-----------------------------------------------");
            Console.WriteLine();
        }

        //Strings Assignment Question 2
        //Write a program in C# to accept a word from the user and display the reverse of it.

        public static void SQ2()
        {
            Console.WriteLine("Strings Assignment Question 1");
            Console.WriteLine();

            Console.WriteLine("Enter a word : ");
            string word = Console.ReadLine();
            Reverse(word);
        }

        static void Reverse(string word) //Reversing the word
        {
            Char[] arr = word.ToCharArray();
            Array.Reverse(arr);
            word = new string(arr);
            Console.WriteLine("Reversed word : {0}", word);

            Console.WriteLine("\n-----------------------------------------------");
            Console.WriteLine();
        }

        //Strings Assignment Question 3
        //Write a program in C# to accept two words from user and find out if they are same. 
        public static void SQ3()
        {
            Console.WriteLine("Strings Assignment Question 3");
            Console.WriteLine();

            Console.WriteLine("Enter the first word : ");
            string word1 = Console.ReadLine();
            Console.WriteLine("Enter the second word : ");
            string word2 = Console.ReadLine();
            if (word1.Equals(word2)) //check if they are same
                Console.WriteLine("The two words are same.");
            else
                Console.WriteLine("The two words are different.");
            Console.WriteLine("\n-----------------------------------------------");
            Console.WriteLine();

        }
    }
}
