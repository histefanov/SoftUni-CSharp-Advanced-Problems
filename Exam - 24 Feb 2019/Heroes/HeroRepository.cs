using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            data = new List<Hero>();
        }

        public int Count { get => data.Count; }

        public void Add(Hero hero)
        {
            data.Add(hero);
        }

        public void Remove(string name)
        {
            data.Remove(data.Find(h => h.Name == name));
        }

        public Hero GetHeroWithHighestStrength()
        {
            return data
                .OrderByDescending(h => h.Item.Strength)
                .FirstOrDefault();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return data
                .OrderByDescending(h => h.Item.Ability)
                .FirstOrDefault();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return data
                .OrderByDescending(h => h.Item.Intelligence)
                .FirstOrDefault();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var hero in data)
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
