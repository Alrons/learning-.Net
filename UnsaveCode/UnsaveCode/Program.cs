using System.Drawing;
using System.IO.Compression;

namespace UnsaveCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 30, 20, 10, 40, 50 };
            
            foreach (var item in TaskFive(arr))
            {
                Console.WriteLine(item);
            }
            ;
            
        }

        public static unsafe void FirstEx()
        {
            int number = 42;
            int* p = &number;

            Console.WriteLine($"Значение переменной {number}");
            Console.WriteLine($"адресс переменной: {(long)p:X}");
            Console.WriteLine($"Значение через указатель {*p}");
            *p = 99;
            Console.WriteLine($"Новое значение переменной: {number}");
        }
        public static unsafe void SecondEx()
        {
            int[] arr = { 10, 20, 30, 40, 50 };
            fixed(int* p = arr) // p — указатель на первый элемент массива
            {
                p[2] = 300;
            }
            foreach (int p in arr) 
            {
                Console.WriteLine($"Значение массива: {p}");
            }
            
        }
        public static unsafe void ThirdEx()
        {
            int[] number = { 10, 20, 30, 40, 50 };
            fixed (int* p = number) // p — указатель на первый элемент массива
            {
                for (int i = 0; i < number.Length; i++) 
                {
                    // конструкция p[i] это синтаксический сахор этого: *(p + i)
                    Console.WriteLine($"Значение массива: {*(p + i)}");
                }
            }
            

        }
        public static unsafe void FourEx()
        {
            Point point = new Point { X = 5, Y = 10 };
            Point* p = &point;   // указатель p хранит адрес структуры point

            Console.WriteLine($"X: {p->X}, Y: {p->Y}");   // доступ к полям структуры
            p->X = 99;                                    // меняем X на 99
            // тоже самое как (*p).X = 99;

        }

        // Напиши unsafe метод, который принимает массив int[] и возвращает сумму всех его элементов, используя только указатели (*, +), а не for с индексами.
        public static unsafe int TaskOne(int[] ints)
        {
            int sum = 0;
            fixed (int* p = ints)
            {
                for (int i = 0; i < ints.Length; i++)
                {
                    sum += *(p + i);
                }
            }
            return sum;
        }

        // Напиши unsafe метод, который принимает указатели на два int и меняет их местами (аналог swap из C++).
        public static unsafe void TaskTwoSwap(int* a, int* b)
        {
            int temp = *a;
            *a = *b;
            *b = temp;
        }

        public static unsafe int TaskThreeMin(int[] ints)
        {
            int min = int.MaxValue;
            fixed (int* p = ints)
            {
                for (int i = 0; i < ints.Length; i++)
                {
                    if (*(p + i) < min)
                    {
                        min = *(p + i);
                    }
                }
            }
            return min;
        }
        public static unsafe void TaskFour(int[] ints)
        {
            fixed (int* p = ints)
            {
                for (int i = 0; i < ints.Length / 2; i++)
                {
                    TaskTwoSwap(&*(p + i), &*(p + (ints.Length - i - 1)));
                }
            }
        }

        // Задача: Быстрое копирование массива с использованием stackalloc и указателей
        //Напиши unsafe метод, который:

        //Принимает int[] source.

        //Выделяет память на стеке с помощью stackalloc для временного буфера.

        //Копирует все элементы из source в стековый буфер.

        //Создаёт новый int[] dest такого же размера и копирует обратно из stackalloc буфера в dest.

        //Возвращает dest.
        public static unsafe int[] TaskFive(int[] ints)
        {
            int length = ints.Length;

            // Выделяем стековую память для временного хранения
            int* buffer = stackalloc int[length];

            // Копируем из массива в стек
            fixed (int* pSrc = ints)
            {
                for (int i = 0; i < length; i++)
                {
                    *(buffer + i) = *(pSrc + i);
                }
            }

            // Копируем из стека в новый массив
            int[] dest = new int[length];
            fixed (int* pDest = dest)
            {
                for (int i = 0; i < length; i++)
                {
                    *(pDest + i) = *(buffer + i);
                }
            }

            return dest;
        }


    }

}

