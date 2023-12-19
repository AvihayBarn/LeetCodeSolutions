using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSolutions
{
    class Algorithms
    {
      



        public static bool IsValidNumber(string s)
        {
            
            if (string.IsNullOrEmpty(s)) return false;
            if (s.Contains('e') || s.Contains('E'))
            {
                int index_of_E = s.IndexOf('e') == -1 ? s.IndexOf('E') : s.IndexOf('e');

                if (index_of_E == 0 || index_of_E == s.Length - 1) return false;
                string first_number = s.Substring(0 , index_of_E + 1-1);
                string second_number = s.Substring(index_of_E+1 );
                bool first_number_validation = first_number.Contains('.') ? IsDecimalNumber(first_number) : IsIntegerNumber(first_number);
                bool second_number_validation = IsIntegerNumber(second_number);
                return (first_number_validation && second_number_validation);
            }
            if(s.Contains('.'))
            {
                return IsDecimalNumber(s);
            }

            return IsIntegerNumber(s);
            
            
        }
        private static bool IsDecimalNumber(string expression)
        {
            if (expression.Length < 2) return false;

            if (expression.StartsWith('+') || expression.StartsWith('-'))
            {
                expression = expression.Remove(0, 1);
            }

            int index_of_dot = expression.IndexOf('.');
            string left_side_of_dot;
            string right_side_of_dot;

            if (index_of_dot == 0)
            {
                left_side_of_dot = string.Empty;
                right_side_of_dot = expression.Substring(1);
            }
            else if (index_of_dot == expression.Length - 1)
            {
                left_side_of_dot = expression.Substring(0, index_of_dot);
                right_side_of_dot = string.Empty;
            }
            else
            {
                left_side_of_dot = expression.Substring(0, index_of_dot);
                right_side_of_dot = expression.Substring(index_of_dot + 1);
            }

            long i = 0;

            if (string.IsNullOrEmpty(left_side_of_dot) && string.IsNullOrEmpty(right_side_of_dot)) return false;

            if (string.IsNullOrEmpty(left_side_of_dot)) 
            {
                if (right_side_of_dot.StartsWith('+') || right_side_of_dot.StartsWith('-')) return false;
                return long.TryParse(right_side_of_dot, out i);
            } 
            if (string.IsNullOrEmpty(right_side_of_dot)) return long.TryParse(left_side_of_dot, out i);


            if (right_side_of_dot.StartsWith('+') || right_side_of_dot.StartsWith('-')) return false;
            return long.TryParse(left_side_of_dot, out i) && long.TryParse(right_side_of_dot, out i);
            
        }
        private static bool IsIntegerNumber(string expression)
        {
            if (expression.StartsWith('+') || expression.StartsWith('-'))
            {
                expression = expression.Remove(0, 1);
            }
            if (expression.StartsWith('+') || expression.StartsWith('-')) return false;

            long i = 0;

            return long.TryParse(expression, out i);

        }


        


        

        



        static void Main(string[] args)
        {
            
        }
    }
}
