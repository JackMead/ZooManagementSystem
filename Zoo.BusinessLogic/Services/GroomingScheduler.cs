using System.Collections.Generic;
using Zoo.BusinessLogic.Models;
using Zoo.BusinessLogic.Models.Animals;

namespace Zoo.BusinessLogic.Services
{
  public class GroomingScheduler : IScheduler
  {
    private static GroomingScheduler instance;

    public static GroomingScheduler Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new GroomingScheduler();
        }

        return instance;
      }
    }

    private GroomingScheduler()
    {
    }

    public void AssignJobs(IEnumerable<Keeper> keepers)
    {
      foreach (var keeper in keepers)
      {
        foreach (var animal in keeper.GetResponsibleAnimals())
        {
          var groomableAnimal = animal as AnimalThatCanBeGroomed;

          if (groomableAnimal != null)
          {
            keeper.GroomAnimal(groomableAnimal);
          }
        }
      }
    }
  }
}