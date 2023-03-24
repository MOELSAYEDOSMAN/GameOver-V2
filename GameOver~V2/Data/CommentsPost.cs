using Microsoft.AspNetCore.Identity;

namespace GameOver_V2.Data
{
    public class CommentsPost
        {
         public string Id { get; set; }
         public string Message { get; set; }
         public DateTime Whe_Write { get; set; }
        public IdentityUser Write { get; set; }
        public PostsUser? Post { get; set; }
        public SharePost? ShareP { get; set; }
        public int nlike { get; set; }
        public int nDislike { get; set; }

    }
}
