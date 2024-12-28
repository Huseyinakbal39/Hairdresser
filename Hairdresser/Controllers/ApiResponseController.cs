using Hairdresser.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hairdresser.Controllers
{
    public class ApiResponseController : Controller
    {
        private static readonly HttpClient _httpClient;
        static ApiResponseController() {
            var clientHandler = new HttpClientHandler
            {

                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            _httpClient = new HttpClient(clientHandler);
        }
        [HttpGet]
        public async Task<List<Servis>> GetAllServices()
        {
            List<Servis> servis = new List<Servis>();
            try
            {
                using (var response = await _httpClient.GetAsync("https://localhost:7063/api/Servis"))
                {
                    if(response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        servis = JsonConvert.DeserializeObject<List<Servis>>(apiResponse);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return servis;
        }



    }
}
