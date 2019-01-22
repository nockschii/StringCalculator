using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StringCalculator
{
    public class Calculator : IStringCalculator
    {
        public int Add(string numbers)
        {
            if(!(numbers.Contains('\n')))
            {
                return 0;
            }

            var numbersOnEnter = numbers.Split('\n');
            if (numbers == "" || numbersOnEnter[1].Length == 0)
            {
                return 0;
            }

            var numbersFirstLine = numbersOnEnter[0].Split(',');
            var numbersSecondLine = numbersOnEnter[1].Split(',');

            List<int> valuesFirstLine = new List<int>();
            valuesFirstLine = ConvertStringToInt(numbersFirstLine);
            
            List<int> valuesSecondLine = new List<int>();
            valuesSecondLine = ConvertStringToInt(numbersSecondLine);


            CheckOnNegativeValues(valuesFirstLine);
            CheckOnNegativeValues(valuesSecondLine);

            int res1 = 0, res2 = 0, res = 0;

            res1 = SumOfIntegers(valuesFirstLine);
            res2 = SumOfIntegers(valuesSecondLine);
            res = res1 + res2;

            return res;
        }

        private void CheckOnNegativeValues(List<int> list)
        {
            int tmp = 0;
            try
            {
                foreach (var item in list)
                {
                    tmp = item;
                    if (tmp < 0)
                    {
                        throw new Exception("negative numbers not allowed");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private List<int> ConvertStringToInt(string[] s)
        {
            var result = new List<int>();

            try
            {
                foreach (var item in s)
                {
                    result.Add(Int32.Parse(item.ToString()));
                }
            }
            catch (ArgumentNullException e)
            { 
                throw e;
            }

            return result;
        }

        private int SumOfIntegers(List<int> intList)
        {
            int result = 0;

            foreach (var integer in intList)
            {
                result += integer;
            }

            return result;
        }

        public string ReadInput()
        {
            var firstLine = "";
            var secondLine = "";

            firstLine = Console.ReadLine();
            secondLine = Console.ReadLine();

            string result = firstLine + Environment.NewLine + secondLine;

            return result;
        }
    }
}
