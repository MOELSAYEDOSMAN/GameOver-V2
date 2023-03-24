using Microsoft.AspNetCore.SignalR;
using GameOver_V2.Data;
using Microsoft.AspNetCore.Identity;

namespace GameOver_V2
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> _userManager;
        public ChatHub(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this._userManager = userManager;
        }
        public async Task sendMessage(string user, string Groub, string message)
        {
            var us = db.Users.SingleOrDefault(x => x.Id == user);
            Groub gr= db.Groubs.SingleOrDefault(x => x.IdGroub == Groub);
            if (us!=null&&gr!=null&&message.Length>0)
            {
                string dtN = DateTime.Now.ToString();
             await   Clients.Group(gr.IdGroub).SendAsync("rcive",message,dtN,us.UserName);
                Chat chat = new Chat()
                {
                    IdChat=Guid.NewGuid().ToString(),
                    SendTime=DateTime.Now,
                    User=us,
                    groub=gr,
                    Message=message
                };
                db.Chats.Add(chat);
               await db.SaveChangesAsync();

            }
        }
        public async Task joinGroub(string groub)
        {
         await   Groups.AddToGroupAsync(Context.ConnectionId,groub);
        }
    }
}
