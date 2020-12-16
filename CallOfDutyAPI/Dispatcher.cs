using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CallOfDutyAPI
{
    public class Dispatcher
    {
        public HttpClient client;

        public static IRestResponse GetCallOfDuty(string gamerTag)
        {
            var client = new RestClient($"https://call-of-duty-modern-warfare.p.rapidapi.com/warzone/{gamerTag}/battle");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "YjZoLwqv01mshmsWxSMSh3Mnduxgp1Hl9n0jsngKVkyLBXnAIL");
            request.AddHeader("x-rapidapi-host", "call-of-duty-modern-warfare.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public static Gamer BRCoDParse(IRestResponse response)
        {
            var brObj = JObject.Parse(response.Content).GetValue("br");
           
            var gamerWins  = brObj["wins"];
            var gamerKills  = brObj["kills"];
            var gamerKdRatio  = brObj["kdRatio"];
            var gamerTopTwentyFive = brObj["topTwentyFive"];
            var gamerTopTen = brObj["topTen"];
            var gamerRevives = brObj["revives"];
            var gamerTopFive = brObj["topFive"];
            var gamerScore = brObj["score"];
            var gamerGamesPlayed = brObj["gamesPlayed"];
            var gamerScorePerMinute = brObj["scorePerMinute"];
            var gamerDeaths = brObj["deaths"];

            var gamer = new Gamer()
            {
                wins = (int) gamerWins,
                kills = (int) gamerKills,
                kdRatio = (float) gamerKdRatio,
                topTwentyFive = (int) gamerTopTwentyFive,
                topTen = (int) gamerTopTen,
                revives = (int) gamerRevives,
                topFive = (int) gamerTopFive,
                score = (int) gamerScore,
                gamesPlayed = (int) gamerGamesPlayed,
                scorePerMinute = (int) gamerScorePerMinute,
                deaths = (int) gamerDeaths,

        };
            return gamer;
        }
    }
}
