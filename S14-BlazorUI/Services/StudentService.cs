using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;
using S14_BlazorUI.Models;

namespace S14_BlazorUI.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<StudentContainer>("Students");
            var students = response?.Students;

            return students ?? new List<Student>();
        }
    }
}