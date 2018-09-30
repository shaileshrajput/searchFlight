using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using SearchFilghts.Assignment.Providers;
using SearchFilghts.Assignment.Models;

namespace SearchFilghts.Assignment.BusinessLogic
{
    public class SearchFlight
    {
        /// <summary>
        /// Returns the filtered & sorted flight data. This function combines data from all three sources and return filtered & sorted flight data 
        /// </summary>
        /// <param name="inputSearch"> model having values for Orign & Destination</param>
        /// <returns>List of filtered,sorted </returns>
        public List<SearchFlightModel> searchFlighsByOriginDestination(SearchFlightModel inputSearch)
        {
            //Depenancy Injection
            SearchFlightsRepo source1 = new SearchFlightsRepo((new DBProvider1()));
            SearchFlightsRepo source2 = new SearchFlightsRepo((new DBProvider2()));
            SearchFlightsRepo source3 = new SearchFlightsRepo((new DBProvider3()));
            //get filtered the data from provider
            List<SearchFlightModel> sourcedata1 = source1.ReadFlightData(inputSearch);
            List<SearchFlightModel> sourcedata2 = source2.ReadFlightData(inputSearch);
            List<SearchFlightModel> sourcedata3 = source3.ReadFlightData(inputSearch);

            //combines the result of all three provider
            var combinedResult = ((from p1 in sourcedata1 select p1)
                        .Union(from p2 in sourcedata2 select p2)
                        .Union(from p3 in sourcedata3 select p3)).ToList();
            //remove the duplicate records & sort them by Price & departureTime
            List<SearchFlightModel> result = combinedResult.GroupBy(d => new { d.Origin, d.DepartureTime, d.Destination, d.DestinationTime, d.Price })
                                        .Select(d => d.First()).OrderBy(x => x.Price).ThenBy(x => x.DepartureTime).ToList();
            return result;
        }
        
    }
}