using System.Text.Json.Serialization;

namespace S14_BlazorUI.Models
{

    public class SubjectContainer
    {
        [JsonPropertyName("$values")]
        public List<Subject> Subjects { get; set; }
    }

}
