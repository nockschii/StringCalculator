using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StringCalculator
{
    public class Calculator : IStringCalculator
    {
        int sum = 0;
        public int Add(string numbers)
        {
            if(String.Empty == numbers)
            {
                return 0;
            }
            else if(numbers.Contains(',') && !(numbers.Contains('\n')))
            {
                var tmp = numbers.Split(',');
                CheckOnNegativeValues(tmp);
                sum = sumOfIntArray(tmp);
            }
            else if(numbers.Contains(',') || numbers.Contains('\n'))
            {
                var tmp = numbers.Split(new Char[] { ',', '\n' });
                CheckOnNegativeValues(tmp);
                sum = sumOfIntArray(tmp);
            }
            else
            {
                sum = Int32.Parse(numbers);
            }

            return sum;
        }

        private int sumOfIntArray(string[] intArray)
        {
            int sum = 0;
            foreach (var item in intArray)
            {
                sum += Int32.Parse(item);
            }
            return sum;
        }

        private void CheckOnNegativeValues(string[] array)
        {
            int tmp = 0;
            try
            {
                foreach (var item in array)
                {
                    tmp = Int32.Parse(item);
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
    }
}
