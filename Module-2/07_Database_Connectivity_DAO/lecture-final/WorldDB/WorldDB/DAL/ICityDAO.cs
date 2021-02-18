using System.Collections.Generic;
using WorldDB.Models;

namespace WorldDB.DAL
{
    interface ICityDAO
    {
        List<City> GetCitiesByCountry(string countryCode);
    }
}