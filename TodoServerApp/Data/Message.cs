using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoServerApp.Data
{
    public class Message
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Сообщение не может быть пустым")]
        public string Text { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int SenderId { get; set; }
        public Profile Sender { get; set; }

        public int ReceiverId { get; set; }
        public Profile Receiver { get; set; }
    }
}