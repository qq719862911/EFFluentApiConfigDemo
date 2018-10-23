using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //Thread thread = new Thread(Run1);
        //thread.Start();
        //while (true)
        //{
        //    Console.WriteLine("主线程中" + DateTime.Now);
        //}

        //Thread t1 = new Thread(() => {
        //    Console.WriteLine("t1 要睡了");
        //    Thread.Sleep(5000);
        //    Console.WriteLine("t1 醒了");
        //});
        ////t1.IsBackground = true;
        //t1.Start();
        //Console.WriteLine("aaa");
        // }

        static int money = 10000;
        //  [MethodImpl(MethodImplOptions.Synchronized)] 
        // static object locker = new object();
        //static void QuQian(string name)
        //{
        //   lock (locker)
        //    {
        //        Console.WriteLine(name + "查看一下余额" + money);
        //        int yue = money - 1;
        //        Console.WriteLine(name + "取钱");
        //        money = yue;//故意这样写，写成 money--其实就没问题Console.WriteLine(name+"取完了，剩"+money)
        //    }
        //}

        static void QuQian(string name)
        {
            Console.WriteLine(name + "查看一下余额" + money);
            int yue = money - 1;
            Console.WriteLine(name + "取钱");
            money = yue;//故意这样写，写成 money--其实就没问题Console.WriteLine(name+"取完了，剩"+money) 
        }

        static void Main(string[] args)
        {
            //Thread t1 = new Thread(() =>
            //{
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        QuQian("t1");
            //    }
            //});

            //Thread t2 = new Thread(() =>
            //{
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        QuQian("t2");
            //    }
            //});

            //t1.Start();
            //t2.Start();
            //t1.Join();
            //t2.Join();
            //Console.WriteLine("余额" + money);
            //Console.ReadKey();

            //ManualResetEvent mre = new ManualResetEvent(false);
            //Thread t1 = new Thread(() =>
            //{
            //    Console.WriteLine("开始等着开");
            //    mre.WaitOne();
            //    Console.WriteLine("终于开门了");
            //});
            //t1.Start();
            //Console.WriteLine("按任意键开门");
            //Console.ReadKey();
            //mre.Set();//开门

            int i = 10;
            object o = i;
            int j = (int)o;
            Console.WriteLine(j);
            Console.Read();
        }

        static void Fun2()
        {

        }

        static void Run1()
        {
            while (true)
            {
                Console.WriteLine("子线程中" + DateTime.Now);
            }
        }
    }
}
