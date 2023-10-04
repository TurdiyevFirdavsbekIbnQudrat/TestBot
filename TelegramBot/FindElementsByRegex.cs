using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net;
using System.Text.Json.Serialization;
namespace TelegramBot
{
    public class FindElementsByRegex
    {
        public string x { get; set; }
        public FindElementsByRegex(string soz)
        {
            x = soz;
        }
        public static List<string> NatijalarListi { get; set; }
        
        public static async void MalumotIzla(string x)
        {
            //   Console.WriteLine("Qidirayotgan narsangizni kiriting :");
            string Natijalar;
            NatijalarListi = new List<string>();
            // string x = Console.ReadLine();
            string str = "[";
            for (int i = 0; i < x.Length; i++)
            {
                if (!str.Contains(x[i].ToString())) str = str + x[i].ToString();
            }
            str += "]";

            using (HttpClient client = new HttpClient())
            {

                string BaseUrl = "https://api.publicapis.org/entries";
                HttpResponseMessage proces = await client.GetAsync(BaseUrl);
                string JsonResult = await proces.Content.ReadAsStringAsync();
                CountAndApi APIss = JsonConvert.DeserializeObject<CountAndApi>(JsonResult);
                //Console.WriteLine(JsonResult);

                foreach (var item in APIss.entries)
                {
                    if (Regex.IsMatch(item.API, str))
                    {
                        NatijalarListi.Add(item.API);
                    }
                }
            }
        }
        
        public static List<string> TopibOlinganlar()
        {
            
            return NatijalarListi; 
        }
        /*
        public static async Task<string> Task1(string BaseUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                return JsonResult;

            }
        }*/
}
}
