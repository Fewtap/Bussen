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

            
            

        }
        

        
        
        public string GetLibPath()
        {
            string libPath = "";

            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX)){
               
                libPath = Directory.GetCurrentDirectory() + @"/Library/SvenskaNamn.txt";
                
            }
            else if(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows)){


                libPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\")) + @"Library\SvenskaNamn.txt";

            }

            return libPath;


        }

    }
}
