using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSamples.Consumer.Shared
{
    public static class APICaller
    {
        public static async Task<HttpResponseMessage> Call(string url, string id)
        {
            using(var client = new HttpClient() { BaseAddress=new Uri(url)})
            {
                try
                {
                    var response = await client.GetAsync($"/api/person/?id={id}");
                    return response;
                }
                catch (Exception ex) {
                    throw new Exception("Problem in connecting to the Api");
                }
            }
        }
    }
}
