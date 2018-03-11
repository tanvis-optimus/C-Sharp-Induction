using System;
using ITCompanyFinder.DataAccessLayer;

namespace ITCompanyFinder.BusinessLogic
{
    /// <summary>
    /// for  passing values in data access layer 
    /// contains fields required to hit the api
    /// </summary>
    public class SetLocationInDAL
    {
        public string GetCompanyByLocation(String location,int count, string token)
        {
            DataFromAPI obj = new DataFromAPI();
            var response = obj.RequestToApi(location,count,token);
            return response;
        }          
    }
}
