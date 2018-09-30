using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchFilghts.Assignment.Models;
using SearchFilghts.Assignment.BusinessLogic;

namespace SearchFilghts.Assignment.Controllers
{
    public class searchFlightsController : Controller
    {
        
        //searchFlights/{origin}/{destination}
        [ValidateInput(true)]
        public ActionResult Index(SearchFlightModel inputSearch)
        {
            if (ModelState.IsValid)
            {

                List<SearchFlightModel> result = new List<SearchFlightModel>();

                SearchFlight source = new SearchFlight();
                result = source.searchFlighsByOriginDestination(inputSearch);
                
                ViewBag.NoRecordFound = false;
                //check flight count if its zero then message is created & if its greater than zero, flight list will be display on view. 
                if (result.Count <= 0)
                {
                    ViewBag.NoRecordFound = true;
                    ViewBag.Message = "No Flights Found for " + inputSearch.Origin + " --> " + inputSearch.Destination;
                }

                return View(result); 
            }
            else
            {
                //Model state is not valid, for validation please check the model 
                return RedirectToAction("Index", "InvalidRequest"); 
            }
        }
    }
}
