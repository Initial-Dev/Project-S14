using System.Text.Json.Serialization;

namespace S14_BlazorUI.Models
{
    public class AcademicClassContainer
    {
        [JsonPropertyName("$values")]
        public List<AcademicClass> AcademicClasses { get; set; }
    }

}
