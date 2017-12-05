using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dijkstra_AlgorithmProject
{
    public class VehiclesInfo
    {
        public string VehicleType { get; set; }
        public int VehicleQuantity { get; set; }

        public VehiclesInfo(string type , int quantity)
        {
            VehicleType = type;
            VehicleQuantity=quantity;
        }

    }

}
