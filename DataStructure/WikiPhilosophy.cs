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
            for (int i = 0; i < limit; i++)
            {
                var html = GetRequest(source);

                Document doc = NSoupClient.Parse(html);

                Element content = doc.GetElementById("mw-content-text");
                Elements paragraphs  = content.GetElementsByTag("p");

                string firstUri = String.Empty;

                foreach (var paragraph in paragraphs)
                {

                    var childs = paragraph.GetElementsByTag("a");

                    foreach (var child in childs)
                    {
                        if (child.ClassName().Contains("external"))
                        {
                            continue;
                        }

                        var attr = child.Attr("href");

                        var allLastUri = attr.Split("/");


                        var lastUri = allLastUri[allLastUri.Length - 1];

                        if (lastUri.StartsWith("#"))
                        {
                            continue;
                        }

                        firstUri = lastUri;

                        if (lastUri.Equals("Philosophy"))
                        {

                            Console.WriteLine(lastUri);
                            break;
                        }
                    }
                }

                var sourceSplited = source.Split("/");
                sourceSplited[sourceSplited.Length - 1] = firstUri;

                source = string.Concat(sourceSplited);
                Console.WriteLine(source);
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
