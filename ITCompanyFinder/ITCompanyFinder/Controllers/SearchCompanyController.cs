﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ITCompanyFinder.BusinessLogic;
using ITCompanyFinder.Models;

namespace ITCompanyFinder.Controllers
{
    public class SearchCompanyController : Controller
    {
        static int hitcount;
        static string city;
        string token;


        // GET: SearchCompany
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDataFromUser()
        {
            hitcount = 0;
            return View("SearchView");
        }

        [HttpPost]
        public ActionResult GetDataFromUser1()
        {
            hitcount = 0;
            return View("SearchView");
        }

        [HttpPost]
        public ActionResult DisplayCompanies()
        {
            hitcount = Int32.Parse(Request["sethitcount"]);
            hitcount++;
            city = Request["tx_location"];
            token = string.Empty;
            var selectedCompanies = GetData();
            return View("CompaniesDataView", selectedCompanies);

        }


        public ActionResult NextPage()
        {

            hitcount = Int32.Parse(Request["hitcountfromui"]) + 1;
            token = ViewBag.NextpageToken;
            token = Request["token"];
            var selectedCompanies = GetData();
            return View("CompaniesDataView", selectedCompanies);


        }


        private List<CompanyDetailsModelUI> GetData()
        {
            DataParsing setLocation = new DataParsing();
            var result = setLocation.GetCompanyByLocation(city, hitcount, token);
            ViewBag.HasResponse = setLocation.HasCity;

            //Convert to companyDetailModel list 
            var selectedCompanies = new List<CompanyDetailsModelUI>();
            for (int index = 0; index < result.Company_Names.Count; index++)
            {
                var company = new CompanyDetailsModelUI
                {
                    CompanyNames = result.Company_Names[index],
                    CompanyAddresses = result.Company_Addresses[index]
                };
                selectedCompanies.Add(company);
            }
            ViewBag.NextPageToken = result.NextPageToken;
            ViewBag.lasthitcount = hitcount;
            return selectedCompanies;
        }
    }

}