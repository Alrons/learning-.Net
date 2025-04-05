using System.Linq;
namespace Core
{
    public static class Show
    {
        public static void Diference<T>(string whatChanged, List<T> firstList, List<T> secondList)
        {
            // Общий заголовок
            Console.WriteLine("---------------------------------\n" + whatChanged + "\n");

            // Заголовки таблицы
            Console.WriteLine("{0,-15} {1,-15}", "Изначальный", "Измененный");

            // Вывод данных
            for (int i = 0; i < firstList.Count; i++)
            {
                if (secondList.Count > i)
                    Console.WriteLine("{0,-15} {1,-15}", firstList[i], secondList[i]);

                else Console.WriteLine("{0,-15} {1,-15}", firstList[i], "-");
            }
        }
        public static void DiferenceDictionary<T>(string whatChanged, Dictionary<int,T> firstDictionary, Dictionary<int, T> secondDictionary)
        {
            // Общий заголовок
            Console.WriteLine("---------------------------------\n" + whatChanged + "\n");

            // Заголовки таблицы
            Console.WriteLine("{0,-15} {1,-15}", "Изначальный", "Измененный");
            
            // Получаем все ключи из обоих списков
            var allKeys = new HashSet<int>(firstDictionary.Keys);
            

            // Вывод данных
            foreach (var key in allKeys)
            {
                T firstValue = firstDictionary.ContainsKey(key) ? firstDictionary[key] : default(T);
                T secondValue = secondDictionary.ContainsKey(key) ? secondDictionary[key] : default(T);

                if (secondValue == null)
                    Console.WriteLine("{0,-15} {1,-15}", firstValue, "-");

                else
                Console.WriteLine("{0,-15} {1,-15}", firstValue, secondValue);
            }
        }
    }
}
