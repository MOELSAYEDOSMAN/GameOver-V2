using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GameOver_V2.Data
{
    public class Comments
    {
        [Key]
        public string IdComments { get; set; }
        public string Comment { get; set; }
        public DateTime DateTime { get; set; }
        public IdentityUser User { get; set; }
        public Game game { get; set; }
       public int numberLike { get; set; }
        public int numberDisLike { get; set; }

    }
}
