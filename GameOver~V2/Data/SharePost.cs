using Microsoft.AspNetCore.Identity;

namespace GameOver_V2.Data
{
    public class SharePost
    {
        public string Id { get; set; }
        public PostsUser PostU { get; set; }
        public List<CommentsPost> commentsPosts { get; set; }
        public IdentityUser UsShare { get; set; }
        public int nLike { get; set; }
        public int nDisLike { get; set; }
        public int Comments_ { get; set; }
        public int Share_ { get; set; }
        public DateTime W_share { get; set; }

    }
}
