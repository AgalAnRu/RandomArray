using System;
namespace RandomArray
{
    internal class AgFillValues
    {
        Random random = new Random();
        int typeOfFill;
        int minValueInt;
        int maxValueInt;
        double minValueDouble;
        double maxValueDouble;
        //Для ряда целых чисел;
        internal void ArrayRandomFill(Array inArray, int minValue, int maxValue)
        {
            typeOfFill = 1;
            minValueInt = minValue;
            maxValueInt = maxValue;
            ArrayRandomFill(inArray);
        }
        //Для ряда дробных чисел;
        internal void ArrayRandomFill(Array inArray, double minValue, double maxValue)
        {
            typeOfFill = 2;
            minValueDouble = minValue;
            maxValueDouble = maxValue;
            ArrayRandomFill(inArray);
        }
        internal void ArrayRandomFill(Array inArray)
        {
            int length = inArray.Length;
            int rank = inArray.Rank;
            int[] inArrayElementIndex = new int[inArray.Rank];
            int[] arrayOfLength = new int[rank];
            int valueInt;
            double valueDouble;
            GetLenthArray(arrayOfLength, inArray);
            int index = 0;
            int row = 0;
            int colomn = 0;
            do
            {
                if (typeOfFill == 1)
                {
                    valueInt = FillValueInt();
                    inArray.SetValue(valueInt, inArrayElementIndex);
                }
                else
                {
                    valueDouble = FillValueDouble();
                    inArray.SetValue(valueDouble, inArrayElementIndex);
                }
                if (inArrayElementIndex[colomn] < arrayOfLength[colomn] - 1)
                {
                    inArrayElementIndex[colomn]++;
                }
                else
                {
                    for (row = colomn + 1; row < rank; row++)
                    {
                        if (inArrayElementIndex[row] < arrayOfLength[row] - 1)
                        {
                            inArrayElementIndex[row]++;
                            for (int i = row - 1; i >= 0; i--)
                                inArrayElementIndex[i] = 0;
                            break;
                        }
                    }
                }
                index++;
            } while (index < length);
        }
        internal void ArrayPrintAll(Array inArray)
        {
            int length = inArray.Length;
            int rank = inArray.Rank;
            Console.WriteLine($"Lenght = {length}, Rank = {rank}");
            int[] inArrayElementIndex = new int[inArray.Rank];
            int[] arrayOfLength = new int[rank];
            GetLenthArray(arrayOfLength, inArray);
            int index = 0;
            int row = 0;
            int colomn = 0;
            do
            {
                Console.Write($" {index + 1}.\t");
                PrintIndex(inArrayElementIndex);
                Console.Write("\t");
                Console.WriteLine(inArray.GetValue(inArrayElementIndex));
                if (inArrayElementIndex[colomn] < arrayOfLength[colomn] - 1)
                {
                    inArrayElementIndex[colomn]++;
                }
                else
                {
                    for (row = colomn + 1; row < rank; row++)
                    {
                        if (inArrayElementIndex[row] < arrayOfLength[row] - 1)
                        {
                            inArrayElementIndex[row]++;
                            for (int i = row - 1; i >= 0; i--)
                                inArrayElementIndex[i] = 0;
                            break;
                        }
                    }
                }
                index++;
            } while (index < length);
        }
        private void GetLenthArray(int[] arrayOfLength, Array inArray)
        {
            int rank = inArray.Rank;
            for (int i = 0; i < rank; i++)
                arrayOfLength.SetValue(inArray.GetLength(i), i);
        }
        private int FillValueInt()
        {
            int value = random.Next(minValueInt, maxValueInt + 1);
            return value;
        }
        private double FillValueDouble()
        {
            double perCent = random.NextDouble();
            double value = minValueDouble + (maxValueDouble - minValueDouble) * perCent;
            return value;
        }
        private void PrintIndex(int[] index)
        {
            Console.Write("( ");
            for (int i = index.Length - 1; i >= 0; i--)
            {
                Console.Write(index[i]);
                Console.Write(" , ");
            }
            Console.Write("\b\b)");
        }
        internal Array ArrayCreatFromUser()
        {
            Array array;
            int rank = GetRankFromInput();
            int[] arrayOfLength = new int[rank];
            for (int i = 0; i < rank; i++)
                arrayOfLength[i] = GetLengthFromInput(i + 1);
            typeOfFill = GetTypeToFill();
            if (typeOfFill == 1)
            {
                array = Array.CreateInstance(typeof(int), arrayOfLength);
                minValueInt = GetMinIntFromInput();
                maxValueInt = GetMaxIntFromInput(minValueInt);
                return array;
            }
            array = Array.CreateInstance(typeof(double), arrayOfLength);
            minValueDouble = GetMinDoubleFromInput();
            maxValueDouble = GetMaxDoubleFromInput(minValueDouble);
            return array;
        }
        private int GetRankFromInput()
        {
            string inputStr = string.Empty;
            while (true)
            {
                Console.WriteLine("Введите ранг массива (целое число от 1 до 32): ");
                inputStr = Console.ReadLine();
                if (int.TryParse(inputStr, out int rank))
                    if (rank > 0 && rank <= 32)
                        return rank;
            }
        }
        private int GetLengthFromInput(int i)
        {
            string inputStr = string.Empty;
            while (true)
            {
                Console.WriteLine($"Введите длину {i}-го размера массива (целое число от 1 до 2 147 483 647): ");
                inputStr = Console.ReadLine();
                if (int.TryParse(inputStr, out int length))
                    if (length > 0)
                        return length;
            }
        }
        private int GetTypeToFill()
        {
            ConsoleKey key;
            while (true)
            {
                Console.WriteLine($"Выберите тип данных (целые [1] или дробные [2]");
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    Console.WriteLine();
                    return 1;
                }
                if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine();
                    return 2;
                }
            }
        }
        private int GetMinIntFromInput()
        {
            string inputStr = string.Empty;
            while (true)
            {
                Console.WriteLine($"Введите минимальное число (целое число от -2 147 483 648 до 2 147 483 647): ");
                inputStr = Console.ReadLine();
                if (int.TryParse(inputStr, out int minValue))
                    return minValue;
            }
        }
        private int GetMaxIntFromInput(int minValue)
        {
            string inputStr = string.Empty;
            while (true)
            {
                Console.WriteLine($"Введите максимальное число (целое число от {minValue} до 2 147 483 647): ");
                inputStr = Console.ReadLine();
                if (int.TryParse(inputStr, out int maxValue))
                    if (maxValue >= minValue)
                        return maxValue;
            }
        }
        private double GetMinDoubleFromInput()
        {
            string inputStr = string.Empty;
            while (true)
            {
                Console.WriteLine($"Введите минимальное число: ");
                inputStr = Console.ReadLine();
                if (double.TryParse(inputStr, out double minValue))
                    return minValue;
            }
        }
        private double GetMaxDoubleFromInput(double minValue)
        {
            string inputStr = string.Empty;
            while (true)
            {
                Console.WriteLine($"Введите максимальное число (не меньше, чем {minValue}: ");
                inputStr = Console.ReadLine();
                if (double.TryParse(inputStr, out double maxValue))
                    if (maxValue >= minValue)
                        return maxValue;
            }
        }
    }
}