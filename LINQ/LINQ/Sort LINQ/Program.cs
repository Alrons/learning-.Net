using Collections;
using Core;

namespace Sort_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lists lists = new Lists();
            Lists lists2 = new Lists();
            List<int> intList = lists.IntList;
            List<string> stringList = lists.StringList;


            Show.Diference("Отсортировал по возростанию (по алфавиту)", stringList, stringList.OrderBy(x => x).ToList());

            Show.Diference("Все 10 будут в начале, а остальные числа будут отсортированы по возрастанию ", intList, intList
                                                                                                    .OrderByDescending(x => x == 10) // Сначала все 10
                                                                                                    .ThenBy(x => x) // Затем остальные числа по возрастанию
                                                                                                    .ToList());
            Show.Diference("Вынес числа 4,5,6 в начало и отсортировал по убыванию", intList, intList.OrderByDescending(x => x == 4 || x == 5 || x == 6)
                                                                                                    .ThenByDescending(x => x)
                                                                                                    .ToList());
            intList.Reverse();
            Show.Diference("Перевернул список", lists2.IntList, intList);
        }
    }
}
