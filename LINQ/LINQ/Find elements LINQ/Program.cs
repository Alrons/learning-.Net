using Collections;
using Core;

namespace Find_elements_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lists lists = new Lists();
            List<int> intList = lists.IntList;
            List<string> stringList = lists.StringList;

            // создаем новый список (в него будем помещять все найденные элементы)
            List<int> intResult = new List<int>();
            List<string> stringResult = new List<string>();

            // добавляем в список то что нашлось (находится 1 элемент поэтому возращяется не List<int>, а возвращяется int)
            intResult.Add(intList.First(x => x == 2));
            Show.Diference("Поиск первого подходящего по условию", intList, intResult);
            intResult.Clear();


            // находим первый попавшийся элемент с подходящей буквой
            stringResult.Add(stringList.First(x => x.Contains("f")));
            Show.Diference("находим первый попавшийся элемент с подходящей буквой 'f'", stringList, stringResult);

            // вызываем исключение, так как если first не находит, он вызывет исключение
            try
            {
                Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::");
                stringResult.Add(stringList.First(x => x.Contains("ааааааааf")));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }

            stringResult.Clear();
            stringResult.Add(stringList.FirstOrDefault(x => x.Contains("ааааааааf")));
            Show.Diference("получаем Default, так как если FirstOrDefault не находит, он показывает Default (будет как пустое место)", stringList, stringResult);
            
            stringResult.Clear();
            stringResult.Add(stringList.LastOrDefault(x => x.Contains("f")));
            Show.Diference("находим последний элемент с подходящей буквой 'f'", stringList, stringResult);

            try
            {
                Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::");
                stringResult.Clear();
                stringResult.Add(stringList.SingleOrDefault(x => x.Contains("f")));
                Show.Diference("находим единственный элемент (но будет исключение, так как букв строк с буквой f несколько)", stringList, stringResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            try
            {
                Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::");
                stringResult.Clear();
                stringResult.Add(stringList.SingleOrDefault(x => x.Contains("x")));
                Show.Diference("находим единственный элемент с буквой x (найдет элемент six)", stringList, stringResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //получаем элемент по ID
            Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::");
            string Result =  stringList.ElementAtOrDefault(2);
            Console.WriteLine(Result);
        }
    }
}
