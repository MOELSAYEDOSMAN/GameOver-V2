using Microsoft.AspNetCore.Identity;

namespace GameOver_V2.Data
{
    public class PostsUser
    {
        public string Id { get; set; }
        public string? DecPost { get; set; }
        public string? ImgSrc { get; set; }
        public DateTime WhUpload { get; set; }
        public int nLike { get; set; }
        public int nDisLike { get; set; }
        public int Comments_ { get; set; }
        public int Share_ { get; set; }
        public IdentityUser user { get; set; }
        public List<CommentsPost> comments { get; set; }

    }
}
