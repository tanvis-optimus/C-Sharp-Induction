using System;
using System.Collections.Generic;

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
        // Initialises the Names and Addresses property
        public CompanyDetailsModelBL()
        {
            Names = new List<String>();
            Addresses = new List<String>();
        }
        #endregion

        //declaring properties
        public IList<String> Names { get; set; }
        public IList<String> Addresses { get; set; }
        public string NextPageToken { get; set; }

    }
}
