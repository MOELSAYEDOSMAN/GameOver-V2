using System.ComponentModel.DataAnnotations;

namespace GameOver_V2.Data
{
    public class BackGroundImageNews
    {
       [Key]
       public string Id { get; set; }
       public string NameImage { get; set; }
       public GameOverNews News { get; set; } 

    }
}
