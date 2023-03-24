using Microsoft.AspNetCore.Identity;

namespace GameOver_V2.Data
{
    public class Frind
    {
        public string Id { get; set; }
        public IdentityUser Send { get; set; }
        public IdentityUser Recive { get; set; }
        public bool acctept { get; set; }

    }
}
