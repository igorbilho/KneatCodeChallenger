using KneatCodeChallenge.Models;
using KneatCodeChallenge.Utilities;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace KneatCodeChallenge.Services
{
    class StarshipService
    {
        const string obj = "starships";

        /// <summary>
        /// Get all starships
        /// </summary>
        /// <returns>Return all starships</returns>
        public List<Starship> GetAllStarships()
        {
            try
            {
                ApiRequest apiRequest = new ApiRequest();
                string result = apiRequest.GetResponse(obj);

                var jss = new JavaScriptSerializer();
                var starships = jss.Deserialize<List<Starship>>(result);

                return starships;
            }
            catch (Exception ex)
            {
                throw new Exception("Oops! Something is wrong with the SWAPI.");
            }
        }
    }
}
