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
        

        
        
        public string GetLibPath()
        {
            string libPath = "";
            
            if(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX)){
                libPath = Directory.GetCurrentDirectory() + @"/Library/SvenskaNamn.txt";
            }
            else if(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows)){
            for (int i = 0; i < 3; i++)
            {
                libPath = Directory.GetParent(libPath).ToString() + @"\Library\SvenskaNamn.txt";
            }
            }
            

            return libPath;
        }

    }
}
