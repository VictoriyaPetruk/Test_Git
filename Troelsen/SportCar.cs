using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Troelsen
{
    public class SportCar : Car
    {
        public string GetPetName()
        {
            Petname = "Fred";
            return Petname;
        }
    }
}