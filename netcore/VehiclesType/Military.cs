using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator
{
    public class Military : IVehicle
    {
        public String GetVehicleType()
        {
            return nameof(Military);
        }
    }
}