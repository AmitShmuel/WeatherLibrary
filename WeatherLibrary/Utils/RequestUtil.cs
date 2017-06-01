using System;
using System.Net;
using System.Xml;

namespace Utils
{
    /// <summary>
    /// This class is used to make different requests 
    /// to resources such as web services, filers, data bases, etc.
    /// </summary>
    static class RequestUtil
    {
        /// <summary>
        /// Returns an XML document response from a web service.
        /// </summary>
        /// <param name="requestUrl">The URL request to the web service</param>
        /// <returns>XML document describing the request</returns>
        /// <exception cref="Exception">Request could not be made.</exception>
        public static XmlDocument WebServiceRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
    }
}
