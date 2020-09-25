using System;
using System.IO;

namespace Bussen
{
    public class Passenger
    {
        public int age_;
        public string name_;

        public static int amountOfP = 0;

        public Passenger(int age, string name)
        {
            age_ = age;
            name_ = name;
            amountOfP++;

        }

        public Passenger()
        {
            string[] names = File.ReadAllLines(new Program().GetLibPath());

            
            

            age_ = new Random().Next(18, 80);
            name_ = names[new Random().Next(0, 999)];
            amountOfP++;
            
        }
    }

}