using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] contest = input.Split(':');
                contests.Add(contest[0], contest[1]);
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] submission = input.Split("=>");
                string contest = submission[0];
                string password = submission[1];
                string username = submission[2];
                int points = int.Parse(submission[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new Dictionary<string, int>());
                    }
                    if (users[username].ContainsKey(contest))
                    {
                        if (users[username][contest] < points)
                        {
                            users[username][contest] = points;
                        }
                    }
                    else
                    {
                        users[username].Add(contest, points);
                    }
                }
            }
            string[] bestUserAndPoints = GetBestUserAndPoints(users);
            Console.WriteLine($"Best candidate is {bestUserAndPoints[0]} with total {bestUserAndPoints[1]} points." + "\n" +
                "Ranking:");

            var sortedUsers = users
                .OrderBy(u => u.Key)
                .ToDictionary(u => u.Key, u => u.Value);

            foreach (var user in sortedUsers)
            {
                Console.WriteLine(user.Key);
                var sortedContests = user.Value
                    .OrderByDescending(c => c.Value)
                    .ToDictionary(c => c.Key, c => c.Value);
                foreach (var contest in sortedContests)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        static string[] GetBestUserAndPoints(Dictionary<string, Dictionary<string, int>> users)
        {
            string bestUser = string.Empty;
            int highestPoints = int.MinValue;

            foreach (var user in users)
            {
                int currentUserPoints = 0;

                foreach (var contest in user.Value)
                {
                    currentUserPoints += contest.Value;
                }

                if (currentUserPoints > highestPoints)
                {
                    highestPoints = currentUserPoints;
                    bestUser = user.Key;
                }
            }

            string[] res = new string[] { bestUser, highestPoints.ToString() };
            return res;
        }
    }
}
