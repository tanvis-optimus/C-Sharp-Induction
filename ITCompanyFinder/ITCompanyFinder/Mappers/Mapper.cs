using ITCompanyFinder.BusinessLogic;
using ITCompanyFinder.Models;

namespace ITCompanyFinder.Mappers
{
    /// <summary>
    /// Maps the details company entity from business logic
    /// to company details model 
    /// </summary>
    public static class Mapper    {

        public static CompanyDetailsModelUI GetCompanyDetails(CompanyDetailsModelBL entity)
        {
            var company = new CompanyDetailsModelUI();
            company.CompanyNames = entity.Company_Names;
            company.CompanyAddresses = entity.Company_Addresses;
            return company;
        }
    }
}