using HeroEngine.Core.Models;

namespace HeroEngine.Core.UI
{
    public class Program
    {
        public static void Main()
        {
            Warrior abalon = new Warrior("Abalon", 3, "Who dares challenge me?!");
            Mage dalia = new Mage("Dalia", 3);
            Rogue mercer = new Rogue("Mercer Frey", 2, 2, 10);

            Console.WriteLine(abalon.Presentation());
            Console.WriteLine("------------");
            Console.WriteLine(dalia.Presentation());
            Console.WriteLine("------------");
            Console.WriteLine(mercer.Presentation());
            abalon.TakeDamage(dalia.AttackHero(13));
            Console.WriteLine(abalon.Presentation());
        }
    }
}
