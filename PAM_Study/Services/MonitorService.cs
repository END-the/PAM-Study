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
    public class MonitorService
    {

        private readonly HttpClient client;
        private readonly JsonSerializerOptions serializerOptions;
        private Models.Monitor monitor;
        private ObservableCollection<Models.Monitor> monitores;



        public MonitorService()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<ObservableCollection<Models.Monitor>> getAllMonitorsAsync()
        {
            Uri uri = new Uri("https://localhost/monitores");

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    monitores = JsonSerializer.Deserialize<ObservableCollection<Models.Monitor>>(content, serializerOptions); 
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching data: {ex.Message}");
            }

            return monitores;
        }
        //NADA DAKI PRA BAIXO TA TESTSADO/CERTO
        public async Task<Models.Monitor> GetMonitorsByIdAsync(long id)
        {
            Uri uri = new Uri("https://localhost/monitores/{id}");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    monitor = JsonSerializer.Deserialize<Models.Monitor>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching data: {ex.Message}");
            }
            return monitor;
        }


        public async Task DeleteMonitorsAsync(long id)
        {
            Uri uri = new Uri("https://localhost/monitores/{id}");
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching data: {ex.Message}");
            }

        }
        public async Task<Models.Monitor> UpdateMonitorAsync(Models.Monitor monitor)
        {

            return monitor;
        }

        public async Task<Models.Monitor> InsertMonitorAsync(Models.Monitor monitor)
        {
            Uri uri = new Uri("https://localhost/monitores");
            try
            {
                monitor = JsonSerializer.Serialize<Models.Monitor>(content, serializerOptions);
                HttpResponseMessage response = await client.PostAsync(uri, monitor);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching data: {ex.Message}");
            }
            return monitor;
        }

    }
}
