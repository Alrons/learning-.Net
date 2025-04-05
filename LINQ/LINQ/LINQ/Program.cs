using Collections;
using Core;
namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lists lists = new Lists();
            List<int> intList = lists.IntList;
            List<string> stringList = lists.StringList;
            Dictionary<int, string> intStringDictionary = lists.IntStringDictionary;

            // Тестируем фильтрацию

            Show.Diference("Отфильтровал все числа равные 5", intList, intList.Where(x => x == 5).ToList());

            Show.Diference("Убираем повторения с помощью Distinct числа", intList, intList.Distinct().ToList());

            Show.Diference("Убираем повторения с помощью Distinct строки", stringList, stringList.Distinct().ToList());

            Show.Diference("Убираем повторение по выбранному свойству DistinctBy", intList, intList.DistinctBy(x => x).ToList());

            Show.DiferenceDictionary("Убираем повторение по выбранному свойству в Dictionary", intStringDictionary, intStringDictionary.DistinctBy(x => x.Value).ToDictionary());

            Show.Diference("Взял 5 первых элементов", intList, intList.Take(5).ToList());

            Show.Diference("Беру элементы, пока выполняется условие x <= 6", intList, intList.TakeWhile(x=> x <= 6).ToList());

            Show.Diference("Пропускаю 5 элементов с помощью Skip", intList, intList.Skip(5).ToList());

            Show.Diference("Пропускаю элементы пока выполняется условие x <= 6", intList, intList.SkipWhile(x => x <= 6).ToList());




        }

        

    }
}
