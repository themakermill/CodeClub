using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductsApiApp.Models;

namespace ProductsApiApp.Controllers
{
    public class CitysController : ApiController
    {
        City[] cities = new City[]
        {
            new City { Id = 1, Name = "North Andover", State = "MA"},
            new City { Id = 2, Name = "San Francisco", State = "CA"},
            new City { Id = 3, Name = "Phoenix", State = "AZ"}
        };

        public IEnumerable<City> GetAllCities()
        {
            return cities;
        }

        public IHttpActionResult GetCity(int id)
        {
            var city = cities.FirstOrDefault((p) => p.Id == id);

            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }
    }
}
