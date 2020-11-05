using System;
using System.IO;

namespace Bussen
{
    public class Passenger
    {
        public int age_;
        public string name_;
        public string sex_;

        public static int amountOfP = 0;

        public Passenger(int age, string name)
        {
            age_ = age;
            name_ = name;
            amountOfP++;

        }

        public Passenger()
        {
            string[] nameAndSexList = File.ReadAllLines(GetLibPath()); //Samlar in alla namn och kön som finns i en CSV fil i "Library"

            int nameIndex = new Random().Next(0, (nameAndSexList.Length - 1)); // Skapar en slumpmässig index för att bestämma namn och kön




            age_ = new Random().Next(18, 80);
            name_ = nameAndSexList[nameIndex].Split(",")[0];//Namn är bakom komma tecken alltså delar vi vid komma tecknet och tar index 0 i vektorn som metodern returnerar.
            sex_ = nameAndSexList[nameIndex].Split(",")[1];//Här väljer vi könet som är framför kommatecknet och därför väljer vi index 1 i vektorn som metoden returnerar.

            amountOfP++;

        }

        public string GetLibPath()
        {
            string libPath = "";

            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
            {

                libPath = Directory.GetCurrentDirectory() + @"/Library/SvenskaNamnOchKön.csv";

            }
            else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Linux))
            {
                libPath = Directory.GetCurrentDirectory() + @"/Library/SvenskaNamnOchKön.csv";
            }
            else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
            {

                libPath = System.Environment.CurrentDirectory + @"\Library\SvenskaNamnOchKön.csv";
                

            }

            return libPath;


        }
    }

}