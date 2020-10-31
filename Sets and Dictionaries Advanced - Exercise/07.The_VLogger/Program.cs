using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.The_VLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, VloggerInfo> vloggers = new Dictionary<string, VloggerInfo>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input.Split();
                if (tokens[1] == "joined")
                {
                    if (!vloggers.ContainsKey(tokens[0]))
                    {
                        vloggers.Add(tokens[0], new VloggerInfo());
                    }
                }
                else if (tokens[1] == "followed")
                {
                    if (tokens[0] != tokens[2] &&
                        vloggers.ContainsKey(tokens[0]) &&
                        vloggers.ContainsKey(tokens[2]))
                    {
                        vloggers[tokens[0]].Following.Add(tokens[2]);
                        vloggers[tokens[2]].Followers.Add(tokens[0]);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            Dictionary<string, VloggerInfo> sortedVloggers = vloggers
                .OrderByDescending(v => v.Value.Followers.Count)
                .ThenBy(v => v.Value.Following.Count)
                .ToDictionary(v => v.Key, v => v.Value);
            bool isFirst = true;
            int rank = 1;

            foreach (var vlogger in sortedVloggers)
            {
                Console.WriteLine(
                    $"{rank}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");

                if (isFirst && vlogger.Value.Followers.Count > 0)
                {
                    HashSet<string> sortedFollowers = vlogger.Value.Followers.OrderBy(f => f).ToHashSet();
                    foreach (var follower in sortedFollowers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                    isFirst = false;
                }
                rank++;
            }
        }

        class VloggerInfo
        {
            public VloggerInfo()
            {
                Followers = new HashSet<string>();
                Following = new HashSet<string>();
            }
            public HashSet<string> Followers { get; set; }
            public HashSet<string> Following { get; set; }
        }
    }
}
