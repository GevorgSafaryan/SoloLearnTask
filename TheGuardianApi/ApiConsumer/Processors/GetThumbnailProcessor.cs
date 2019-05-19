using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using TheGuardianApi.ApiConsumer.Helpers;
using TheGuardianApi.ApiConsumer.Models;

namespace TheGuardianApi.ApiConsumer.Processors
{
    public static class GetThumbnailProcessor
    {
        public static string Section { get; set; }

        public static async Task<List<ThumbnailModel>> GetThumbnail()
        {
            string apiKey = ConfigurationManager.AppSettings["apiKey"];
            //string apiKey = "a9bd33ab-2b21-4a72-8d8f-5d8fd8631277";
            string url = $"https://content.guardianapis.com/search?api-key={ apiKey }&show-fields=thumbnail";
            using (var responseMessage = await ApiHelper.HttpClient.GetAsync(url))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    ResponseModel response = await responseMessage.Content.ReadAsAsync<ResponseModel>();
                    var results = response.Response.Results;
                    List<ThumbnailModel> thumbnails = new List<ThumbnailModel>();
                    for (int i = 0; i < results.Count; i++)
                    {
                        thumbnails.Add(results[i].Fields);
                    }
                    Section = response.Response.Results[1].SectionId;
                    return thumbnails;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public static async Task<int> GetPageSize()
        {
            string apiKey = ConfigurationManager.AppSettings["apiKey"];
            string url = $"https://content.guardianapis.com/search?api-key={ apiKey }";
            using (HttpResponseMessage responseMessage = await ApiHelper.HttpClient.GetAsync(url))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    ResponseModel response = await responseMessage.Content.ReadAsAsync<ResponseModel>();
                    return response.Response.PageSize;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
    }
}
