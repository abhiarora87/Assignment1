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
                Console.WriteLine("Question 1");
                Console.WriteLine("Enter first number");
                int a = 0;
                int b = 0;
            try
            {
                a = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Exception occured please enter a valid value");
            }
            Console.WriteLine("Enter second number");
            try
            {
                b = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Exception occured please enter a valid value");
            }

            if (a >= 1 && a <= b && b <= 1000)
            {
                printSelfDividingNumbers(a, b);
            }
            else Console.WriteLine("Invalid values for Question 1");



            //printing series of numbers
            Console.WriteLine("Question 2");
            Console.WriteLine("Enter a number to print series");
            int num = 0;
            try
            {
                num = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Exception occured please enter a valid value");
            }

            printSeries(num);


            //printing star pattern
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Question 3");
            Console.WriteLine("Enter a number to print star");
            int star = 0;
            try
            {
                star = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Exception occured please enter a valid value");
            }
         printTriangle(star);


            //Printing Matches in two arrays
            Console.WriteLine();
            Console.WriteLine("Question 4");
            Console.WriteLine("Enter number of Jewels");
         int i = 0;
            try
            {
                i = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Exception occured please enter a valid value");
            }
        int[] jewel = new int[i];

        Console.WriteLine("Enter Jewels");
        for (int jCount = 0; jCount < i; jCount++)
        {
            jewel[jCount] = 0;
                try
                {
                    jewel[jCount] = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Exception occured please enter a valid value");
                }
        }

        Console.WriteLine("Enter number of Stones");
            int j = 0;
            try
            {
                j = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Exception occured please enter a valid value");
            }
        int[] stone = new int[j+1];

        Console.WriteLine("Enter Stones");
        for (int sCount=0; sCount < j; sCount++)
        {
                stone[sCount] = 0;
                try
                {
                    stone[sCount] = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Exception occured please enter a valid value");
                }
        }

        Console.WriteLine("Stones that are jewels : " + numJewelsInStones(jewel, stone));


            //Printing larger string in arrays
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Question 5");
            int[] arrayOne = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arrayTwo = { 1, 2, 5, 7, 8, 9, 10 };
            var resultSet = getLargestCommonSubArray(arrayOne, arrayTwo);
            Console.WriteLine("First set of input array is: { 1, 2, 3, 4, 5, 6, 7, 8, 9 }");
            Console.WriteLine("Second set of input array is: { 1, 2, 5, 7, 8, 9, 10 }");
            Console.WriteLine( "The largest substring is: ");
            foreach (var item in resultSet)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
        
        /// <summary>
        /// Question 1 Actual Implementation
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void printSelfDividingNumbers(int a, int b)
            {
            try
            {
                List<int> printValue = new List<int>();

                for (int i = a; i <= b; i++)
                {
                    int compare = 0;


                    if (i < 10)
                    {
                        compare = i % i;
                        if (compare == 0)
                        {
                            printValue.Add(i);
                        }
                    }
                    else
                    {
                        bool flag = false;
                        int[] storeValue = DigitConvert(i);

                        for (int k = 0; k < storeValue.Length; k++)
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

                //Converting digits to array
                int[] DigitConvert(int number)
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

                var result = String.Join(",", printValue);
                Console.WriteLine(result);
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSelfDividingNumbers()");
            }
 
        }
    
         
        /// <summary>
        /// Question 2 to print the series of numbers
        /// </summary>
        /// <param name="num"></param>
        public static void printSeries(int num)
        {
            try
            {
                for (int i = 1; i <= num; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSeries()");
            }
        }

        /// <summary>
        /// Question 3 to print star pattern by asking user for a number
        /// </summary>
        /// <param name="star"></param>
        public static void printTriangle(int star)
        {
            try
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
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
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
            try
            {
                foreach (int element in S)
                {
                    if (J.Contains(element))
                        count++;
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
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
            try
            {
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

            }
            catch
            {
                Console.WriteLine("Exception occured while computing getLargestCommonSubArray()");
            }
            if (listOne.Count >= listTwo.Count)
                    commonArray = listOne.ToArray();
                else
                    commonArray = listTwo.ToArray();
            return commonArray;
        }
    }
}
