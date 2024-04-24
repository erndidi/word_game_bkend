namespace webapi.Models.DTO
{
    public class SignUpDTO
    {
        public string firstname { get; set; }

        public string lastname { get; set; }
        public string email { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public int score { get; set; }

        public bool succeeded { get; set; }

        public string errorMessage { get; set; }


    }
}
