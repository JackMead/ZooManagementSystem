using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zoo.BusinessLogic.Models;
using Zoo.BusinessLogic.Models.Animals;
using Zoo.BusinessLogic.Services;

namespace Zoo.ConsoleApp
{
    public static class Program
    {

        public static void Main()
        {
            var lions = new[]
            {
                new Lion(new DateTime(2010, 4, 28)),
                new Lion(new DateTime(2012, 5, 11))
            };
            var otherAnimals = new Animal[]
            {
                new Rabbit(new DateTime(2014, 1, 1)),
                new Zebra(new DateTime(2008, 12, 1)),
                new GuineaFowl(new DateTime(1994,9,15)), 
            };
            var animals = lions.Union<Animal>(otherAnimals).ToList();

            var keepers = new[]
            {
                new Keeper(lions),
                new Keeper(otherAnimals)
            };


            var feedingScheduler = FeedingScheduler.Instance;
            var groomingScheduler = GroomingScheduler.Instance;

            var schedulers = new IScheduler[]
            {
                feedingScheduler,
                groomingScheduler
            };

            while (true)
            {
                Console.WriteLine("Feeding the animals...");
                Console.WriteLine("Grooming the animals...");
                foreach (var scheduler in schedulers)
                {
                    scheduler.AssignJobs(keepers);
                }

                Console.WriteLine("Done. Results:");

                foreach (var animal in animals)

                {
                    Console.WriteLine(animal);
                }

                Console.WriteLine();
                Thread.Sleep(1000);
            }

            
        }
    }
}
