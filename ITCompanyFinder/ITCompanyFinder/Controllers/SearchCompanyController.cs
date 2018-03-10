using System;
using System.Web.Mvc;
using ITCompanyFinder.BusinessLogic;

namespace ITCompanyFinder.Controllers
{
    public class SearchCompanyController : Controller
    {
        int hitcount=0;
        static string city;   
        
        // GET: SearchCompany
        public ActionResult Index()
        {
            return View();
        } 
        
        [HttpGet]
        public ActionResult GetDataFromUser()
        {           
            return View("SearchView");
        }

        [HttpPost]
        public ActionResult DisplayCompanies()
        {
            hitcount++;
            city = Request["tx_location"];

            SetLocationInDAL setLocation = new SetLocationInDAL();
            var result = setLocation.GetCompanyByLocation(city,hitcount,string.Empty);
            //GetParsedDataFromApi(result);
            DataParsing req = new DataParsing();
            var entity = req.XmlParsing(result);
            ViewBag.NextPageToken = entity.NextPageToken;
            var model = Mappers.Mapper.GetCompanyDetails(entity);
            ViewData["result"] = model;
            ViewBag.lasthitcount = hitcount;

            return View("CompaniesDataView", model);
        }
        [HttpPost]
        public ActionResult NextPage() {

            hitcount = Int32.Parse(Request["hitcountfromui"])+1;
            var nextPageToken = ViewBag.NextpageToken;
            SetLocationInDAL set = new SetLocationInDAL();
            nextPageToken = Request["token"];
            var result = set.GetCompanyByLocation(city,hitcount,nextPageToken);
          
            DataParsing req = new DataParsing();
            var entity = req.XmlParsing(result);
            ViewBag.NextPageToken = entity.NextPageToken;
            var model = Mappers.Mapper.GetCompanyDetails(entity);
            ViewData["result"] = model;
            ViewBag.lasthitcount = hitcount;
            return View(model);

        }    

    
}
}