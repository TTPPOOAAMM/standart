using System;

public static class AverageCalculator
{
    public static double CalculateAverage(int[] array, int size)
    {
        // Проверка на нулевую ссылку (CERT)
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        // Проверка на отрицательный размер (MISRA: явное управление ошибочными значениями)
        if (size < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be non-negative.");
        }

        // Проверка на превышение размера массива (CERT: переполнение буфера)
        if (size > array.Length)
        {
            throw new ArgumentException("Size exceeds the array length.", nameof(size));
        }

        // Проверка деления на ноль (CERT)
        if (size == 0)
        {
            throw new ArgumentException("Size must be greater than zero.", nameof(size));
        }

        long sum = 0;
        checked // Активация проверки переполнения (CERT)
        {
            for (int i = 0; i < size; i++)
            {
                sum += array[i]; // OverflowException, если сумма превысит long.MaxValue
            }
        }

        return (double)sum / size;
    }
}