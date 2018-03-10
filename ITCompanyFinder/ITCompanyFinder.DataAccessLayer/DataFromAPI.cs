using System;
using System.IO;
using System.Net;


namespace ITCompanyFinder.DataAccessLayer
{
    /// <summary>
    /// this classs hits requests the api
    /// </summary>
    public class DataFromAPI
    {

        #region Variables       
        string _mApiKey;
        string _mUrl;
        string _mReq;
        string _mResponseString;
        #endregion

        #region Constructor
        public DataFromAPI()
        {

            _mApiKey = "AIzaSyAMCUtWMud-HGlFfZpSJdPhE6nxu_xDkaU";
            _mUrl = "https://maps.googleapis.com/maps/api/place/textsearch/xml?";

        }
        #endregion        

        #region RequestToApi
        /// <summary>
        /// this method hits the api and returns the response
        /// </summary>
        /// <returns></returns>
        public String RequestToApi(String location, int hitcount, string token)
        {
            if (hitcount == 1)
            { //concatenating results to form complete url
                _mReq = _mUrl + "query=" + "IT+companies+in+" + location + "&key=" + _mApiKey;

            }

            else
            {
                _mReq = _mUrl + "query=" + "IT+companies+in+" + location + "&key=" + _mApiKey + "&pagetoken=" + token;

            }

            //requesting API
            WebRequest request = WebRequest.Create(
             _mReq);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            _mResponseString = reader.ReadToEnd();
            return (_mResponseString);
        }
        #endregion
    }

}
