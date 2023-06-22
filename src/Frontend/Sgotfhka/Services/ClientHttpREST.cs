using System;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace Sisgtfhka.Services
{
    public class ClientHttpREST
    {
        private readonly HttpClient _httpClient;

        public ClientHttpREST(HttpClient client)
        {
            _httpClient = client;
        }

        public void SetToken(string pToken)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", pToken);
        }

        public async Task<String> GetObjetcsAllAsync(string pPath)
        {
            try
            {
                var response = await _httpClient.GetAsync(pPath);

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadAsStringAsync();

                return result;
              }
              catch (Exception e)
              {
                    throw e;
              }
        }

        public async Task<String> GetObjetcAsync(string pPath, string pId)
        {
            try
            {
                var response = await _httpClient.GetAsync(pPath + "/" + pId);

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadAsStringAsync();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<String> PostObjetcAsync(string pPath, string pData)
        {
            try {

                StringContent stringContent = new StringContent(pData, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(pPath, stringContent);
 
                return response.StatusCode.ToString();            
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<String> PostObjetcContentAsync(string pPath, string pData)
        {
            try
            {
                StringContent stringContent = new StringContent(pData, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(pPath, stringContent);

                var result = await response.Content
                    .ReadAsStringAsync();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<String> PostObjetcContentAndCodeAsync(string pPath, string pData)
        {
            try
            {
                StringContent stringContent = new StringContent(pData, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(pPath, stringContent);

                var result = await response.Content
                    .ReadAsStringAsync();

                string statusCode = response.StatusCode.ToString();

                return statusCode + "|" + result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<String> PutObjetcAsync(string pPath, string pId, string pData)
        {
            try
            {

                StringContent stringContent = new StringContent(pData, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(pPath + "/" + pId, stringContent);

                return response.StatusCode.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<String> PutObjetcContentAndCodeAsync(string pPath, string pId, string pData)
        {
            try
            {

                StringContent stringContent = new StringContent(pData, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(pPath + "/" + pId, stringContent);

                var result = await response.Content
                   .ReadAsStringAsync();

                return response.StatusCode.ToString() +"|"+ result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<String> DeleteObjetcAsync(string pPath, string pId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(pPath + "/" + pId);

                return response.StatusCode.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }     
    }
}