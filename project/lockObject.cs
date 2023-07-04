using System;
using System.Threading;

public sealed class Singleton
{
    private static Singleton instance;
    private static readonly object lockObject = new object();
    private static int counter = 0;

    private Singleton()
    {
        // Private constructor
    }

    public static Singleton Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
            }
            return instance;
        }
    }

    public void PrintMessage()
    {
        Console.WriteLine("Hello, I am a Singleton instance! Counter: " + counter);
        counter++;
    }
}

public class WorkerThread
{
    private bool useLockObject;

    public WorkerThread(bool useLockObject)
    {
        this.useLockObject = useLockObject;
    }

    public void DoWork()
    {
        for (int i = 0; i < 5; i++)
        {
            Singleton singleton = Singleton.Instance;

            if (useLockObject)
            {
                lock (singleton)
                {
                    singleton.PrintMessage();
                }
            }
            else
            {
                singleton.PrintMessage();
            }

            Thread.Sleep(100); // Menambahkan jeda untuk simulasi kasus perlombaan
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Singleton Implementation Comparison");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("1. With lockObject");
        Console.WriteLine("2. Without lockObject");
        Console.WriteLine("0. Exit");
        Console.WriteLine();

        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RunThreadsWithLockObject();
                    break;
                case "2":
                    RunThreadsWithoutLockObject();
                    break;
                case "0":
                    exitProgram = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void RunThreadsWithLockObject()
    {
        Console.WriteLine("Running threads with lockObject");
        Console.WriteLine("-----------------------------");

        WorkerThread worker1 = new WorkerThread(true);
        WorkerThread worker2 = new WorkerThread(true);

        Thread thread1 = new Thread(worker1.DoWork);
        Thread thread2 = new Thread(worker2.DoWork);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }

    private static void RunThreadsWithoutLockObject()
    {
        Console.WriteLine("Running threads without lockObject");
        Console.WriteLine("--------------------------------");

        WorkerThread worker1 = new WorkerThread(false);
        WorkerThread worker2 = new WorkerThread(false);

        Thread thread1 = new Thread(worker1.DoWork);
        Thread thread2 = new Thread(worker2.DoWork);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}
