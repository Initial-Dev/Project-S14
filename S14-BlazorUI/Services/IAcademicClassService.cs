using S14_BlazorUI.Models;

namespace S14_BlazorUI.Services
{
    public interface IAcademicClassService
    {
        Task<List<AcademicClass>> GetAcademicClassesAsync();
        Task<AcademicClass> GetAcademicClassByIdAsync(int id);
    }

}
