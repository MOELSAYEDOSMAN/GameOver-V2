using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace GameOver_V2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<UserMoreInfromation> userMData { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Groub> Groubs { get; set; }
        public DbSet<GameOverNews> GameOverNews{ get; set; }
        public DbSet<buyGame> buyGames { get; set; }
        public DbSet<ImageGames> ImageGames { get; set; }
        public DbSet<SubscriberGroub> SubscriberGroubs { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<SharePost> SharePosts { get; set; }
        public DbSet<CommentsPost> CommentsPosts { get; set; }
        public DbSet<PostsUser> PostsUsers { get; set; }
        public DbSet<Chat_User> Chat_User { get; set; }
        public DbSet<Frind> Frinds { get; set; }
        public DbSet<BackGroundImageNews> BackGroundImageNews { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

            optionsBuilder.UseSqlServer("Server=DESKTOP-09R3REO\\MOHAMED;Database=GameOver_V2;Trusted_Connection=True;MultipleActiveResultSets=true");

        }

        //Function
        static DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        public static List<object> GamesData()
        {
            using (ApplicationDbContext context = new ApplicationDbContext(optionsBuilder.Options))
            {
                var a = (
                       from g in context.Games
                       select new { g.Name, g.iconSrc, g.Price, g.Title }
                       ).ToList<object>();
                return a;
            }
        }
    }
}