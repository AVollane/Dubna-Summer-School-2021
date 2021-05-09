using System;
using System.Collections.Generic;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = FindNumbersWithConditions(1005, 160323);
            Console.WriteLine($"Элементов, удовлетворяющих условию: {numbers.Length}");
            Console.WriteLine($"Пятнадцатый элемент в порядке от наибольшего к наименьшему: {numbers[numbers.Length - 15]}");
            Console.ReadLine();
        }

        static int[] FindNumbersWithConditions(int minNum = 1005, int maxNum = 160323)
        {
            List<int> answerNumbers = new List<int>();
            string strNum = String.Empty;
            int secondDigit = 0; // переменная для сохранения второй цифры числа
            int fourthDigit = 0; // переменная для сохранения четвёртой цифры числа
            // Цикл, проверяющий все числа от минимального до максимального включительно
            for (int i = minNum; i <= maxNum; i++)
            {
                // Превратим число в строку
                strNum = i.ToString();
                // Преобразуем вторую и четвёртую цифру из строки в число
                secondDigit = Int32.Parse(strNum[1].ToString());
                fourthDigit = Int32.Parse(strNum[3].ToString());

                // Проверяет удовлетворение заданным условиям
                if (!strNum.Contains('3') & !strNum.Contains('4') & secondDigit - fourthDigit < 3)
                {
                    answerNumbers.Add(i);
                }
            }
            return answerNumbers.ToArray();
        }
    }
}
