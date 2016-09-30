using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MITCRMApp
{
    public class ServicesBase<T> : IServicesBase<T> where T : EntityBase, new()
    {
        string BASE_URL_SERVICE = "http://mitinfnetapi.azurewebsites.net/";

        public ServicesBase()
        {
        }

        public void Init(string url = "http://mitinfnetapi.azurewebsites.net/")
        {
            try
            {
                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(url),
                    Timeout = TimeSpan.FromSeconds(40)
                };

                App._clientHttp = httpClient;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<T>> GetAll()
        {
            if (App._clientHttp == null)
                Init();

            try
            {
                var data = await App._clientHttp.GetAsync($"{BASE_URL_SERVICE}api/customer");

                if (data != null && data.IsSuccessStatusCode)
                {
                    var dataAsString = await data.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(dataAsString))
                        return JsonConvert.DeserializeObject<List<T>>(dataAsString);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetById(int id)
        {
            if (App._clientHttp == null)
                Init();

            try
            {
                var data = await App._clientHttp.GetAsync($"{BASE_URL_SERVICE}api/customer/{id}");

                if (data != null && data.IsSuccessStatusCode)
                {
                    var dataAsString = await data.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(dataAsString))
                        return JsonConvert.DeserializeObject<T>(dataAsString);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
