using System;
using System.Collections.Generic;
using System.Text;

namespace ITCompanyFinder.BusinessLogic
{
    /// <summary>
    ///  model for company details 
    ///  includes compane name,address
    ///  and next token for api
    /// </summary>
    public class CompanyDetailsModelBL
    {
        #region constructor
        // Initialises the company details property
        public CompanyDetailsModelBL()
        {
            Company_Names = new List<String>();
            Company_Addresses = new List<String>();
        }
        #endregion

        //declaring properties
        public IList<String> Company_Names { get; set; }
        public IList<String> Company_Addresses { get; set; }
        public string NextPageToken { get; set; }

    }
}
