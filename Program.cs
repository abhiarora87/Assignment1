using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Linq.Expressions;


namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Enter first number");
            //Console.ReadLine();
            //int a = 1, b = 22;
            //printSelfDividingNumbers(a, b);

            //printing series of numbers
            //Console.WriteLine("Enter a number to print series");
            //int num  = Convert.ToInt32(Console.ReadLine());
            //printSeries(num);

            //printing star pattern
            //Console.WriteLine();
            // Console.WriteLine("Enter a number to print star");
            // int star = Convert.ToInt32(Console.ReadLine());
            //printTriangle(star);

            //Printing Matches in two arrays
            /*
            Console.WriteLine("Enter number of Jewels");
            int i = Convert.ToInt32(Console.ReadLine());
            int[] jewel = new int[i];
            Console.WriteLine("Enter Jewels");
            for (int jCount = 0; jCount < i; jCount++)
            {

                jewel[jCount] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Enter number of Stones");
            int j = Convert.ToInt32(Console.ReadLine());
            int[] stone = new int[j+1];

            Console.WriteLine("Enter Stones");
            for (int sCount=0; sCount < j; sCount++)
            {
                stone[sCount] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Stones that are jewels : " + numJewelsInStones(jewel, stone));
            */

            //Printing larger string in arrays
            int[] arrayOne = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arrayTwo = { 1, 2, 5, 7, 8, 9, 10 };
            var resultSet = getLargestCommonSubArray(arrayOne, arrayTwo);
            Console.WriteLine( "The largest substring is: ");
            foreach (var item in resultSet)
            {
                Console.Write(item);
            }

        }
        
        /// <summary>
        /// Question 1 Actual Implementation
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void printSelfDividingNumbers(int a, int b)
            {
            List<int> printValue = new List<int>();

               for (int i=1; i<=22; i++)
             {
                int compare = 0;
                
                   
                if (i < 10)
                   {
                    compare = i % i;
                    if(compare == 0)
                    {
                            printValue.Add(i);
                    } 
                   }
                else
                { bool flag = false;
                    int[] storeValue = DigitConvert(i);
                    
                            for(int k = 0; k < storeValue.Length; k++)
                            {
                                if (storeValue[k] != 0 && (i % storeValue[k] == 0))
                                {
                                    flag = true;
                                }
                                else
                                {
                                    flag = false;
                                    break;
                                }
                            
                            }

                            if (flag == true)
                            {
                            printValue.Add(i);
                        
                            }

                        }
                    }

            var result = String.Join(",", printValue);
            Console.WriteLine(result);
            Console.ReadLine();
              }
         /// <summary>
         /// Question 1 Helper method
         /// </summary>
         /// <param name="number"></param>
         /// <returns></returns>         
        static int[] DigitConvert(int number)
            {
            List<int> listOfInts = new List<int>();
            while (number > 0)
            {
                listOfInts.Add(number % 10);
                number = number / 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
            }


        /// <summary>
        /// Question 2 to print the series of numbers
        /// </summary>
        /// <param name="num"></param>
        public static void printSeries(int num)
        {
            for(int i=1; i<= num; i++)
            {
                for(int j=1;j <=i; j++)
                {
                    Console.Write(i+" ");
                }
            }
        }

        /// <summary>
        /// Question 3 to print star pattern by asking user for a number
        /// </summary>
        /// <param name="star"></param>
        public static void printTriangle(int star)
        {
            int i, j, k;
            for (i = star; i >= 1; i--)
            {
                for (j = star; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (k = 1; k < (i * 2); k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Question 4 to print the Stones that are Jewels
        /// </summary>
        /// <param name="J"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        public static int numJewelsInStones(int[] J, int[] S)
        {
            int count = 0;

            foreach(int element in S)
            {
                if (J.Contains(element))
                    count++;
            }
            return count;

        }

        /// <summary>
        /// Question 5 Get Largest Common Array
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Array getLargestCommonSubArray(int[] a, int[] b)
        {
            object[] commonArray;

            ArrayList listOne = new ArrayList();
            //ArrayList listTwo;
            ArrayList listTwo = new ArrayList();

            for (int counterOne = 0, counterTwo = 0; counterOne < a.Length && counterTwo < b.Length; counterOne++)
            {
                if (a[counterOne] < b[counterTwo])
                {
                    
                    if (listOne.Count > 0)
                    {
                        if (listTwo.Count < listOne.Count)
                        {
                            listTwo = new ArrayList(listOne);
                        }
                        listOne.Clear();
                    }
                }
                else if (a[counterOne] >= b[counterTwo])
                {
                    while (a[counterOne] > b[counterTwo])
                    {
                        counterTwo++;
                    }
                    while (a[counterOne] == b[counterTwo])
                    {
                        listOne.Add(a[counterOne]);
                        counterTwo++;
                    }
                }

               
            }


            if (listOne.Count >= listTwo.Count)
                commonArray = listOne.ToArray();
            else
                commonArray = listTwo.ToArray();

            return commonArray;
        }
    }
    
}
