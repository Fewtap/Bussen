using System;
using System.IO;

namespace Bussen
{


    


    class Program
    {
        static void Main(string[] args)
        {
            Buss buss = new Buss();

            buss.Run();

            Console.ReadKey();

        }

        public string GetSolutionDir()
        {
            string buildPath = Directory.GetCurrentDirectory();


            for (int i = 0; i < 3; i++)
            {
                buildPath = Directory.GetParent(buildPath).ToString();
            }

            return buildPath;
        }

    }
}
