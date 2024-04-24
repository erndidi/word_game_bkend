namespace webapi.Models;

    public class PlayerDTO
    {
        public string playerid { get; set; }
        public string firstname { get; set; }

    public string lastname { get; set; }
    public string email { get; set; }

    public string username { get; set; } 

    public string password { get; set; }

    public Guid sessionid { get; set; }   

    public int games_played { get; set; }

    public int? score { get; set; }

    public bool update_success { get; set; }    

    public bool playerLoggedIn { get; set; }    

    public string playerErrorMessage { get; set; }
    } 

