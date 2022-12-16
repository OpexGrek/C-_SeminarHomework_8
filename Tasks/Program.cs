Console.WriteLine("Choose Task");
Console.WriteLine("Task 1: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.");
Console.WriteLine("Task 2: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
Console.WriteLine("Task 3: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
Console.WriteLine("Task 4: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.");
Console.WriteLine("Task 5: Напишите программу, которая заполнит спирально массив 4 на 4.");
int task = Convert.ToInt32(Console.ReadLine());

switch (task)
{
    case 1:
        Task1();
        break;
    case 2:
        Task2();
        break;
    case 3:
        Task3();
        break;
    case 4:
        Task4();
        break;
    case 5:
        Task5();
        break;
    default:
        Console.WriteLine("There is no such task");
        break;
}


// Блок функций и методов
int InputNumber(string inputSize)                               // Функция ввода размерностей массива
{
    Console.Write(inputSize);
    int outputSize = Convert.ToInt32(Console.ReadLine());
    return outputSize;
}
int[,] InputRandomArray(int[,] massive)                         // Функция заполнения массива рандомом
{
    Random random = new Random();
    for (int i = 0; i < massive.GetLength(0); i++)
    {
        for (int j = 0; j < massive.GetLength(1); j++)
        {
            massive[i, j] = random.Next(0, 21);
            Console.Write(massive[i, j] + " ");
        }
        Console.WriteLine();
    }
    return massive;
}
void PrintArray(int[,] massive)                                 // Метод вывода двумерного массива
{
    for (int i = 0; i < massive.GetLength(0); i++)
    {
        for (int j = 0; j < massive.GetLength(1); j++)
        {
            Console.Write(massive[i, j] + " ");
        }
        Console.WriteLine();
    }
}
void InsRow(int i, int[] massive, int[,] massive2d)             // Метод создания двумерного массива из строк одномерного
{
    for (int j = 0; j < massive.Length; j++)
    {
        massive2d[i, j] = massive[j];
    }
}
int FindRowArray(int[] RowArray)                                // Функция поиска номера строки с наименьшей суммой элементов 
{
    int min = RowArray[0];
    int index = 0;
    for (int i = 0; i < RowArray.Length; i++)
    {
        if (RowArray[i] < min)
        {
            min = RowArray[i];
            index = i;
        }
    }
    return index + 1;
}
int[,] InputHandArray(int[,] massive)                           // Функция заполнения массива вручную
{
    for (int i = 0; i < massive.GetLength(0); i++)
    {
        Console.WriteLine("Input numbers with space");
        string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        for (int j = 0; j < massive.GetLength(1); j++)
        {
            massive[i, j] = Convert.ToInt32(input[j]);
        }
    }
    return massive;
}
int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB, int[,] matrixC)    // Функция перемножения матриц
{
    for (int i = 0; i < matrixC.GetLength(0); i++)
    {
        for (int j = 0; j < matrixC.GetLength(1); j++)
        {
            matrixC[i, j] = 0;
            for (int k = 0; k < matrixA.GetLength(1); k++)
            {
                matrixC[i, j] = matrixC[i, j] + matrixA[i, k] * matrixB[k, j];
            }
        }
    }
    return matrixC;
}
void InputRandomArray3d(int[,,] array3D)                        // Метод заполнения 3-х мерного массива рандомом с неповторяющимися числами
{
    int[] temp = new int[array3D.GetLength(0) * array3D.GetLength(1) * array3D.GetLength(2)];
    int number;
    for (int i = 0; i < temp.GetLength(0); i++)
    {
        temp[i] = new Random().Next(10, 100);
        number = temp[i];
        if (i >= 1)
        {
            for (int j = 0; j < i; j++)
            {
                while (temp[i] == temp[j])
                {
                    temp[i] = new Random().Next(10, 100);
                    j = 0;
                    number = temp[i];
                }
                number = temp[i];
            }
        }
    }
    int count = 0;
    for (int x = 0; x < array3D.GetLength(0); x++)
    {
        for (int y = 0; y < array3D.GetLength(1); y++)
        {
            for (int z = 0; z < array3D.GetLength(2); z++)
            {
                array3D[x, y, z] = temp[count];
                count++;
            }
        }
    }
}
void PrintArray3D(int[,,] array3D)                              // Метод вывода 3-ч мерного массива
{
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                Console.Write(array3D[i, j, k] + "(" + i + "," + j + "," + k + ")" + " ");    
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

// Задача 54: Задайте двумерный массив. Напишите программу,
// которая упорядочит по убыванию элементы каждой строки двумерного массива. (можно использовать готовую функцию)
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2
void Task1()
{
    Console.WriteLine("Input array size MxN");
    int m = InputNumber("Input m: ");
    int n = InputNumber("Input n: ");
    int[,] array2d = new int[m, n];
    int[] SortArray = new int[n];
    InputRandomArray(array2d);
    Console.WriteLine();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            SortArray[j] = array2d[i, j];
        }
        Array.Sort(SortArray, (x, y) => y.CompareTo(x));                // Сортировка на убывание
        InsRow(i, SortArray, array2d);
    }
    Console.WriteLine();
    PrintArray(array2d);
}

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу,
// которая будет находить строку с наименьшей суммой элементов. (можно использовать готовую функцию)
// Например, задан массив:
// 1 4 7 2  -> 14
// 5 9 2 3  -> 19
// 8 4 2 4  -> 18
// 5 2 6 7  -> 20
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
void Task2()
{
    Console.WriteLine("Input array size MxN");
    int m = InputNumber("Input m: ");
    int n = InputNumber("Input n: ");
    int[,] array2d = new int[m, n];
    int[] SortArray = new int[n];
    int[] RowArray = new int[m];
    InputRandomArray(array2d);
    Console.WriteLine();
    for (int i = 0; i < m; i++)
    {
        int sum = 0;
        for (int j = 0; j < n; j++)
        {
            SortArray[j] = array2d[i, j];
            sum = sum + SortArray[j];
        }
        RowArray[i] = sum;
        Console.WriteLine("Sum on the " + (i + 1) + " row: " + sum);
    }
    Console.WriteLine();
    Console.WriteLine("The smallest sum of elements is in " + FindRowArray(RowArray) + " row");
}

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18
void Task3()
{
    int m = InputNumber("Input number rows the first matrix: ");
    int n = InputNumber("Input number columns the first matrix (and rows the second matrix): ");
    int p = InputNumber("Input number columns the second matrix ");
    int[,] matrixA = new int[m, n];
    int[] SortArray = new int[n];
    int[,] matrixB = new int[n, p];
    int[,] matrixC = new int[m, p];
    Console.WriteLine();
    Console.WriteLine("Input matrix A");
    InputHandArray(matrixA);
    Console.WriteLine();
    Console.WriteLine("Input matrix B");
    InputHandArray(matrixB);
    MatrixMultiplication(matrixA, matrixB, matrixC);
    Console.WriteLine("Matrix A");
    PrintArray(matrixA);
    Console.WriteLine();
    Console.WriteLine("Matrix B");
    PrintArray(matrixB);
    Console.WriteLine();
    Console.WriteLine("Matrix C = Matrix A * Matrix B");
    PrintArray(matrixC);
}


// Задача 60. 
// ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)
void Task4()
{
    int x = InputNumber("Input X: ");
    int y = InputNumber("Input Y: ");
    int z = InputNumber("Input Z: ");
    int[,,] array3D = new int[x, y, z];
    InputRandomArray3d(array3D);
    PrintArray3D(array3D);
}


// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07
void Task5()
{
    Console.WriteLine("Input array size MxN");
    int m = InputNumber("Input m: ");
    int n = InputNumber("Input n: ");
    int[,] SnailMatrix = new int[n, m];
    int row = 0;
    int col = 0;
    int dx = 1;
    int dy = 0;
    int dirChanges = 0;
    int visits = m;

    for (int i = 0; i < SnailMatrix.Length; i++)
    {
        SnailMatrix[row, col] = i + 1;
        if (--visits == 0)
        {
            visits = m * (dirChanges % 2) + n * ((dirChanges + 1) % 2) - (dirChanges / 2 - 1) - 2;
            int temp = dx;
            dx = -dy;
            dy = temp;
            dirChanges++;
        }

        col += dx;
        row += dy;
    }
    PrintArray(SnailMatrix);
}