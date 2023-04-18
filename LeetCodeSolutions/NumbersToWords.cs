
using System.Diagnostics;
using System.Collections.Generic;

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
        public static void Main()
        {
            Debug.WriteLine(NumberToWords(100));
            Debug.WriteLine(NumberToWords(0));
        }
    }

}