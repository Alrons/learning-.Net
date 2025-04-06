using Collections;

namespace Group_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lists lists = new Lists();
            List<int> intList = lists.IntList;
            List<string> stringList = lists.StringList;


            // пример с группировкой GroupBy (создается 2 группы, для строк с длиной строки которая делится на 2 и нет)
            List<IGrouping<int, string>> groopList = stringList.GroupBy(x => x.Count() % 2).ToList();

            foreach (IGrouping<int, string> groop in groopList)
            {
                if (groop.Key == 0)
                {
                    foreach (string i in groop)
                    {
                        Console.WriteLine(i);
                    }
                }

            }

            // пример где создается множество групп, где строки с одинаковым знечением объединяются (выводится все элементы по ключу 10 после 9)
            List<IGrouping<int, int>> groopList2 = intList.GroupBy(x => x).ToList();

            foreach (IGrouping<int, int> groop in groopList2)
            {
                if (groop.Key == 9)
                {
                    Console.WriteLine("_________");
                    foreach (int i in groop)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine("_________");
                }
                if (groop.Key == 10)
                {
                    foreach (int i in groop)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            Console.Write("_________"); Console.Write("_________"); Console.Write("_________\n");

            // Выборка ключа у повторяющихся элементов (тех что в группе больше одного)
            List<int> groopList3 = intList.GroupBy(x => x).Where(x => x.Count() > 1).Select(x=>x.Key).ToList();

            foreach (int i in groopList3)
            {
                Console.WriteLine(i);
            }

            Console.Write("_________"); Console.Write("_________"); Console.Write("_________\n");

            // почти тоже самое что и GroupBy является ToLookup
            // Выборка ключа у повторяющихся элементов (тех что в группе больше одного)
            List<int> groopList4 = intList.ToLookup(x => x).Where(x => x.Count() > 1).Select(x => x.Key).ToList();

            foreach (int i in groopList3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
