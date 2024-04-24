
using Serilog;
using System;
using System.Security.Cryptography;
using webapi.Models;
using webapi.Models.DTO;

namespace webapi.Data
{
    public class PlayerStore
    {

        public static async Task<string> UpdatePlayerScore(WordGameContext dc,LoginDTO loginDTO)
        {
            Log.Logger = new LoggerConfiguration()
                      .WriteTo.Console()
                      .CreateLogger();

            string message = string.Empty;

            try
            {
                Player player = dc.Players.Where(p=>p.Id == loginDTO.playerId).FirstOrDefault();
                player.Score = loginDTO.score;
                //todo update session id if needed.
                await dc.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("An error occurred while executing UpdateUserScoreWord method for user{0}", loginDTO.playerId.ToString()));
                message = ex.Message;
            }
            if (string.IsNullOrEmpty(message))
            {
                message = "Update succeeded.";
            }

            return message;
        }

        public static Guid GetSessionId()
        {
            byte[] sessionIdBytes = new byte[16]; // Generate 16 bytes for session ID

            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(sessionIdBytes); // Fill the byte array with random values
            }

            Guid sessionId = Guid.NewGuid(); // Convert the byte array to a hexadecimal string

            return sessionId;
        }

        public async static Task<PlayerDTO> AddPlayerAsync(WordGameContext dataContext, SignUpDTO signup)
        {
            Log.Logger = new LoggerConfiguration()
                       .WriteTo.Console()
                       .CreateLogger();
            Guid uid = Guid.Empty;

            PlayerDTO playerDTO = new PlayerDTO();
            try
            {

                if (!string.IsNullOrEmpty(signup.email))
                {
                    bool doesExmailExist = dataContext.Players.Any(p => p.Email == signup.email);

                    if (doesExmailExist)
                    {
                        playerDTO.update_success = false;
                        playerDTO.playerErrorMessage = "email already exists";
                    }
                    else
                    {
                        Player playerToDB = new Player
                        {
                            Email = signup.email,
                            Password = signup.password,
                            Firstname = signup.firstname,
                            Lastname = signup.lastname,
                            Username = signup.username,
                            Id = Guid.NewGuid().ToString(),
                            Score = signup.score
                        };

                        dataContext.Players.Add(playerToDB);

                        //player. = playerToDB.Id;

                        await dataContext.SaveChangesAsync();

                        playerDTO.email = playerToDB.Email;
                        playerDTO.password = playerToDB.Password;
                        playerDTO.firstname = playerToDB.Firstname;
                        playerDTO.lastname = playerToDB.Lastname;
                        playerDTO.username = playerToDB.Username;                       
                        playerDTO.score = playerToDB.Score;
                        playerDTO.playerid = playerToDB.Id;
                        playerDTO.update_success = true;

                    }



                }


            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing AddUser method");
                playerDTO.update_success = false;
            }

            return playerDTO;
        }

        public async static Task<LoginDTO> Login(WordGameContext dataContext, LoginDTO login)
        {
            Log.Logger = new LoggerConfiguration()
                     .WriteTo.Console()
                     .CreateLogger();
            Guid uid = Guid.Empty;
            int? incoming_score = login.score;   

            try
            {
                PlayerDTO playerDTO = new PlayerDTO();
                if (!string.IsNullOrEmpty(login.email))
                {
                    bool doesExmailExist = dataContext.Players.Any(p => p.Email == login.email);

                    if (doesExmailExist)
                    {
                        bool passwordCorrect = dataContext.Players.Where(p => p.Password == login.password).Any(p => p.Email == login.email);
                        if (passwordCorrect)
                        {                            
                            login.username = dataContext.Players.Where(p => p.Email == login.email && p.Password == login.password).Select(s => s.Username).FirstOrDefault();
                            int? currentScore = dataContext.Players.Where(p => p.Email == login.email && p.Password == login.password).Select(s => s.Score).FirstOrDefault();
                            login.playerId = dataContext.Players.Where(p => p.Email == login.email && p.Password == login.password).Select(s => s.Id).FirstOrDefault();
                            login.score = incoming_score + currentScore;
                            await UpdatePlayerScore(dataContext, login);
                        }
                        else
                        {
                            login.playerErrorMessage = "password is incorrect";
                        }
                    }


                }
                else
                {
                    login.playerErrorMessage = "username not found";
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing AddUser method");
                login.update_success = false;
            }

            return login;
        }
        //todo: 
        public static LoginDTO Logout(WordGameContext dataContext, LoginDTO login)
        {
            Log.Logger = new LoggerConfiguration()
                   .WriteTo.Console()
                   .CreateLogger();
            Guid uid = Guid.Empty;

            try
            {

              
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing AddUser method");
                login.update_success = false;
            }

            return login;
        }
    }
}
