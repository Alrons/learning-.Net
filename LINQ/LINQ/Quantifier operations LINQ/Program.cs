using Collections;
using Core;

namespace Quantifier_operations_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lists lists = new Lists();
            List<int> intList = lists.IntList;
            List<string> stringList = lists.StringList;
            Dictionary<int, string> intStringDictionary = lists.IntStringDictionary;


            // Проверка, что все элементы удолетворяют условию
            List<int> numbers = new List<int> { 2, 4, 6, 8 };
            bool allEven = numbers.All(x => x % 2 == 0);
            Console.WriteLine(allEven); // Вывод: True

            // проверка что все строки в списке не пустые
            bool allNonEmpty = stringList.All(x => !string.IsNullOrEmpty(x));
            Console.WriteLine(allNonEmpty); // Вывод: True

            // Проверка, есть ли в списке хотябы одно отрицательное число
            List<int> numbers2 = new List<int> { 1, 2, -3, 4 };
            bool hasNegative = numbers2.Any(x => x < 0);
            Console.WriteLine(hasNegative); // Вывод: True

            // Пример с False. В intList нет числа меньге нуля 
            // Проверка, есть ли в списке хотябы одно отрицательное число
            bool hasNegative2 = intList.Any(x => x < 0);
            Console.WriteLine(hasNegative2); // Вывод: False 

            //Пример с Contains
            // Проверяет, содержится ли в списке "two"
            bool result = stringList.Contains("two");
            Console.WriteLine(result); // True
        }
    }
}
