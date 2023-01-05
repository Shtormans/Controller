using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    internal static class APIResponseConverter
    {
        public static async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
        {
            var contentString = await response.Content.ReadAsStringAsync();

            var objResponse = JsonConvert.DeserializeObject<T>(contentString);

            return objResponse;
        }

        public static StringContent SerializeResponse<T>(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return content;
        }
    }
}
