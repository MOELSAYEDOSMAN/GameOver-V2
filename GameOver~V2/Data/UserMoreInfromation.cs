using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GameOver_V2.Data
{
    public class UserMoreInfromation
    {
        [Key]
       public string IdUserMoreInfromation { get; set; }
       public IdentityUser User { get; set; }
       public string? ImageSrc { get; set; }
       public DateTime Birthday { get; set; }
    }
}
