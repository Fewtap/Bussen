
/*Hjälpkod för att komma igång
 * Notera att båda klasserna är i samma fil för att det ska underlätta.
 * Om programmet blir större bör man ha klasserna i separata filer såsom jag går genom i filmen
 * Då kan det vara läge att ställa in startvärden som jag gjort.
 * Man kan också skriva ut saker i konsollen i konstruktorn för att se att den "vaknar
 * Denna kod hjälper mest om du siktar mot betyget E och C
 * För högre betyg krävs mer självständigt arbete
 */
using System;
using System.Collections.Generic;
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
        string ErrorMessageParse = "Prova att bara skriva in siffror.";


        public void Run()
        {
            Console.WriteLine("Welcome to the awesome Buss-simulator");

            do
            {
                bool tryagain = true;
                int selection = 0;
                do
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine();

                    Console.WriteLine("  1. Add a passenger.");
                    Console.WriteLine("  2. Show the total age of all the passengers in the bus.");
                    Console.WriteLine("  3. Show passenger information.");
                    Console.WriteLine("  4. Calculate the average age of all the passengers in the bus.");
                    Console.WriteLine("  5. Find the oldest person.");
                    Console.WriteLine("  6. Hitta en passagerare via åldern.");
                    Console.WriteLine("  7. Sortera bussen efter ålder.");
                    Console.WriteLine("  8. Exit the program.");
                    Console.WriteLine();
                    Console.WriteLine("------------------------------");




                    try
                    {
                        selection = int.Parse(Console.ReadKey().KeyChar.ToString());
                        tryagain = false;
                    }
                    catch (Exception)
                    {

                        tryagain = true;
                        Console.Clear();
                        Console.WriteLine("Det du skrev in är inte en giltlig inmatning, prova igen.");
                        System.Console.WriteLine();
                    }
                } while (tryagain);



                switch (selection)
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

                        break;

                    case 5:
                        Console.Clear();
                        max_age();
                        break;
                    case 6:
                        Console.Clear();
                        find_age();
                        break;
                    case 7:
                        Console.Clear();
                        sort_buss();
                        break;
                    case 8:
                        Console.Clear();
                        programIsActive = false;
                        break;




                }

                tryagain = false;






            }
            while (programIsActive);


        }



        //Metoder för betyget E

        public void add_passenger()
        {

            bool loop = false;
            bool ParseSucessfull = true; //Check if the parse is sucessfull

            if (Passengers[Passengers.Length - 1] == null) //För att kolla så att inte bussen är full
            {
                do
                {
                    Console.WriteLine("  1. Skapa en passagerare med slumpmässigt namn och ålder.");
                    Console.WriteLine("  2. Skapa din egna passagerare.");
                    Console.WriteLine();

                    int selection = 0;



                    do
                    {
                        try
                        {
                            if (!ParseSucessfull)
                            {
                                Console.Clear();
                                System.Console.WriteLine("Tryck på 1 eller 2.");
                            }

                            selection = int.Parse(Console.ReadKey().KeyChar.ToString());
                            ParseSucessfull = true;
                        }
                        catch (Exception)
                        {
                            ParseSucessfull = false;
                        }
                    } while (!ParseSucessfull);


                    switch (selection)
                    {


                        case 1:
                            Passengers[Passenger.amountOfP] = new Passenger();
                            break;
                        case 2:

                            Console.Clear();
                            System.Console.Write("Skriv ett namn till din passagerare: ");
                            string name = Console.ReadLine();
                            System.Console.Write("Skriv in en ålder till din passagerare: ");
                            int age = 0;

                            try
                            {
                                age = int.Parse(Console.ReadLine());
                                if (age < 0)
                                {
                                    ParseSucessfull = false;
                                }
                                else
                                {
                                    ParseSucessfull = true;
                                }

                            }
                            catch (Exception)
                            {
                                ParseSucessfull = false;
                            }

                            Console.Clear();
                            System.Console.WriteLine("Välj könet av din passagerare:\n1. Man\n2. Kvinna");

                            string sex = "";
                            try
                            {
                                selection = int.Parse(Console.ReadKey().KeyChar.ToString());
                            }
                            catch (Exception)
                            {

                            }


                            switch (selection)
                            {
                                case 1:
                                    sex = "Man";
                                    break;
                                case 2:
                                    sex = "Kvinna";
                                    break;
                                default:
                                    System.Console.WriteLine("Det är inte en giltligt val.");
                                    break;
                            }


                            Passengers[Passenger.amountOfP] = new Passenger(age, name, sex);
                            break;

                        case 3:
                            return;
                        default:
                            Console.Clear();
                            System.Console.WriteLine("Det det du skrev in var inte giltligt försök igen.");
                            loop = true;
                            System.Console.WriteLine();
                            break;
                    }
                }
                while (loop == true);


                Console.Clear();
                System.Console.WriteLine(Passengers[Passenger.amountOfP - 1].name_ + " som är " + Passengers[Passenger.amountOfP - 1].age_ + " år, klev på bussen");


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
                if (Passengers[i] != null)
                {
                    Console.WriteLine("Namn: " + Passengers[i].name_);
                    Console.WriteLine("Ålder: " + Passengers[i].age_);
                    System.Console.WriteLine("Kön: " + Passengers[i].sex_);
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
                if (Passengers[i] != null)
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

            return Math.Round(totalAge / divisor, 2);


        }

        public void max_age()
        {
            int oldestPassengerI = 0;

            for (int i = 0; i < Passengers.Length; i++)
            {
                if (Passengers[i] != null)
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

        public void find_age()
        {
            Console.Clear();
            int selection = 0;
            bool loop = false;
            bool PassengerIsFound = false;
            List<Passenger> PassengersFound = new List<Passenger>();
            System.Console.WriteLine("1. Hitta en specifik ålder.\n2. Hitta en ålder inom ett specifikt omfång.");
            System.Console.WriteLine();
            do
            {
                try
                {
                    selection = int.Parse(Console.ReadKey().KeyChar.ToString());
                    loop = false;
                }
                catch (Exception)
                {
                    loop = true;
                }

            } while (loop);

            Console.Clear();

            switch (selection)
            {
                case 1:

                    System.Console.Write("Välj en ålder att söka på: ");

                    int ageSelection = 0;
                    do
                    {
                        try
                        {
                            ageSelection = int.Parse(Console.ReadLine());
                            loop = false;
                        }
                        catch (Exception)
                        {
                            System.Console.WriteLine(ErrorMessageParse);
                            loop = true;
                        }


                    } while (loop);

                    Console.Clear();
                    System.Console.WriteLine("Resultat:\n");



                    for (int i = 0; i < Passengers.Length; i++)
                    {
                        if (Passengers[i] != null)
                        {
                            if (ageSelection == Passengers[i].age_)
                            {

                                PassengersFound.Add(Passengers[i]);
                                PassengerIsFound = true;
                            }
                        }

                    }



                    if (PassengerIsFound)
                    {

                        foreach (var passenger in PassengersFound)
                        {
                            System.Console.WriteLine("Namn: " + passenger.name_ + "\nÅlder: " + passenger.age_ + "\nKön: " + passenger.sex_ + "\n");
                        }


                    }
                    else if (!PassengerIsFound)
                    {
                        System.Console.WriteLine("Det fanns ingen som hade den åldern.");
                    }

                    break;

                case 2:
                    int minAge = 0;
                    int maxAge = 0;

                    do
                    {
                        System.Console.Write("Välj minimum åldern: ");
                        try
                        {
                            minAge = int.Parse(Console.ReadLine());
                            loop = false;
                        }
                        catch (Exception)
                        {
                            System.Console.WriteLine(ErrorMessageParse);
                            loop = true;
                        }

                        System.Console.Write("Välj max åldern: ");
                        try
                        {
                            maxAge = int.Parse(Console.ReadLine());
                            loop = false;
                        }
                        catch (Exception)
                        {
                            System.Console.WriteLine(ErrorMessageParse);
                            loop = true;
                        }
                    } while (loop);




                    for (int i = 0; i < Passengers.Length; i++)
                    {
                        if (Passengers[i] != null)
                        {
                            if (Passengers[i].age_ > minAge && Passengers[i].age_ < maxAge)

                            {
                                PassengersFound.Add(Passengers[i]);
                                PassengerIsFound = true;

                            }
                        }
                    }
                    if (PassengerIsFound)
                    {
                        foreach (var passenger in PassengersFound)
                        {
                            System.Console.WriteLine("Namn: " + passenger.name_ + "\nÅlder: " + passenger.age_ + "\nKön: " + passenger.sex_ + "\n");
                        }
                    }
                    else if (!PassengerIsFound)
                    {
                        System.Console.WriteLine("Det fanns ingen som hade den åldern.");
                    }
                    break;

                default:
                    System.Console.WriteLine("Det är inte ett giltligt alternativ.");
                    break;
            }
        }

        public void sort_buss()
        {
            Passenger temp;

            for (int j = 0; j <= Passengers.Length - 2; j++)
            {
                for (int i = 0; i <= Passengers.Length - 2; i++)
                {
                    if (Passengers[i + 1] != null)
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

        public void getting_off()
        {
            List<Passenger> passengerHits = new List<Passenger>();
            bool PassengerIsFound = false;
            bool loop = false;

            System.Console.Write("Skriv namnet på passageraren som du vill ska gå av: ");
            string name = Console.ReadLine();
            for (int i = 0; i < Passengers.Length; i++)//Söker igenom hela bussen
            {
                if (Passengers[i] != null)
                {
                    for (int j = 0; j < 2; j++)//För att kolla både med stor och liten första bokstav.
                    {
                        switch (j)
                        {
                            case 0://Stor första bokstav
                                string nameWithUpper = name.Substring(0, 1).ToUpper();
                                if (nameWithUpper == Passengers[i].name_)
                                {
                                    passengerHits.Add(Passengers[i]);
                                    PassengerIsFound = true;
                                }
                                break;
                            case 1:
                                string nameWithLower = name.Substring(0, 1).ToLower();
                                if (nameWithLower == Passengers[i].name_)
                                {
                                    passengerHits.Add(Passengers[i]);
                                    PassengerIsFound = true;
                                }
                                break;
                        }
                    }
                }
            }

            if (PassengerIsFound == true)
            {
                int passengerIndex = 0;

                if (passengerHits.Count > 1)
                {
                    System.Console.WriteLine("Det fanns flera träffar: \n");

                    Passenger p;

                    for (int i = 0; i < passengerHits.Count; i++)
                    {
                        p = passengerHits[i];
                        System.Console.WriteLine(Convert.ToString((i + 1)) + ". Namn: " + p.name_ + "\nÅlder: " + p.age_ + "\nKön: " + p.sex_ + "\n");
                    }

                    System.Console.Write("Välj respektive nummer för att passageraren skall kliva av: ");

                    int selection = 0;

                    do
                    {
                        try
                        {
                            selection = int.Parse(Console.ReadKey().KeyChar.ToString());
                        }
                        catch (Exception)
                        {
                            loop = true;
                            System.Console.WriteLine(ErrorMessageParse + "\n");
                        }
                    } while (loop);

                    selection--;//Detta är för att numret som användaren skriver in skall motsvara rätt vektor index.

                    

                    for (int i = 0; i < Passengers.Length; i++)//Hitta passageraren i vektorn
                    {
                        if (Passengers[i] != null)
                        {
                            for (int j = 0; j < passengerHits.Count; j++)
                            {
                                if (passengerHits[j] == Passengers[i])
                                {
                                    passengerIndex = i;
                                }
                            }
                        }
                    }

                    for (int i = passengerIndex; i < Passengers.Length - 1; i++)
                    {
                        Passengers[i] = Passengers[i + 1];
                    }


                }

            }

        }
    }

}