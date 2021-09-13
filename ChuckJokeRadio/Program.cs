using System;
using System.Net.Http;

namespace ChuckJokeRadio
{
    class Program
    {
        //TODO plocka även ut och visa datumet för när skämtet skapades/senast uppdaterades
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            while (true)
            {
                string url = @"https://api.chucknorris.io/jokes/random";
                string json = client.GetStringAsync(url).Result;

                //JOKE
                string startTag = "\"value\":\"";
                int start = json.IndexOf(startTag) + startTag.Length;
                int end = json.IndexOf("\"}", start);

                string joke = json.Substring(start, end - start);


                //DATE
                string startDate = "\"created_at\":\"";
                int dStart = json.IndexOf(startDate) + startDate.Length;
                int dEnd = json.IndexOf("\",");

                string dateValue = json.Substring(dStart, dEnd - dStart);

                string dateString = dateValue;
                DateTime date = DateTime.Parse(dateString);
      
                
                
                //CONSOLE
                Console.WriteLine(joke);
                Console.WriteLine(date.ToString("D"));

                Console.WriteLine();
                Console.Write("Press enter for another joke");
                Console.ReadLine();

                Console.Clear();

                /*
                 * Json DATA FORMATED
                 * 
                     {
                      "categories": [],
                      "created_at": "2020-01-05 13:42:28.143137",
                      "icon_url": "https://assets.chucknorris.host/img/avatar/chuck-norris.png",
                      "id": "f4rYv3-iRJ6qRw5Y0FaZgw",
                      "updated_at": "2020-01-05 13:42:28.143137",
                      "url": "https://api.chucknorris.io/jokes/f4rYv3-iRJ6qRw5Y0FaZgw",
                      "value": "When Chuck Norris was in high school he was the star of his debate team. It was quite a feat for someone whose rebuttal was always; \"no\"."
                      }
                */


            }
        }
    }
}
