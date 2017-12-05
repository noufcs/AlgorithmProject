using System;
using System.Collections.Generic;
namespace Dijkstra_AlgorithmProject
{
    public class ZipCode
    {
        public string ZipCodeNumber { get; set; }
        public ICollection<VehiclesInfo> Infos { get; set; }
        public ZipCode(string zipCodenumber)
        {
            ZipCodeNumber = zipCodenumber;
            Infos = new List<VehiclesInfo>();
        }


    }
}
