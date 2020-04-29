using System;
using System.Threading;

namespace DockerSamples.Docker01
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine("Hello World!");
                Thread.Sleep(1000);
            }

        }
    }
}
