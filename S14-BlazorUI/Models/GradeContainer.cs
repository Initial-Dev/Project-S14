using System.Text.Json.Serialization;

namespace S14_BlazorUI.Models
{
    public class GradeContainer
{
    [JsonPropertyName("$values")]
    public List<Grade> Grades { get; set; }
}
}
