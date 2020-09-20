using System;

namespace Assignment1_Fall20
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
             PrintTriangle(n);

             int n2 = 5;
             PrintSeriesSum(n2);

             int[] A = new int[] { 1,2,2,6 }; ;
             bool check = MonotonicCheck(A);
             Console.WriteLine(check);

             int[] nums = new int[] { 3,1,4,1,5 };
             int k = 2;
             int pairs = DiffPairs(nums, k);
             Console.WriteLine(pairs);

           string keyboard = "abcdefghijklmnopqrstuvwxyz";
             string word = "dis";
             int time = BullsKeyboard(keyboard, word);
             Console.WriteLine(time);

              string str1 = "goulls";
              string str2 = "gobulls";
              int minEdits = StringEdit(str1, str2);
              Console.WriteLine(minEdits);
           
            
        }

        public static void PrintTriangle(int n)
        {
            try
            {
                // Write your code here
                int j;
                int c = n - 1;
                //loop for printing * for the given n number of rows
                for (int i = 1; i <= n; i++) 
                {
                    //loop for printing space to get pyramid shape
                    for (j = 1; j <= c; j++)  
                    {
                        //prints space
                        Console.Write(" ");  
                       
                    }
                    c--;
                    //loop for printing odd number of stars
                    for (j = 1; j <= 2 * i - 1; j++) 
                    {
                        //prints *
                        Console.Write("*");       
                    }
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintTriangle()");
            }
        }

        public static void PrintSeriesSum(int n2)
        {
            try
            {
                // Write your code here

                int sum = 0;                       
                Console.WriteLine("The odd numbers are :");
                for (int i = 1; i <= n2; i++)
                {
                    Console.Write(" ");
                    //prints the odd numbers on screen
                    Console.Write(2 * i - 1);
                    // calculates the sum of the odd numbers
                    sum = sum + 2 * i - 1;     


                }
                Console.WriteLine("\nThe sum is : " + sum);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintSeriesSum()");
            }
        }

        public static bool MonotonicCheck(int[] n)
        {
            try
            {
                // Write your code here

                {
                    bool increasing = true, decreasing = true;
                    for (int i = 1; i < n.Length; ++i)
                    {
                        //checks if array is in increasing order
                        increasing = increasing & n[i - 1] <= n[i];
                        //checks if array is in decreasing order
                        decreasing = decreasing & n[i - 1] >= n[i]; 
                    }
                    return increasing || decreasing;                //returns the result

                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MonotonicCheck()");
            }

            return false;
        }

        public static int DiffPairs(int[] J, int k)
        {
            try
            {
                // Write your code here
                //sorts the array
                   Array.Sort(J);
                   int i = 0, j = 0, count = 0;
                   while (i < J.Length && j < J.Length)
                   {
                       //checks if the numbers are equal
                       while (i < J.Length - 1 && J[i] == J[i + 1]) 
                           i++;
                       //checks if the numbers are equal
                       while (j < J.Length - 1 && J[j] == J[j + 1]) 
                           j++;
                       // checks if the difference is greater than k

                       if (J[j] - J[i] > k)                        
                           i++;
                       // checks if the difference is lesser than k

                       else if (J[j] - J[i] < k)                  
                           j++;

                       // if not greater or lesser then difference is equal
                       else
                       {
                           // increments count and the iterators
                           count++;   
                           i++;
                           j++;
                       }
                   } return count;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing DiffPairs()");
            }

            return 0;
        }

        public static int BullsKeyboard(string keyboard, string word)
        {
            try
            {
                // Write your code here
                // checks string is empty
                if (word == null || word.Length == 0)     
                {
                    return 0;
                }
                //create array
                int[] idx = new int[26];
                // calculates index value for keyboard
                for (int i = 0; i < keyboard.Length; i++)
                {
                    idx[keyboard[i] - 'a'] = i;                         
                }
                int result = 0;
                // calculates the absolute distance between the letters and returns the result
                for (int i = -1, j = 0; j < word.Length; i++, j++)
                {
                    if (i == -1)
                    {
                        result =result + Math.Abs(idx[word[0] - 'a'] - 0);
                    }                                                                   
                    else
                    {
                        result=result+ Math.Abs(idx[word[j] - 'a'] - idx[word[i] - 'a']); 
                    }
                }
                return result;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing BullsKeyboard()");
            }

            return 0;
        }

        public static int StringEdit(string str1, string str2)
        {
            try
            {
                // Write your code here
                //if str1 is empty returns str2 length as it will take that many edits
                if (str1.Length == 0)
                {
                    return str2.Length;                    
                }
                //if str2 is empty returns str1 length as it will take that many edits
                else if (str2.Length == 0)
                {
                    return str1.Length;                    
                }
                // gets the length of 2 strings
                int n = str1.Length;                        
                int m = str2.Length;
                //creates a new array
                int[,] se = new int[str1.Length + 1, str2.Length + 1];
                // check for insert,delete or replace operations by iterating over the two strings
                for (int i = 0; i <= n; i++)
                {
                    for (int j = 0; j <= m; j++)            
                    {
                        
                        if (i == 0)
                            se[i, j] = j;
                        else if (j == 0)
                            se[i, j] = i;
                        //if characters equal then no operation
                        else if (str1[i - 1] == str2[j - 1])       
                            se[i, j] = se[i - 1, j - 1];
                        //if characters not same then calculate minimum distance using math.min for insert,delete,replace
                        else
                        {
                            se[i, j] = 1 + Math.Min(se[i - 1, j],Math.Min( se[i - 1, j - 1], se[i, j - 1]));
                        }
                    }
                }
                return se[n, m];

            }
            catch
            {
                Console.WriteLine("Exception occured while computing StringEdit()");
            }

            return 0;
        }
       
    }

}
