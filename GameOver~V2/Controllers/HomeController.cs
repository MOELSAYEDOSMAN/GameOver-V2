using GameOver_V2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameOver_V2.Controllers
{
    public class HomeController : Controller
    {
        //poroberity:
        private readonly ApplicationDbContext db;
        private readonly ILogger<HomeController> _logger;
        DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(ApplicationDbContext db, ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            _logger = logger;
            _userManager = userManager;
        }
        static Game currentGame { get; set; }
        //-----------------------------------------------------------
        #region  Game
        //start Game------------------------------------------------------------------
        public IActionResult Game(string Id)
        {
            //Find Game
            var game = db.Games.SingleOrDefault(x => x.Name.Replace(" ", "").Contains(Id));
            if (game == null)
            {
                return NotFound();
            }
            else
            {

                var ComUser = (from com in db.Comments
                              where com.game.IdGame ==game.IdGame
                              join per in db.Users
                              on com.User.Id equals per.Id
                              select new {com.Comment,com.DateTime,com.numberDisLike,com.numberLike,com.IdComments,per.Email }
                              ).ToList();
               
                currentGame = game;
                ViewBag.Comments = ComUser;
                ViewBag.imgBackGround = db.ImageGames.Where(i=>i.game.IdGame==game.IdGame).ToList();
                return View(game);
            }
        }
        //comments Game
        public IActionResult Comments()
        {
            //Return Comments Game
      
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Comments(string comment)
        {
            if (comment.Length == 0)
            {

                return Content("<html><head><script>alert('Must Enter Message!');</script></head></html>");
            }
            else
            {
                //Save Comment
                var us = await _userManager.GetUserAsync(User);
                //New Comment
                Comments cm = new Comments()
                {
                    IdComments = Guid.NewGuid().ToString(),
                    Comment = comment,
                    numberDisLike = 0,
                    numberLike = 0,
                    User = us,
                    DateTime = DateTime.Now,
                    game=db.Games.SingleOrDefault(x=>x.IdGame==currentGame.IdGame)
                };
                db.Comments.Add(cm);
                //Update DataBase
                await db.SaveChangesAsync();
                return Json("");
            }

        }
        //---------------
        [HttpPost]
        public IActionResult AddLikeOrDisLikeGame(string TypeLike)
        {
            //Find Game
            var gam = db.Games.SingleOrDefault(x => x.IdGame == currentGame.IdGame);
            if (gam != null)
            {
                if (TypeLike == "Like")
                {
                    gam.likeN++;
                }
                else
                {
                    gam.disLikeN++;
                }
                //Update Data base
                db.SaveChanges();
            }
            return Content("<script type=\"text/javascript\">alert(\"Done!\");</script>");
        }
        //end Game----------------------------------------------------------------------
        #endregion




        public IActionResult Index()
        {
            // List Free Game
            var Free_Game = db.Games.Where(x=>x.Price==0).OrderByDescending(x => x.downloadNumber).Take(5).ToList();
            ViewBag.Free_Game = Free_Game;
            // list News
            var News1 = db.GameOverNews.OrderByDescending(x => x).ToList();
            ViewBag.news=News1;
            // List Top Game
            var Top_Game = db.Games.OrderByDescending(x => x.downloadNumber).Take(5).ToList();
            ViewBag.TopGame=Top_Game;
            return View();
        }
    }
}
