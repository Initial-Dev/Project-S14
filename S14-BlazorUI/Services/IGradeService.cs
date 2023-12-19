using S14_BlazorUI.Models;

namespace S14_BlazorUI.Services
{
    public interface IGradeService
    {
        Task<List<Grade>> GetGradesByStudentId(int studentId);

        Task<List<SubjectGrades>> GetGradesBySubjectForStudentAsync(int studentId);
    }
}
