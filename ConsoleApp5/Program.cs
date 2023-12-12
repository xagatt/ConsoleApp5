using Microsoft.VisualBasic;
using System;

namespace ConsoleApp5
{
    class Program
    {

        static void PrintMenu()
        {
            Console.WriteLine("---------------------------------------------МЕНЮ-------------------------------------------------");
            Console.WriteLine("1 - работа с одномерными массивами");
            Console.WriteLine("2 - работа с двумерными массивами");
            Console.WriteLine("3 - работа с рваными массивами");
            Console.WriteLine("4 - выход");
            Console.WriteLine();
        }


        static void PrintMenu1()
        {
            Console.WriteLine("1 - создать массив");
            Console.WriteLine("2 - напечатать массив");
            Console.WriteLine("3 - добавить после каждого четного элемента элемент со значением 0");
            Console.WriteLine("4 - назад");
        }

        static void PrintMenu2()
        {
            Console.WriteLine("1 - создать двумерный массив");
            Console.WriteLine("2 - напечатать двумерный массив");
            Console.WriteLine("3 - удалить все строки, в которых есть хотя бы один нулевой элемент");
            Console.WriteLine("4 - назад");
        }

        static void PrintMenuRag()
        {
            Console.WriteLine("1 - создать рваный массив");
            Console.WriteLine("2 - напечатать рваный массив");
            Console.WriteLine("3 - добавить К строк в конец массива");
            Console.WriteLine("4 - назад");
        }



        /// Функция считывает целое число с клавиатуры в заданном диапазоне и возвращает его значение.
        /// left мин
        /// right макс
        /// msg сообщение, выводимое пользователю
        static int ReadIntNumber(int left, int right, string msg)
        {
            bool isValidInput;
            int number;

            do
            {
                // Вывод сообщения пользователю
                Console.WriteLine(msg);

                // Считывание введенной строки и проверка
                isValidInput = Int32.TryParse(Console.ReadLine(), out number);

                // Проверка, что число находится в заданном диапазоне
                if (number < left || number >= right)
                {
                    Console.WriteLine("Ошибка: введенное число не находится в указанном диапазоне.");
                    isValidInput = false;
                }
            } while (!isValidInput);

            // Возвращение корректного целочисленного значения
            return number;
        }


        //ручное формирование одномерного массива
        static int[] FormMas(int[] arr, int size)
        {
            // Ввод количества элементов в массиве с проверкой
            do
            {
                size = ReadIntNumber(1, 100, "Введите количество элементов в массиве");
            } while (size < 0);

            int j = 0;

            // Заполнение массива значениями, вводимыми с клавиатуры
            for (int i = 0; i < size; i++)
            {
                j++;
                (new int[size])[i] = ReadIntNumber(-100, 100, "Введите " + j + " элемент массива");
            }

            Console.WriteLine();
            return new int[size];
        }


        // Функция создает одномерный массив случайных чисел.
        static int[] RandFormMas(int size)
        {
            // Ввод количества элементов в массиве с проверкой
            do
            {
                size = ReadIntNumber(1, 100, "Введите количество элементов в массиве");
            } while (size < 0);

            // Создание объекта Random для случайных чисел
            Random rnd = new Random();

            // Новый одномерный массив
            int[] arr = new int[size];

            // Заполнение массива случайными значениями в диапазоне от -100 до 100
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(-100, 100);
            }

            Console.WriteLine();
            return arr;
        }



