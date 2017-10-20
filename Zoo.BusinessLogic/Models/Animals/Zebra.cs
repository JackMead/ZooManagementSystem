using System;

namespace Zoo.BusinessLogic.Models.Animals
{
  public class Zebra : AnimalThatCanBeGroomed
  {
      private DateTime lastSweptOut;
      public Zebra(DateTime dateOfBirth) : base(dateOfBirth)
      {

      }

      public void SweepOut()
      {
          lastSweptOut = DateTime.Now;
      }
    }
}