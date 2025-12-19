using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoServerApp.Data
{
    public class Interest
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        // связь с профилями
        [JsonIgnore]
        public List<Profile> Profiles { get; set; } = new();
    }
}