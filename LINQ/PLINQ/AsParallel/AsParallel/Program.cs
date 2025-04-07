using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace AsParallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>()
            {
                "vk.com",
                "fb.com",
                "twitter.com",
                "youtube.com"
            };

            var stringList = Enumerable.Repeat("Слово", 1000000).ToList();

            ExTree(stringList);
        }

        private static void ExOne()
        {
            // сравнение скорости выполнения
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            var list2 = Enumerable.Range(0, 1000000000).AsParallel().Where(x => x % 2 == 0).ToList();
            stopwatch.Stop();
            Console.WriteLine("время выполнения с AsParallel: " + stopwatch.ElapsedMilliseconds);

            Stopwatch stopwatch2 = new Stopwatch();

            stopwatch2.Start();

            var list3 = Enumerable.Range(0, 1000000000).Where(x => x % 2 == 0).ToList();

            stopwatch2.Stop();

            Console.WriteLine("время выполнения без AsParallel: " + stopwatch2.ElapsedMilliseconds);

            // несколько раз позапускал, и когда как поучается. Но в основном с AsParallel будет лучше. 
            //вот мой последние несколько результатов:
            //время выполнения с AsParallel: 8358, 9042, 7437 мс
            //время выполнения без AsParallel: 14929, 10364, 9412 мс
        }
        private static void ExTwo(List<string> list)
        {
            // пропинговали сервера
            list.AsParallel().ForAll(p =>
            {
                Console.WriteLine(p + "его пинг: " + new Ping().Send(p).RoundtripTime.ToString());
            });
        }

        private static void ExTree(List<string> stringList)
        {
            // сравнение скорости работы со строками

            Stopwatch stopwatch10 = new Stopwatch();

            stopwatch10.Start();
            var list20 = stringList.AsParallel().Where(x => x.Count() % 2 == 1).ToList();
            stopwatch10.Stop();
            Console.WriteLine("время выполнения с AsParallel: " + stopwatch10.ElapsedMilliseconds);

            Stopwatch stopwatch20 = new Stopwatch();

            stopwatch20.Start();

            var list30 = stringList.Where(x => x.Count() % 2 == 1).ToList();

            stopwatch20.Stop();

            Console.WriteLine("время выполнения без AsParallel: " + stopwatch20.ElapsedMilliseconds);


            // со списком строк в 1 миллион это пограничное состояние для моего пк. Здесь, если уверен что списки будут больше чем 1 м. можно использовать AsParallel
            //время выполнения с AsParallel: 65, 59, 64, 63
            //время выполнения без AsParallel: 81, 79, 66, 79
        }
        private static void ExFour()
        {
            // но с маленькими списками лучше не использовать
            Stopwatch stopwatch3 = new Stopwatch();

            stopwatch3.Start();
            var list4 = Enumerable.Range(0, 100000).AsParallel().Where(x => x % 2 == 0).ToList();
            stopwatch3.Stop();
            Console.WriteLine("время выполнения с AsParallel: " + stopwatch3.ElapsedMilliseconds);

            Stopwatch stopwatch4 = new Stopwatch();

            stopwatch4.Start();

            var list5 = Enumerable.Range(0, 100000).Where(x => x % 2 == 0).ToList();

            stopwatch4.Stop();

            Console.WriteLine("время выполнения без AsParallel: " + stopwatch4.ElapsedMilliseconds);

            // вот время выполнения
            //время выполнения с AsParallel: 9, 16
            //время выполнения без AsParallel: 1, 1

            //можно конечно использовать WithDegreeOfParallelism(2) чтобы ограничить количество потоков. И да будет лучше, но все равно очень долго
        }

        private static void ExFive()
        {
            // смотрим как будет сильно падать скорость если использовать AsOrdered

            ////Stopwatch stopwatch = new Stopwatch();

            ////stopwatch.Start();
            ////var list2 = Enumerable.Range(0, 1000000000).AsParallel().AsOrdered().Where(x => x % 2 == 0).ToList();
            ////stopwatch.Stop();
            ////Console.WriteLine("время выполнения с AsParallel: " + stopwatch.ElapsedMilliseconds);

            ////Stopwatch stopwatch2 = new Stopwatch();

            ////stopwatch2.Start();

            ////var list3 = Enumerable.Range(0, 1000000000).Where(x => x % 2 == 0).ToList();

            ////stopwatch2.Stop();

            ////Console.WriteLine("время выполнения без AsParallel: " + stopwatch2.ElapsedMilliseconds);


            // не когда так не делайте (эта операция сожрала все ресурсы компа)
            //время выполнения с AsParallel: 62595
            //время выполнения без AsParallel: 7784
            // я закоментировал это пример так как сильная нагузка на пк
        }
    }
}
