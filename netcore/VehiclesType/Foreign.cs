using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator
{
    public class Foreign : IVehicle
    {
        public String GetVehicleType()
        {
            return nameof(Foreign);
        }
    }
}