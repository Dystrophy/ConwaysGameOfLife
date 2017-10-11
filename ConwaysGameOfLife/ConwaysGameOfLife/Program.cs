using System;
using ConwaysGameOfLife.Helpers;

namespace ConwaysGameOfLife
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConwayTimer timer = new ConwayTimer(20,40);

            var aTimer = timer.GetTimer(500);

            aTimer.Start();

            Console.ReadLine();
        }
    }
}
