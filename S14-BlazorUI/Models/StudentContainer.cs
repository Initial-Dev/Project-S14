using System.Text.Json.Serialization;

namespace S14_BlazorUI.Models
{
    public class StudentContainer
    {
        [JsonPropertyName("$values")]
        public List<Student> Students { get; set; }
    }

}