        // Функция формирования двумерного массива с клавиатуры
        static int[,] FormDimMas(out int strings, out int rows)
        {
            // Запрашиваем у пользователя количество строк и столбцов для массива
            strings = ReadIntNumber(1, 50, "Введите количество строк");
            rows = ReadIntNumber(1, 50, "Введите количество столбцов");

            // Создаем двумерный массив с заданным количеством строк и столбцов
            int[,] table = new int[strings, rows];

            // Заполнение массива элементами
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    table[i, j] = ReadIntNumber(1, 100, "Введите элемент двумерного массива");
                }
            }
            return table;
        }

        // Функция двумерного массива с рандомными значениями
        static int[,] RandFormDimMas(int strings, int rows)
        {
            // Переменная для хранения
            int[,] table;

            // Генерации случайных чисел
            Random rnd = new Random();

            // Ввод количества строк с проверкой
            do
            {
                strings = ReadIntNumber(1, 50, "Введите количество строк");
            } while (strings < 0);

            // Ввод количества столбцов
            do
            {
                rows = ReadIntNumber(1, 50, "Введите количество столбцов");
            } while (rows < 0);

            // Инициализация массива
            table = new int[strings, rows];

            // Заполнение массива случайными значениями
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < rows; j++)
                    table[i, j] = rnd.Next(1, 10);
                Console.WriteLine();
            }
            return table;
        }

        // Функция рваного массива
        static int[][] FormRagMas(int strings, int rows)
        {
            Console.WriteLine("Формирование рваного массива");
            int[][] rag;

            // Ввод количества строк с проверкой
            do
            {
                strings = ReadIntNumber(1, 50, "Введите количество строк:");
            } while (strings < 0);

            // Инициализация рваного массива
            rag = new int[strings][];

            // Заполнение
            for (int i = 0; i < strings; i++)
            {
                // Ввод количества столбцов с проверкой
                do
                {
                    rows = ReadIntNumber(1, 50, "Введите количество столбцов:");
                } while (rows < 0);

                // Инициализация строки массива по количеству столбцов
                rag[i] = new int[rows];

                // Заполнение текущей строки массива значениями
                for (int j = 0; j < rows; j++)
                    rag[i][j] = ReadIntNumber(0, 10, "");  // Ввод и проверка
            }
            return rag;
        }



        // Функция рваного массива случайных чисел
        static int[][] RandFormRagMas(int strings, int rows)
        {
            // Генерация случайных чисел
            Random rnd = new Random();
            Console.WriteLine("Формирование рваного массива");
            do
            {
                strings = ReadIntNumber(1, 50, "Введите количество строк:");
            } while (strings < 0);

            // Создание рваный массив с указанным количеством строк
            int[][] rag = new int[strings][];

            // Заполнение каждую строку
            for (int i = 0; i < strings; i++)
            {
                do
                {
                    rows = ReadIntNumber(1, 50, "Введите количество столбцов:");
                } while (rows < 0);

                rag[i] = new int[rows];

                // Заполняем каждый столбец случайным числом от 0 до 10
                for (int j = 0; j < rows; j++)
                {
                    rag[i][j] = rnd.Next(0, 50);
                }
            }
            return rag;
        }


        // Функция добавляет в одномерный массив ноль после каждого четного элемента
        static int[] AddZeroAfterEven(int[] arr)
        {
            // Вычисление новой длины массива, учитывая добавление нуля после каждого четного элемента
            int newLength = arr.Length + CountEvenElements(arr);

            // Создание нового массива
            int[] newArray = new int[newLength];

            // Индекс
            int ind = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                // Заполнение
                newArray[ind++] = arr[i];

                // Добавление нуля после каждого четного элемента
                if (arr[i] % 2 == 0 && i < arr.Length - 1)
                {
                    newArray[ind++] = 0;
                }
            }
            return newArray;
        }

        // Функция находит количество четных элементов
        static int CountEvenElements(int[] arr)
        {
            // Счетчик четных
            int count = 0;
            // Foreach для перебора в массивах
            foreach (int num in arr)
            {
                if (num % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }


        // Функция удаляет строки из двумерного массива, в которых есть хотя бы один нулевой элемент
        static int[,] DeleteRowsWithZero(int[,] arr)
        {
            // Получение количества строк и столбцов в оригинальном массиве
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);

            // Подсчет количества строк, содержащих хотя бы один нулевой элемент
            int rowCount = CountRowsWithZero(arr);

            // Создание нового массива с уменьшенным числом строк
            int[,] newArray = new int[rows - rowCount, columns];

            // Индекс для отслеживания текущей строки в новом массиве
            int index = 0;

            // Перебор всех строк в оригинальном массиве
            for (int i = 0; i < rows; i++)
            {
                // Флаг - есть ли ноль в строке
                bool ZeroInclude = false;

                // Перебор всех столбцов в текущей строке
                for (int j = 0; j < columns; j++)
                {
                    // Если найден нулевой элемент  выходим из цикла
                    if (arr[i, j] == 0)
                    {
                        ZeroInclude = true;
                        break;
                    }
                }

                // Если в строке нет нулевых элементов, копируем ее в новый массив
                if (!ZeroInclude)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        newArray[index, j] = arr[i, j];
                    }
                    index++;
                }
            }
            return newArray;
        }

        // Функция подсчитывает количество строк с нулем
        static int CountRowsWithZero(int[,] array)
        {
            // Получение количества строк и столбцов в массиве
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            // Счетчик строк с хотя бы одним нулевым элементом
            int count = 0;

            // Перебор всех строк и столбцов в массиве
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (array[i, j] == 0)
                    {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }

        // Добавление строки в конец рваного массива
        static int[][] AddRowsToEnd(int[][] ragArr, int K)
        {
            // Определение количества строк и столбцов
            int defRows = ragArr.Length;
            int defColumns = ragArr.Length > 0 ? ragArr[0].Length : 0;

            // Создание нового рваного массива с увеличенным числом строк
            int[][] newArray = new int[defRows + K][];

            // Копирование существующих строк в новый массив
            for (int i = 0; i < defRows; i++)
            {
                // Создание новой строки с тем же количеством столбцов
                newArray[i] = new int[defColumns];

                // Копирование элементов из существующей строки в новую строку
                Array.Copy(ragArr[i], newArray[i], defColumns);
            }

            // Добавление новых строк в конец массива
            for (int i = defRows; i < defRows + K; i++)
            {
                // Ввод количества столбцов
                int newColumns = ReadIntNumber(1,50,"Введите количество столбцов для новой строки:");

                newArray[i] = new int[newColumns];

                // Заполнение новой строки
                for (int j = 0; j < newColumns; j++)
                {
                    newArray[i][j] = ReadIntNumber(1,100,$"Введите элемент [{i}, {j}]:");
                }
            }

            return newArray;
        }

        // Функция вывода массива
        static void PrintMas(int[] arr, int size)
        {
            // Проверка на пустой массив
            if (size == 0)
            {
                Console.WriteLine("Массив пустой или не создан");
            }
            else
            {
                Console.WriteLine("Текущий массив: ");

                // Вывод элементов массива на экран
                for (int i = 0; i < size; i++)
                {
                    Console.Write(arr[i] + "  ");
                }
            }
        }

        // Функция вывода двумерного массива
        static void Print2DArray(int[,] arr)
        {
            // Получение количества строк и столбцов в массиве
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);

            // Перебор всех строк
            for (int i = 0; i < rows; i++)
            {
                // Перебор всех столбцов в текущей строке
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }

                // Переход на новую строку
                Console.WriteLine();
            }
        }

        // Функция вывода рваного массива
        static void PrintMas(int[][] rag)
        {
            int i = 0;

            // Проверка массива
            if (rag.Length > 0 && rag[i].Length > 0)
            {
                Console.WriteLine("Текущий массив:");

                // Перебор строк
                for (i = 0; i < rag.Length; i++)
                {
                    // Перебор элементов в текущей строке
                    for (int j = 0; j < rag[i].Length; j++)
                    {
                        Console.Write(rag[i][j] + "  ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Массив пустой или не создан");
            }
        }


        static void Main(string[] args)
        {
            int i = 0, j = 0, size = 0, answer = 0, rows = 0, columns = 0;
            int caseSwitch = 0, firstCase = 0, secondCase = 0, thirdCase = 0;
            int[,] table = new int[i, j];
            int[][] rag = new int[rows][];
            int[] arr = new int[size];


            do
            {
                PrintMenu();
                caseSwitch = ReadIntNumber(1, 5, "Выбор операции: ");
                switch (caseSwitch)
                {
                    case 1:                                                                                  //одномерный

                        do
                        {
                            PrintMenu1();
                            firstCase = ReadIntNumber(1, 5, "Выбор операции: ");
                            switch (firstCase)
                            {
                                case 1:
                                    Console.WriteLine("Заполнить массив самостоятельно - 1 \nЗаполнить массив c помощью ДСЧ - 2");
                                    do
                                    {
                                        answer = ReadIntNumber(1, 3, "Выберите способ ввода: ");
                                    } while ((answer < 1) | (answer > 2));
                                    if (answer == 1)
                                        arr = FormMas(arr, size);
                                    else
                                        arr = RandFormMas(size);
                                    break;

                                case 2:
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    PrintMas(arr, size);
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    break;

                                case 3:
                                    arr = AddZeroAfterEven(arr);
                                    Console.WriteLine();
                                    break;

                                default:

                                    if (firstCase == 4)
                                    {
                                        Console.WriteLine("Вы вернулись к главному меню");
                                        size = 0;
                                    }
                                    else
                                        Console.WriteLine("Ошибка ввода. Введите снова");
                                    break;
                            }
                        } while (firstCase != 4);
                        Console.Clear();
                        break;

                    case 2:                                                                                  //двумерный

                        do
                        {
                            PrintMenu2();
                            secondCase = ReadIntNumber(1, 5, "Выбор операции: ");
                            switch (secondCase)
                            {
                                case 1:
                                    Console.WriteLine("Заполнить массив самостоятельно - 1 \nЗаполнить массив c помощью ДСЧ - 2");        
                                    do
                                    {
                                        answer = ReadIntNumber(0, 3, "Выберите способ ввода: ");
                                    } while ((answer < 1) | (answer > 2));
                                    if (answer == 1)
                                        table = FormDimMas(out rows, out columns);
                                    else
                                        table = RandFormDimMas(rows, columns);
                                    break;

                                case 2:
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    PrintMas(arr, rows);
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    break;

                                case 3:
                                    table = DeleteRowsWithZero(table);
                                    Console.WriteLine();
                                    break;

                                default:
                                    if (secondCase == 4)
                                    {
                                        Console.WriteLine("Вы вернулись к главному меню");
                                        rows = 0;
                                        columns = 0;
                                    }

                                    else
                                        Console.WriteLine("Ошибка, введите снова");
                                    break;
                            }

                        } while (secondCase != 4);
                        Console.Clear();
                        break;

                    case 3:                                                                   //рваный

                        do
                        {
                            PrintMenuRag();
                            thirdCase = ReadIntNumber(1, 5, "Выбор операции: ");
                            switch (thirdCase)                                                                          
                            {
                                case 1:

                                    Console.WriteLine("Заполнить массив самостоятельно - 1 \nЗаполнить массив c помощью ДСЧ - 2");
                                    do
                                    {
                                        answer = ReadIntNumber(1, 3, "Выберите способ ввода: ");
                                    } while ((answer < 1) | (answer > 2));
                                    if (answer == 1)
                                        rag = FormRagMas(rows, columns);
                                    else
                                        rag = RandFormRagMas(rows, columns);
                                    break;

                                case 2:
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    PrintMas(rag);
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    break;

                                case 3:
                                    Console.WriteLine("Введите кол-во строк, которое хотите добавить: ");
                                    int K = ReadIntNumber(0, 100, "Введите K");
                                    rag = AddRowsToEnd(rag, K);
                                    Console.WriteLine();
                                    break;

                                default:
                                    if (thirdCase == 4)
                                    {
                                        Console.WriteLine("Вы вернулись к главному меню");
                                        rag = new int[0][];
                                    }
                                    else
                                        Console.WriteLine("Ошибка ввода. Введите снова");
                                    break;
                            }

                        } while (thirdCase != 4);
                        Console.Clear();
                        break;
                }
                if ((caseSwitch >= 5) | (caseSwitch <= 0))
                    Console.WriteLine("Ошибка. Введите снова");
            } while (caseSwitch != 4);
        }
    }
}
