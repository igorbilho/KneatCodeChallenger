using System;
using System.IO;
using System.Net;

namespace KneatCodeChallenge.Utilities
{
    class ApiRequest
    {
        const string uriBase = @"https://swapi.co";

        /// <summary>
        /// Response of the HTTP GET request
        /// </summary>
        /// <param name="obj">Object to be requested</param>
        /// <returns>Return a JSON with the result</returns>
        public string GetResponse(string obj)
        {
            var uri = $"{uriBase}/api/{obj}";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string myResponse = "";

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    myResponse = sr.ReadToEnd();
                }

                var startIndex = myResponse.IndexOf("results") + 9;
                var result = myResponse.Substring(startIndex);
                result = result.Substring(0, result.Length - 1);

                return result;
            }
            catch (Exception)
            {
                throw new Exception("Oops! Something is wrong with the SWAPI.");
            }
        }
    }
}
