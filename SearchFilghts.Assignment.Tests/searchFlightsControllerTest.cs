using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Web.Mvc;
using System.Collections.Generic;
using SearchFilghts.Assignment.Models;
using SearchFilghts.Assignment.BusinessLogic;
using SearchFilghts.Assignment.Controllers;

namespace SearchFilghts.Assignment.Tests
{
    [TestClass]
    public class searchFlightsControllerTest
    {
        [TestMethod]
        public void TestInvalidModelState()
        {
            SearchFlightModel inputSearch = new SearchFlightModel() { Origin = "", Destination = "" };
            searchFlightsController controller = new searchFlightsController();
            controller.ModelState.AddModelError("Required", "Required");
            var result = controller.Index(inputSearch) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("InvalidRequest", result.RouteValues["controller"]);
        }
        [TestMethod]
        public void TestValidModelState()
        {
            SearchFlightModel inputSearch = new SearchFlightModel() { Origin = "LAS", Destination = "LAX" };
            searchFlightsController controller = new searchFlightsController();
            var result = controller.Index(inputSearch) as ViewResult;
            Assert.AreEqual(false, result.ViewBag.NoRecordFound);
        }
        [TestMethod]
        public void TestNoFlightFound()
        {
            SearchFlightModel inputSearch = new SearchFlightModel() { Origin="abc",Destination="wxy"};
            searchFlightsController controller = new searchFlightsController();
            ViewResult view = controller.Index(inputSearch) as ViewResult;
            Assert.AreEqual(true, view.ViewBag.NoRecordFound);
            Assert.AreEqual("No Flights Found for " + inputSearch.Origin + " --> " + inputSearch.Destination, view.ViewBag.Message);
        }
        [TestMethod]
        public void TestFlightsFound()
        {
            SearchFlightModel inputSearch = new SearchFlightModel() { Origin = "MIA", Destination = "ORD" };
            searchFlightsController controller = new searchFlightsController();
            var result = controller.Index(inputSearch) as ViewResult;
            Assert.AreEqual(false, result.ViewBag.NoRecordFound);
        }
        [TestMethod]
        public void TestFlightsExpectedResults()
        {
            SearchFlightModel inputSearch = new SearchFlightModel() { Origin = "LHR", Destination = "BOS" };

            List<SearchFlightModel> expectedResult = new List<SearchFlightModel>();
            SearchFlight source = new SearchFlight();
            expectedResult = source.searchFlighsByOriginDestination(inputSearch);

            searchFlightsController controller = new searchFlightsController();
            var view = controller.Index(inputSearch) as ViewResult;
            List<SearchFlightModel> actualResult = (List<SearchFlightModel>) view.ViewData.Model;
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            if (expectedResult.Count > 0)
            {
                for (int i = 0; i >= expectedResult.Count; i++)
                {
                    Assert.AreEqual(expectedResult[i].Origin, actualResult[i].Origin);
                    Assert.AreEqual(expectedResult[i].DepartureTime, actualResult[i].DepartureTime);
                    Assert.AreEqual(expectedResult[i].Destination, actualResult[i].DestinationTime);
                    Assert.AreEqual(expectedResult[i].DestinationTime, actualResult[i].DestinationTime);
                    Assert.AreEqual(expectedResult[i].Price, actualResult[i].Price);
                }
            }
        }
    }
}
