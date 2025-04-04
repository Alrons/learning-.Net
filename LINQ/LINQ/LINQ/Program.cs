using Collections;
namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lists lists = new Lists();

            ShowDiference("Отфильтровал все числа равные 5",lists.intList, lists.intList.Where(x => x == 5).ToList());
        }

        private static void ShowDiference(string whatChanged,List<int> firstList, List<int> secondList)
        {
            // Общий заголовок
            Console.WriteLine(whatChanged);

            // Заголовки таблицы
            Console.WriteLine("{0,-15} {1,-15}", "Изначальный", "Измененный");

            // Вывод данных
            for (int i = 0; i < firstList.Count; i++)
            {
                if(secondList.Count > i)
                Console.WriteLine("{0,-15} {1,-15}", firstList[i], secondList[i]);

                else Console.WriteLine("{0,-15} {1,-15}", firstList[i], "-");
            }
        }

    }
}
