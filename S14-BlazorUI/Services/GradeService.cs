using S14_BlazorUI.Models;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace S14_BlazorUI.Services
{
    public class GradeService : IGradeService
    {
        private readonly HttpClient _httpClient;

        public GradeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Grade>> GetGradesByStudentId(int studentId)
        {
            var response = await _httpClient.GetFromJsonAsync<GradeContainer>($"grades/student/{studentId}");
            var grades = response?.Grades;

            return grades ?? new List<Grade>();
        }

        public async Task<List<SubjectGrades>> GetGradesBySubjectForStudentAsync(int studentId)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                NullValueHandling = NullValueHandling.Ignore,
            };

            var responseString = await _httpClient.GetStringAsync($"grades/student/{studentId}");
            
            Console.WriteLine(responseString);

            // BORKEN
            // doesn't work for some reason
            var grades = JsonConvert.DeserializeObject<List<Grade>>(responseString, settings);

            //var grades = response?.Grades;

            var subjectGradesList = grades
                .GroupBy(g => g.Subject?.Name)
                .Select(group => new SubjectGrades
                {
                    SubjectName = group.Key ?? "Unknown Subject",
                    Grades = group.Select(g => new GradeInfo
                    {
                        Id = g.Id,
                        Value = g.Value,
                        Date = g.Date,
                        TeacherName = $"{g.Teacher.FirstName} {g.Teacher.LastName}"
                    })
                    .OrderByDescending(g => g.Date)
                    .ToList()
                })
                .ToList();


            return subjectGradesList;
        }
    }
}
