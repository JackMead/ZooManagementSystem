using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic.Models.Animals
{
    class Mammoth : Animal
    {
        private DateTime lastSweptOut;
        public Mammoth(DateTime dateOfBirth) : base(dateOfBirth)
        {

        }

        public void SweepOut()
        {
            lastSweptOut = DateTime.Now;
        }
    }
}
