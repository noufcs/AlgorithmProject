using System;
using System.Collections.Generic;
using System.Linq;
namespace Dijkstra_AlgorithmProject
{
    public class InfoRepository
    {
        private IDictionary<string, ZipCode> _ZipCodeByName { get; set; }
        public InfoRepository()
        {
            _ZipCodeByName = new Dictionary<string, ZipCode>();
        }

        public void Add(ZipCode zipNo)
        {
            if(_ZipCodeByName.ContainsKey(zipNo.ZipCodeNumber))
            {
                throw new ArgumentException("'{0}' is already stored",zipNo.ZipCodeNumber);
            }
            _ZipCodeByName.Add(zipNo.ZipCodeNumber,zipNo);
        }

        public int getQuantity(String zipCode , string vehicleType)
        {
            if (_ZipCodeByName.ContainsKey(zipCode))
            {
                var zipcode = _ZipCodeByName[zipCode];
                var VehicleInfo = zipcode.Infos.FirstOrDefault(i => i.VehicleType == vehicleType);
                if (VehicleInfo != null)
                    return VehicleInfo.VehicleQuantity;
                else
                {
                    throw new ArgumentException("ZipCode" +zipCode+ "does not contain this Vehicle type");
                    
                }
            }
            else
            {
                throw new ArgumentException("ZipCode" + zipCode+ "is not found");
            }
        }

        public IDictionary<string,VehiclesInfo> GetTypesByZip(string type)
        {
            return _ZipCodeByName
                .Where(x => x.Value.Infos.Any(i => i.VehicleType == type))
                .ToDictionary(x => x.Key, x => x.Value.Infos.First(y => y.VehicleType == type));
        }
    }
}
