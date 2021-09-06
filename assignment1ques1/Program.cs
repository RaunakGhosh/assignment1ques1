using System;
using System.Collections.Generic;
using System.Linq;


namespace assignment1ques1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the string:");
            string s = Console.ReadLine();
            bool pos = HalvesAreAlike(s);
            if (pos.Equals("true"))//This provides the condition that if the method returns true it will enter the if block
            {
                Console.WriteLine("Both Halfs of the string are alike");
            }
            else
            {
                Console.WriteLine("Both Halfs of the string are not alike");
            }

            Console.WriteLine();

        }
        private static bool HalvesAreAlike(string s)
        {
            try
            {
                
                int vcounter1 = 0;
                int vcounter2 = 0;
                int mid = s.Length / 2; //gets the middle of the String
                String[] parts = { s.Substring(0, mid), s.Substring(mid) };//provides two parts of the string in the string array
                  foreach (char i in parts[0])//Placing a for each loop to count number of characters in the first half of the word
                {
                    if (i.Equals("a") || i.Equals("e") || i.Equals("i") || i.Equals("o") || i.Equals("u") || i.Equals("A") || i.Equals("E") || i.Equals("I") || i.Equals("O") || i.Equals("U")) //if character equals a vowel then we count the vowel
                    {
                        vcounter1++;
                    }
                }
                foreach (char i in parts[1])//Placing a for each loop to count number of characters in the second half of the word
                {
                    if (i.Equals("a") || i.Equals("e") || i.Equals("i") || i.Equals("o") || i.Equals("u") || i.Equals("A") || i.Equals("E") || i.Equals("I") || i.Equals("O") || i.Equals("U"))//if character equals a vowel then we count the vowel
                    {
                        vcounter2++;
                    }
                }
                if (vcounter1 == vcounter2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} exception caught.", e);
                return false;
            }

        }

    }
}
