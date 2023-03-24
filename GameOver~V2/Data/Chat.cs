using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GameOver_V2.Data
{
    public class Chat
    {
        [Key]
        public string IdChat { get; set; }
        public string Message { get; set; }
        public IdentityUser User { get; set; }
        public Groub groub { get; set; }
        public DateTime SendTime { get; set; }
    }
}
