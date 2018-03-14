using System;
using System.IO;
using System.Net;


namespace ITCompanyFinder.DataAccessLayer
{
    /// <summary>
    /// this class requests the api
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
            _mApiKey = "AIzaSyDQ9ooOBSyT6zTqhdx_-msCjWqJUPECxl8";
            _mUrl = "https://maps.googleapis.com/maps/api/place/textsearch/xml?";
        }
        #endregion

        #region RequestToApi
        /// <summary>
        /// this method hits the api and returns the response
        /// </summary>
        /// <param name="location"></param>
        /// <param name="hitCount"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public String RequestToApi(String location, int hitCount, string token)
        {
            if (hitCount == 1)
            {
                //concatenating results to form complete url
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
