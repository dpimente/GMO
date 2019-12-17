using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MiddleTierConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // #6 - Fibonacci
            var fibonacciInput = 100;
            Console.WriteLine($"The final Fibonacci value of {fibonacciInput} is " +
                              Fibonacci(fibonacciInput));

            // #7 - Seek Closet to the Average
            var arrayToTest = new int[] {1, 2, 3, 5, -1, 7, 145, -33, 22, 14};
            Console.WriteLine($"The closet value of the array {string.Join(",",arrayToTest)} is " + ClosestToTheAverage(arrayToTest));

            // #8 - Seek in Sorted Data Structure
            var twoDimensionalArray = new[]
            {
                new[] {4, 7, 12, 23, 27, 34},
                new[] {6, 10, 15, 24, 30, 40},
                new[] {12, 15, 18, 29, 32, 48},
                new[] {14, 18, 21, 30, 35, 54},
                new[] {20, 23, 24, 35, 37, 62},
                new[] {22, 27, 29, 39, 40, 68},
                new[] {28, 32, 33, 44, 46, 76},
                new[] {30, 36, 38, 48, 49, 82}
            };

            Console.WriteLine("The two dimensional array for problem 8 is:");
            foreach (var array in twoDimensionalArray)
            {
                Console.WriteLine($"{ string.Join(",", array)}");
            }

            var firstValueToFind = 18;
            Console.WriteLine($"The was the value {firstValueToFind} found? " +
                              SeekInSortedDataStructure(twoDimensionalArray, firstValueToFind));
            var secondValueToFind = 26;
            Console.WriteLine($"The was the value {secondValueToFind} found? " +
                              SeekInSortedDataStructure(twoDimensionalArray, secondValueToFind));
        }

        /// <summary>
        /// The Fibonacci function
        /// </summary>
        /// <param name="endIteration">The final iteration</param>
        /// <returns>The number at the final iteration.</returns>
        private static BigInteger Fibonacci(int endIteration)
        {
            // I'm skipping the first iteration, which would be zero.
            if (endIteration == 0)
            {
                return 0;
            }

            var startingValue = new BigInteger(0);
            var currentValue = new BigInteger(1);
            var tempValue = new BigInteger(0);

            for (int i = 2; i <= endIteration; i++)
            {
                tempValue = startingValue + currentValue;
                startingValue = currentValue;
                currentValue = tempValue;
            }

            return currentValue;
        }

        /// <summary>
        /// The closests to the average number. Takes an array, and finds the number within the array closests to the average.
        /// </summary>
        /// <param name="arrayToCheck">The array to check.</param>
        /// <returns>The closests number.</returns>
        private static int ClosestToTheAverage(IEnumerable<int> arrayToCheck)
        {
            // Converting the array to a list for added functionality.
            var intList = arrayToCheck.ToList();

            // Grabbing the average;
            var average = intList.Average();

            var closestNumber = 0;
            var closestNumberDifferenceBetweenAverage = double.MaxValue;

            // Going through the list and finding the closest value to the average
            //
            // ALSO: This body can be converted to LINQ, depending on the team some like it written in the current form and others in LINQ.
            // I think a good way is to have a tool like resharper where it's easy to convert between the two. That way you have a production standard,
            // while every developer can work in the form they prefer.
            foreach (var value in intList)
            {
                if (Math.Abs(value - average) < closestNumberDifferenceBetweenAverage)
                {
                    closestNumber = value;
                    closestNumberDifferenceBetweenAverage = Math.Abs(value - average);
                }
            }

            // Here's what the converted body would look like.
            //foreach (var value in intList.Where(value => Math.Abs(value - average) < closestNumberDifferenceBetweenAverage))
            //{
            //    closestNumber = value;
            //}

            // It would also allow me to remove the two variables:
            // 'closestNumberDifferenceBetweenAverage', inside of the where clause, double.MaxValue can be used instead of 'closestNumberDifferenceBetweenAverage'
            // 'average' - again inside of the where clause, intList.Average()  can  be used instead of 'average'


            return closestNumber;
        }

        /// <summary>
        /// The seek in sorted date structure function. Finds if a value exists in a two dimensional array.
        /// </summary>
        /// <param name="twoDimensionalArray">The array to check.</param>
        /// <param name="numberToFind">The value to find in the array.</param>
        /// <returns>The boolean value saying if the number to find is in the array or not.</returns>
        private static bool SeekInSortedDataStructure(IReadOnlyList<int[]> twoDimensionalArray, int numberToFind)
        {
            // I wrote this first, it works but it slow. Normally I wouldn't keep this on production level code but this is going ot review so I wanted to show it.
            //for (var i = 0; i < twoDimensionalArray.Count; i++)
            //{
            //    for (var j = 0; j < twoDimensionalArray[i].Length; j++)
            //    {
            //        if (numberToFind == twoDimensionalArray[i][j])
            //        {
            //            return true;
            //        }
            //    }
            //}

            // going diagonally this time. This works if the number of rows and columns are equal
            for (var i = 0; i < twoDimensionalArray.Count; i++)
            {
                    // Checking the diagonal if it's the value 
                    if (twoDimensionalArray[i][i] == numberToFind)
                    {
                        return true;
                    }

                    // Checking if it's above the row of [i][i] 
                    // or on the column to the left of [i][i]
                    if (twoDimensionalArray[i][i] > numberToFind)
                    {
                        // checking the row above [i][i] instance
                        for (var col = i; col > 0; col--)
                        {
                            if (twoDimensionalArray[i][col] == numberToFind)
                            {
                                return true;
                            }
                        }

                        for (var row = i; row > 0; row--)
                        {
                            if (twoDimensionalArray[row][i] == numberToFind)
                            {
                                return true;
                            }
                        }

                        // The value would have been found by now, can return false.
                        return false;
                    }
            }

            return false;
        }
    }
}
