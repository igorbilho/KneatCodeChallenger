using KneatCodeChallenge.Services;
using KneatCodeChallenge.Utilities;
using System;

namespace KneatCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Author: Igor Abílio Santana Santos");
                Console.WriteLine("Created: 21/03/2018");

                Console.WriteLine();
                Console.WriteLine();

                int distance = 0;
                bool success = false;
                Console.Write("Could you inform a distance between 2 planets in MGLT: ");

                while (!success)
                {
                    try
                    {
                        distance = Convert.ToInt32(Console.ReadLine());
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The distance needs to be a integer.");
                        Console.WriteLine();
                        Console.Write("Please inform a distance between 2 planets in MGLT: ");
                    }
                }

                Console.WriteLine();

                Console.WriteLine("Result:");

                Conversion conversion = new Conversion();
                StarshipService starshipService = new StarshipService();

                try
                {
                    var starships = starshipService.GetAllStarships();
                    foreach (var starship in starships)
                    {
                        var hours = conversion.CalculateHours(starship.consumables);
                        var result = distance / (hours * Convert.ToInt32(starship.MGLT));
                        Console.WriteLine($"-> { starship.name }: { result } stop(s)");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine();
                Console.WriteLine();

                Console.Write("Would you like to make another simulation? If YES press Y or press ENTER to exit... ");
                ConsoleKeyInfo answer = Console.ReadKey();
                if (!answer.KeyChar.ToString().ToUpper().Equals("Y"))
                {
                    repeat = false;
                }
            }
        }
    }
}
