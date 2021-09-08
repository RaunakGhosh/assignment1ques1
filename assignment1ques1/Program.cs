﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            if (pos)//This provides the condition that if the method returns true it will enter the if block
            {
                Console.WriteLine("Both Halfs of the string are alike");
            }
            else
            {
                Console.WriteLine("Both Halfs of the string are not alike");
            }

            Console.WriteLine();
            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s1 = Console.ReadLine();
            bool flag = CheckIfPangram(s1);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:
            int[,] arr = new int[,] { { 1, 2, 3 }, { 3, 2, 1 } };
            int Wealth = MaximumWealth(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("Richest person has a wealth of {0}", Wealth);


            //Question 4:
            string jewels = "aA";
            string stones = "aAAbbbb";
            Console.WriteLine("Q4:");
            int num = NumJewelsInStones(jewels, stones);
            Console.WriteLine("the number of stones you have that are also jewels are {0}:", num);

            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            String word2 = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(word2, indices);
            Console.WriteLine("The Final string after rotation is"+ " " + rotated_string);


            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            int[] nums = { 0, 1, 2, 3, 4 };
            int[] index = { 0, 1, 2, 2, 1 };
            int[] target = CreateTargetArray(nums, index);
            Console.WriteLine("Target array  for the Given array's is:");
            for (int i = 0; i < target.Length; i++)
            {
                Console.Write(target[i] + "\t");

            }
            Console.WriteLine();


        }
        /*<summary>
You are given a string s of even length.Split this string into two halves of equal lengths, and let a be the first half and b be the second half.
Two strings are alike if they have the same number of vowels ('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'). Notice that s contains uppercase and lowercase letters.
Return true if a and b are alike. Otherwise, return false

Example 1:
Input: s = "book"
Output: true
Explanation: a = "bo" and b = "ok". a has 1 vowel and b has 1 vowel. Therefore, they are alike.
</summary>*/

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
                    if (i.Equals('a') || i.Equals('e') || i.Equals('i') || i.Equals('o') || i.Equals('u') || i.Equals('A') || i.Equals('E') || i.Equals('I') || i.Equals('O') || i.Equals('U')) //if character equals a vowel then we count the vowel
                    {
                        vcounter1++;
                    }
                }
                foreach (char i in parts[1])//Placing a for each loop to count number of characters in the second half of the word
                {
                    if (i.Equals('a') || i.Equals('e') || i.Equals('i') || i.Equals('o') || i.Equals('u') || i.Equals('A') || i.Equals('E') || i.Equals('I') || i.Equals('O') || i.Equals('U'))//if character equals a vowel then we count the vowel
                    {
                        vcounter2++;
                    }
                }
                if (vcounter1 == vcounter2)//the counters are equal then return true
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
        /* 
<summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.
Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.
</summary>
</returns> true/false </returns>
Note: Use of String function (Contains) and hasmap is not allowed, think of other ways how you could the numbers be represented
*/
        private static bool CheckIfPangram(string s)
        {
            try
            {
                
                bool[] sentence = new bool[26];

                // For indexing in sentence[]
                int ind = 0;

                // Traverse all characters
                for (int i = 0; i < s.Length; i++)
                {
                    // If uppercase character, subtract 'A'
                    // to find index.
                    if ('A' <= s[i] && s[i] <= 'Z')//we check whether the element in s belongs to A to Z of the alphabet
                        ind = s[i] - 'A';

                    // If lowercase character,
                    // subtract 'a' to find
                    // index.
                    else if ('a' <= s[i] && s[i] <= 'z')//we check whether the element in s belongs to a to z of the alphabet
                        ind = s[i] - 'a';

                    // If this character is other than english lowercase and uppercase characters.
                    else
                        continue;

                    sentence[ind] = true;
                }

                // Return false if any character is unmarked
                for (int i = 0; i <= 25; i++)
                {
                    if (sentence[i] == false)
                        return (false);
                }

                // If all characters
                // were present
                return (true);
            }
            catch (Exception e)
            {

                Console.WriteLine("{0} exception caught.", e);
                return false;
            }

        }
        /*
        <summary> 
        You are given an m x n integer grid accounts where accounts[i][j] is the amount of money the ith customer has in the jth bank. 
        Return the wealth that the richest customer has.
        A customer's wealth is the amount of money they have in all their bank accounts. 
        The richest customer is the customer that has the maximum wealth.

       Example 1:
       Input: accounts = [[1,2,3],[3,2,1]]
       Output: 6
       Explanation:
       1st customer has wealth = 1 + 2 + 3 = 6
       2nd customer has wealth = 3 + 2 + 1 = 6
       Both customers are considered the richest with a wealth of 6 each, so return 6.
       </summary>
        */
        private static int MaximumWealth(int[,] accounts)
        {
            try
            {
                int tot = 0;
                int currtot = 0;

                for (int i = 0; i < accounts.GetLength(0); i++)//traverses through first dimension i.e. persons in the 2D array
                {
                    currtot = 0;
                    for (int j = 0; j < accounts.GetLength(1); j++)//traverses through second dimension i.e. bank accounts in the 2D array
                    {
                        currtot += accounts[i,j];//Adds bank account per person in the loop
                        
                    }
                    if(currtot > tot)//condition which shows if current total bank account is greater than the total then enter the if block
                    {
                        tot = currtot;
                    }
                    
                }
                return tot;

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} exception caught.", e);
                return 0;
            }
        }
        /*
 <summary>
You're given strings jewels representing the types of stones that are jewels, and stones representing the stones you have.
Each character in stones is a type of stone you have. You want to know how many of the stones you have are also jewels.
Letters are case sensitive, so "a" is considered a different type of stone from "A".
 
Example 1:
Input: jewels = "aA", stones = "aAAbbbb"
Output: 3
Example 2:
Input: jewels = "z", stones = "ZZ"
Output: 0
 
Constraints:
•	1 <= jewels.length, stones.length <= 50
•	jewels and stones consist of only English letters.
•	All the characters of jewels are unique.
</summary>
 */
        private static int NumJewelsInStones(string jewels, string stones)
        {
            try
            {
                int tot = 0;


                for (int i = 0; i < stones.Length && stones.Length <= 50 && Regex.IsMatch(stones, @"^[a-zA-Z]+$"); i++)//traverses through bigger string i.e. stones and also checks for length is less than equal to 50 and all terms in stone is a letter.
                {
                    for (int j = 0; j < jewels.Length && jewels.Length >= 1 && Regex.IsMatch(jewels, @"^[a-zA-Z]+$"); j++)//traverses through smaller string i.e. jewels and also checks for length is greater than equal to 1 and all terms in jewels is a letter.
                    {
                        
                            if (stones[i] == jewels[j])//if jewel elements equal to stone elements then add the element in tot variable
                            {
                                tot += i;
                            }
                        }
                    
                    
                }
                return tot;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                return 0;
            }

        }



        /*

        <summary>
        Given a string s and an integer array indices of the same length.
        The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        Return the shuffled string.

        Example 3:
        Input: s = "aiohn", indices = [3,1,4,2,0], result = [n, i, h, a, o]
        Output: "nihao"
        */

        private static string RestoreString(string s, int[] indices)
        {
            try
            {
                if(s.Length != indices.Length)//if string input length is not equal to indices input length then return null
                {
                    return "null";
                }
                else
                {
                    char[] result = new char[indices.Length];//creating new character array result which equals indices input length
                    for (int i = 0; i< s.Length; i++)//traverse through each element in string input
                    {
                        result[indices[i]] = s[i];//each string element will fill the result character arrays indice positions so that it displays in order.
                    }
                    return new String(result);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /*
        <summary>
Given two arrays of integers nums and index. Your task is to create target array under the following rules:
•	Initially target array is empty.
•	From left to right read nums[i] and index[i], insert at index index[i] the value nums[i] in target array.
•	Repeat the previous step until there are no elements to read in nums and index.
Return the target array.
It is guaranteed that the insertion operations will be valid.
 
Example 1:
Input: nums = [0,1,2,3,4], index = [0,1,2,2,1]
Output: [0,4,1,3,2]


Explanation:
nums       index     target
0            0        [0]
1            1        [0,1]
2            2        [0,1,2]
3            2        [0,1,3,2]
4            1        [0,4,1,3,2]
*/
        private static int[] CreateTargetArray(int[] nums, int[] index)
        {
            try
            {
                var target = new List<int>(nums.Length); // taking list as target and keeping the length equivalent
                if (nums.Length == index.Length && nums.Length >= 1 && nums.Length <= 100 && index.Length >= 1 && index.Length <= 100)// we have num length equivalent to index length and num length is greater than equal to 1 and less than equal to 100 and index length is greater than equal to 1 and less than equal to 100
                {
                    for (int i = 0; i < nums.Length; i++) //traversing through till num length
                    {
                        if (nums[i] >= 0 && nums[i] <= 100 && index[i] >= 0 && index[i] <= i) //traversing through num array which is greater than equal to 0 and less than equal to 100 and index array is less than equal to i element
                        {
                            target.Insert(index[i], nums[i]); // this inserts the values of index and num to target. 
                        }
                    }
                }
                int[] target_val = target.ToArray();//Convert target to array and insert it to target_val int array
                return target_val;//returns target_val to main
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
    }
}


    
