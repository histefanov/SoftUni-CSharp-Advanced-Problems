using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }
        
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => roster.Count; }

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return roster.Remove(roster.Find(p => p.Name == name));
        }

        public void PromotePlayer(string name)
        {
            int playerIndex = roster.FindIndex(p => p.Name == name);
            if (roster[playerIndex].Rank == "Trial")
            {
                roster[playerIndex].Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            int playerIndex = roster.FindIndex(p => p.Name == name);
            if (roster[playerIndex].Rank == "Member")
            {
                roster[playerIndex].Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classInput)
        {
            var kickedPlayers = roster
                .Where(p => p.Class == classInput)
                .ToArray();

            foreach (var player in kickedPlayers)
            {
                roster.Remove(player);
            }

            return kickedPlayers;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
