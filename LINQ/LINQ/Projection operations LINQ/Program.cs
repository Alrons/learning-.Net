using Collections;
using Core;

namespace Projection_operations_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lists lists = new Lists();
            List<string> stringList = lists.StringList;
            Dictionary<int, string> intStringDictionary = lists.IntStringDictionary;
            List<List<string>> stringListInList = lists.StringListInList;

            // Примеры с проекцией

            Show.Diference("Беру первые 2 буквы с помощью select", stringList, stringList.Select(word => word.Substring(0,2)).ToList());

            int i = 1;
            Show.Diference("Беру первые 2 буквы с помощью select и добавляю нумерацию", stringList, stringList.Select(word => $"{i++} {word.Substring(0, 2)}").ToList());

            // ну и зачем тут select когда есть ToDictionary
            Show.DiferenceDictionary("Беру первые 2 буквы с помощью ToDictionary", intStringDictionary, intStringDictionary.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Substring(0, 2)));

            // пример зачем нужен SelectMany
            Show.Diference("Достаю вложенные списки делая один плоский список\n" +
                " (было List<List<string>> стало List<string>)\n" +
                "Со вторым списком еще дополнительно проецирую только 2 буквы", stringListInList.SelectMany(x => x).ToList(), stringListInList.SelectMany(x => x.Select(word => word.Substring(0,2))).ToList());
        }
    }
}
