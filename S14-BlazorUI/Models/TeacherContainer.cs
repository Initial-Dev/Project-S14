using System.Text.Json.Serialization;

namespace S14_BlazorUI.Models
{
    public class TeacherContainer
    {
        [JsonPropertyName("$values")]
        public List<Teacher> Teachers { get; set; }
    }

}
