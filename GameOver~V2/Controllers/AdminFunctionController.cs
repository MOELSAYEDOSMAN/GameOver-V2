using Microsoft.AspNetCore.Mvc;
using GameOver_V2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Build.Framework;

namespace GameOver_V2.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminFunctionController : Controller
    {
        ApplicationDbContext db;
        public AdminFunctionController(ApplicationDbContext _db)
        {
            db = _db;
        }
        //Home Admin
        public IActionResult Index()
        {
            return View();
        }

        //1-Create Game
        #region Create New Game
        public class InputGame
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string bigDec { get; set; }
            [Required]
            public string lowDec { get; set; }
            [Required]
            public string Cpu { get; set; }
            [Required]
            public string Hard { get; set; }
            [Required]
            public string Ram { get; set; }
            [Required]
            public string Gpu { get; set; }
            [Required]
            public string Link { get; set; }
            [Required]
            public string Type { get; set; }
            public bool Age { get; set; }
            public decimal Price { get; set; }

        }
        public IActionResult NewGame()
        {
            InputGame inputGame = new InputGame();
            return View(inputGame);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> NewGame(InputGame inputGame, List<IFormFile> Icon, List<IFormFile> backGroundImages)
        {
            if (Icon.Count > 0 && backGroundImages.Count > 0)
            {
                //serch in Old Game
                var OldGame = db.Games.SingleOrDefault(g => g.Title == inputGame.Name.Replace(" ", "_"));
                if (OldGame==null&&ModelState.IsValid)
                {
                    //save Icon 
                    string NameImg = Guid.NewGuid().ToString() + ".jpg";
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Img/BackGroundGame", NameImg);
                    using (var steam = System.IO.File.Create(filepath))
                    {
                        await Icon[0].CopyToAsync(steam);
                    }
                    //save BackGround Images
                    List<string> SrcBackGround = new List<string>();
                    foreach (var img in backGroundImages)
                    {
                        string ImgName = Guid.NewGuid().ToString() + ".jpg";
                        SrcBackGround.Add(ImgName);
                        filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Img/BackGroundGame", ImgName);
                        using (var steam = System.IO.File.Create(filepath))
                        {
                            await img.CopyToAsync(steam);
                        }

                    }
                    //set Information Game
                    Game game = new Game() 
                    {
                    IdGame=Guid.NewGuid().ToString(),
                    Name=inputGame.Name,
                    Price=inputGame.Price,
                    Age=inputGame.Age,
                    iconSrc=NameImg,
                    Cpu=inputGame.Cpu,
                    Hard=inputGame.Hard,
                    Gpu=inputGame.Gpu,
                    Ram=inputGame.Ram,
                    Link=inputGame.Link,
                    bigDec=inputGame.bigDec,
                    lowDec=inputGame.lowDec,
                    Type=inputGame.Type,
                    DateDownload=DateTime.Now,
                    downloadNumber=0,
                    disLikeN=0,
                    likeN=0,
                    Title=inputGame.Name.Replace(" ","_")
                    };
                    //save Game
                    db.Games.Add(game);
                    //save Multi Image
                    foreach(string s in SrcBackGround)
                    {
                        db.ImageGames.Add(new ImageGames
                        {
                            IdImageGames = Guid.NewGuid().ToString(),
                            game = game,
                            ImgSrc = s
                        });
                    }
                    //Update DataBase
                    db.SaveChanges();
                    return Content("<html><head><script>alert('Save Game !');</script></head></html>");

                }
                else
                {
                    return Content("<html><head><script>alert('Error In Input Game Or Game Alrady !');</script></head></html>");

                }
            }
            else
            {
                return Content("alert('Must Photos To Game !');", "application/javascript");

            }
        }
        #endregion
        //2-News
        #region News
        public class InputNews 
        {
        [Required]
         public string NameNews { get; set; }
         [Required]
        public string Title { get; set; }
        [Required]
        public string Descrption { get; set; }
        }
        public IActionResult CreatNews()
        {
            InputNews _inputNews=new InputNews();
            return View(_inputNews);
        }
        [HttpPost]
        public async Task<IActionResult> CreatNews(InputNews _inputNews, List<IFormFile> Icon, List<IFormFile> PageHtmlN, List<IFormFile> ImageInfileHtml)
        {
            if(ModelState.IsValid&&Icon.Count>0&& PageHtmlN.Count>0&& ImageInfileHtml.Count>0)
            {
                //save Icon
                string NameImg = Guid.NewGuid().ToString() + ".jpg";
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Img/News", NameImg);
                using (var steam = System.IO.File.Create(filepath))
                {
                    await Icon[0].CopyToAsync(steam);
                }
                //save News
                string HtmlPagefile = _inputNews.NameNews.Replace(" ","_") + ".html";
                filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/News", HtmlPagefile);
                    using (var steam = System.IO.File.Create(filepath))
                    {
                        await PageHtmlN[0].CopyToAsync(steam);
                    }
                // selt Image In File
                List<string> ImagesFile = new List<string>();
                foreach (var img in ImageInfileHtml)
                {
                    ImagesFile.Add(img.FileName);
                    filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/News/img", img.FileName);
                    using (var steam = System.IO.File.Create(filepath))
                    {
                        await img.CopyToAsync(steam);
                    }
                }
                //set Data News
                GameOverNews NewNews=new GameOverNews()
                {
                    IdGameOverNews = Guid.NewGuid().ToString(),
                    Dec= _inputNews.Descrption,
                    Title= _inputNews.Title,
                    ImgSrc= NameImg,
                    News= HtmlPagefile
                };
                db.GameOverNews.Add(NewNews);
                //set data Image
                foreach(string s in ImagesFile)
                {
                    await db.BackGroundImageNews.AddAsync(new BackGroundImageNews()
                    {
                        Id = Guid.NewGuid().ToString(),
                        NameImage = s,
                        News = NewNews
                    });
                }
                //update Data Base
                db.SaveChanges();
                return Redirect("/Home");
            }
            else
            {
                ViewBag.Error = "Please Enter File";
                return View();
            }
            
        }
        #endregion
    }
}
