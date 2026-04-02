using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroEngine.Core.Enums;

namespace HeroEngine.Core.Models
{
    public abstract class AEnemy : ACharacter
    {
        public  string Name { get; set; }
        public EnemyType Type { get; set; }

        public AEnemy(string name) : base(name)
        {
            Name = name;
        }

        /// <summary>
        /// Shows all parameters of an enemy
        /// </summary>
        /// <returns>a string of the full object parameters</returns>
        public override string ToString() => $"{Name} {MaxHP} {Type}";

        /// <summary>
        /// This method attacks a hero and reduces his current hp
        /// </summary>
        /// <param name="hero">the hero you want to attack</param>
        public void AttackHero(AHero hero)
        {
            hero.CurrentHealth = (int)Type / 2;
            Console.WriteLine(hero.CurrentHealth);
        }
    }
}
