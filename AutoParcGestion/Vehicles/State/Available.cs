using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGestion.Vehicles.State
{
    public class Available : TransfertState
    {
        public override void ChangeState()
        {
            VVehicle.TransfertState = new Ordered();
        }

        public override string ToString()
        {
            return "Available";
        }
    }
}
