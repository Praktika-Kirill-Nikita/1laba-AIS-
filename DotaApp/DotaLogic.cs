using System.Collections.Generic;
using System.Linq;

namespace DotaApp
{
    public class DotaLogic
    {
        private List<Hero> heroes = new List<Hero>();
        private int nextId = 1;

        public Hero CreateHero(string name, string role, string attribute, int complexity)
        {
            var hero = new Hero(nextId++, name, role, attribute, complexity);
            heroes.Add(hero);
            return hero;
        }

        public bool DeleteHero(int id)
        {
            var hero = heroes.FirstOrDefault(h => h.Id == id);
            if (hero != null)
            {
                heroes.Remove(hero);
                return true;
            }
            return false;
        }

        public Hero GetHero(int id)
        {
            return heroes.FirstOrDefault(h => h.Id == id);
        }

        public bool UpdateHero(int id, string name, string role, string attribute, int complexity)
        {
            var hero = heroes.FirstOrDefault(h => h.Id == id);
            if (hero != null)
            {
                hero.Name = name;
                hero.Role = role;
                hero.Attribute = attribute;
                hero.Complexity = complexity;
                return true;
            }
            return false;
        }

        public Dictionary<string, List<Hero>> GroupByAttribute()
        {
            return heroes.GroupBy(h => h.Attribute)
                        .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Hero> FindByRole(string role)
        {
            return heroes.Where(h => h.Role.Contains(role)).ToList();
        }

        public List<Hero> GetAllHeroes()
        {
            return heroes;
        }
    }
}