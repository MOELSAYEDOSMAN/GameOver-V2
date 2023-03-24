using System.ComponentModel.DataAnnotations;

namespace GameOver_V2.Data
{
    public class ImageGames
    {
        [Key]
        public string IdImageGames { get; set; }
        public string ImgSrc { get; set; }
        public Game game { get; set; }
    }
}
