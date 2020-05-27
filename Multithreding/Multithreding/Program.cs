using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Multithreding
{
    class Test
    {
     public void test1()
        {
            Console.WriteLine("Thread1 started");
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("Test1:" + i);

            }
            Console.WriteLine("Thread1 excited");
        }
       public void test2()
        {
            Console.WriteLine("Thread2 started");
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("Test2:" + i);
                if(i==50)
                {
                    Console.WriteLine("Thread2 is go for sleep");
                    Thread.Sleep(5000);
                    Console.WriteLine("Thread2 is woke up");
                }

            }
            Console.WriteLine("Thread2 excited");
        }
        public void test3()
        {
            Console.WriteLine("Thread3 started");
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("Test3:" + i);

            }
            Console.WriteLine("Thread3 exited");
        }
        public void display()
        {
            lock (this)
            {


                Console.WriteLine("[Taj mahal is a");
                Thread.Sleep(5000);
                Console.WriteLine("world famous architecture]");
            }
        }
    }
        class Program
    {
        static void Main(string[] args)
        {

            //single threading model
            Console.WriteLine("Main thread start");
            Test t = new Test();
            //t.test1();
            // t.test2();
             // t.test3();

            //Multithreading model

            Thread t1 = new Thread(t.test1);
            Thread t2 = new Thread(t.test2);
            Thread t3 = new Thread(t.test3);
            t1.Start();
            //t2.Start();
            //t3.Start();
          

            //join() method
            //till the three threads are exit,the main thread does not exit.

            t1.Join();
          //  t2.Join();
           // t3.Join();
            Console.WriteLine("Main thread Excited");

            //Lock method
            Thread t4 = new Thread(t.display);
            t4.Start();
            Thread t5 = new Thread(t.display);
            t5.Start();
            Thread t6 = new Thread(t.display);
            t6.Start();




        }
    }
}
