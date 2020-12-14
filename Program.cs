using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Linq.Expressions;

namespace laba2
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                NewThread();
            }
        }

        static int count = 0;
        public static void NewThread()
        {
            Thread thread = new Thread(NewThread);
            Console.WriteLine("Для создания потока нажмите Пробел");
            var random = new Random().Next(1000, 5000);
            var key = Console.ReadKey();
            try
            {
                switch (key.Key)
                {
                    case ConsoleKey.Spacebar:
                        thread.Start();
                        Console.WriteLine($"Поток {count} создан");
                        Task.Delay(random);
                        Thread.Sleep(random);
                        count += 1;
                        thread.Abort();
                        Console.WriteLine($"Поток {count} остановлен");
                        break;
                }
                
            } catch {
                Console.WriteLine("Exception");
            }
        }
    }
}