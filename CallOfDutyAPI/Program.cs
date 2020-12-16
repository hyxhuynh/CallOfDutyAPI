using Newtonsoft.Json.Linq;
using System;

namespace CallOfDutyAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type your gamer tag:");
            var response = Dispatcher.GetCallOfDuty(Console.ReadLine());
            var gamerOne = Dispatcher.BRCoDParse(response);
            Console.WriteLine("===========================================");
            Console.WriteLine("Here are your game details:");
            Console.WriteLine($"wins: {gamerOne.wins}");
            Console.WriteLine($"kills: {gamerOne.kills}");
            Console.WriteLine($"KD ratio: {gamerOne.kdRatio}");
            Console.WriteLine($"revives: {gamerOne.revives}");
            Console.WriteLine($"games played: {gamerOne.gamesPlayed}");
            Console.WriteLine($"deaths: {gamerOne.deaths}");
            Console.WriteLine($"score: {gamerOne.score}");
            Console.WriteLine($"score per min: {gamerOne.scorePerMinute}");
            Console.WriteLine($"Top 25: {gamerOne.topTwentyFive}");
            Console.WriteLine($"Top 10: {gamerOne.topTen}");
            Console.WriteLine($"Top 5: {gamerOne.topFive}");
        }
    }
}
