using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions
{
    class Calculator
    {



        public static int Calculate(string expression)
        {
            int num = 0;

            return num;
        }
        private static int PureCalculation(string expression)
        {
            int num = 0;
            expression.Trim();
           
            int i = 0;
            if (expression.StartsWith("-"))
            {
                num = -int.Parse(expression.ElementAt(++i).ToString());
                
            }
            else
            {
                num = int.Parse(expression.ElementAt(i).ToString());
                
            }

            i++;
            while(i < expression.Length)
            {
                string s = expression.ElementAt(i).ToString();
                num = expression.ElementAt(i).Equals('+') ? num + int.Parse(expression.ElementAt(++i).ToString()) : num - int.Parse(expression.ElementAt(++i).ToString());
                i++;
            }
            
           
         

            return num;
        }

        
    }
}
