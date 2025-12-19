using System.ComponentModel.DataAnnotations;

namespace TodoServerApp.Data
{
    public class Profile
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯёЁ\s-]+$", ErrorMessage = "В имени могут быть только буквы")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Укажите возраст")]
        [Range(18, 122, ErrorMessage = "Возраст должен быть от 18 до 122 лет")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Город обязателен")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯёЁ\s-]+$", ErrorMessage = "Название города должно состоять из букв")]
        public string? City { get; set; }

        public string? Bio { get; set; }

        public DateTime LastActive { get; set; }

        public List<Interest> Interests { get; set; } = new();

        public string? UserId { get; set; }
    }
}