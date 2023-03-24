using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GameOver_V2.Data
{
    public class SubscriberGroub
    {
        [Key]
        public string IdSubscriberGroub { get; set; }
        public IdentityUser User { get; set; }
        public Groub groub { get; set; }
    }
}
