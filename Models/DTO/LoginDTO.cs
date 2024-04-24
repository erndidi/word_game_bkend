using System.Security.Policy;

namespace webapi.Models.DTO
{
    public class LoginDTO
    {
        public string playerId { get; set; }
        public string email { get; set; }

        public string username { get; set; }
        
        public string password { get; set; }

        public int? score { get; set; }

        public string playerErrorMessage { get;set; }

        public bool update_success { get; set; }
    }
}
