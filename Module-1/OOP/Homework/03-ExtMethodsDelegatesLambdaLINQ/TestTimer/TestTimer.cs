namespace TestTimer
{
    using System;
    using System.Threading;
    using TimerClass;
    using TimerEvent;

    public class TestTimer
    {
        public static void Main()
        {
            // Problem 7. Timer
            Console.WriteLine("Problem 7. Timer");
            TimerClass timerOne = new TimerClass(5, 2, delegate { PrintHello("Hello!"); });
            Thread threadT = new Thread(new ThreadStart(timerOne.Run));
            threadT.Start();

            Console.WriteLine(new string('=', 50));

            Console.WriteLine("Problem 8.* Events");
            TimerEventClass timerTwo = new TimerEventClass(2);
            timerTwo.Run();
        }

        public static void PrintHello(string input)
        {
            Console.WriteLine(input);
        }
    }
}
