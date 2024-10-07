using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using PAM_Study.Models;


namespace PAM_Study.Services
{
    internal class MonitorService
    {

        private readonly HttpClient client;
        private readonly JsonSerializerOptions serializerOptions;
        private Models.Monitor monitor;
        private List<Models.Monitor> monitores;



        public MonitorService()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<List<Models.Monitor>> getAllMonitorsAsync()
        {
            Uri uri = new Uri("https://localhost/monitores");

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    monitores = JsonSerializer.Deserialize<List<Models.Monitor>>(content, serializerOptions); 
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching data: {ex.Message}");
            }

            return monitores;
        }

    }
}
