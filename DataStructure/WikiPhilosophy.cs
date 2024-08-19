using System.Net;

namespace DataStructure
{
    public class WikiPhilosophy
    {

        public static void Main(string[] args)
        {
            string destination = "https://en.wikipedia.org/wiki/Philosophy";
            string source = "https://en.wikipedia.org/wiki/Java_(programming_language)";

            testConjecture(destination, source, 10);
        }

        public static void testConjecture(string destination, string source, int limit)
        {
            var html = GetRequest(destination);
        }

        private static string GetRequest(string url)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) 
            { 
                using (StreamReader reader = new StreamReader(response.GetResponseStream())) 
                { 
                    return reader.ReadToEnd(); 
                } 
            }
        }
    }
}
