using System.ComponentModel.DataAnnotations;

namespace GameOver_V2.Data
{
    public class GameOverNews
    {
        [Key]
        public string IdGameOverNews { get; set; }
        public string Title { get; set; }
        public string News { get; set; }
        public string ImgSrc { get; set; }
        public string Dec { get; set; }
        public List<BackGroundImageNews> ImageNews { get; set; }

    }
}
