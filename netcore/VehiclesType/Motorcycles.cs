using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator
{
    public class Motorcycles : IVehicle
    {
        public string GetVehicleType()
        {
            return nameof(Motorcycles);
        }
    }
}