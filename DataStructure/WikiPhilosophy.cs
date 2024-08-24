using NSoup;
using NSoup.Nodes;
using NSoup.Select;
using System.Net;

namespace DataStructure
{
    public class WikiPhilosophy
    {

        public static string BaseUrl = "https://en.wikipedia.org";

        private static List<string> visitedUrl = new();

        public static void Main(string[] args)
        {
            string destination = "https://en.wikipedia.org/wiki/Philosophy";
            string source = "https://en.wikipedia.org/wiki/Java_(programming_language)";

            testConjecture(destination, source, 10);
        }

        public static void testConjecture(string destination, string source, int limit)
        {
            string url = source;

            for (int i = 0; i < limit; i++)
            {

                if (visitedUrl.Contains(url))
                {
                    continue;
                }

                Console.WriteLine($"Fetching {url}");

                visitedUrl.Add(url);
                if (url.Equals(destination))
                {
                    break;
                }

                var html = GetRequest(url);

                Document doc = NSoupClient.Parse(html);

                Element content = doc.GetElementById("mw-content-text");
                Elements paragraphs  = content.GetElementsByTag("p");
                bool isFirstUriInit = false;

                string firstUri = String.Empty;

                foreach (var paragraph in paragraphs)
                {

                    var childs = paragraph.GetElementsByTag("a");

                    if (childs.First != null && childs.First.Attr("href").Contains("#") == false && isFirstUriInit == false)
                    {
                        firstUri = childs.First.Attr("href");
                        url = BaseUrl + firstUri;
                        Console.WriteLine($"** {firstUri} **");
                        isFirstUriInit = true;
                    }


                    foreach (var child in childs)
                    {
                        if (child.ClassName().Contains("external"))
                        {
                            continue;
                        }

                        var attr = child.Attr("href");


                        if (attr.Contains("#"))
                        {
                            continue;
                        }

                        var allLastUri = attr.Split("/");

                        var lastUri = allLastUri[allLastUri.Length - 1];

                        if (lastUri.Equals("Philosophy"))
                        {
                            url = BaseUrl + attr;
                            Console.WriteLine($"** {lastUri} **");
                            break;
                        }

                    }
                }
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
