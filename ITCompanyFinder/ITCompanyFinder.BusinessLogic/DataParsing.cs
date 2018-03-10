using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;


namespace ITCompanyFinder.BusinessLogic
{
    /// <summary>
    /// this calss parses the api response 
    /// and sets data on model class
    /// </summary>
    public class DataParsing
    {
        #region variables
        string _nextPage;
        XmlDocument _mResponseDoc;
        IList<string> Company_Names;
        IList<string> Company_Addresses;
        List<string> Details;
        #endregion

        #region constructor
        public DataParsing()
        {
            //initialising lists
            Company_Names = new List<String>();
            Company_Addresses = new List<String>();
            Details = new List<String>();
            _mResponseDoc = new XmlDocument();
        }
        #endregion        

        #region XML parsing
        /// <summary>
        /// this method parses the xml response from api
        /// </summary>
        /// <param name="responsestring"></param>
        /// <returns></returns>
        public CompanyDetailsModelBL XmlParsing(string responsestring)

        {
            _mResponseDoc.LoadXml(responsestring);
            XmlNodeList nextPageToken = _mResponseDoc.GetElementsByTagName("next_page_token");
            XmlNodeList nameList = _mResponseDoc.GetElementsByTagName("name");
            XmlNodeList addressList = _mResponseDoc.GetElementsByTagName("formatted_address");
            foreach (XmlNode node in nameList)
            {
                Company_Names.Add(node.InnerText);
            }

            foreach (XmlNode node in addressList)
            {
                Company_Addresses.Add(node.InnerText);
            }
            //foreach (var word in Company_Names.Zip(Company_Addresses, (companyNamesObj, companyAddressObj) => new { companyNamesObj, companyAddressObj }))
            //{
            //    Details.Add(word.companyNamesObj + "  ----  " + word.companyAddressObj);
            //}
            foreach (XmlNode node in nextPageToken)
            {
                _nextPage = (node.InnerText);
            }
            return new CompanyDetailsModelBL
            {
               Company_Names = Company_Names,
               Company_Addresses = Company_Addresses,
                NextPageToken = _nextPage
            };
        }
        #endregion
    }

}
