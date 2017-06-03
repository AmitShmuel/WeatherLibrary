using System;
using System.IO;
using System.Net;
using System.Xml.Linq;

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
        public static XDocument XmlWebServiceRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                return XDocument.Load(new StreamReader(response.GetResponseStream()));

                /*
                 * if too many requests have been made and the web service blocked access,
                 * you can use a txt file containing the xml data
                 */
                //return XDocument.Load(new StreamReader(@"weatherdata.txt"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
        }
    }
}
