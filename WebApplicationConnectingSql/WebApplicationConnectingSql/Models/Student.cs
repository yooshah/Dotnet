using System.Text.Json.Serialization;

namespace WebApplicationConnectingSql.Models
{
    public class Student
    {

        [JsonPropertyName("StudentID")]
        public int StudentID { get; set; }

        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string LastName { get; set; }

        [JsonPropertyName("Age")]
        public int Age { get; set; }

        
    }
}
