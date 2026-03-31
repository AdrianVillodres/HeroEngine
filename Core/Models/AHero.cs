using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HeroEngine.Core.Models
{
    public abstract class AHero
    {
        public const int baseHealth = 100;
        public string Name { get; set; }
        public int Level { get; }
        public int MaxHealth { get; set; }

        public int CurrentHealth { get; set; }

        public AHero(string name, int level)
        {
            Name = name;
            Level = level;
            MaxHealth = (int)(baseHealth * (1 + 0.25 * (level - 1)));
            CurrentHealth = MaxHealth;
        }

        /// <summary>
        /// This method is used to see the stats of the hero
        /// </summary>
        /// <returns>The full string of the stats of the hero</returns>
        public virtual string Presentation() => $"[Hero] {Name} | Level: {Level} | HP: {CurrentHealth}/{MaxHealth}";

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
            return damage;
        }


        /// <summary>
        /// This method is used to make the hero take the damage from another hero's attacks
        /// </summary>
        /// <param name="rawDamageTaken">The raw damage of the attack</param>
        public virtual void TakeDamage(int rawDamageTaken)
        {
            CurrentHealth -= rawDamageTaken;
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
            Console.WriteLine($"{Name} recieves {rawDamageTaken} | HP: {CurrentHealth}/{MaxHealth}");

            if (!IsAlive)
            {
                Console.WriteLine($"{Name} has been defeated!");
            }
        }

        public bool IsAlive => CurrentHealth > 0;

    }
}
