using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Helpers;
using Newtonsoft.Json;
using Microsoft.CSharp.RuntimeBinder;

namespace GreenBeePrinter
{
    public static class ApiCore
    {
        const String apiBaseUrl = "http://localhost/greenbapi/";

        public static async Task<T> getJsonObj<T>(string action, Dictionary<string, string> postParams) where T : new()
        {
            using (var client = new HttpClient())
            {
                char[] charsToTrim = { ','};
                String postData = "{\"Request-Agent\":\"Android\",\"data\":{";

                if (postParams != null)
                    foreach (var item in postParams)
                    {
                        postData += "\"" + item.Key + "\"" + ":" + "\"" + item.Value + "\",";
                    }
                
                postData = postData.TrimEnd(charsToTrim) + "}}";
                
                //MessageBox.Show(postData);
                //String postData = "{\"Request-Agent\":\"Android\",\"data\":{\"loginid\":\"cashier01\",\"password\":\"123456\"}}";

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, apiBaseUrl + action);
                requestMessage.Headers.Add("Authorization", "Cashier-Login");
                requestMessage.Content = new StringContent(postData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    string responseAsString = await response.Content.ReadAsStringAsync();

                    dynamic jsonResultData = JsonConvert.DeserializeObject(responseAsString);

                    bool success = jsonResultData.success;
                    
                    if (!success) return default(T);
                    try
                    {
                        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(jsonResultData.data)); }
                    catch (RuntimeBinderException){ }
                }
                return default(T);
            }
        }
    }


}
