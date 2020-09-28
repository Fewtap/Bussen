
/*Hjälpkod för att komma igång
 * Notera att båda klasserna är i samma fil för att det ska underlätta.
 * Om programmet blir större bör man ha klasserna i separata filer såsom jag går genom i filmen
 * Då kan det vara läge att ställa in startvärden som jag gjort.
 * Man kan också skriva ut saker i konsollen i konstruktorn för att se att den "vaknar
 * Denna kod hjälper mest om du siktar mot betyget E och C
 * För högre betyg krävs mer självständigt arbete
 */
using System;
using System.IO;
using System.Linq;
//Nedan är namnet på "namespace" - alltså projektet. 
//SKapa ett nytt konsollprojekt med namnet "Bussen" så kan ni kopiera över all koden rakt av från denna fil
namespace Bussen
{
    class Buss
    {
        public Passenger[] Passengers = new Passenger[25];
        bool programIsActive = true;
        

        public void Run()
        {
            Console.WriteLine("Welcome to the awesome Buss-simulator");

            do
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine();

                Console.WriteLine("  1. Add a passenger.");
                Console.WriteLine("  2. Show the total age of all the passengers in the bus.");
                Console.WriteLine("  3. Show passenger information.");
                Console.WriteLine("  4. Calculate the average age of all the passengers in the bus.");
                Console.WriteLine("  5. Find the oldest person.");
                Console.WriteLine("  6. Exit the program.");
                Console.WriteLine();
                Console.WriteLine("------------------------------");

                bool tryagain = true;
                while (tryagain)
                {
                    try
                    {



                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1:
                                Console.Clear();
                                add_passenger();
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Den totala åldern av alla passagerare är: " + calc_total_age());
                                                             
                                break;
                            case 3:
                                Console.Clear();
                                print_buss();
                                Console.WriteLine();
                                
                                break;
                            case 4:
                                Console.Clear();
                                Console.WriteLine("Den genomsnittliga åldern i bussen är: " + calc_average_age() + " år.");
                                Console.Clear();
                                break;

                            case 5:
                                Console.Clear();
                                max_age();                                
                                break;
                            case 6:
                                programIsActive = false;
                                break;



                        }
                    }
                    catch (Exception)
                    {

                        tryagain = true;
                        Console.Clear();
                        Console.WriteLine("Det du skrev in är inte en giltlig inmatning, prova igen.");
                    }

                    tryagain = false;
                }
                
                
                
                
            }
            while (programIsActive);

            
        }

        

        //Metoder för betyget E
        
        public void add_passenger()
        {
            

            bool ParseSucessfull = true; //Check if the parse is sucessfull
            int _age = 0;
            if(Passengers[Passengers.Length - 1] == null) //För att kolla så att inte bussen är full
            {
                Console.WriteLine("  1. Skapa en passagerare med slumpmässigt namn och ålder.");
                Console.WriteLine("  2. Skapa din egna passagerare.");
                Console.WriteLine();

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Passengers[Passenger.amountOfP] = new Passenger();
                        break;
                    case 2:
                        do
                        {
                            Console.WriteLine();
                            if (ParseSucessfull)
                            {
                                Console.Write("Skriv in åldern på passageraren: ");
                            }
                            else if (!ParseSucessfull)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Skriv endast bara in siffror.");
                            }
                            ParseSucessfull = int.TryParse(Console.ReadLine(), out _age);

                        }
                        while (!ParseSucessfull);

                        
                        Console.Write("Skriv in ett namn på passageraren: ");
                        string _name = Console.ReadLine();




                        Passengers[Passenger.amountOfP] = new Passenger(_age, _name);
                        break;

                    default:
                        break;
                }

                Console.Clear();
                Console.WriteLine(Passengers[Passenger.amountOfP - 1].name_ + " som är " + Passengers[Passenger.amountOfP - 1].age_ + " år, klev på bussen.");
                
            }
            else
            {
                Console.WriteLine("Bussen är tyvärr full nu, be en passagerare att gå av innan en ny stiger på.");
            }
            

            
            
            

            //Lägg till passagerare. Här skriver man då in ålder men eventuell annan information.
            //Om bussen är full kan inte någon passagerare stiga på
        }
        
        
        

        public void print_buss()
        {
            Console.Clear();

            for (int i = 0; i < Passengers.Length; i++)
            {
                if(Passengers[i] != null)
                {
                    Console.WriteLine("Namn: " + Passengers[i].name_ );
                    Console.WriteLine("Ålder: " + Passengers[i].age_);
                    Console.WriteLine();
                }
                
                
            }
            Console.WriteLine("Det finns " + (Passengers.Length - Passenger.amountOfP) + " platser kvar.");
            
        }

        public int calc_total_age()
        {
            int ageSum = 0;

            for (int i = 0; i < Passengers.Length; i++)
            {
                if(Passengers[i] != null)
                {
                    ageSum += Passengers[i].age_;
                }
            }
            return ageSum;
        }

        public double calc_average_age()
        {
            int divisor = 0;
            double totalAge = Convert.ToDouble(calc_total_age());


            for (int i = 0; i < Passengers.Length; i++)
            {
                if (Passengers[i] != null)
                {
                    divisor++;
                }
            }

            return Math.Round(totalAge / divisor,2);

            
        }

        public void max_age()
        {
            int oldestPassengerI = 0;

            for (int i = 0; i < Passengers.Length; i++)
            {
                if(Passengers[i] != null)
                {
                    if (Passengers[oldestPassengerI].age_ < Passengers[i].age_)
                    {
                        oldestPassengerI = i;
                    }
                }
                
                
            }

            Passenger oldestP = Passengers[oldestPassengerI];
            Console.Clear();
            Console.WriteLine("The oldest passenger is " + oldestP.name_ + " who is " + oldestP.age_ + " years old.");
        }

        public void sort_bus()
        {

            Passenger temp;
            for (int j = 0; j <= Passengers.Length - 2; j++)
            {
                for (int i = 0; i <= Passengers.Length - 2; i++)
                {
                    if (Passengers[i].age_ > Passengers[i + 1].age_)
                    {
                        temp = Passengers[i + 1];
                        Passengers[i + 1] = Passengers[i];
                        Passengers[i] = temp;
                    }
                }
            }





        }
    }
}