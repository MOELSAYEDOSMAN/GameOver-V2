using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GameOver_V2.Data
{
    public class Groub
    {
        [Key]
        public string IdGroub { get; set; }
        public string Name { get; set; }
        public int subscriberNumber { get; set; }
        public string iconImage { get; set; }
        public string Title { get; set; }
        public bool Password { get; set; }
        public string? PasswordGroub { get; set; }
        public IdentityUser Creator { get; set; }
        public List<SubscriberGroub> subscribers { get; set; }
    }
}
