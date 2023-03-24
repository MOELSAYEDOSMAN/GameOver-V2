using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GameOver_V2.Data
{
    public class buyGame
    {
        [Key]
        public string IdbuyGame { get; set; }
        public Game game { get; set; }
        public IdentityUser User { get; set; }
    }
}
