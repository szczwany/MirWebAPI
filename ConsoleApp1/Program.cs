using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            // DONE
            // Scraper.ScrapeMaps();

            // DONE
            //var mapSeed = new MapSeed();
            //mapSeed.CreateMapInserts();

            // DONE
            // Scraper.ScrapeMonsters();

            // var monsterSeed = new MonsterSeed();
            // monsterSeed.CreateMonster();

            // monsterSeed.CreateMonstersString();

            // Scraper.ScrapeNpcs();
            // Scraper.ScrapeFloors();

            // Scraper.ScrapeSkills();
            Scraper.ScrapeQuests();

            Console.ReadKey();
        }
    }
}
