using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConwaysGameOfLife.Helpers;

namespace ConwaysGameOfLife
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConwayTimer timer = new ConwayTimer();

            var aTimer = timer.GetTimer(1000);

            aTimer.Start();

            Console.ReadLine();
        }
    }
}
