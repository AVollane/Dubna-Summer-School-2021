using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] chars = new char[] { 'Ю', 'Н', 'И', 'Д', 'У', 'Б', 'Н', 'А' };
            string[] sevenCharsCombinations = Combinations.FindSevenCharsCombinations(chars);

            List<string> codes = new List<string>();
            for (int i = 0; i < sevenCharsCombinations.Length; i++)
            {
                Permutations permutations = new Permutations(sevenCharsCombinations[i]);
                codes.AddRange(permutations.GetPermutationsList());
            }
            Console.WriteLine($"Всего кодов: {codes.Count}");
            Console.WriteLine("Исключаем коды, которые не соответствуют условию. . .");
            List<string> rightCodes = codes.Where(x => !x.StartsWith('А') & !x.Contains("ДУ") & x.IndexOf('И') != 2 & x.IndexOf('И') != 3)
                .ToList();
            Console.WriteLine($"Кодов, которые соответствуют условию: {rightCodes.Count}");
            Console.ReadLine();
        }
    }

    public class Combinations
    {
        /// <summary>
        /// Ищет сочетания элементов по семь
        /// </summary>
        /// <param name="codeChars">Массив символов</param>
        /// <returns></returns>
        public static string[] FindSevenCharsCombinations(char[] codeChars)
        {
            // Создаём массив для хранения 7-ми символьного кода.
            List<char> charsForCode = new List<char>();

            List<string> sevenCharCodes = new List<string>();

            for (int i = 0; i < codeChars.Length; i++)
            {

                // Если мы можем взять из начала массива 7 элементов, то берём их
                // и записываем в список
                if (i + 7 < codeChars.Length)
                {
                    // Записываем эти символы в список
                    for (int j = i; j < 7; j++)
                    {
                        charsForCode.Add(codeChars[j]);
                    }
                }

                // Если же не можем, то забираем оставшиеся символы и дополняем
                // символами из начала массива
                else
                {

                    // Записываем оставшиеся символы
                    for (int j = i; j < codeChars.Length; j++)
                    {
                        charsForCode.Add(codeChars[j]);
                    }

                    // Записываем в список символы из начала, т.е. дополняем его до семи
                    for (int j = 0; j < 7 - (codeChars.Length - i); j++)
                    {
                        charsForCode.Add(codeChars[j]);
                    }
                }

                // формируем из символов строки и возвращаем их
                string code = String.Empty;
                foreach (char ch in charsForCode)
                {
                    code += ch.ToString();
                }
                // Console.WriteLine(code);
                sevenCharCodes.Add(code);
                charsForCode.Clear();
            }
            return sevenCharCodes.ToArray();
        }
    }

    /// <summary>
    /// Поиск перестановок массива символов
    /// </summary>
    public class Permutations
    {
        //Список перестановок
        private List<string> _permutationsList;
        private String _str;

        /// <summary>
        /// Добавляет новую перестановку в список
        /// </summary>
        /// <param name="a">Массив символов
        /// <param name="repeat">Содержать повторы
        private void AddToList(char[] a, bool repeat = true)
        {
            var bufer = new StringBuilder("");
            for (int i = 0; i < a.Count(); i++)
            {
                bufer.Append(a[i]);
            }
            if (repeat || !_permutationsList.Contains(bufer.ToString()))
            {
                _permutationsList.Add(bufer.ToString());
            }

        }

        /// <summary>
        /// Рекурсивный поиск всех перестановок
        /// </summary>
        /// <param name="a">
        /// <param name="n">
        /// <param name="repeat">Содержать повторы
        private void RecPermutation(char[] a, int n, bool repeat = true)
        {
            for (var i = 0; i < n; i++)
            {
                var temp = a[n - 1];
                for (var j = n - 1; j > 0; j--)
                {
                    a[j] = a[j - 1];
                }
                a[0] = temp;
                if (i < n - 1) AddToList(a, repeat);
                if (n > 0) RecPermutation(a, n - 1, repeat);
            }
        }

        public Permutations()
        {
            _str = "";
        }

        public Permutations(String str)
        {
            _str = str;
        }
        /// <summary>
        /// Строка, на основе которой строятся перестановки
        /// </summary>
        public String PermutationStr
        {
            get
            {
                return _str;
            }
            set
            {
                _str = value;
            }
        }
        /// <summary>
        /// Получает список всех перестановок
        /// </summary>
        /// <param name="repeat">Содержать повторения
        /// <returns></returns>
        public List<string> GetPermutationsList(bool repeat = true)
        {
            _permutationsList = new List<string> { _str };
            RecPermutation(_str.ToArray(), _str.Length, repeat);
            return _permutationsList;
        }
        /// <summary>
        /// Получает отсортированный список всех перестановок
        /// </summary>
        /// <param name="repeat">Содержать повторения
        /// <returns></returns>
        public List<string> GetPermutationsSortList(bool repeat = true)
        {
            GetPermutationsList(repeat).Sort();
            return _permutationsList;
        }

    }
}
