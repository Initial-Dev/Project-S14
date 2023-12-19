namespace S14_BlazorUI.Models
{
    public class SubjectGrades
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public string TeacherName { get; set; }
    public List<GradeInfo> Grades { get; set; }
}
}
