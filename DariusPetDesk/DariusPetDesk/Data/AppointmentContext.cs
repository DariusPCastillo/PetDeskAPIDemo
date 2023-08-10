using Darius_PetDesk.Data.Interfaces;
using Darius_PetDesk.Models;
using System.Text.Json;

namespace Darius_PetDesk.Data
{
    public class AppointmentContext : IAppointmentContext
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly HttpClient _client;

        public AppointmentContext(IConfiguration config, ILogger<AppointmentContext> logger, IHttpClientFactory clientF)
        {
            _logger = logger;
            _config = config;
            _client = clientF.CreateClient("AppointmentContext");
            
        }
        public async Task<IEnumerable<Root>> GetAppointment(CancellationToken cToken)
        {
            var url = string.Format("https://723fac0a-1bff-4a20-bdaa-c625eae11567.mock.pstmn.io/appointments");
            
            try
            {
               var response = await _client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"{response.StatusCode}: {response.ReasonPhrase}");
               var stringResponse = await response.Content.ReadAsStringAsync();
               var collection = JsonSerializer.Deserialize<IEnumerable<Root>>(stringResponse);
                return collection;

            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAppointment::Exception:Message:{ex.Message}");
                throw; 
            }

        }

    }
}
