using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Code Solution and Code logic
                // Create a boolean array to mark presence of numbers in nums array
                // Iterate through nums, marking the corresponding index of the boolean array
                // Finally, return the numbers that are not present in nums (those with false value in the boolean array)
                 // Iterate over nums and mark the presence of each number

                List<int> missingNumbers = new List<int>();
                int n = nums.Length; // Getting the size of the array
                bool[] present = new bool[n + 1]; // Creating boolean array to track presence

                foreach (var num in nums)
                {
                    if (num <= n) present[num - 1] = true;
                }

                // Finding missing numbers based on the false values in the 'present' array
                for (int i = 0; i < n; i++)
                {
                    if (!present[i]) missingNumbers.Add(i + 1);
                }

                return missingNumbers; // Return the list of missing numbers
            }
            catch (Exception)
            {
                throw;
            }
        }
                
            

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
          try
    {
        // I decided to use two lists to separate even and odd numbers
        // This approach is easier for me to visualize
        List<int> evenNumbers = new List<int>();
        List<int> oddNumbers = new List<int>();

        // Iterate through the array and sort numbers into respective lists
        foreach (int num in nums)
        {
            if (num % 2 == 0)
            {
                // If the number is even (divisible by 2 with no remainder)
                evenNumbers.Add(num);
            }
            else
            {
                // If the number is odd
                oddNumbers.Add(num);
            }
        }

        // Combine the lists: even numbers first, then odd numbers
        evenNumbers.AddRange(oddNumbers);

        // Convert the combined list back to an array and return it
        return evenNumbers.ToArray();
    }
    catch (Exception)
    {
        throw;
    }
}
        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Using a dictionary to store complements
         Dictionary<int, int> complements = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            
            // If we've seen the complement before, we've found our pair
            if (complements.ContainsKey(complement))
            {
                return new int[] { complements[complement], i };
            }
            
            // Otherwise, add this number and its index to the dictionary
            if (!complements.ContainsKey(nums[i]))
            {
                complements.Add(nums[i], i);
            }
        }

        // If no solution is found, return an empty array
        return new int[0];
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Sorting the array to easily find the largest and smallest numbers
        Array.Sort(nums);
        int n = nums.Length;

        // The max product will either be the product of the three largest numbers,
        // or the product of the two smallest (if negative) and the largest number
        int product1 = nums[n-1] * nums[n-2] * nums[n-3];
        int product2 = nums[0] * nums[1] * nums[n-1];

        // Return the larger of the two products
        return Math.Max(product1, product2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                 // Edge case: if the number is 0, return "0"
        if (decimalNumber == 0) return "0";

        // Using a list to store binary digits
        List<int> binary = new List<int>();

        while (decimalNumber > 0)
        {
            binary.Add(decimalNumber % 2);
            decimalNumber /= 2;
        }

        // Reverse the list and convert to string
        binary.Reverse();
        return string.Join("", binary);
            }
            catch (Exception)
            {
                throw;
            }
        }

         // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // // I'm using a binary search approach here
        // The idea is to compare the middle element with the right element
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            // If the array is already sorted, return the first element
            if (nums[left] < nums[right])
                return nums[left];

            int mid = left + (right - left) / 2;

            // If the middle element is greater than the right element,
            // the minimum is in the right half
            if (nums[mid] > nums[right])
            {
                left = mid + 1;
            }
            // Otherwise, the minimum is in the left half or is the middle element
            else
            {
                right = mid;
                 }
        }
                   // When left and right meet, we've found the minimum
        return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }


        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
              // Negative numbers can't be palindromes
        if (x < 0)
            return false;

        // I'm going to reverse the number and compare
        int original = x;
        int reversed = 0;

        while (x > 0)
        {
            // Extract the last digit
            int digit = x % 10;
            
            // Add it to the reversed number
            reversed = reversed * 10 + digit;
            
            // Remove the last digit from x
            x /= 10;
        }

        // If the reversed number equals the original, it's a palindrome
        return original == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
        
         // Base cases
        if (n <= 1)
            return n;

        // I'm using an iterative approach to avoid recursion stack overflow
        int prev = 0, current = 1;

        for (int i = 2; i <= n; i++)
        {
            // Calculate the next Fibonacci number
            int next = prev + current;
            
            // Update prev and current for the next iteration
            prev = current;
            current = next;
        }

        return current;
                
                
                 // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
// New Concepts learned , I consider my self still fairly new to using Github to collab with projects and I gained depper understanding of binary search from this project.
// The Two Sum Problem 3 along with the videos on canbas helped to solve it and the concept of binary search is still fairly new to me im trying to gret use to it .
//The Fibonacci problem (Question 8) made me realize the limitations of recursive solutions for large inputs. I learned about stack overflow errors and had to research more efficient method.
//Problem-Solving Strategies: I found that breaking down problems into smaller steps really helped, especially for complex problems like the rotated array.
// For Question 4 I initially sorted the entire array but later realized I only needed to track a few max and min values.
//Error Handlin gImplementing try-catch blocks for each method made me more aware of potential exceptions and the importance of robust error handling in real-world applications.
// Problems on the terminal was very helpful with syntax error keeping on track. I get lost easily when i have to do multiple types of get still trying to handle.