using System;
using System.Collections.Generic;
using ITCompanyFinder.DataAccessLayer;
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
        public bool HasCity = false;
        XmlDocument _mResponseDoc;
        IList<string> _companyNames;
        IList<string> _companyAddresses;      
        #endregion

        #region constructor
        public DataParsing()
        {
            //initialising lists
            _companyNames = new List<String>();
            _companyAddresses = new List<String>();           
            _mResponseDoc = new XmlDocument();
        }
        #endregion

        #region CallingApi
        /// <summary>
        /// this method calls a method which hits the api and returns response string
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public CompanyDetailsModelBL GetCompanyByLocation(String location, int count, string token)
        {
            DataFromAPI obj = new DataFromAPI();
            var response = obj.RequestToApi(location, count, token);
            return XmlParsing(response);
        }
        #endregion

        #region XML parsing
        /// <summary>
        /// this method parses the xml response from api 
        /// </summary>
        /// <param name="responseString"></param>
        /// <returns></returns>
        public CompanyDetailsModelBL XmlParsing(string responseString)

        {
            _mResponseDoc.LoadXml(responseString);
            XmlNodeList nextPageToken = _mResponseDoc.GetElementsByTagName("next_page_token");
            XmlNodeList nameList = _mResponseDoc.GetElementsByTagName("name");
            XmlNodeList addressList = _mResponseDoc.GetElementsByTagName("formatted_address");
            foreach (XmlNode node in nameList)
            {
                HasCity = true;
                _companyNames.Add(node.InnerText);
            }
            foreach (XmlNode node in addressList)
            {
                _companyAddresses.Add(node.InnerText);
            }
            foreach (XmlNode node in nextPageToken)
            {
                _nextPage = (node.InnerText);
            }
            return new CompanyDetailsModelBL
            {
                Names = _companyNames,
                Addresses = _companyAddresses,
                NextPageToken = _nextPage
            };
        }
        #endregion
    }

}
