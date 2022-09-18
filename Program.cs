using System;

namespace RandomArray
{
    internal class Program
    {
        static Array array;
        static void Main(string[] args)
        {
            AgFillValues afv = new AgFillValues();
            Console.WriteLine("Пример заполнения  неизвестного заранее массива (ввод параметров с консоли)");
            array = afv.ArrayCreatFromUser();
            afv.ArrayRandomFill(array);
            afv.ArrayPrintAll(array);
            Console.ReadKey();
            Console.WriteLine("Пример прямого вызова метода (целочисленный), заполнение от -100 до 100");
            int[,,,] arrayFourRankInt = new int[2, 2, 2, 3];
            afv.ArrayRandomFill(arrayFourRankInt, -100, 100);
            afv.ArrayPrintAll(arrayFourRankInt);
            Console.ReadKey();
            Console.WriteLine("Пример прямого вызова метода (дробный), заполнение от -10 до 10");
            double[,,] arrayThreeRankDouble = new double[2, 3, 4];
            double min = -10;
            double max = 10;
            afv.ArrayRandomFill(arrayThreeRankDouble, min, max);
            afv.ArrayPrintAll(arrayThreeRankDouble);
            Console.ReadKey();
        }
    }
}
