using System;
using System.Collections.Generic;
using System.Linq;
using HeroEngine.Core.Enums;
using HeroEngine.Core.Models;
using HeroEngine.Core.TXTParsing;

namespace HeroEngine.Core.UI
{
    public class CombatSystem
    {
        const string BattleLogMSG = "  BATTLE LOG - Round ";
        int round = 1;
        Random rand = new Random();
        string path = "../../../Core/File/combat_log.txt"; //This route make the file create in the File folder of the project
        CombatHelper combatHelper = new CombatHelper();
        List<ACharacter> defeatedCharacters = new List<ACharacter>(); //I make this list to be abre to control the defeated characters for the enemydefeatedfirst method easier
        public void Combat(List<ACharacter> fighters)
        {
            Directory.CreateDirectory("Files");

            while (fighters.Any(f => f.IsAlive && f.CharType == "HERO") &&
                   fighters.Any(f => f.IsAlive && f.CharType == "ENEMY"))
            {
                Console.WriteLine("==================================================");
                Console.WriteLine($"{BattleLogMSG} {round}");
                Console.WriteLine("==================================================");

                TxtManager.Append(path, "==================================================");
                TxtManager.Append(path, $"  BATTLE LOG - Round {round}");
                TxtManager.Append(path, "==================================================");

                fighters.Sort((a, b) => b.Speed.CompareTo(a.Speed));

                foreach (var fighter in fighters)
                {
                    if (fighter.IsAlive)
                    {
                        ACharacter target = null;
                        string action = "Attack";
                        int hpBefore = 0;

                        if (fighter.abilities.Count > 0)
                        {
                            Ability ability = fighter.abilities[rand.Next(fighter.abilities.Count)];
                            action = ability.Name;

                            if (ability.Type == AbilityType.Attack)
                            {
                                target = EnemyTarget(fighters, fighter);
                                hpBefore = target.CurrentHealth;

                                int dmg = fighter.AttackEngine(ability.Power);
                                fighter.TotalDamage += dmg;
                                target.TakeDamageEngine(dmg);
                                combatHelper.TotalDamage(dmg);
                            }
                            else
                            {
                                target = AllyTarget(fighters, fighter);
                                hpBefore = target.CurrentHealth;

                                if (ability.Type == AbilityType.Healing)
                                    target.CurrentHealth += ability.Power;

                                if (ability.Type == AbilityType.Defense)
                                    target.defenseBuffCount++;

                                if (ability.Type == AbilityType.Support)
                                    target.attackBuffCount++;
                            }
                        }
                        else
                        {
                            target = EnemyTarget(fighters, fighter);
                            hpBefore = target.CurrentHealth;

                            int dmg = fighter.AttackEngine(10);
                            target.TakeDamageEngine(dmg);
                            if (target.CurrentHealth <= 0)
                                defeatedCharacters.Add(target);
                        }

                        int damageDone = hpBefore - target.CurrentHealth;
                        string defeated = target.IsAlive ? "" : " | DEFEATED!";

                        string log = $"  {fighter.CharType} {fighter.Name} > {action} > {target.Name} -> {damageDone} dmg{defeated}";

                        Console.WriteLine(log);
                        TxtManager.Append(path, log);
                    }
                }

                int heroesAlive = fighters.Count(f => f.CharType == "HERO" && f.IsAlive);
                int enemiesAlive = fighters.Count(f => f.CharType == "ENEMY" && f.IsAlive);

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"  Remaining enemies: {enemiesAlive} | Heroes standing: {heroesAlive}");
                Console.WriteLine("==================================================");

                TxtManager.Append(path, "--------------------------------------------------");
                TxtManager.Append(path, $"  Remaining enemies: {enemiesAlive} | Heroes standing: {heroesAlive}");
                TxtManager.Append(path, "==================================================");

                round++;
            }

            Console.WriteLine("Combat finished!");
            Console.WriteLine($"The total damage that was dealed in all the combat is: {combatHelper.Damage}");
            Console.WriteLine($"The most profitable hero is: {combatHelper.MostProfitableHero(fighters)}");
            Console.WriteLine($"The enemy that survived least rounds is: {combatHelper.EnemyDefeatedFirst(fighters)}");
        }

        private ACharacter EnemyTarget(List<ACharacter> fighters, ACharacter attacker)
        {
            List<ACharacter> targets = fighters
                .Where(f => f.IsAlive && f.CharType != attacker.CharType)
                .ToList();

            if (targets.Count == 0)
                return attacker;

            return targets[rand.Next(targets.Count)];
        }

        private ACharacter AllyTarget(List<ACharacter> fighters, ACharacter attacker)
        {
            List<ACharacter> targets = fighters
                .Where(f => f.IsAlive && f.CharType == attacker.CharType)
                .ToList();

            if (targets.Count == 0)
                return attacker;

            return targets[rand.Next(targets.Count)];
        }
    }
}