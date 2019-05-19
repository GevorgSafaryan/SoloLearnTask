using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using TheGuardianApi.ApiConsumer.Helpers;
using TheGuardianApi.ApiConsumer.Models;

namespace TheGuardianApi.ApiConsumer.Processors
{
    public static class FilterBySectionProcessor
    {
        public static async Task<List<string>> GetSections(string section)
        {
            string apiKey = ConfigurationManager.AppSettings["apiKey"];
            string url = $"https://content.guardianapis.com/search?api-key={ apiKey }&section={ section}";
            using (HttpResponseMessage responseMessage = await ApiHelper.HttpClient.GetAsync(url))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    ResponseModel response = await responseMessage.Content.ReadAsAsync<ResponseModel>();
                    var results = response.Response.Results;
                    List<string> sections = new List<string>();
                    for (int i = 0; i < results.Count; i++)
                    {
                        sections.Add(results[i].SectionId);
                    }
                    return sections;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
    }
}
