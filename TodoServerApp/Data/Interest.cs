using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoServerApp.Data
{
    public class Interest
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        // связь с профилями
        [JsonIgnore] // это нужно, чтобы при сериализации не было бесконечного цикла
        public List<Profile> Profiles { get; set; } = new();
    }
}