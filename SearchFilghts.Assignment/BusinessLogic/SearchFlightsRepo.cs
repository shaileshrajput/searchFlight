using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchFilghts.Assignment.Providers;
using SearchFilghts.Assignment.DataAccess;
using SearchFilghts.Assignment.Models;
using System.Data;

namespace SearchFilghts.Assignment.BusinessLogic
{
    public class SearchFlightsRepo
    {
        IDataProvider provider;
        //Inversion of control
        public SearchFlightsRepo(IDataProvider objProvider)
        {
            provider = objProvider;
        }
        /// <summary>
        /// Returns the filtered & sorted flight data. This function combines data from all three sources and return filtered & sorted flight data 
        /// </summary>
        /// <param name="inputSearch"> model having values for Orign & Destination</param>
        /// <returns>List of filtered,sorted </returns>
        public List<SearchFlightModel> ReadFlightData(SearchFlightModel model)
        {
            IDataRepository repository = new DataRepository();
            DataTable resultDT = repository.ReadDataFromProvider(provider.GetProviderName(), provider.GetProviderFileSeprator());
            //get the flight data from datatable
            List<SearchFlightModel> items = resultDT.AsEnumerable()
                                                    .Where(row => row.Field<string>("Origin") == model.Origin && row.Field<string>("Destination") == model.Destination)
                                                    .Select(row =>
                                                    new SearchFlightModel
                                                    {
                                                        Origin = row.Field<string>("Origin"),
                                                        DepartureTime = row.Field<DateTime>("Departure Time"),
                                                        Destination = row.Field<string>("Destination"),
                                                        DestinationTime = row.Field<DateTime>("Destination Time"),
                                                        Price = row.Field<float>("Price")
                                                    }).Distinct().OrderBy(x => x.Price).ThenBy(x => x.DepartureTime).ToList();

            return items;
        }

    }
}