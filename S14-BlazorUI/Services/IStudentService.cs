using S14_BlazorUI.Models;

namespace S14_BlazorUI.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsAsync();
    }
}
