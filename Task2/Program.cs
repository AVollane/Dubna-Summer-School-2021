using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MachineStartHandling(700, 1000);
            Console.ReadLine();
        }

        // Конвертирует целочисленное значение в массив символов
        static char[] IntToCharArray(int integer)
        {
            string integerStr = integer.ToString();
            return integerStr.ToCharArray();
        }

        static int[] CharArrayToTwoDigitIntArray(char[] charArray)
        {
            List<int> listOfIntegers = new List<int>();
            string str = String.Empty;
            // Формируем двузначные числа из символов методом перебора возможностей
            for (int i = 0; i < charArray.Length; i++)
            {
                for (int j = 0; j < charArray.Length; j++)
                {
                    // Если индексы совпадают, то не формировать число
                    if (j != i)
                    {
                        str = charArray[i].ToString() + charArray[j].ToString();
                        listOfIntegers.Add(Int32.Parse(str));
                    }

                }
            }
            return listOfIntegers.ToArray();
        }

        static void MachineStartHandling(int minValue, int maxValue)
        {

            int whereMaxMinusMinEqualsEighty = 0;

            for (int i = minValue; i <= maxValue; i++)
            {
                char[] intCharArray = IntToCharArray(i);
                int[] twoDigitIntArray = CharArrayToTwoDigitIntArray(intCharArray);
                int minValueFromArray = twoDigitIntArray.Min();
                int maxValueFromArray = twoDigitIntArray.Max();
                Console.Write($"Число: {i}; Результат: ");
                if (maxValueFromArray - minValueFromArray == 80)
                {
                    whereMaxMinusMinEqualsEighty++;
                }
                Console.Write($"{maxValueFromArray - minValueFromArray}\n");
            }
            Console.WriteLine("=======================================");
            Console.WriteLine($"Количество чисел N на отрезке [{minValue}; {maxValue}],\n в результате обработки которых на экране автомата появится число 80: {whereMaxMinusMinEqualsEighty}");
        }
    }
}
