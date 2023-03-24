using System.ComponentModel.DataAnnotations;

namespace GameOver_V2.Data
{
    public class Game
    {
        [Key]
        public string IdGame { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string lowDec { get; set; }
        public string bigDec { get; set; }
        public string Cpu { get; set; }
        public string Hard { get; set; }
        public string Ram { get; set; }
        public string Gpu { get; set; }
        public string Type { get; set; }
        public int downloadNumber { get; set; }
        public int likeN { get; set; }
        public int disLikeN { get; set; }
        public DateTime DateDownload { get; set; }
        public string Link { get; set; }
        public bool Age { get; set; }
        public string iconSrc { get; set; }
        public decimal Price { get; set; }
        public List<ImageGames> Images { get; set; }
        public List<Comments> Comments { get; set; }
}
}
