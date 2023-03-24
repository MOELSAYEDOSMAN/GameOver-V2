using GameOver_V2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GameOver_V2.Controllers
{
    [Authorize]
    public class UserFunctionController : Controller
    {
        //poroberity:
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> _userManager;
        public UserFunctionController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this._userManager = userManager;
        }
        //-----------------------------------------------
        //start GropHome
        public async Task<IActionResult> GropHome()
        {
            //Get User
            var us = await _userManager.GetUserAsync(User);
            //Join
            var Groubs = (from g in db.Groubs
                          join s in db.SubscriberGroubs
                          on g.IdGroub equals s.groub.IdGroub
                          where s.User.Id == us.Id
                          select new { g.IdGroub, g.subscriberNumber, g.Name, g.Title, g.iconImage, g.Password }).ToList();
            ViewBag.Groubs = Groubs;
            //Not Join
            var GroubsNot =(from g in db.Groubs.Where(x=>x.subscribers.Where(w=>w.User.Id==us.Id).Count()==0)
                            select new { g.IdGroub, g.subscriberNumber, g.Name, g.Title, g.iconImage, g.Password }).ToList();
            ViewBag.GroubsNots = GroubsNot;
            return View();
        }
        //class Input Groub
        //Create Groubs
        public class InputGroub
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Title { get; set; }
            public bool Password { get; set; }
            public string? PasswordChar { get; set; } 
        }
        public IActionResult CreateGroubs()
        {
            InputGroub input=new InputGroub();
            return PartialView(input);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGroubs(InputGroub input,List<IFormFile> file)
        {
            if(ModelState.IsValid&&file.Count>0)
            {
                if((input.Password==true&&input.PasswordChar!=null)|| (input.Password == false && input.PasswordChar== null))
                {
                    //get User Creator
                    var us = await _userManager.GetUserAsync(User);
                    //save Photo
                    string NameImg = Guid.NewGuid().ToString() + ".jpg";
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Img/Icon", NameImg);
                    using (var steam = System.IO.File.Create(filepath))
                    {
                        await file[0].CopyToAsync(steam);
                    }
                    //save Groub
                    Groub groub = new Groub()
                    {
                        IdGroub=Guid.NewGuid().ToString(),
                        iconImage=NameImg,
                        Name=input.Name,
                        Title=input.Title,
                        Creator=us,
                        subscriberNumber=1,
                        Password=input.Password,
                        PasswordGroub=input.PasswordChar
                    };
                    db.Groubs.Add(groub);
                    //add Creator In Groub
                    SubscriberGroub subscriber = new SubscriberGroub()
                    {
                        IdSubscriberGroub=Guid.NewGuid().ToString(),
                        groub=groub,
                        User=us
                    };
                    db.SubscriberGroubs.Add(subscriber);
                    //Update DataBase
                   await db.SaveChangesAsync();
                    return Redirect("GropHome");
                }
                else
                {
                    return Content("<html><head><script>alert('Hello, World!');</script></head></html>");

                }
            }
            else
            {
                return Content("<script>alert('Error Model!');</script>"); ;
            }
            
        }
        //End
        //------------------------------------------------
        //Subscribe in Groub
        static Groub groubTran { get; set; }
        public async Task<IActionResult> Subscribe_In_Groub(string Id)
        {
            //serch Groub
            var gr = db.Groubs.SingleOrDefault(g => g.IdGroub == Id);
            if (gr == null)
            {
                return NotFound();
            }
            else
            {
                //if Groub 
                if(gr.Password==false)
                {
                    //get User
                    var us = await _userManager.GetUserAsync(User);
                    //add User In Subbscriber Groub
                    SubscriberGroub sub = new SubscriberGroub()
                    {
                        IdSubscriberGroub=Guid.NewGuid().ToString(),
                        User=us,
                        groub=gr
                    };
                    db.SubscriberGroubs.Add(sub);
                    //subscriber Groub ++
                    gr.subscriberNumber++;
                    //Update Data Base
                    db.SaveChanges();
                    //return Alert*
                    return Json("Done");
                }
                else
                {
                    groubTran = gr;
                    ViewBag.BoolF=true;
                    return PartialView();
                }
            }   
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> SetPasswordGroub(string Password)
        {
            if(Password== groubTran.PasswordGroub)
            {
                var Gr = db.Groubs.SingleOrDefault(x => x.IdGroub == groubTran.IdGroub);
                //get User
                var us = await _userManager.GetUserAsync(User);
                //add User In Subbscriber Groub
                SubscriberGroub sub = new SubscriberGroub()
                {
                    IdSubscriberGroub = Guid.NewGuid().ToString(),
                    User = us,
                    groub = Gr
                };
                db.SubscriberGroubs.Add(sub);
                //subscriber Groub ++
                Gr.subscriberNumber++;
                //Update Data Base
                db.SaveChanges();
                //return Alert*
                return Content("<script>alert('Done!');</script>");
            }
            else
            {
                ViewBag.PasswordGroub = "Error In Password";
            }
            return View();
        }
            //End 
            //----------------------------------------------------------------------------
            //ChatPage
       public async Task<IActionResult> Chat(string Id)
        {
            //select Groub
            var gr = db.Groubs.SingleOrDefault(x => x.IdGroub == Id);
            if(gr!=null)
            {
                //get Groub
                ViewBag.gr = gr;
                //Select Subscriber
                var Subs = (from c in db.SubscriberGroubs
                           where c.groub.IdGroub == Id
                           join u in db.Users
                           on c.User.Id equals u.Id
                           join mr in db.userMData
                           on c.User.Id equals mr.User.Id
                           select new {u.Id,u.Email,u.UserName,mr.ImageSrc})
                         .ToList();
                ViewBag.Subs = Subs;
                //Select Chat
                var chts = (from c in db.Chats
                            where c.groub.IdGroub == Id
                            join u in db.Users
                            on c.User equals u
                            select new { c.Message, c.SendTime, u.UserName,u.Id }).ToList();
                ViewBag.Chts = chts;
                //Get user
                var us =  _userManager.GetUserId(User);
                ViewBag.IdUser = us;
                return View();
            }
            else
            {
                return NotFound();
            }

        }

        //End
        //Posts
        public async Task<IActionResult> PagesPosts()
        {
            var us = _userManager.GetUserId(User);
            var lspos = new List<PostsUser>();
            var Pos = (
                     from f in db.Frinds
                     where (f.Recive.Id == us || f.Send.Id == us) && f.acctept == true
                     from p in db.PostsUsers.OrderByDescending(x => x.WhUpload)
                     where (p.user.Id == f.Recive.Id || p.user.Id == f.Send.Id)  
                     join m in db.userMData
                     on p.user.Id equals m.User.Id
                     select  new { p.ImgSrc,p.DecPost,p.Comments_,p.nDisLike,p.nLike,p.Share_, m.ImageSrc,p.user.Email, p.user.UserName }
                     ).ToList().Distinct();
            ViewBag.pos = Pos;
           
            var usr = db.userMData.Single(x => x.User.Id == us);
            ViewBag.imgUsr = usr.ImageSrc;
            return View();
        }
        //CreatePost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadPost(string PostMessage, List<IFormFile> ImageFiles)
        {
            if(PostMessage==null&&ImageFiles==null)
            {
                return Json("Must Enter Any Think");
            }
            else
            {
                PostsUser p = new PostsUser()
                {
                    Comments_ = 0,
                    Share_ = 0,
                    Id = Guid.NewGuid().ToString(),
                    nDisLike = 0,
                    nLike = 0,
                    WhUpload = DateTime.Now,

                };
                //get User Creator
                var us = await _userManager.GetUserAsync(User);
                p.user = us;
                //save Photo
                if (ImageFiles.Count>0)
                {
                    string NameImg = Guid.NewGuid().ToString() + ".jpg";
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Img/Posts", NameImg);
                    using (var steam = System.IO.File.Create(filepath))
                    {
                        await ImageFiles[0].CopyToAsync(steam);
                    }
                    p.ImgSrc = NameImg;
                }

                if(PostMessage!=null)
                {
                    p.DecPost = PostMessage;
                }

                db.PostsUsers.Add(p);
                db.SaveChanges();
            }
            return View("PagesPosts");
        }
        //----------------------------------------------------------------------------
        //Frinds Page
        public async Task<IActionResult> FrindsPage()
        {
            //get User
            var us =_userManager.GetUserId(User);
            //Get Frinds
            var frindsDone1 = (from f in db.Frinds
                               where f.acctept == true
                               && f.Recive.Id == us
                               join u in db.userMData
                               on f.Send.Id equals u.User.Id
                               select new { f.Send.Email, u.ImageSrc, f.Send.UserName }
                            ).ToList();
            ViewBag.Frinds1 = frindsDone1;
            var frindsDone2 = (from f in db.Frinds
                               where f.acctept == true
                               && f.Send.Id == us
                               join u in db.userMData
                               on f.Recive.Id equals u.User.Id
                               select new { f.Recive.Email, u.ImageSrc, f.Recive.UserName }
                ).ToList();
            ViewBag.Frinds2 = frindsDone2;

            //Get New Frinds
            var frindsRecive1 = (from f in db.Frinds
                               where f.acctept == false
                               && f.Recive.Id == us
                               join u in db.userMData
                               on f.Send.Id equals u.User.Id
                               select new { f.Send.Email, u.ImageSrc, f.Send.UserName }
                ).ToList();
            ViewBag.FrindsRecive = frindsRecive1;
            return View();
        }
        //Add Frinds
        //acssept
        public async Task<IActionResult> AddFrindTr(string id)
        {
            var us = db.Users.SingleOrDefault(x => x.Email == id);
            if(us!=null)
            {
                var usr = await _userManager.GetUserAsync(User);
                db.Frinds.SingleOrDefault(x => x.Recive == usr && x.Send == us).acctept = true;
                db.SaveChanges();
            }
            return Json("Done!");
        }
        //refuced
        public async Task<IActionResult> AddFrindful(string id)
        {
            var us = db.Users.SingleOrDefault(x => x.Email == id);
            if (us != null)
            {
                var usr = await _userManager.GetUserAsync(User);
               var fr= db.Frinds.SingleOrDefault(x => x.Recive == usr && x.Send == us);
               db.Frinds.Remove(fr);
                db.SaveChanges();
            }
            return Json("Done!");
        }
        //End
        //-------------------------------------------------------------------------------
        //User Person Page
        public async Task<IActionResult> PageUser(string Id)
        {
            var us = db.Users.SingleOrDefault(x => x.Email == Id);
            if(us!=null)
            {
                int stateUserPage;
                var usc = _userManager.GetUserId(User);
                if(usc==us.Id)
                {
                    stateUserPage = 1;
                }
                else
                {
                    var usFrinds = (from f in db.Frinds
                                    where (f.Send.Id == usc && f.Recive.Id == us.Id) ||
                                    (f.Recive.Id == usc && f.Send.Id == us.Id)
                                    select new { f.acctept }).ToList();
                    if(usFrinds.Count>0)
                    {
                        if (usFrinds[0].acctept==true)
                        {
                            stateUserPage = 3;
                        }
                        else
                        {
                            stateUserPage = 4;
                        }

                    }
                    else
                    {
                        stateUserPage = 2;
                    }
                }
                ViewBag.stsateUser = stateUserPage;
                //moereInfromation
                var mUser = db.userMData.SingleOrDefault(u => u.User.Id == us.Id);
                ViewBag.Muser = mUser;
                //Get Games
                var Gams = (from b in db.buyGames
                            where b.User.Id == us.Id
                            join g in db.Games
                            on b.game.IdGame equals g.IdGame
                            select new { g.Name, g.iconSrc }).ToList();
                ViewBag.gms = Gams;
                //Get Frinds
                var frindsDone1 = (from f in db.Frinds
                                   where f.acctept == true
                                   && f.Recive.Id == us.Id
                                   join u in db.userMData
                                   on f.Send.Id equals u.User.Id
                                   select new { f.Send.Email, u.ImageSrc, f.Send.UserName }
                                ).ToList();
                
                ViewBag.Frinds1 = frindsDone1;
                var frindsDone2 = (from f in db.Frinds
                                   where f.acctept == true
                                   && f.Send.Id == us.Id
                                   join u in db.userMData
                                   on f.Recive.Id equals u.User.Id
                                   select new { f.Recive.Email, u.ImageSrc, f.Recive.UserName }
                    ).ToList();
                ViewBag.Frinds2 = frindsDone2;
                //Posts
                var pots=db.PostsUsers.Where(p => p.user.Id == us.Id).ToList();
                //var shpost = (from p in db.SharePosts
                //              where p.UsShare.Id == us.Id
                //              join sp in db.PostsUsers
                //              on p.PostU.Id equals sp.Id
                //              join mr in db.userMData
                //              on p.UsShare.Id equals mr.User.Id
                //              select new { p.commentsPosts,p.Comments_,p.nDisLike,p.nLike,p.Share_,sp.DecPost,sp.ImgSrc}).ToList();
                return View(pots);
            }
            else
            {
                return NotFound();
            }
            
        }

        //add Frinds
        [HttpPost]
        public async Task<IActionResult> AddFrinds(string Email)
        {
            var us = db.Users.SingleOrDefault(x => x.Email == Email);
            if (us == null)
            {
                return NotFound();
            }
            else
            {

                var usr = await _userManager.GetUserAsync(User);
                Frind frind = new Frind()
                {
                    Id = Guid.NewGuid().ToString(),
                    acctept = false,
                    Recive = us,
                    Send = usr
                };
                db.Frinds.Add(frind);
                db.SaveChanges();
            }
            return Json("Alert('Done')");
        }
        //End
        //-------------------------------------------------------------------------------
        //write Post
    
        //--------------------------------------------------------------------------------
    }
}
