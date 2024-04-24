using Microsoft.VisualBasic;
using Serilog;
using System.Security.Cryptography;
using webapi.Models;
using webapi.Models.DTO;

namespace webapi.Data
{
    public static class WordStore
    {
public static WordDTO GetMockWord()
{
    WordDTO dto = new WordDTO();
    dto.Id = 1;
    dto.Text = "TestWord";
    DefinitionDTO def1 = new DefinitionDTO{ Id="asdf", Text="first def", WordId=1};
    DefinitionDTO def2 = new DefinitionDTO{ Id="asdf", Text="sec def", WordId=1};
    DefinitionDTO def3 = new DefinitionDTO{ Id="asdf", Text="third def", WordId=1};
    DefinitionDTO def4 = new DefinitionDTO{ Id="asdf", Text="fourth def", WordId=1};
    DefinitionDTO def5 = new DefinitionDTO{ Id="asdf", Text="fifth def", WordId=1};
    DefinitionDTO def6 = new DefinitionDTO{ Id="asdf", Text="sixth def", WordId=1};
    DefinitionDTO def7 = new DefinitionDTO{ Id="asdf", Text="seventh def", WordId=1};
    dto.Definitions.Add(def1);
    dto.Definitions.Add(def2);
    dto.Definitions.Add(def3);
    dto.Definitions.Add(def4);
    dto.Definitions.Add(def5);
    dto.Definitions.Add(def6);
    dto.Definitions.Add(def7);
    return dto;
}

        //public static bool IsEmailNotAvailable(WordGameContext dataContext, string email)
        //{
        //    return dataContext.UserDetail.Any(ud => ud.Email == email);
        //}

        //public static bool IsUserNameNotAvailable(WordGameContext dataContext, string email)
        //{
        //    return dataContext.UserDetail.Any(ud => ud.UserName == email);
        //}
        public static void GetPlayer(WordGameContext dataContext, ref PlayerDTO player)
        {
            string testEmail = player.email;
            string password = player.password;           


        }

      

        //private static void AddUserWord(DataContext dataContext, PlayerDTO user)
        //{
        //    try
        //    {
        //        if (user.Email != null)
        //        {
        //            string? wordIds = (from u in dataContext.UserDetail
        //                               select u.UserWords).FirstOrDefault();

        //            if (!string.IsNullOrEmpty(wordIds))
        //            {
        //                if (wordIds.Contains(","))
        //                {
        //                    List<string> currentWords = wordIds.Split(',').ToList();

        //                    if (currentWords.Count > 50)
        //                    {
        //                        currentWords.RemoveAt(0);
        //                        currentWords.Add(string.Concat(user.UsedWordId, ","));
        //                    }
        //                    else
        //                    {
        //                        currentWords.Add(string.Concat(user.UsedWordId, ","));
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                wordIds = string.Concat(user.UsedWordId, ",");
        //            }

        //        }
        //        dataContext.SaveChanges();

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "An error occurred while executing GetWord method");
        //    }
        //}

        //public static void UpdateUser(WordGameContext dataContext, PlayerDTO user)
        //{
        //    try
        //    {
        //        if (IsSessionValid(dataContext, user))
        //        {
        //            UserDetail userFromDB = dataContext.UserDetail.Where(ud => ud.Id == user.Id).FirstOrDefault();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "An error occurred while executing UpdateUser method");
        //    }
        //}

       
        //public static List<PlayerDTO> GetTopPlayerScores(WordGameContext dc)
        //{
        //    List<PlayerDTO> topPlayers = (from player in dc.UserDetail
        //                                  orderby player.Score descending
        //                                  select new PlayerDTO
        //                                  {
        //                                      UserName = player.UserName,
        //                                      Score = player.Score
        //                                  }).Take(10).ToList();
        //    return topPlayers;
        //}


      
        

        //private static bool IsSessionValid(WordGameContext dc, PlayerDTO udto)
        //{
        //    UserDetail ud = dc.UserDetail.Where(u => u.SessionId == udto.SessionId).FirstOrDefault();
        //    DateTime rightNow = DateTime.Now;
        //    DateTime userTimeInSession = ud.UpdateDateTime;

        //    TimeSpan timeElapsed = rightNow - userTimeInSession;
        //    double minutesElapsed = timeElapsed.TotalMinutes;
        //    return minutesElapsed < Constants.Timeout ? true : false;
        //}

        //private static string GetNewUserWordString(string currentWord, string newWord)
        //{
        //    string[] workArray = currentWord.Split(',');
        //    workArray.Append(string.Format("{0}, {1}", ",", currentWord));
        //    return workArray.ToString();
        //}
    }
}
