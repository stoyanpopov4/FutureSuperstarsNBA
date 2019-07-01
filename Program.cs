using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace FutureSuperstarsNBA
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxYears, minRating, currentYear, currentYearsPlayed;
            bool isQualified = false;

            DateTime current = DateTime.Now;
            currentYear = current.Year;

            string jsonPath = @"C:\Users\stoqn\source\repos\FutureSuperstarsNBA\FutureSuperstarsNBA\Players.json";
            string csvPath = @"C:\Users\stoqn\source\repos\FutureSuperstarsNBA\FutureSuperstarsNBA\QualifiedPlayers.txt";

            string json = File.ReadAllText(jsonPath);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var playerList = ser.Deserialize<List<Players>>(json);

            Console.WriteLine("Please enter the maximum years played in the league and the minimum rating that is required from players to qualify.\n ");

            if(int.TryParse(Console.ReadLine(), out maxYears) && int.TryParse(Console.ReadLine(), out minRating))
            {
                using (StreamWriter file = new StreamWriter(csvPath))
                {
                    file.WriteLine("Name" + "," + "Rating");
                    foreach (var player in playerList)
                    {
                        currentYearsPlayed = currentYear - player.PlayingSince;
                        if (currentYearsPlayed <= maxYears && player.Rating >= minRating)
                        {
                            isQualified = true;
                            file.WriteLine(player.ToCSV());   
                        }
                    }

                    if(isQualified == true)
                        Console.WriteLine("\nSucces. The players that qualified are recorded correct.");
                    else
                        Console.WriteLine("\nThere isnt any players ho match the requirements.");
                }
            }
            else
                Console.WriteLine("You have entered incorrect data.");
        }
    }
}
