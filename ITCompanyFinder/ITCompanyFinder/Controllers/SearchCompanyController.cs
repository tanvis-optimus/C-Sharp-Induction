using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ITCompanyFinder.BusinessLogic;
using ITCompanyFinder.Models;

namespace ITCompanyFinder.Controllers
{
    public class SearchCompanyController : Controller
    {
        #region Variables
        static int _hitCount;
        static string _city;
        string _mtoken;
        #endregion

        #region Action for HomePage
        [HttpGet]
        public ActionResult GetDataFromUser()
        {
            ViewBag.title = "IT Company Finder";
            return View("SearchView");
        }
        #endregion

        #region Action on search button
        /// <summary>
        ///  get city entered by user and 
        /// display the list of companies
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DisplayCompanies()
        {
            ViewBag.title = "List Of Companies";
            _hitCount = Int32.Parse(Request["sethitcount"]);
            _hitCount++;
            _city = Request["tx_location"];
            ViewBag.city = _city;
            _mtoken = string.Empty;
            var selectedCompanies = GetData();
            return View("CompaniesDataView", selectedCompanies);
        }
        #endregion

        #region Action on next button
        public ActionResult NextPage()
        {
            ViewBag.title = "List Of Companies";
            _hitCount = Int32.Parse(Request["hitcountfromui"]) + 1;
            _mtoken = ViewBag.NextpageToken;
            _mtoken = Request["token"];
            var selectedCompanies = GetData();
            return View("CompaniesDataView", selectedCompanies);
        }
        #endregion

        #region Send Data to view
        /// <summary>
        /// this method gets data from business logic and 
        /// sends the result to view
        /// </summary>
        /// <returns></returns>
        private List<CompanyDetailsModelUI> GetData()
        {
            DataParsing setLocation = new DataParsing();
            var result = setLocation.GetCompanyByLocation(_city, _hitCount, _mtoken);
            ViewBag.HasResponse = setLocation.HasCity;

            //Convert to companyDetailModel list 
            var selectedCompanies = new List<CompanyDetailsModelUI>();
            for (int index = 0; index < result.Names.Count; index++)
            {
                var company = new CompanyDetailsModelUI
                {
                    CompanyNames = result.Names[index],
                    CompanyAddresses = result.Addresses[index]
                };
                selectedCompanies.Add(company);
            }
            ViewBag.NextPageToken = result.NextPageToken;
            ViewBag.lasthitcount = _hitCount;
            return selectedCompanies;
        }
        #endregion
    }

}