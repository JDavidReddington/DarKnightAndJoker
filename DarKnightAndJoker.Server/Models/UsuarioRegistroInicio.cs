using System.ComponentModel.DataAnnotations;

namespace DarKnightAndJoker.Server.Models
{
    public class UsuarioRegistroInicio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string userNameDark { get; set; }
        [Required]
        public string emailDark { get; set; }
        [Required]
        public string passworDark { get; set; }
    }
}
