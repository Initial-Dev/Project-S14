using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using S14_BlazorUI.Services;
using S14_BlazorUI.Models;

namespace S14_BlazorUI.Services
{

    public class AcademicClassService : IAcademicClassService
    {
        private readonly HttpClient _httpClient;

        public AcademicClassService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AcademicClass>> GetAcademicClassesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<AcademicClassContainer>("academicClasses");
            var academicClasses = response?.AcademicClasses;

            return academicClasses ?? new List<AcademicClass>();
        }

        public async Task<AcademicClass> GetAcademicClassByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<AcademicClass>($"academicClasses/{id}");
            return response ?? new AcademicClass();
        }
    }

}
