using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronuoustask
{
    class Program
    {
        static void Main(string[] args)
        {

            //create a new task
            Task t = new Task(
                () =>
                {
                    Thread.Sleep(3000);
                    Console.WriteLine("The task finished");
                }
                    );

            t.Start();
            bool twait = t.Wait(3000);

            //properties of Task class

            Console.WriteLine("The status of the task is", t.Status);
            Console.WriteLine("Iscancelled:", t.IsCanceled);
            Console.WriteLine("Iscompleted:", t.IsCompleted);
            Console.WriteLine("Isfaulted:", t.IsFaulted);
            Console.WriteLine("The main process is finished");


            //The task is created with a Run() method

            Task t2 = Task.Run(() =>
              {
                  Console.WriteLine("Task:{0} is currently processing..",Task.CurrentId);
              });
            
            
            //The task inside a task
            Task parent = new Task(
                () => {
                Task child = new Task(
                    () =>
                    {
                        Thread.Sleep(2000);
                        Console.WriteLine("child task finished");
                    },
                    TaskCreationOptions.AttachedToParent
                );
            child.Start();
            Thread.Sleep(2000);
            Console.WriteLine("parent class finished");
        }
        );
         parent.Start();
            parent.Wait();

       //Asnchrously access a multiple tasks
           
      Task[] tasks = new Task[10];
      for (int i = 0; i < 10; i++)
      {
          tasks[i] = Task.Run(() => Thread.Sleep(2000));
      }
      try {
         Task.WaitAll(tasks);
      }
      catch (AggregateException ae) {
         Console.WriteLine("One or more exceptions occurred: ");
         foreach (var ex in ae.Flatten().InnerExceptions)
            Console.WriteLine("   {0}", ex.Message);
      }   

      Console.WriteLine("Status of completed tasks:");
      foreach (var t in tasks)
         Console.WriteLine("   Task #{0}: {1}", t.Id, t.Status);


        }
    }
}
