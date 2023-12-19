using System.Net.Http.Json;
using S14_BlazorUI.Models;

namespace S14_BlazorUI.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly HttpClient _httpClient;

        public TeacherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Teacher>> GetTeachersAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<TeacherContainer>("Teachers/subjects");
            var teachers = response?.Teachers;

            return teachers ?? new List<Teacher>();
        }
    }

}
