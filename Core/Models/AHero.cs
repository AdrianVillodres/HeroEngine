using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using HeroEngine.Core.Enums;

namespace HeroEngine.Core.Models
{
    public abstract class AHero : ACharacter
    {
        public const int baseHealth = 100;
        public string Name { get; set; }
        public int Level { get; }
        public int CurrentHealth { get; set; }

        public List<Ability> abilities = new List<Ability>();

        public int defenseBuffCount { get; private set; }

        public int attackBuffCount { get; private set; }
        

        public AHero(string name, int level) : base(name)
        {
            Name = name;
            Level = level;
            MaxHP = (int)(baseHealth * (1 + 0.25 * (level - 1)));
            CurrentHealth = MaxHP;
            defenseBuffCount = 0;
            attackBuffCount = 0;
        }

        /// <summary>
        /// This method is used to see the stats of the hero
        /// </summary>
        /// <returns>The full string of the stats of the hero</returns>
        public virtual string Presentation() => $"[Hero] {Name} | Level: {Level} | HP: {CurrentHealth}/{MaxHP}";

        /// <summary>
        /// This method is used to attack another hero
        /// </summary>
        /// <param name="damage">The raw damage points of the attack</param>
        /// <returns>The real damage of the attack</returns>
        public virtual int AttackHero(int damage)
        {
            if (!IsAlive)
            {
                Console.WriteLine($"{Name} is defeated and cannot attack.");
                return 0;
            }

            Console.WriteLine($"{Name} attacks! Deals {damage} damage");
            return damage + (attackBuffCount * 2);
        }


        /// <summary>
        /// This method is used to make the hero take the damage from another hero's attacks
        /// </summary>
        /// <param name="rawDamageTaken">The raw damage of the attack</param>
        public virtual void TakeDamage(int rawDamageTaken)
        {
            rawDamageTaken -= attackBuffCount * 2;
            CurrentHealth -= rawDamageTaken;
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
            Console.WriteLine($"{Name} recieves {rawDamageTaken} | HP: {CurrentHealth}/{MaxHP}");

            if (!IsAlive)
            {
                Console.WriteLine($"{Name} has been defeated!");
            }
        }

        public bool IsAlive => CurrentHealth > 0;

        /// <summary>
        /// This method adds an ability to the hero in case the ability is not already added and sorts the abilities ordering them for the rarity
        /// </summary>
        /// <param name="ability">The ability full object</param>
        public void AddAbility(Ability ability)
        {
            Predicate<Ability> same = a => a.Name == ability.Name;
            if (abilities.Exists(same))
            {
                Console.WriteLine($"The ability {ability.Name} already exists");
            }
            else
            {
                abilities.Add(ability);
                abilities.Sort((a, b) => a.Rarity.CompareTo(b.Rarity));
                Console.WriteLine($"The ability {ability.Name} has benn added succesfully");
            }
        }

        /// <summary>
        /// This method lists all the abilities that the hero has
        /// </summary>
        public void ListAllAbilities()
        {
            Console.WriteLine("=============================================================================");
            Console.WriteLine($"{Name} ABILITY LOADOUT");
            foreach (Ability ability in abilities)
            {
                Console.WriteLine($"[{ability.Rarity}]   {ability.Name}  |   Type: {ability.Type}    |   Cost: {ability.Cost} mana");
            }
            Console.WriteLine("=============================================================================");
        }

        /// <summary>
        /// This method casts the ability of the hero in case the hero has it and makes different effects depending on the ability type
        /// </summary>
        /// <param name="ability">the ability full object</param>
        /// <param name="hero">the hero full object</param>
        public void CastAbility(Ability ability, AHero hero)
        {
            if (abilities.Contains(ability))
            {
                switch (ability.Type)
                {
                    case AbilityType.Attack:
                        Console.WriteLine($"Casting '{ability.Name}' [{ability.Rarity}]...");
                        Console.WriteLine($"{Name} inficts {ability.Power} of damage to {hero.Name}");
                        hero.TakeDamage(ability.Power);
                        break;
                    case AbilityType.Healing:
                        Console.WriteLine($"Casting '{ability.Name}' [{ability.Rarity}]...");
                        Console.WriteLine($"{Name} heals {ability.Power} of HP to {hero.Name}");
                        hero.CurrentHealth += ability.Power;
                        break;
                    case AbilityType.Defense:
                        Console.WriteLine($"Casting '{ability.Name}' [{ability.Rarity}]...");
                        Console.WriteLine($"{Name} upgrade defense of {hero.Name}");
                        hero.defenseBuffCount++;
                        break;
                    case AbilityType.Support:
                        Console.WriteLine($"Casting '{ability.Name}' [{ability.Rarity}]...");
                        Console.WriteLine($"{Name} upgrade attack of {hero.Name}");
                        hero.attackBuffCount++;
                        break;
                }
            }
            else
            {
                Console.WriteLine($"{Name} does not have this ability");
            }
        }

    }
}
