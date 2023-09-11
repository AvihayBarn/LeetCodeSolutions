
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;

namespace LeetCodeSolutions
{
    class NumbersToWords
    {
        public static string NumberToWords(int num)
        {

            Dictionary<int, string> numbers_titles_map = new Dictionary<int, string>() { { 0, "" }, { 1, "Thousand" }, { 2, "Million" }, { 3, "Billion" } };
            Dictionary<int, string> numbers_digits_map = new Dictionary<int, string>() { { 0, "" }, { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" }, { 5, "Five" }, { 6, "Six" }, { 7, "Seven" }, { 8, "Eight" }, { 9, "Nine" } };
            Dictionary<int, string> numbers_tens_map = new Dictionary<int, string>() { { 10, "Ten" }, { 11, "Eleven" }, { 12, "Twelve" }, { 13, "Thirteen" }, { 14, "Fourteen" }, { 15, "Fifteen" }, { 16, "Sixteen" }, { 17, "Seventeen" }, { 18, "Eighteen" }, { 19, "Nineteen" } };
            Dictionary<int, string> numbers_bigger_tens_map = new Dictionary<int, string>() { { 2, "Twenty" }, { 3, "Thirty" }, { 4, "Forty" }, { 5, "Fifty" }, { 6, "Sixty" }, { 7, "Seventy" }, { 8, "Eighty" }, { 9, "Ninety" } };
            string number_string = "";
            int i = 0;
            int temp = 0;
            string temp_string;
            while (i < 4 && num > 0)
            {
                temp_string = "";
                temp = num % 1000;
                int tens = temp % 100;

                if (tens / 10 == 0)
                {
                    temp_string = $@"{numbers_digits_map[tens]}";
                }
                else
                {
                    if (tens / 10 == 1)
                    {
                        temp_string = $@"{numbers_tens_map[tens]}";
                    }
                    else
                    {
                        temp_string = $@"{numbers_bigger_tens_map[tens / 10]}";
                        if (tens % 10 > 0)
                        {
                            temp_string = $@"{temp_string} {numbers_digits_map[tens % 10]}";
                        }
                    }
                }

                if (temp / 100 > 0)
                {
                    temp_string = $@"{numbers_digits_map[temp / 100]} Hundred{(string.IsNullOrEmpty(temp_string) ? "" : $@" {temp_string}")}";
                }
                if (i > 0 && temp > 0)
                {
                    temp_string = $@"{temp_string} {numbers_titles_map[i]}";
                }
                if (!string.IsNullOrEmpty(temp_string))
                {
                    if (!string.IsNullOrEmpty(number_string))
                    {
                        number_string = i > 0 ? $@"{temp_string} {number_string}" : temp_string;
                    }
                    else
                    {
                        number_string = temp_string;
                    }
                }



                i++;
                num /= 1000;
            }
            return number_string;
        }

       /* public static int FirstMissingPositive(int[] nums)
        {
            StringBuilder MaxBitRepresentation = new StringBuilder();
            for (int i = 0; i < nums.Max(); i++) MaxBitRepresentation.Append('0');
            string map = MaxBitRepresentation.ToString();

            int firstMissingPositive = 1;
            for(int i=0; i< nums.Length;i++)
            {
                if(nums[i] >= 1 && map.)
                {
                    map = map.Substring(0,)
                }

            }

            return firstMissingPositive;

        }*/
        public static int FirstMissingPositive(int[] nums)
        {
            bool[] b = new bool[nums.Length + 2];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0 && nums[i] <= nums.Length)
                {
                    b[nums[i]] = true;
                }
            }
            
            for (int i = 1; i < b.Length; i++)
            {
                if (!b[i])
                {
                    return i;
                }
            }
            return 0;

        }
        /*public static int Trap(int[] height)
        {
            int water = 0;
            int level = height.Max();
            while(level > 0)
            {
                int i = 0;
                while(i < height.Length)
                {
                    if (height[i] >= level)
                    {
                        int current_level = i;
                        i++;
                        while (i < height.Length && level > height[i]) i++;
                        if (i == height.Length) continue;
                        else
                        {
                            water += i - current_level - 1;
                        }
                            

                    }
                    else i++;
                }
                level--;
                
            }

            return water;
        }*/
        public static int Trap(int[] height)
        {
            int water = 0;
            int count = 0;

            int i = 0;
            while(i < height.Length-2)
            {
                
                int current_index = i+1;

                while(current_index < height.Length && height[i] > height[current_index] && height[current_index] >= height[current_index+1])
                {
                    count += height[i] - height[current_index];
                    current_index++;
                }

                if (current_index < height.Length)
                {
                    water += count;
                }

                 i = current_index;

                
            }

            return water;
        }

        public class MedianFinder
        {
            private readonly static int BUFFER_SIZE = 10;
            private double median;
            private int pointer;
            private int[] arr;
            public MedianFinder()
            {
                median = 0;
                pointer = 0;
                arr = new int[BUFFER_SIZE];
                for (int i = 0; i < arr.Length; i++) arr[i] = int.MaxValue;
            }

            public void AddNum(int num)
            {
                if(pointer == arr.Length)
                {
                    int[] temp = new int[arr.Length + BUFFER_SIZE];
                    for(int i=0;i<arr.Length;i++)
                    {
                        temp[i] = arr[i];
                    }
                    for (int i = pointer; i < temp.Length; i++) temp[i] = int.MaxValue;
                    arr = temp;
                   
                }
                arr[pointer] = num;
                pointer++;
                Array.Sort(arr);

                cauculateMedian();
            }

            public double FindMedian()
            {
                List<int> list = new List<int>();
                
                return median;
            }
            private void cauculateMedian()
            {
                if(pointer % 2 == 1)
                {
                    median = arr[pointer / 2];
                }
                else
                {
                   
                    median = (double)(arr[pointer / 2] + arr[(pointer / 2) - 1]) / 2;
                }
            }
        }
       
    }

}