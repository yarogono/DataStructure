using NSoup;
using NSoup.Nodes;
using NSoup.Select;
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

            Document doc = NSoupClient.Parse(html);

            Element content = doc.GetElementById("mw-content-text");
            Elements paragraphs  = content.GetElementsByTag("p");

            foreach (Element p in paragraphs)
            {
                Elements links = p.Select("a[href]");
                foreach (Element link in links)
                {
                    Console.WriteLine($" * a: <{link.Attr("href")}>  ({trim(link.Text(), 35)})");
                }
                break;
            }

            Console.ReadLine();
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

        private static String trim(string s, int width)
        {
            if (s.Length > width)
                return s.Substring(0, width - 1) + ".";
            else
                return s;
        }
    }
}
