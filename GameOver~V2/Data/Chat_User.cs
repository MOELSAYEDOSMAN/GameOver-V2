using Microsoft.AspNetCore.Identity;

namespace GameOver_V2.Data
{
    public class Chat_User
    {
        public string Id { get; set; }
        public IdentityUser Send { get; set; }
        public IdentityUser Recive { get; set; }
        public string Message { get; set; }
        public DateTime Date_Sent { get; set; }
    }
}
