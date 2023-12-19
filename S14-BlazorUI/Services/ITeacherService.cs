using S14_BlazorUI.Models;

namespace S14_BlazorUI.Services
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetTeachersAsync();
    }
}
